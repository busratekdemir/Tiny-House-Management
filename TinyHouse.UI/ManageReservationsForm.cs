using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class ManageReservationsForm : Form
    {
        private string connectionString = DbHelper.GetConnectionString();

        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        r.Id,
                        u.FullName AS Kiraci,
                        t.Title AS Ev,
                        r.StartDate AS Baslangic,
                        r.EndDate AS Bitis,
                        r.TotalPrice
                    FROM Reservations r
                    INNER JOIN Users u ON r.UserId = u.Id
                    INNER JOIN TinyHouses t ON r.TinyHouseId = t.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvReservations.DataSource = dt;
            }

            if (!dgvReservations.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn silBtn = new DataGridViewButtonColumn();
                silBtn.Name = "Sil";
                silBtn.HeaderText = "Sil";
                silBtn.Text = "Sil";
                silBtn.UseColumnTextForButtonValue = true;
                dgvReservations.Columns.Add(silBtn);
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservations.Columns[e.ColumnIndex].Name == "Sil")
            {
                int reservationId = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["Id"].Value);
                DialogResult result = MessageBox.Show("Bu rezervasyonu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Reservations WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@Id", reservationId);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            MessageBox.Show("Rezervasyon silindi.");
                            ManageReservationsForm_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız.");
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
