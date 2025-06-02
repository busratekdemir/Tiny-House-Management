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
    
    public partial class UpdateListingForm : Form
    {
        private int listingId;

        public UpdateListingForm(int listingId)
        {
            InitializeComponent();
            this.listingId = listingId;
        }

        private void UpdateListingForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var ilan = context.TinyHouses.FirstOrDefault(x => x.Id == listingId);

                if (ilan != null)
                {
                    txtTitle.Text = ilan.Title;
                    txtDescription.Text = ilan.Description;
                    nudPrice.Value = ilan.PricePerNight;
                    txtLocation.Text = ilan.Location;
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var ilan = context.TinyHouses.FirstOrDefault(x => x.Id == listingId);

                if (ilan != null)
                {
                    ilan.Title = txtTitle.Text;
                    ilan.Description = txtDescription.Text;
                    ilan.PricePerNight = nudPrice.Value;
                    ilan.Location = txtLocation.Text;

                    context.SaveChanges();
                    MessageBox.Show("İlan güncellendi.");
                    this.Close();
                }
            }
        }
        private User _loggedInUser;
        private int _ilanId;
        public UpdateListingForm(int ilanId, User loggedInUser)
        {

            InitializeComponent();
            _ilanId = ilanId;
            _loggedInUser = loggedInUser;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }


    }
}

