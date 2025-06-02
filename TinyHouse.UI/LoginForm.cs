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
using TinyHouse.UI;
using TinyHouse.Business;
using Microsoft.EntityFrameworkCore;


namespace TinyHouse.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void lblRegisterLink_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide(); // LoginForm gözükmez
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                using (var context = new TinyHouse.Data.TinyHouseContext())
                {
                    var user = await context.Users
                        .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                    if (user != null)
                    {
                        MessageBox.Show("Giriş başarılı!");

                        if (user.Role == "Admin")
                        {
                            AdminForm adminForm = new AdminForm();
                            this.Hide();
                            adminForm.ShowDialog();
                            this.Close();
                        }
                        else if (user.Role == "Ev Sahibi")
                        {
                            OwnerForm ownerForm = new OwnerForm(user); // user parametresiyle gönderiyoruz!
                            this.Hide();
                            ownerForm.ShowDialog();
                            this.Close();
                        }
                        else if (user.Role == "Kiracı")
                        {
                            // Kiracı formu ileride buraya eklenecek
                            MessageBox.Show("Kiracı paneli yakında!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz e-posta veya şifre.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA: " + ex.Message);
            }
        }

    }
}
