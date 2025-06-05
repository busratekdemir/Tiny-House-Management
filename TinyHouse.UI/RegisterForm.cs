using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TinyHouse.UI
{
    public partial class RegisterForm : Form
    {
        // Veritabanı bağlantı cümlesi
        private string connectionString = DbHelper.GetConnectionString();

        public RegisterForm()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışır, rol seçenekleri combobox'a eklenir
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Kiracı");
            cmbRole.Items.Add("Ev Sahibi");
        }

        // Kayıt ol butonuna basıldığında çalışır
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Formdan gelen kullanıcı bilgileri alınır
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Aynı email ile kayıtlı kullanıcı var mı kontrol edilir
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Bu e-posta adresiyle zaten bir kayıt var.");
                        return;
                    }

                    // Kullanıcı kaydı yapılır
                    string insertQuery = @"
    INSERT INTO Users (FullName, Email, Password, Role, IsActive)
    VALUES (@FullName, @Email, @Password, @Role, @IsActive)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@IsActive", 1); // kullanıcı aktif olarak kaydedilir

                    int result = cmd.ExecuteNonQuery();

                    // Kayıt başarılıysa giriş ekranına geçilir
                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarılı!");
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt sırasında bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    // Hata oluşursa gösterilir
                    MessageBox.Show("HATA: " + ex.Message);
                }
            }
        }

        // ComboBox seçim değiştiğinde çalışır (şu an boş)
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
