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
    public partial class ListingForm : Form
    {
        public ListingForm()
        {
            InitializeComponent();
        }

        private void ListingForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var ilanlar = context.TinyHouses
                    .Select(t => new
                    {
                        t.Id,
                        t.Title,
                        t.Location,
                        t.PricePerNight,
                        EvSahibi = t.Owner.FullName
                    })
                    .ToList();

                dgvHouses.DataSource = ilanlar;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }

    }
}
