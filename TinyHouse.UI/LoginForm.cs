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

            // 0) Basit validasyon
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
                // 1) Kullanıcıyı doğrula
                var user = _authService.Authenticate(email, password);
                if (user == null)
                {
                    MessageBox.Show("E-posta veya şifre hatalı ya da hesap pasif.");
                    return;
                }

                // 2) Rol enum’unu çöz
                if (!Enum.TryParse(user.Role.Replace(" ", ""), out UserRole roleEnum))
                {
                    MessageBox.Show("Yetkisiz rol: " + user.Role);
                    return;
                }

                // 3) Oturum bilgilerini kaydet
                SessionContext.CurrentUserId = user.Id;
                SessionContext.CurrentUserFullName = user.FullName;
                SessionContext.CurrentUserRole = roleEnum;

                // 4) LoginForm’u gizle, rol formunu aç
                this.Hide();

                Form roleForm = roleEnum switch
                {
                    UserRole.Admin => new AdminForm(),
                    UserRole.EvSahibi => new OwnerForm(user.Id, user.FullName),
                    UserRole.Kiraci => new KiraciForm(user.Id),
                    _ => null
                };

                if (roleForm == null)
                {
                    MessageBox.Show("Yetkiniz olmayan bir rol.");
                    this.Show();                 // geri aç, kullanıcıya form kalsın
                    return;
                }

                // Kiracı formunu modeless aç; diğerlerini modal tut
                if (roleEnum == UserRole.Kiraci)
                {
                    roleForm.FormClosed += (_, __) => this.Close();   // KiraciForm kapanınca uygulama kapansın
                    roleForm.Show();                                  // modeless
                }
                else
                {
                    roleForm.ShowDialog();                            // modal
                    this.Close();                                     // dialog kapandıktan sonra uygulamayı kapat
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında hata oluştu:\n" + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak özel bir işlem yok
        }
    }
}
