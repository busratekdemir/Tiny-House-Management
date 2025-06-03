using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TinyHouse.UI
{
    public partial class AdminForm : Form
    {
        private string connectionString = DbHelper.GetConnectionString();


        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kullanıcı sayısı
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users", conn))
                {
                    label6.Text = cmd.ExecuteScalar().ToString();
                }

                // İlan sayısı
                using (SqlCommand cmdRezervasyon = new SqlCommand("SELECT COUNT(*) FROM TinyHouses", conn))
                {
                    label7.Text = cmdRezervasyon.ExecuteScalar().ToString();
                }

                /*   Rezervasyon sayısın, COUNT fonksiyonu ile de yazabiliriz
                     using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reservations", conn))
                    {
                        label8.Text = cmd.ExecuteScalar().ToString();
                     }*/
                string query = "SELECT dbo.fn_ToplamRezervasyonSayisi()";
                SqlCommand cmdRezervasyonSayisi = new SqlCommand(query, conn);
                label8.Text = cmdRezervasyonSayisi.ExecuteScalar().ToString();


            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserListForm form = new UserListForm();
            form.Show();
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            ListingForm form = new ListingForm();
            form.Show();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            ManageReservationsForm form = new ManageReservationsForm();
            form.Show();
        }
    }
}
