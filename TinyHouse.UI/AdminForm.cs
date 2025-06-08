using System;
using System.Windows.Forms;
using TinyHouse.Business.Services;  // UserService, HouseService, ReservationService, ReportService
using TinyHouse.UI.Helpers;
using System.Linq;


namespace TinyHouse.UI
{
    public partial class AdminForm : Form
    {
        private readonly UserService _userService;
        private readonly HouseService _houseService;
        private readonly ReservationService _reservationService;
        private readonly ReportService _reportService;

        public AdminForm()
        {
            InitializeComponent();

            // Servislerin inşası
            _userService = new UserService();
            _houseService = new HouseService();
            _reservationService = new ReservationService();
            _reportService = new ReportService();

            // Load olayını bağla
            this.Load += AdminForm_Load;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // 1) Yetki kontrolü
            if (SessionContext.CurrentUserRole != UserRole.Admin)
            {
                MessageBox.Show("Yeterli yetkiniz yok.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            try
            {
                // 2) Özet veriler
                var userCount = _userService.GetAllUsers().Count();
                var houseCount = _houseService.GetAllHouses().Count();
                var resCount = _reservationService.GetAllReservations().Count();

                label3.Text = userCount.ToString();
                label4.Text = houseCount.ToString();
                label5.Text = resCount.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veri yüklenirken hata oluştu:\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using var form = new UserListForm();
            form.ShowDialog();
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            using var form = new ListingForm();
            form.ShowDialog();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            using var form = new ManageReservationsForm();
            form.ShowDialog();
        }
    }
}
