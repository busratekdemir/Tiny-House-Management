using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;

namespace TinyHouse.UI
{
    public partial class ManageReservationsForm : Form
    {
        private readonly ReservationService _resService;

        public ManageReservationsForm()
        {
            InitializeComponent();
            _resService = new ReservationService();
        }

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ReservationModel> reservations = _resService.GetAllReservations();
                var displayList = reservations.Select(r => new
                {
                    r.Id,
                    Kiraci = r.UserId,
                    EvId = r.TinyHouseId,
                    Baslangic = r.StartDate,
                    Bitis = r.EndDate,
                    ToplamFiyat = r.TotalPrice,
                    Durum = r.Status.ToString()
                }).ToList();

                dgvReservations.DataSource = displayList;

                if (!dgvReservations.Columns.Contains("Sil"))
                {
                    var silBtn = new DataGridViewButtonColumn
                    {
                        Name = "Sil",
                        HeaderText = "Sil",
                        Text = "Sil",
                        UseColumnTextForButtonValue = true
                    };
                    dgvReservations.Columns.Add(silBtn);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Rezervasyonlar yüklenirken hata oluştu.");
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservations.Columns[e.ColumnIndex].Name == "Sil")
            {
                int resId = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["Id"].Value);
                var dr = MessageBox.Show(
                    "Bu rezervasyonu silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    bool ok = _resService.CancelReservation(resId);
                    if (ok)
                    {
                        MessageBox.Show("Rezervasyon silindi.");
                        ManageReservationsForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Silme başarısız.");
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
