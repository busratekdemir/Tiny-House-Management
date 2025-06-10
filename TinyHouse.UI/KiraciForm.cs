using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using TinyHouse.Business.Services;
using TinyHouse.Data.Models;
using TinyHouse.UI.Helpers;

namespace TinyHouse.UI
{
    public partial class KiraciForm : Form
    {
        private readonly ReservationService _resService;
        private readonly HouseService _houseService;
        private readonly TinyHouse.Business.Services.ReviewService _reviewService;

        // Kiracının rezervasyon listesini tutan binding list
        private BindingList<ReservationModel> _bindingReservations;
        private ReservationModel _selectedReservation;
        private HouseModel _selectedHouse; 

        public KiraciForm(int userId)
        {
            InitializeComponent();

            _resService = new ReservationService();
            _houseService = new HouseService();
            _reviewService = new TinyHouse.Business.Services.ReviewService();

            SessionContext.CurrentUserId = userId;

            // Form yüklendiğinde hem evleri hem rezervasyonları yükle
            Load += KiraciForm_Load;

            // Evleri filtreleme
            btnFilter.Click += (_, __) => ReloadHouses();
            btnSelectHouse.Click += btnSelectHouse_Click;
            btnInspect.Click += btnInspect_Click;

            // Rezervasyonlar sekmesi için seçim değişimini dinle
            dgvMyReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyReservations.AutoGenerateColumns = true;
            dgvMyReservations.SelectionChanged += DgvMyReservations_SelectionChanged;

            // Yorum gönderme butonu
            btnSubmitComment.Click += BtnSubmitComment_Click;

            // Başlangıçta yorum panelini pasif yap
            EnableCommentPanel(false);

            // Çıkış
            btnLogout.Click += (_, __) => Close();
        }

        private void KiraciForm_Load(object sender, EventArgs e)
        {
            ReloadHouses();
            ReloadReservations();
        }

        private void ReloadHouses()
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;
            dgvHouses.DataSource = _houseService.GetAvailableHouses(from, to);
            HideColumns(dgvHouses, "PhotoUrls", "AvailableFrom", "AvailableTo", "IsActive");
            flpPhotos.Controls.Clear();
            _selectedReservation = null;
        }

        private void ReloadReservations()
        {
            var userId = SessionContext.CurrentUserId;
            var list = _resService.GetReservationsByUser(userId);
            _bindingReservations = new BindingList<ReservationModel>(list);
            dgvMyReservations.DataSource = _bindingReservations;

            // İstemediğin sütunları gizle
            HideColumns(dgvMyReservations, "UserId", "TinyHouseId", "Status", "PaymentStatus");
        }

        private void DgvMyReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMyReservations.CurrentRow?.DataBoundItem is ReservationModel res)
            {
                _selectedReservation = res;
                EnableCommentPanel(true);
            }
            else
            {
                _selectedReservation = null;
                EnableCommentPanel(false);
            }
        }

        private void EnableCommentPanel(bool enable)
        {
            nudRating.Enabled = enable;
            txtComment.Enabled = enable;
            btnSubmitComment.Enabled = enable;
        }

        private void BtnSubmitComment_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show("Lütfen önce bir rezervasyon seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var review = new ReviewModel
            {
                HouseId = _selectedReservation.HouseId,
                UserId = SessionContext.CurrentUserId,
                Rating = (int)nudRating.Value,
                Text = txtComment.Text.Trim(),
                Status = CommentStatus.Pending
            };

            _reviewService.AddReview(review);
            MessageBox.Show("Yorumunuz admin onayına gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Paneli sıfırla
            txtComment.Clear();
            nudRating.Value = nudRating.Minimum;
            EnableCommentPanel(false);
        }

        private void btnSelectHouse_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow?.DataBoundItem is HouseModel house)
            {
                ShowInfo($"Seçili ilan: {house.Title}");
                DisplaySelectedHousePhotos(house);
                _selectedHouse = house;
            }
            else
            {
                ShowWarning("Lütfen önce bir ilan satırı seçin.");
            }
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {
            if (_selectedHouse == null)
            {
                ShowWarning("Lütfen önce ilan seçin.");
                return;
            }
            using var reviewForm = new ReviewForm(_selectedHouse.Id);
            reviewForm.ShowDialog();
        }

        // Foto galerisini göster
        private void DisplaySelectedHousePhotos(HouseModel h)
        {
            flpPhotos.Controls.Clear();
            if (!string.IsNullOrWhiteSpace(h.PhotoUrls))
            {
                List<string> imgs = new();
                try { imgs = JsonSerializer.Deserialize<List<string>>(h.PhotoUrls) ?? new(); }
                catch (JsonException) { imgs.Add(h.PhotoUrls); }
                foreach (var url in imgs)
                {
                    flpPhotos.Controls.Add(new PictureBox
                    {
                        Width = 120,
                        Height = 90,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(5),
                        ImageLocation = url,
                        BorderStyle = BorderStyle.FixedSingle
                    });
                }
                flpPhotos.Visible = imgs.Count > 0;
            }
            else flpPhotos.Visible = false;
        }

        private void HideColumns(DataGridView grid, params string[] cols)
        {
            foreach (var col in cols)
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
        }

        private void ShowInfo(string msg)
            => MessageBox.Show(msg, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void ShowWarning(string msg)
            => MessageBox.Show(msg, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

