using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class ListingForm : Form
    {
        private string connectionString = DbHelper.GetConnectionString();

        public ListingForm()
        {
            InitializeComponent();
        }

        private void ListingForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        t.Id,
                        t.Title,
                        t.Location,
                        t.PricePerNight,
                        u.FullName AS EvSahibi
                    FROM TinyHouses t
                    INNER JOIN Users u ON t.OwnerId = u.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvHouses.DataSource = dt;
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
