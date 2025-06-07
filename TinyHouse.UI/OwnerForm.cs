using System;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;

namespace TinyHouse.UI
{
    public partial class OwnerForm : Form
    {
        private readonly int _ownerId;
        private readonly string _ownerName;
        private readonly HouseService _houseService;
        private readonly ReservationService _resService;

        public OwnerForm(int ownerId, string ownerName)
        {
            InitializeComponent();

            _ownerId = ownerId;
            _ownerName = ownerName;
            _houseService = new HouseService();
            _resService = new ReservationService();

            Load += OwnerForm_Load;
            btnAddHouse.Click += btnAddHouse_Click;
            btnUpdate.Click += btnUpdate_Click;
            dgvMyHouses.CellContentClick += dgvMyHouses_CellClick;
            btnShowIncome.Click += btnShowIncome_Click;
            btnLogout.Click += btnLogout_Click;
            dgvRequests.CellContentClick += dgvRequests_CellClick;
            tabControlOwner.SelectedIndexChanged += tabControlOwner_SelectedIndexChanged;
        }

        private void OwnerForm_Load(object sender, EventArgs e)
        {
            if (SessionContext.CurrentUserRole != UserRole.EvSahibi)
            {
                MessageBox.Show("Bu sayfayı görüntüleme yetkiniz yok.");
                Close();
                return;
            }

            lblTitle.Text = $"Hoş geldiniz, {_ownerName}!";
            LoadMyHouses();
            LoadRequests();
        }

        private void LoadMyHouses()
        {
            try
            {
                var list = _houseService.GetHousesByOwner(_ownerId)
                    .Select(h => new { h.Id, h.Title, h.Location, h.PricePerNight })
                    .ToList();

                dgvMyHouses.DataSource = list;

                if (!dgvMyHouses.Columns.Contains("Sil"))
                {
                    dgvMyHouses.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Sil",
                        HeaderText = "Sil",
                        Text = "Sil",
                        UseColumnTextForButtonValue = true
                    });
                }

                if (dgvMyHouses.Columns.Contains("Id"))
                    dgvMyHouses.Columns["Id"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("İlanlar yüklenirken bir hata oluştu.");
            }
        }

        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            using var addForm = new AddListingForm(_ownerId);
            addForm.ShowDialog();
            LoadMyHouses();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMyHouses.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir ilan seçin.");
                return;
            }
            int houseId = Convert.ToInt32(dgvMyHouses.CurrentRow.Cells["Id"].Value);
            using var updateForm = new UpdateListingForm(houseId);
            updateForm.ShowDialog();
            LoadMyHouses();
        }

        private void dgvMyHouses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMyHouses.Columns[e.ColumnIndex].Name != "Sil")
                return;

            int houseId = Convert.ToInt32(dgvMyHouses.Rows[e.RowIndex].Cells["Id"].Value);
            var confirmation = MessageBox.Show(
                "Bu ilanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmation != DialogResult.Yes)
                return;

            bool ok = _houseService.DeleteHouse(houseId);
            if (!ok)
            {
                MessageBox.Show(
                    "Bu ilanı silemezsiniz. Önce bu ilana ait tüm aktif rezervasyonları iptal etmelisiniz.",
                    "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("İlan başarıyla silindi.");
                LoadMyHouses();
            }
        }

        private void btnShowIncome_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = _resService.GetOwnerIncome(_ownerId);
                MessageBox.Show($"Toplam geliriniz: {total:N2} ₺", "Gelir Bilgisi");
            }
            catch (Exception)
            {
                MessageBox.Show("Gelir bilgisi alınırken hata oluştu.");
            }
        }

        private void LoadRequests()
        {
            try
            {
                var list = _resService.GetRequestsByOwner(_ownerId)
                    .Select(r => new
                    {
                        r.Id,
                        r.TenantName,
                        r.HouseTitle,
                        r.StartDate,
                        r.EndDate,
                        r.TotalPrice
                    })
                    .ToList();

                dgvRequests.DataSource = list;

                if (!dgvRequests.Columns.Contains("Approve"))
                {
                    dgvRequests.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Approve",
                        HeaderText = "Onayla",
                        Text = "Onayla",
                        UseColumnTextForButtonValue = true
                    });
                    dgvRequests.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Reject",
                        HeaderText = "Reddet",
                        Text = "Reddet",
                        UseColumnTextForButtonValue = true
                    });
                }

                if (dgvRequests.Columns.Contains("Id"))
                    dgvRequests.Columns["Id"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Talepler yüklenirken hata oluştu.");
            }
        }

        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvRequests.Columns[e.ColumnIndex].Name;
            int reqId = Convert.ToInt32(dgvRequests.Rows[e.RowIndex].Cells["Id"].Value);
            bool ok = false;

            if (col == "Approve")
                ok = _resService.ApproveRequest(reqId);
            else if (col == "Reject")
                ok = _resService.RejectRequest(reqId);
            else
                return;

            MessageBox.Show(ok
                ? (col == "Approve" ? "Rezervasyon onaylandı." : "Rezervasyon reddedildi.")
                : "İşlem sırasında hata oluştu.");

            LoadRequests();
        }

        private void tabControlOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlOwner.SelectedTab.Text == "İlanlarım") LoadMyHouses();
            else if (tabControlOwner.SelectedTab.Text == "Talepler") LoadRequests();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            Close();
        }
    }
}
