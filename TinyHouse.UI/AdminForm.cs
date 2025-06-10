// TinyHouse.UI/AdminForm.cs
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;
using TinyHouse.Business.Services;
using TinyHouse.Data.Utilities;  // CommentStatus için


namespace TinyHouse.UI
{
    public partial class AdminForm : Form
    {
        // Service katmanları
        private readonly UserService _userService;
        private readonly HouseService _houseService;
        private readonly ReservationService _reservationService;
        private readonly TinyHouse.Business.Services.ReviewService _reviewService;

        // BindingList’ler
        private BindingList<UserModel> _bindingUsers;
        private BindingList<HouseModel> _bindingHouses;
        private BindingList<ReservationModel> _bindingReservations;
        private BindingList<ReviewModel> _bindingComments;

        public AdminForm()
        {
            InitializeComponent();

            // Servisleri başlat
            _userService = new UserService();
            _houseService = new HouseService();
            _reservationService = new ReservationService();
            _reviewService = new TinyHouse.Business.Services.ReviewService();

            // Form Load
            this.Load += AdminForm_Load;

            // --- Kullanıcı sekmesi event’leri ---
            btnAddUser.Click += BtnAddUser_Click;
            btnEditUser.Click += BtnEditUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnToggleUserStatus.Click += BtnToggleUserStatus_Click;

            // --- Evler sekmesi event’leri ---
            btnAddHouse.Click += BtnAddHouse_Click;
            btnEditHouse.Click += BtnEditHouse_Click;
            btnDeleteHouse.Click += BtnDeleteHouse_Click;
            btnToggleHouseStatus.Click += BtnToggleHouseStatus_Click;

            // --- Rezervasyonlar sekmesi event’leri ---
            btnApproveReservation.Click += BtnApproveReservation_Click;
            btnRejectReservation.Click += BtnRejectReservation_Click;
            btnCancelReservation.Click += BtnCancelReservation_Click;
            btnDeleteReservation.Click += BtnDeleteReservation_Click;

            // --- Yorumlar sekmesi event’leri ---
            dgvReviews.CellClick += DgvReviews_CellClick;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Kullanıcı filtresi
            cmbUserFilter.Items.AddRange(new[] { "Tümü", "Aktif", "Pasif" });
            cmbUserFilter.SelectedIndex = 0;

            // Verileri yükle
            ReloadUsersGrid();
            ReloadHousesGrid();
            ReloadReservationsGrid();
            ReloadCommentsGrid();
        }

        // -------- Kullanıcı Sekmesi --------
        private void ReloadUsersGrid()
        {
            var allUsers = _userService.GetAllUsers();
            var filtered = cmbUserFilter.SelectedItem.ToString() switch
            {
                "Aktif" => allUsers.Where(u => u.IsActive).ToList(),
                "Pasif" => allUsers.Where(u => !u.IsActive).ToList(),
                _ => allUsers
            };

            _bindingUsers = new BindingList<UserModel>(filtered);
            dgvUsers.DataSource = _bindingUsers;

            lblTotalUsers.Text = allUsers.Count.ToString();
            lblActiveUsers.Text = allUsers.Count(u => u.IsActive).ToString();
            lblPassiveUsers.Text = (allUsers.Count - allUsers.Count(u => u.IsActive)).ToString();
        }

        private void cmbUserFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ReloadUsersGrid();

        }
      

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            using var form = new UserEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var m = form.UserModel;
                _userService.Create(m.FullName, m.Email, m.PasswordHash, m.Role);
                ReloadUsersGrid();
            }
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            var sel = (UserModel)dgvUsers.CurrentRow.DataBoundItem;
            using var form = new UserEditForm(sel);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _userService.Update(form.UserModel);
                ReloadUsersGrid();
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            var sel = (UserModel)dgvUsers.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"'{sel.FullName}' silinecek. Emin misiniz?",
                                "Kullanıcı Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _userService.DeleteUser(sel.Id);
                ReloadUsersGrid();
            }
        }

        private void BtnToggleUserStatus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            var sel = (UserModel)dgvUsers.CurrentRow.DataBoundItem;
            _userService.ToggleUserStatus(sel.Id);
            ReloadUsersGrid();
        }

        // -------- Evler Sekmesi --------
        private void ReloadHousesGrid()
        {
            var all = _houseService.GetAllHouses().ToList();
            _bindingHouses = new BindingList<HouseModel>(all);
            dgvHouses.DataSource = _bindingHouses;

            lblTotalHouses.Text = all.Count.ToString();
            lblActiveHouses.Text = all.Count(h => h.IsActive).ToString();
            lblPassiveHouses.Text = (all.Count - all.Count(h => h.IsActive)).ToString();
        }

        private void BtnAddHouse_Click(object sender, EventArgs e)
        {
            int ownerId = SessionContext.CurrentUserId;
            using var form = new AddListingForm(ownerId);
            if (form.ShowDialog() == DialogResult.OK)
                ReloadHousesGrid();
        }

        private void BtnEditHouse_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            var sel = (HouseModel)dgvHouses.CurrentRow.DataBoundItem;
            using var form = new UpdateListingForm(sel.Id);
            if (form.ShowDialog() == DialogResult.OK)
                ReloadHousesGrid();
        }

        private void BtnDeleteHouse_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            var sel = (HouseModel)dgvHouses.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"\"{sel.Title}\" silinecek. Emin misiniz?",
                                "Ev Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (_houseService.HasActiveReservations(sel.Id))
            {
                MessageBox.Show("Bu eve ait aktif rezervasyonlar olduğu için silemezsiniz.",
                                "Silme İşlemi Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var deleted = _houseService.DeleteHouse(sel.Id);
            MessageBox.Show(deleted
                ? "İlan başarıyla silindi."
                : "İlan silinirken bir sorun oluştu.",
                "Bilgi", MessageBoxButtons.OK,
                deleted ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            ReloadHousesGrid();
        }

        private void BtnToggleHouseStatus_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow == null) return;
            var sel = (HouseModel)dgvHouses.CurrentRow.DataBoundItem;
            _houseService.ToggleHouseStatus(sel.Id);
            ReloadHousesGrid();
        }

        // -------- Rezervasyonlar Sekmesi --------
        private void ReloadReservationsGrid()
        {
            var all = _reservationService.GetAllReservations();
            _bindingReservations = new BindingList<ReservationModel>(all);
            dgvReservations.DataSource = _bindingReservations;

            // Gizlenecek sütunlar
            foreach (var col in new[] { "Id", "UserId", "HouseId" })
                if (dgvReservations.Columns.Contains(col))
                    dgvReservations.Columns[col].Visible = false;

            lblTotalReservations.Text = all.Count.ToString();
            lblPendingReservations.Text = all.Count(r => r.Status == ReservationStatus.Pending).ToString();
            lblApprovedReservations.Text = all.Count(r => r.Status == ReservationStatus.Confirmed).ToString();
            lblRejectedReservations.Text = all.Count(r => r.Status == ReservationStatus.Rejected).ToString();
            lblCancelledReservations.Text = all.Count(r => r.Status == ReservationStatus.Cancelled).ToString();
        }

        private void BtnApproveReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null) return;
            var sel = (ReservationModel)dgvReservations.CurrentRow.DataBoundItem;
            if (_reservationService.UpdateReservationStatus(sel.Id, ReservationStatus.Confirmed))
                MessageBox.Show("Rezervasyon onaylandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadReservationsGrid();
        }

        private void BtnRejectReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null) return;
            var sel = (ReservationModel)dgvReservations.CurrentRow.DataBoundItem;
            if (_reservationService.UpdateReservationStatus(sel.Id, ReservationStatus.Rejected))
                MessageBox.Show("Rezervasyon reddedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadReservationsGrid();
        }

        private void BtnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null) return;
            var sel = (ReservationModel)dgvReservations.CurrentRow.DataBoundItem;
            if (_reservationService.UpdateReservationStatus(sel.Id, ReservationStatus.Cancelled))
                MessageBox.Show("Rezervasyon iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadReservationsGrid();
        }

        private void BtnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null) return;
            var sel = (ReservationModel)dgvReservations.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"#{sel.Id} kalıcı olarak silinecek. Emin misiniz?",
                                "Rezervasyonu Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            if (_reservationService.DeleteReservation(sel.Id))
                MessageBox.Show("Rezervasyon silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadReservationsGrid();
        }

        // -------- Yorumlar Sekmesi --------
        private void ReloadCommentsGrid()
        {
            // Yalnızca onay bekleyen yorumları getir
            var all = _reviewService.GetAllReviews();
            _bindingComments = new BindingList<ReviewModel>(all);
            dgvReviews.DataSource = _bindingComments;

            // Onayla ve Sil buton kolonları
            if (!dgvReviews.Columns.Contains("Approve"))
                dgvReviews.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Approve",
                    HeaderText = "Onayla",
                    Text = "Onayla",
                    UseColumnTextForButtonValue = true
                });
            if (!dgvReviews.Columns.Contains("Delete"))
                dgvReviews.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Sil",
                    Text = "Sil",
                    UseColumnTextForButtonValue = true
                });

            // Gizlenecek sütunlar
            foreach (var col in new[] { "Id", "UserId", "HouseId" })
                if (dgvReviews.Columns.Contains(col))
                    dgvReviews.Columns[col].Visible = false;
        }

        private void DgvReviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgvReviews.Columns.Count) return;
            var colName = dgvReviews.Columns[e.ColumnIndex].Name;
            var sel = (ReviewModel)dgvReviews.Rows[e.RowIndex].DataBoundItem;

            if (colName == "Approve")
                _reviewService.UpdateReviewStatus(sel.Id, CommentStatus.Approved);

            else if (colName == "Delete")
                _reviewService.DeleteReview(sel.Id);
            else
                return;

            ReloadCommentsGrid();
        }

        
    }
}
