using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class UpdateListingForm : Form
    {
        private int _ilanId;
        private string _connectionString = DbHelper.GetConnectionString();

        public UpdateListingForm(int ilanId)
        {
            InitializeComponent();
            _ilanId = ilanId;
        }

        private void UpdateListingForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Title, Description, PricePerNight, Location FROM TinyHouses WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", _ilanId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTitle.Text = reader["Title"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                    nudPrice.Value = Convert.ToDecimal(reader["PricePerNight"]);
                    txtLocation.Text = reader["Location"].ToString();
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE TinyHouses
                    SET Title = @Title,
                        Description = @Description,
                        PricePerNight = @Price,
                        Location = @Location
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Price", nudPrice.Value);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@Id", _ilanId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("İlan güncellendi.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız.");
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


