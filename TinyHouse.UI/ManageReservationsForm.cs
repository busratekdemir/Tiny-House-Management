using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyHouse.Data;

namespace TinyHouse.UI
{
    public partial class ManageReservationsForm : Form
    {
        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var rezervasyonlar = from r in context.Reservations
                                     join u in context.Users on r.UserId equals u.Id
                                     join t in context.TinyHouses on r.TinyHouseId equals t.Id
                                     select new
                                     {
                                         Kiraci = u.FullName,
                                         Ev = t.Title,
                                         r.StartDate,
                                         r.EndDate,
                                         r.TotalPrice
                                     };

                dgvReservations.DataSource = rezervasyonlar.ToList();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvReservations.Columns["Sil"].Index)
            {
                var kiraciAdi = dgvReservations.Rows[e.RowIndex].Cells["Kiracı"].Value.ToString();
                var evAdi = dgvReservations.Rows[e.RowIndex].Cells["Ev"].Value.ToString();
                var baslangic = Convert.ToDateTime(dgvReservations.Rows[e.RowIndex].Cells["Başlangıç"].Value);
                var bitis = Convert.ToDateTime(dgvReservations.Rows[e.RowIndex].Cells["Bitiş"].Value);

                using (var context = new TinyHouseContext())
                {
                    var rezervasyon = (from r in context.Reservations
                                       join u in context.Users on r.UserId equals u.Id
                                       join t in context.TinyHouses on r.TinyHouseId equals t.Id
                                       where u.FullName == kiraciAdi &&
                                             t.Title == evAdi &&
                                             r.StartDate == baslangic &&
                                             r.EndDate == bitis
                                       select r).FirstOrDefault();

                    if (rezervasyon != null)
                    {
                        context.Reservations.Remove(rezervasyon);
                        context.SaveChanges();
                        MessageBox.Show("Rezervasyon silindi.");

                        // Listeyi güncelle
                        ManageReservationsForm_Load(null, null);
                    }
                }
            }
        }
    }
}

