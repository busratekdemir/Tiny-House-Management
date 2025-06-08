// TinyHouse.UI/UpdateListingForm.cs
using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;

namespace TinyHouse.UI
{
    public partial class UpdateListingForm : Form
    {
        private readonly HouseService _houseService;
        private readonly int _houseId;

        public UpdateListingForm(int houseId)
        {
            InitializeComponent();
            _houseService = new HouseService();
            _houseId = houseId;

            Load += UpdateListingForm_Load;
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void UpdateListingForm_Load(object sender, EventArgs e)
        {
            try
            {
                HouseModel house = _houseService.GetHouseById(_houseId);
                if (house == null)
                {
                    MessageBox.Show("İlan bulunamadı.");
                    Close();
                    return;
                }

                txtTitle.Text = house.Title;
                txtDescription.Text = house.Description;
                txtPhotoUrls.Text = house.PhotoUrls;
                nudPrice.Value = house.PricePerNight;
                txtLocation.Text = house.Location;
                chbIsActive.Checked = house.IsActive;
                dtpAvailableFrom.Value = house.AvailableFrom ?? DateTime.Today;
                dtpAvailableTo.Value = house.AvailableTo ?? DateTime.Today;
            }
            catch
            {
                MessageBox.Show("İlan yüklenirken hata oluştu.");
                Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text.Trim();
                string desc = txtDescription.Text.Trim();
                string photos = txtPhotoUrls.Text.Trim();
                string location = txtLocation.Text.Trim();
                decimal price = nudPrice.Value;
                DateTime from = dtpAvailableFrom.Value.Date;
                DateTime to = dtpAvailableTo.Value.Date;
                bool isActive = chbIsActive.Checked;

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(location))
                {
                    MessageBox.Show("Başlık ve konum boş olamaz.");
                    return;
                }
                if (price <= 0)
                {
                    MessageBox.Show("Fiyat 0'dan büyük olmalı.");
                    return;
                }
                if (to < from)
                {
                    MessageBox.Show("Bitiş tarihi başlangıçtan önce olamaz.");
                    return;
                }

                var house = new HouseModel
                {
                    Id = _houseId,
                    Title = title,
                    Description = desc,
                    PhotoUrls = photos,
                    AvailableFrom = from,
                    AvailableTo = to,
                    IsActive = isActive,
                    PricePerNight = price,
                    Location = location,
                    OwnerId = SessionContext.CurrentUserId
                };

                bool ok = _houseService.UpdateHouse(house);

                if (ok)
                {
                    MessageBox.Show("İlan başarıyla güncellendi.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
