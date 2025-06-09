// UserEditForm.cs
using System;
using System.Windows.Forms;
using TinyHouse.Data.Models;

namespace TinyHouse.UI
{
    public partial class UserEditForm : Form
    {
        public UserModel UserModel { get; private set; }

        // Yeni kullanıcı
        public UserEditForm()
        {
            InitializeComponent();
            UserModel = new UserModel();
            btnOk.Click += (s, e) => SaveAndClose();
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        // Mevcut kullanıcı düzenle
        public UserEditForm(UserModel existing) : this()
        {
            UserModel = existing;
            txtFullName.Text = existing.FullName;
            txtEmail.Text = existing.Email;
            cmbRole.SelectedItem = existing.Role;
            // Şifre alanı boş kalabilir; kullanıcı değiştirmek isterse doldursun
        }

        private void SaveAndClose()
        {
            UserModel.FullName = txtFullName.Text;
            UserModel.Email = txtEmail.Text;
            // Null kontrolü ekleyin
            UserModel.Role = cmbRole.SelectedItem?.ToString() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {

            }
            DialogResult = DialogResult.OK;
        }
    }
}
