
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;

namespace TinyHouse.UI
{
    public partial class ListingForm : Form
    {
        private readonly HouseService _houseService;

        public ListingForm()
        {
            InitializeComponent();
            _houseService = new HouseService();
        }

        private void ListingForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<HouseModel> houses = (List<HouseModel>)_houseService.GetAllHouses();
                dgvHouses.DataSource = houses.Select(h => new
                {
                    h.Id,
                    h.Title,
                    h.Location,
                    h.PricePerNight,
                    EvSahibi = h.OwnerId
                }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("İlanlar yüklenirken hata oluştu.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
