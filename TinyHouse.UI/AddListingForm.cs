using System;
using System.Windows.Forms;
using TinyHouse.Data;

namespace TinyHouse.UI
{
    public partial class AddListingForm : Form
    {
        private int ownerId;  // Ev sahibinin Id'si

        // Constructor → Ev sahibinin ID'si dışarıdan alınır
        public AddListingForm(int ownerId)
        {
            InitializeComponent();
            this.ownerId = ownerId;
        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            decimal price = nudPrice.Value;
            string location = txtLocation.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Fiyat 0'dan büyük olmalıdır.");
                return;
            }

            using (var context = new TinyHouseContext())
            {
                var ilan = new TinyHouse.Data.TinyHouse
                {
                    Title = title,
                    Description = description,
                    PricePerNight = price,
                    Location = location,
                    OwnerId = ownerId
                };

                context.TinyHouses.Add(ilan);
                context.SaveChanges();
            }

            MessageBox.Show("İlan başarıyla eklendi.");
            this.Close();  // Formu kapat
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Geri tuşu sadece formu kapatır
        }

        private void AddListingForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
