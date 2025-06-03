using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class OwnerForm : Form
    {
        private int _userId;
        private string _fullName;
        private string _connectionString = @"Server=DESKTOP-2U2UUHO\SQLEXPRESS;Database=TinyHouseDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        public OwnerForm(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
        }

        private void ListeleIlanlar()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Title, Location, PricePerNight FROM TinyHouses WHERE OwnerId = @OwnerId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OwnerId", _userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvMyHouses.DataSource = dt;
            }
            // Sil butonu için
            if (!dgvMyHouses.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn silButton = new DataGridViewButtonColumn();
                silButton.Name = "Sil";
                silButton.HeaderText = "İşlem";
                silButton.Text = "Sil";
                silButton.UseColumnTextForButtonValue = true;

                dgvMyHouses.Columns.Add(silButton);
            }

        }

        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            AddListingForm form = new AddListingForm(_userId);
            form.ShowDialog();
            ListeleIlanlar();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMyHouses.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir ilan seçin.");
                return;
            }

            int ilanId = Convert.ToInt32(dgvMyHouses.CurrentRow.Cells["Id"].Value);
            UpdateListingForm form = new UpdateListingForm(ilanId);
            form.ShowDialog();
            ListeleIlanlar();
        }

        private void dgvMyHouses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMyHouses.Columns[e.ColumnIndex].Name == "Sil")
            {
                int ilanId = Convert.ToInt32(dgvMyHouses.Rows[e.RowIndex].Cells["Id"].Value);

                var result = MessageBox.Show("Bu ilanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM TinyHouses WHERE Id = @Id AND OwnerId = @OwnerId";

                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@Id", ilanId);
                        cmd.Parameters.AddWithValue("@OwnerId", _userId);

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                            MessageBox.Show("İlan silindi!");
                        else
                            MessageBox.Show("Silme başarısız.");
                    }

                    ListeleIlanlar();
                }
            }

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT dbo.fn_EvSahibiGeliri(@OwnerId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OwnerId", _userId);

                    object result = cmd.ExecuteScalar();
                    decimal gelir = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    MessageBox.Show("Toplam geliriniz: " + gelir + " ₺", "Gelir Bilgisi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


    }
}
