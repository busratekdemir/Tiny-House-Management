using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Data;
namespace TinyHouse.UI
{
    public partial class OwnerForm : Form
    {
        private User _loggedInUser; // Giriş yapan kullanıcı

        // Constructor: Giriş yapan kullanıcı bilgisi parametreyle gelir
        public OwnerForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;
        }

        // Form yüklendiğinde sadece bu kullanıcıya ait ilanları göster
        private void OwnerForm_Load(object sender, EventArgs e)
        {
            using (var context = new TinyHouseContext())
            {
                var ilanlar = context.TinyHouses
                    .Where(t => t.OwnerId == _loggedInUser.Id) // Sadece bu kullanıcıya ait olanlar
                    .Select(t => new
                    {
                        t.Id,
                        t.Title,
                        t.Description,
                        t.Location,
                        t.PricePerNight
                    })
                    .ToList();

                dgvMyHouses.DataSource = ilanlar;
            }

            // sil butonu tekrar eklenmesin
            if (!dgvMyHouses.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn silBtn = new DataGridViewButtonColumn();
                silBtn.Name = "Sil";
                silBtn.HeaderText = "Sil";
                silBtn.Text = "Sil";
                silBtn.UseColumnTextForButtonValue = true;
                dgvMyHouses.Columns.Add(silBtn);
            }
        }

        // DataGridView'de bir hücreye tıklandığında (özellikle Sil)
        private void dgvMyHouses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMyHouses.Columns[e.ColumnIndex].Name == "Sil")
            {
                int ilanId = Convert.ToInt32(dgvMyHouses.Rows[e.RowIndex].Cells["Id"].Value);

                var result = MessageBox.Show("Bu ilanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (var context = new TinyHouseContext())
                    {
                        var ilan = context.TinyHouses.FirstOrDefault(i => i.Id == ilanId && i.OwnerId == _loggedInUser.Id);
                        if (ilan != null)
                        {
                            context.TinyHouses.Remove(ilan);
                            context.SaveChanges();
                            MessageBox.Show("İlan silindi!");
                        }
                    }

                    // Listeyi yenile
                    OwnerForm_Load(null, null);
                }
            }
        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            AddListingForm form = new AddListingForm(_loggedInUser.Id); // ownerId değişkenin varsa
            form.ShowDialog();

            // İlan eklendikten sonra listeyi güncelle
            OwnerForm_Load(null, null);
        }

        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            AddListingForm form = new AddListingForm(_loggedInUser.Id);
            form.ShowDialog(); // Form kapanana kadar bekle
            OwnerForm_Load(null, null); // Listeyi yenile
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvMyHouses.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir ilan seçin.");
                return;
            }

            int ilanId = Convert.ToInt32(dgvMyHouses.CurrentRow.Cells["Id"].Value);
            UpdateListingForm form = new UpdateListingForm(ilanId);
            form.ShowDialog();

            // Güncellemeden sonra listeyi yenile
            OwnerForm_Load(null, null);
        }

        
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
