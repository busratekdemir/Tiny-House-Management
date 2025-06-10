using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;

namespace TinyHouse.UI
{
    public partial class ReviewForm : Form
    {
        private readonly int _houseId;
        private readonly ReviewService _reviewService;
        private readonly HouseService _houseService;
        private readonly Business.Services.ReviewService  review_service;

       //tarih tanımları
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;

        // Ana constructor: Sadece houseId ile
        public ReviewForm(int houseId)
        {
            InitializeComponent();
            _houseId = houseId;
            _reviewService = new ReviewService();
            _houseService = new HouseService();
            review_service = new Business.Services.ReviewService();

            Load += ReviewForm_Load;
            btnReserve.Click += btnReserve_Click;
            btnBack.Click += btnBack_Click;
        }

        // Eğer tarih gerekiyorsa overload
        public ReviewForm(int houseId, DateTime fromDate, DateTime toDate)
            : this(houseId)
        {
            _fromDate = fromDate;
            _toDate = toDate;
        }

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            var house = _houseService.GetHouseById(_houseId);
            if (house != null)
            {
                lblTitle.Text = house.Title;
                txtDescription.Text = house.Description;
                lblPrice.Text = house.PricePerNight.ToString("C");
                lblLocation.Text = house.Location;
            }
            else
            {
                MessageBox.Show("İlan bulunamadı!");
            }

            dgvReviews.DataSource = review_service.GetVallReviews(_houseId);
            string[] hCols = { "Status", "UserId", "Id", "HouseId" };

            foreach (var sutun in hCols)
            {
                if (dgvReviews.Columns.Contains(sutun))
                    dgvReviews.Columns[sutun].Visible = false;
            }

        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                var svc = new ReservationService();

                // Eğer tarih set edilmediyse, bugünden 1 gün sonrası
                DateTime from = _fromDate == default ? DateTime.Today : _fromDate;
                DateTime to = _toDate == default ? DateTime.Today.AddDays(1) : _toDate;

                svc. AddReservation(
                    SessionContext.CurrentUserId, 
                    _houseId,
                    from,
                    to,
                    _houseService.GetHouseById(_houseId).PricePerNight
                );

                MessageBox.Show("Rezervasyon talebiniz ev sahibine iletildi. Onay bekleniyor!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rezervasyon yapılamadı:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
