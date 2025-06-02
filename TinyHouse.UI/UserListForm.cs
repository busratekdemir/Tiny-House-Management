using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class UserListForm : Form
    {
       private string _connectionString = @"Server=localhost;Database=TinyHouseDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";



        public UserListForm()
        {
            InitializeComponent();
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, Email, Role FROM Users";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvUsers.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }
    }
}
