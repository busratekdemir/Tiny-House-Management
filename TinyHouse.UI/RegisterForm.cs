using TinyHouse.UI.Helpers;  // UserRole enum’u için
using System.Text.RegularExpressions;



using TinyHouse.Business.Services;

namespace TinyHouse.UI
{
    public partial class RegisterForm : Form
    {
        // Veritabanı bağlantı cümlesi
        private readonly UserService _userService;

        public RegisterForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        // Form yüklendiğinde çalışır, rol seçenekleri combobox'a eklenir
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add(UserRole.Kiraci.ToString());    // "Kiraci"
            cmbRole.Items.Add(UserRole.EvSahibi.ToString());  // "EvSahibi"
        }


        // Kayıt ol butonuna basıldığında çalışır
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            // 1) Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // 2) Email format kontrolü
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin.");
                return;
            }

            // 3) Şifre uzunluğu kontrolü
            if (password.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.");
                return;
            }

            // 4) Aynı email var mı?
            var existingUser = _userService.GetByEmail(email);
            if (existingUser != null)
            {
                MessageBox.Show("Bu e-posta ile kayıtlı bir kullanıcı zaten var.");
                return;
            }

            try
            {
                // 5) Şifreyi hash’le
                string hashed = BCrypt.Net.BCrypt.HashPassword(password);

                // 6) Yeni kullanıcı oluştur
                int newUserId = _userService.Create(fullName, email, hashed, role);
                if (newUserId > 0)
                {
                    MessageBox.Show("Kayıt başarılı!");
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        }

        // ComboBox seçim değiştiğinde çalışır (şu an boş)
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
