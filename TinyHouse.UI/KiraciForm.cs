using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TinyHouse.UI
{
    public partial class KiraciForm : Form
    {
        private int _userId;
        private string _connectionString = DbHelper.GetConnectionString();

        public KiraciForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void KiraciForm_Load(object sender, EventArgs e)
        {
            ListeleIlanlar();
        }
        private void ListeleIlanlar()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Title, Location, PricePerNight FROM TinyHouses";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvHouses.DataSource = dt;
            }
        }

        private void btnReserve_Click_1(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir ilan seçin.");
                return;
            }

            int ilanId = Convert.ToInt32(dgvHouses.CurrentRow.Cells["Id"].Value);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                DateTime baslangic = DateTime.Now.Date.AddDays(1); // örnek tarih
                DateTime bitis = DateTime.Now.Date.AddDays(3);     // örnek tarih
                decimal fiyat = Convert.ToDecimal(dgvHouses.CurrentRow.Cells["PricePerNight"].Value);
                decimal toplam = (decimal)(bitis - baslangic).TotalDays * fiyat;

                string query = @"INSERT INTO Reservations (UserId, TinyHouseId, StartDate, EndDate, TotalPrice)
                                 VALUES (@UserId, @TinyHouseId, @StartDate, @EndDate, @TotalPrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _userId);
                cmd.Parameters.AddWithValue("@TinyHouseId", ilanId);
                cmd.Parameters.AddWithValue("@StartDate", baslangic);
                cmd.Parameters.AddWithValue("@EndDate", bitis);
                cmd.Parameters.AddWithValue("@TotalPrice", toplam);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Rezervasyon başarılı!");
                else
                    MessageBox.Show("Hata oluştu.");
            }
        }

        private void btnMyRes_Click_1(object sender, EventArgs e)
        {
            KiraciForm form = new KiraciForm(_userId);
            form.ShowDialog();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        
    }
}
