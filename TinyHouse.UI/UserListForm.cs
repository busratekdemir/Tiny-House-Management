using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyHouse.Data;

namespace TinyHouse.UI
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var users = context.Users.Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.Role
                }).ToList();

                dgvUsers.DataSource = users;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }

    }
}
