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

            // Event handler’ları bağla
            this.Load += UpdateListingForm_Load;
            btnUpdate.Click += BtnUpdate_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void UpdateListingForm_Load(object sender, EventArgs e)
        {
            try
            {
                var house = _houseService.GetHouseById(_houseId);
                if (house == null)
                {
                    MessageBox.Show("İlan bulunamadı.", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Formu mevcut veriyle doldur
                txtTitle.Text = house.Title;
                txtDescription.Text = house.Description;
                txtPhotoUrls_.Text = house.PhotoUrls;
                nudPrice.Value = house.PricePerNight;
                txtLocation.Text = house.Location;
                chbIsActive.Checked = house.IsActive;
                dtpAvailableFrom.Value = house.AvailableFrom ?? DateTime.Today;
                dtpAvailableTo.Value = house.AvailableTo ?? DateTime.Today;
            }
            catch
            {
                MessageBox.Show("İlan yüklenirken hata oluştu.", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Validasyon
                string title = txtTitle.Text.Trim();
                string location = txtLocation.Text.Trim();
                decimal price = nudPrice.Value;
                DateTime from = dtpAvailableFrom.Value.Date;
                DateTime to = dtpAvailableTo.Value.Date;

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(location))
                {
                    MessageBox.Show("Başlık ve konum boş olamaz.", "Uyarı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (price <= 0)
                {
                    MessageBox.Show("Fiyat 0'dan büyük olmalı.", "Uyarı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (to < from)
                {
                    MessageBox.Show("Bitiş tarihi başlangıçtan önce olamaz.", "Uyarı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Modeli oluşturup güncelle
                var house = new HouseModel
                {
                    Id = _houseId,
                    Title = title,
                    Description = txtDescription.Text.Trim(),
                    PhotoUrls = txtPhotoUrls_.Text.Trim(),
                    AvailableFrom = from,
                    AvailableTo = to,
                    IsActive = chbIsActive.Checked,
                    PricePerNight = price,
                    Location = location,
                    OwnerId = SessionContext.CurrentUserId
                };

                bool ok = _houseService.UpdateHouse(house);

                // 3) Sonuç
                if (ok)
                {
                    MessageBox.Show("İlan başarıyla güncellendi.", "Bilgi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu.", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
