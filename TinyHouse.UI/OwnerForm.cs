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

        private void OwnerForm_Load(object sender, EventArgs e)
        {
            ListeleIlanlar();
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

        
    }
}
