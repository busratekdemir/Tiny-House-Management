using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;

using TinyHouse.UI.Helpers;         // ← SessionContext, UserRole burada


namespace TinyHouse.UI
{
    public partial class UserListForm : Form
    {
        private readonly UserService _userService;

        public UserListForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<UserModel> users = _userService.GetAllUsers();
                dgvUsers.DataSource = users.Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.Role,
                    Durum = u.IsActive ? "Aktif" : "Pasif"
                }).ToList();

                if (!dgvUsers.Columns.Contains("Pasifleştir"))
                {
                    var btn = new DataGridViewButtonColumn
                    {
                        Name = "Pasifleştir",
                        HeaderText = "Pasifleştir",
                        Text = "Pasifleştir",
                        UseColumnTextForButtonValue = true
                    };
                    dgvUsers.Columns.Add(btn);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu.");
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "Pasifleştir")
            {
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["Id"].Value);
                var result = MessageBox.Show(
                    "Bu kullanıcıyı pasifleştirmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bool ok = _userService.Deactivate(userId);
                    if (ok)
                    {
                        MessageBox.Show("Kullanıcı pasif yapıldı.");
                        UserListForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Pasifleştirme başarısız.");
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
