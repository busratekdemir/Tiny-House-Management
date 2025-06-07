using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyHouse.Business;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI;
using TinyHouse.UI.Helpers;



namespace TinyHouse.UI
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService(); 
        }

        // Kayıt ol linkine tıklanınca RegisterForm açılır, mevcut LoginForm gizlenir.
        private void lblRegisterLink_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        // Giriş yap butonuna tıklanınca çalışır.

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen e-posta ve şifre girin.");
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta girin.");
                return;
            }

            try
            {
                var user = _authService.Authenticate(email, password);
                if (user == null)
                {
                    MessageBox.Show("E-posta veya şifre hatalı ya da hesap pasif.");
                    return;
                }

                

                string normalized = user.Role.Replace(" ", "");
                if (!Enum.TryParse<UserRole>(normalized, out var roleEnum))
                {
                    MessageBox.Show("Enum parse hatası: " + user.Role);
                    return;
                }

                SessionContext.CurrentUserId = user.Id;
                SessionContext.CurrentUserFullName = user.FullName;
                SessionContext.CurrentUserRole = roleEnum;

                this.Hide();
                switch (roleEnum)
                {
                    case UserRole.Admin:
                        
                        using (var f = new AdminForm())
                            f.ShowDialog();
                        break;
                    case UserRole.EvSahibi:
                        using (var f = new OwnerForm(user.Id, user.FullName))
                            f.ShowDialog();
                        break;
                    case UserRole.Kiraci:
                        using (var f = new KiraciForm(user.Id))
                            f.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Yetkiniz olmayan bir rol.");
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                // Hatanın detayını mutlaka görün
                MessageBox.Show("Giriş işlemi sırasında hata oluştu:\n" + ex.Message);
                throw;
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak özel bir işlem yok
        }
    }
}
