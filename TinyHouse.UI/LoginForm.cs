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


        private void lblRegisterLink_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            string connectionString = DbHelper.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password AND IsActive = 1";


                    using (Microsoft.Data.SqlClient.SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                int userId = Convert.ToInt32(reader["Id"]);
                                string fullName = reader["FullName"].ToString();

                                MessageBox.Show("Giriş başarılı!");

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
                                MessageBox.Show("Geçersiz giriş. Hesabınız pasif olabilir veya bilgiler yanlış.");

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HATA: " + ex.Message);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
