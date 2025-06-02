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
  private string connectionString = @"Server=localhost;Database=TinyHouseDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";


        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Kiracı");
            cmbRole.Items.Add("Ev Sahibi");
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Bu e-posta adresiyle zaten bir kayıt var.");
                        return;
                    }

                    string insertQuery = @"
                        INSERT INTO Users (FullName, Email, Password, Role)
                        VALUES (@FullName, @Email, @Password, @Role)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    int result = cmd.ExecuteNonQuery();

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
                    MessageBox.Show("HATA: " + ex.Message);
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
