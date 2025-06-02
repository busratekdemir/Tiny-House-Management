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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                label6.Text = context.Users.Count().ToString();           // Kullanıcı sayısı
                label7.Text = context.TinyHouses.Count().ToString();      // İlan sayısı
                label8.Text = context.Reservations.Count().ToString();    // Rezervasyon sayısı
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(); // Giriş ekranını tekrar aç
            loginForm.Show();
            this.Hide(); // AdminForm'u gizle
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserListForm form = new UserListForm();
            form.Show();
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            ListingForm form = new ListingForm();
            form.Show();
        }


        
        private void btnRes_Click(object sender, EventArgs e)
        {
            ManageReservationsForm form = new ManageReservationsForm();
            form.Show();

        }
    }
}
