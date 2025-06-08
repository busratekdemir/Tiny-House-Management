using System;
using System.Collections.Generic;
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
        private readonly ReviewService _reviewService;

        private HouseModel _selectedHouse = null;

        public KiraciForm(int userId)
        {
            InitializeComponent();

            _resService = new ReservationService();
            _houseService = new HouseService();
            _reviewService = new ReviewService();

            SessionContext.CurrentUserId = userId;

            Load += KiraciForm_Load;
            btnFilter.Click += (_, __) => ReloadHouses();
            btnSelectHouse.Click += btnSelectHouse_Click; // İlan Seç tuşu
            btnInspect.Click += btnInspect_Click;
            btnLogout.Click += (_, __) => Close();
            // Diğer eventleri ihtiyaca göre ekle (yorum, rezervasyon vs.)
        }

        private void KiraciForm_Load(object sender, EventArgs e)
        {
            ReloadHouses();
        }

        private void ReloadHouses()
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;
            dgvHouses.DataSource = _houseService.GetAvailableHouses(from, to);
            HideColumns(dgvHouses, "PhotoUrls", "AvailableFrom", "AvailableTo", "IsActive");
            flpPhotos.Controls.Clear();
            _selectedHouse = null; // Yeni filtrede eski seçimi temizle
        }

        private void btnSelectHouse_Click(object sender, EventArgs e)
        {
            if (dgvHouses.CurrentRow?.DataBoundItem is HouseModel house)
            {
                _selectedHouse = house;
                ShowInfo($"Seçili ilan: {house.Title}");
                DisplaySelectedHousePhotos(house);
            }
            else
            {
                ShowWarning("Lütfen önce bir ilan satırı seçin.");
            }
        }

        private void DisplaySelectedHousePhotos(HouseModel h)
        {
            flpPhotos.Controls.Clear();
            if (!string.IsNullOrWhiteSpace(h.PhotoUrls))
            {
                List<string> imgs = new();
                try
                {
                    imgs = JsonSerializer.Deserialize<List<string>>(h.PhotoUrls) ?? new List<string>();
                }
                catch (JsonException)
                {
                    // Eğer tek bir URL ise, onu da ekle
                    imgs.Add(h.PhotoUrls);
                }
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

        private void btnInspect_Click(object sender, EventArgs e)
        {
            if (_selectedHouse == null)
            {
                ShowWarning("Lütfen önce 'İlan Seç' butonuna tıklayarak bir ilan seçin.");
                return;
            }
            using var reviewForm = new ReviewForm(_selectedHouse.Id);
            reviewForm.ShowDialog();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

 

        // Diğer fonksiyonlar (yorum ekleme, rezervasyon...) da benzer şekilde seçili _selectedHouse ile ilerlemeli.
    }
}
