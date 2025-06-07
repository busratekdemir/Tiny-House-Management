using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;

namespace TinyHouse.UI
{
    public partial class KiraciForm : Form
    {
        private readonly ReservationService _resService;
        private readonly HouseService _houseService;

        public KiraciForm(int userId)
        {
            InitializeComponent();
            _resService = new ReservationService();
            _houseService = new HouseService();
            SessionContext.CurrentUserId = userId;

            Load += OnLoad;
            dgvHouses.SelectionChanged += OnHouseSelectionChanged;
            btnReserve.Click += OnReserveClick;
            dgvMyReservations.CellContentClick += OnReservationCancel;
            tabControl1.SelectedIndexChanged += OnTabChanged;
            btnLogout.Click += (_, __) => Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            dgvHouses.DataSource = _houseService.GetAllHouses();
            HidePhotoPanel();
            ReloadReservations();
        }

        private void OnHouseSelectionChanged(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null)
            {
                HidePhotoPanel();
                return;
            }

            int id = Convert.ToInt32(dgvHouses.CurrentRow.Cells["Id"].Value);
            var house = _houseService.GetHouseById(id);
            if (house == null || string.IsNullOrWhiteSpace(house.PhotoUrls))
            {
                HidePhotoPanel();
                return;
            }

            List<string> urls;
            try
            {
                urls = JsonSerializer.Deserialize<List<string>>(house.PhotoUrls) ?? new List<string>();
            }
            catch
            {
                urls = new List<string>();
            }

            flpPhotos.Controls.Clear();
            foreach (var url in urls)
            {
                var pic = new PictureBox
                {
                    Width = 120,
                    Height = 90,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(5),
                    ImageLocation = url,
                    BorderStyle = BorderStyle.FixedSingle
                };
                flpPhotos.Controls.Add(pic);
            }
            flpPhotos.Visible = urls.Count > 0;
        }

        private void HidePhotoPanel()
        {
            flpPhotos.Controls.Clear();
            flpPhotos.Visible = false;
        }

        private void OnReserveClick(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvHouses.CurrentRow.Cells["Id"].Value);
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;
            int days = (end - start).Days;
            if (days <= 0)
            {
                MessageBox.Show("Bitiş tarihi başlangıçtan sonra olmalı.");
                return;
            }

            decimal price = Convert.ToDecimal(dgvHouses.CurrentRow.Cells["PricePerNight"].Value);
            bool success = _resService.AddReservation(SessionContext.CurrentUserId, id, start, end, price * days);

            MessageBox.Show(success ? "Talebin iletildi (onay bekliyor)." : "Bu tarihler dolu!");
            if (success) ReloadReservations();
        }

        private void ReloadReservations()
        {
            var data = _resService.GetReservationsByUser(SessionContext.CurrentUserId);
            dgvMyReservations.DataSource = data;

            if (!dgvMyReservations.Columns.Contains("btnCancel"))
            {
                dgvMyReservations.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "btnCancel",
                    HeaderText = "İptal Et",
                    Text = "İptal Et",
                    UseColumnTextForButtonValue = true
                });
            }

            if (dgvMyReservations.Columns.Contains("Id"))
                dgvMyReservations.Columns["Id"].Visible = false;
        }

        private void OnReservationCancel(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMyReservations.Columns[e.ColumnIndex].Name != "btnCancel")
                return;

            int resId = Convert.ToInt32(dgvMyReservations.Rows[e.RowIndex].Cells["Id"].Value);
            bool done = _resService.CancelReservation(resId);
            MessageBox.Show(done ? "Rezervasyon iptal edildi." : "İptal işlemi başarısız.");
            if (done) ReloadReservations();
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Rezervasyonlarım")
                ReloadReservations();
        }
    }
}
