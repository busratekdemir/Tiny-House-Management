using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyHouse.UI;
using TinyHouse.Business;
using Microsoft.Data.SqlClient;

namespace TinyHouse.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // Veritabanı bağlantı cümlesi alınır
            string connectionString = DbHelper.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kullanıcının aktif olup olmadığı ve bilgilerin doğru olup olmadığı kontrol edilir
                    string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password AND IsActive = 1";

                    using (Microsoft.Data.SqlClient.SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Giriş başarılıysa kullanıcı bilgileri alınır
                                string role = reader["Role"].ToString();
                                int userId = Convert.ToInt32(reader["Id"]);
                                string fullName = reader["FullName"].ToString();

                                MessageBox.Show("Giriş başarılı!");

                                // Rolüne göre ilgili form açılır
                                if (role == "Admin")
                                {
                                    AdminForm adminForm = new AdminForm();
                                    this.Hide();
                                    adminForm.ShowDialog();
                                    this.Close();
                                }
                                else if (role == "Ev Sahibi")
                                {
                                    OwnerForm ownerForm = new OwnerForm(userId, fullName);
                                    this.Hide();
                                    ownerForm.ShowDialog();
                                    this.Close();
                                }
                                else if (role == "Kiracı")
                                {
                                    KiraciForm kiraciForm = new KiraciForm(userId);
                                    this.Hide();
                                    kiraciForm.ShowDialog();
                                    this.Close();
                                }

                            }
                            else
                            {
                                // Kullanıcı bulunamazsa uyarı verilir
                                MessageBox.Show("Geçersiz giriş. Hesabınız pasif olabilir veya bilgiler yanlış.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajı gösterilir
                    MessageBox.Show("HATA: " + ex.Message);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak özel bir işlem yok
        }
    }
}
