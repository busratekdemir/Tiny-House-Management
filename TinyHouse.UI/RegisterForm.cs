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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Kiracı");
            cmbRole.Items.Add("Ev Sahibi");
            cmbRole.Items.Add("Admin");
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (var context = new TinyHouseContext())
            {
                var yeniKullanici = new User
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    Role = role
                };

                context.Users.Add(yeniKullanici);
                context.SaveChanges();
            }

            MessageBox.Show("Kayıt başarılı!");

            // Giriş ekranına geç
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

    }
}
