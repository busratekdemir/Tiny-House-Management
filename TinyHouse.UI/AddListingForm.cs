// AddListingForm.cs
using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.UI.Helpers;  // Eğer SessionContext vb. burada tanımlıysa

namespace TinyHouse.UI
{
    public partial class AddListingForm : Form
    {
        private readonly int _ownerId;
        private readonly HouseService _houseService;

        public AddListingForm(int ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _houseService = new HouseService();

            // Buton event’lerini bağla
            btnAddListing.Click += BtnAddListing_Click;
            btnBack.Click += BtnBack_Click;
        }

        private void BtnAddListing_Click(object sender, EventArgs e)
        {
            // 1) Validasyon
            var title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Lütfen ilan başlığı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var desc = txtDescription.Text.Trim();
            var photos = txtPhotoUrls.Text.Trim();

            var price = nudPrice.Value;
            if (price <= 0)
            {
                MessageBox.Show("Gecelik fiyat 0'dan büyük olmalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loc = txtLocation.Text.Trim();
            if (string.IsNullOrEmpty(loc))
            {
                MessageBox.Show("Lütfen konum girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? from = dtpAvailableFrom.Checked
                ? dtpAvailableFrom.Value.Date
                : (DateTime?)null;
            DateTime? to = dtpAvailableTo.Checked
                ? dtpAvailableTo.Value.Date
                : (DateTime?)null;

            if (from.HasValue && to.HasValue && to < from)
            {
                MessageBox.Show("Bitiş tarihi başlangıç tarihinden önce olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isActive = chbIsActive.Checked;

            // 2) Servis çağrısı
            try
            {
                int newId = _houseService.AddHouse(
                    _ownerId,
                    title,
                    desc,
                    photos,
                    from,
                    to,
                    isActive,
                    price,
                    loc
                );

                if (newId > 0)
                {
                    MessageBox.Show("İlan başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("İlan eklenirken bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
