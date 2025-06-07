using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.UI.Helpers;

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
        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            // 1) Alan validasyonları
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title)) { MessageBox.Show("Başlık girin."); return; }

            string desc = txtDescription.Text.Trim();
            string photos = txtPhotoUrls.Text.Trim(); // Beklenen JSON dizisi

            decimal price = nudPrice.Value;
            if (price <= 0) { MessageBox.Show("Fiyat 0’dan büyük olmalı."); return; }

            string loc = txtLocation.Text.Trim();
            if (string.IsNullOrEmpty(loc)) { MessageBox.Show("Konum girin."); return; }

            DateTime? from = dtpAvailableFrom.Checked
                ? dtpAvailableFrom.Value.Date
                : (DateTime?)null;
            DateTime? to = dtpAvailableTo.Checked
                ? dtpAvailableTo.Value.Date
                : (DateTime?)null;

            bool isActive = chbIsActive.Checked;

            // 2) Service katmanına devret
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
                    MessageBox.Show("İlan başarıyla eklendi!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("İlan eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message);
            }
        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
