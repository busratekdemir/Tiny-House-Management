using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class AddListingForm : Form
    {
        private int ownerId;
        private string connectionString = @"Server=localhost;Database=TinyHouseDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";


        public AddListingForm(int ownerId)
        {
            InitializeComponent();
            this.ownerId = ownerId;
        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            decimal price = nudPrice.Value;
            string location = txtLocation.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Fiyat 0'dan büyük olmalıdır.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO TinyHouses (Title, Description, PricePerNight, Location, OwnerId)
                                 VALUES (@Title, @Description, @PricePerNight, @Location, @OwnerId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@PricePerNight", price);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@OwnerId", ownerId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("İlan başarıyla eklendi.");
            this.Close();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

