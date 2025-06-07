using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;  // UserService, HouseService, ReservationService
using TinyHouse.UI.Helpers;         // SessionContext, UserRole


namespace TinyHouse.UI
{
    public partial class AdminForm : Form
    {
        private readonly UserService _userService;
        private readonly HouseService _houseService;
        private readonly ReservationService _reservationService;


        public AdminForm()
        {
            InitializeComponent();
            _userService = new UserService();
            _houseService = new HouseService();
            _reservationService = new ReservationService();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // 1) Yetki kontrolü
            if (SessionContext.CurrentUserRole != UserRole.Admin)
            {
                MessageBox.Show("Yeterli yetkiniz yok.");
                this.Close();
                return;
            }

            try
            {
                // 2) Kullanıcı sayısı
                var allUsers = _userService.GetAllUsers();
                label6.Text = allUsers.Count.ToString();

                // 3) İlan sayısı
                var allHouses = _houseService.GetAllHouses();
                label7.Text = allHouses.Count.ToString();

                // 4) Rezervasyon sayısı
                var allRes = _reservationService.GetAllReservations();
                label8.Text = allRes.Count.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu.");
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var userListForm = new UserListForm();
            userListForm.ShowDialog();
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            var listingForm = new ListingForm();
            listingForm.ShowDialog();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            var manageResForm = new ManageReservationsForm();
            manageResForm.ShowDialog();
        }
    }
}
