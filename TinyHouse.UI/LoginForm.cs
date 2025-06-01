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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (var context = new TinyHouseContext())
            {
                bool isValid = await context.Users.AnyAsync(u => u.Email == email && u.Password == password);

                if (isValid)
                {
                    MessageBox.Show("Giriş başarılı!");

                    // Burada ana sayfa açılabilir ya da başka bir forma geçilebilir
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçersiz e-posta veya şifre.");
                }
            }
        }
    }
}
