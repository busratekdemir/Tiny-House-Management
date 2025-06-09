namespace TinyHouse.UI
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnLogout = new Button();
            bb = new TabControl();
            tabPage1 = new TabPage();
            lblPassiveUsers = new Label();
            lblActiveUsers = new Label();
            lblTotalUsers = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnToggleUserStatus = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnAddUser = new Button();
            label4 = new Label();
            dgvUsers = new DataGridView();
            cmbUserFilter = new ComboBox();
            tabPage2 = new TabPage();
            lblPassiveHouses = new Label();
            lblActiveHouses = new Label();
            lblTotalHouses = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            btnEditHouse = new Button();
            btnDeleteHouse = new Button();
            btnToggleHouseStatus = new Button();
            btnAddHouse = new Button();
            dgvHouses = new DataGridView();
            tabPage3 = new TabPage();
            lblCancelledReservations = new Label();
            lblRejectedReservations = new Label();
            lblApprovedReservations = new Label();
            lblPendingReservations = new Label();
            lblTotalReservations = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            btnDeleteReservation = new Button();
            btnCancelReservation = new Button();
            btnRejectReservation = new Button();
            btnApproveReservation = new Button();
            dgvReservations = new DataGridView();
            tabPage5 = new TabPage();
            label18 = new Label();
            btnDeleteReview = new Button();
            btnApproveReview = new Button();
            dgvReviews = new DataGridView();
            tabPage4 = new TabPage();
            bb.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(189, 3);
            label1.Name = "label1";
            label1.Size = new Size(283, 28);
            label1.TabIndex = 0;
            label1.Text = "Admin Paneline Hoşgeldiniz.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(6, 150);
            label2.Name = "label2";
            label2.Size = new Size(156, 23);
            label2.TabIndex = 1;
            label2.Text = "Kullanıcı İşlemleri:";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(8, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Çıkış Yap";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // bb
            // 
            bb.Controls.Add(tabPage1);
            bb.Controls.Add(tabPage2);
            bb.Controls.Add(tabPage3);
            bb.Controls.Add(tabPage5);
            bb.Controls.Add(tabPage4);
            bb.Dock = DockStyle.Fill;
            bb.Location = new Point(0, 0);
            bb.Name = "bb";
            bb.SelectedIndex = 0;
            bb.Size = new Size(721, 598);
            bb.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Honeydew;
            tabPage1.Controls.Add(lblPassiveUsers);
            tabPage1.Controls.Add(lblActiveUsers);
            tabPage1.Controls.Add(lblTotalUsers);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(btnToggleUserStatus);
            tabPage1.Controls.Add(btnEditUser);
            tabPage1.Controls.Add(btnDeleteUser);
            tabPage1.Controls.Add(btnAddUser);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(dgvUsers);
            tabPage1.Controls.Add(cmbUserFilter);
            tabPage1.Controls.Add(btnLogout);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(713, 565);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kullanıcılar";
            // 
            // lblPassiveUsers
            // 
            lblPassiveUsers.AutoSize = true;
            lblPassiveUsers.Location = new Point(595, 132);
            lblPassiveUsers.Name = "lblPassiveUsers";
            lblPassiveUsers.Size = new Size(0, 20);
            lblPassiveUsers.TabIndex = 30;
            // 
            // lblActiveUsers
            // 
            lblActiveUsers.AutoSize = true;
            lblActiveUsers.Location = new Point(603, 98);
            lblActiveUsers.Name = "lblActiveUsers";
            lblActiveUsers.Size = new Size(0, 20);
            lblActiveUsers.TabIndex = 29;
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Location = new Point(655, 59);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(0, 20);
            lblTotalUsers.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.LightGreen;
            label7.Location = new Point(486, 59);
            label7.Name = "label7";
            label7.Size = new Size(167, 20);
            label7.TabIndex = 27;
            label7.Text = "Toplam Kullanıcı Sayısı :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightGreen;
            label6.Location = new Point(486, 98);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 26;
            label6.Text = "Aktif Kullanıcı:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightGreen;
            label5.Location = new Point(487, 132);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 25;
            label5.Text = "Pasif Kullanıcı:";
            // 
            // btnToggleUserStatus
            // 
            btnToggleUserStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnToggleUserStatus.BackColor = Color.LemonChiffon;
            btnToggleUserStatus.Location = new Point(457, 189);
            btnToggleUserStatus.Name = "btnToggleUserStatus";
            btnToggleUserStatus.Size = new Size(122, 29);
            btnToggleUserStatus.TabIndex = 24;
            btnToggleUserStatus.Text = "Aktif/Pasif Yap";
            btnToggleUserStatus.UseVisualStyleBackColor = false;
            // 
            // btnEditUser
            // 
            btnEditUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditUser.BackColor = Color.LemonChiffon;
            btnEditUser.Location = new Point(191, 189);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(160, 29);
            btnEditUser.TabIndex = 23;
            btnEditUser.Text = "Kişi Güncelle";
            btnEditUser.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteUser.BackColor = Color.LemonChiffon;
            btnDeleteUser.Location = new Point(357, 189);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(94, 29);
            btnDeleteUser.TabIndex = 22;
            btnDeleteUser.Text = "Kişi Sil";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddUser.BackColor = Color.LemonChiffon;
            btnAddUser.Location = new Point(58, 189);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(127, 29);
            btnAddUser.TabIndex = 21;
            btnAddUser.Text = "Kişi Ekle";
            btnAddUser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightGreen;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(8, 78);
            label4.Name = "label4";
            label4.Size = new Size(67, 25);
            label4.TabIndex = 20;
            label4.Text = "Filtrele:";
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.MintCream;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Bottom;
            dgvUsers.Location = new Point(3, 234);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(707, 328);
            dgvUsers.TabIndex = 19;
            // 
            // cmbUserFilter
            // 
            cmbUserFilter.FormattingEnabled = true;
            cmbUserFilter.Location = new Point(81, 78);
            cmbUserFilter.Name = "cmbUserFilter";
            cmbUserFilter.Size = new Size(151, 28);
            cmbUserFilter.TabIndex = 18;
            cmbUserFilter.SelectedIndexChanged += cmbUserFilter_SelectedIndexChanged_1;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.MistyRose;
            tabPage2.Controls.Add(lblPassiveHouses);
            tabPage2.Controls.Add(lblActiveHouses);
            tabPage2.Controls.Add(lblTotalHouses);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(btnEditHouse);
            tabPage2.Controls.Add(btnDeleteHouse);
            tabPage2.Controls.Add(btnToggleHouseStatus);
            tabPage2.Controls.Add(btnAddHouse);
            tabPage2.Controls.Add(dgvHouses);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(713, 565);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Evler";
            // 
            // lblPassiveHouses
            // 
            lblPassiveHouses.AutoSize = true;
            lblPassiveHouses.Location = new Point(647, 85);
            lblPassiveHouses.Name = "lblPassiveHouses";
            lblPassiveHouses.Size = new Size(0, 20);
            lblPassiveHouses.TabIndex = 11;
            // 
            // lblActiveHouses
            // 
            lblActiveHouses.AutoSize = true;
            lblActiveHouses.Location = new Point(647, 53);
            lblActiveHouses.Name = "lblActiveHouses";
            lblActiveHouses.Size = new Size(0, 20);
            lblActiveHouses.TabIndex = 10;
            // 
            // lblTotalHouses
            // 
            lblTotalHouses.AutoSize = true;
            lblTotalHouses.Location = new Point(647, 22);
            lblTotalHouses.Name = "lblTotalHouses";
            lblTotalHouses.Size = new Size(0, 20);
            lblTotalHouses.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(295, 15);
            label11.Name = "label11";
            label11.Size = new Size(72, 28);
            label11.TabIndex = 8;
            label11.Text = "İlanlar";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.RosyBrown;
            label10.Location = new Point(570, 85);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 7;
            label10.Text = "Pasif İlan:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.RosyBrown;
            label9.Location = new Point(570, 53);
            label9.Name = "label9";
            label9.Size = new Size(71, 20);
            label9.TabIndex = 6;
            label9.Text = "Aktif İlan:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.RosyBrown;
            label8.Location = new Point(579, 23);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 5;
            label8.Text = "Toplam:";
            // 
            // btnEditHouse
            // 
            btnEditHouse.BackColor = Color.LightCoral;
            btnEditHouse.Location = new Point(137, 111);
            btnEditHouse.Name = "btnEditHouse";
            btnEditHouse.Size = new Size(129, 29);
            btnEditHouse.TabIndex = 4;
            btnEditHouse.Text = "İlan Güncelle";
            btnEditHouse.UseVisualStyleBackColor = false;
            // 
            // btnDeleteHouse
            // 
            btnDeleteHouse.BackColor = Color.LightCoral;
            btnDeleteHouse.Location = new Point(295, 111);
            btnDeleteHouse.Name = "btnDeleteHouse";
            btnDeleteHouse.Size = new Size(94, 29);
            btnDeleteHouse.TabIndex = 3;
            btnDeleteHouse.Text = "İlan Sil";
            btnDeleteHouse.UseVisualStyleBackColor = false;
            // 
            // btnToggleHouseStatus
            // 
            btnToggleHouseStatus.BackColor = Color.LightCoral;
            btnToggleHouseStatus.Location = new Point(414, 111);
            btnToggleHouseStatus.Name = "btnToggleHouseStatus";
            btnToggleHouseStatus.Size = new Size(132, 29);
            btnToggleHouseStatus.TabIndex = 2;
            btnToggleHouseStatus.Text = "Aktif/Pasif Yap";
            btnToggleHouseStatus.UseVisualStyleBackColor = false;
            // 
            // btnAddHouse
            // 
            btnAddHouse.BackColor = Color.LightCoral;
            btnAddHouse.Location = new Point(22, 111);
            btnAddHouse.Name = "btnAddHouse";
            btnAddHouse.Size = new Size(94, 29);
            btnAddHouse.TabIndex = 1;
            btnAddHouse.Text = "İlan Ekle";
            btnAddHouse.UseVisualStyleBackColor = false;
            // 
            // dgvHouses
            // 
            dgvHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHouses.BackgroundColor = Color.SeaShell;
            dgvHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHouses.Dock = DockStyle.Bottom;
            dgvHouses.Location = new Point(3, 146);
            dgvHouses.Name = "dgvHouses";
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.Size = new Size(707, 416);
            dgvHouses.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.PaleTurquoise;
            tabPage3.Controls.Add(lblCancelledReservations);
            tabPage3.Controls.Add(lblRejectedReservations);
            tabPage3.Controls.Add(lblApprovedReservations);
            tabPage3.Controls.Add(lblPendingReservations);
            tabPage3.Controls.Add(lblTotalReservations);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(btnDeleteReservation);
            tabPage3.Controls.Add(btnCancelReservation);
            tabPage3.Controls.Add(btnRejectReservation);
            tabPage3.Controls.Add(btnApproveReservation);
            tabPage3.Controls.Add(dgvReservations);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(713, 565);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Rezervasyonlar";
            // 
            // lblCancelledReservations
            // 
            lblCancelledReservations.AutoSize = true;
            lblCancelledReservations.Location = new Point(593, 519);
            lblCancelledReservations.Name = "lblCancelledReservations";
            lblCancelledReservations.Size = new Size(58, 20);
            lblCancelledReservations.TabIndex = 15;
            lblCancelledReservations.Text = "label22";
            // 
            // lblRejectedReservations
            // 
            lblRejectedReservations.AutoSize = true;
            lblRejectedReservations.Location = new Point(467, 519);
            lblRejectedReservations.Name = "lblRejectedReservations";
            lblRejectedReservations.Size = new Size(58, 20);
            lblRejectedReservations.TabIndex = 14;
            lblRejectedReservations.Text = "label21";
            // 
            // lblApprovedReservations
            // 
            lblApprovedReservations.AutoSize = true;
            lblApprovedReservations.Location = new Point(312, 519);
            lblApprovedReservations.Name = "lblApprovedReservations";
            lblApprovedReservations.Size = new Size(58, 20);
            lblApprovedReservations.TabIndex = 13;
            lblApprovedReservations.Text = "label20";
            // 
            // lblPendingReservations
            // 
            lblPendingReservations.AutoSize = true;
            lblPendingReservations.Location = new Point(210, 519);
            lblPendingReservations.Name = "lblPendingReservations";
            lblPendingReservations.Size = new Size(58, 20);
            lblPendingReservations.TabIndex = 12;
            lblPendingReservations.Text = "label19";
            // 
            // lblTotalReservations
            // 
            lblTotalReservations.AutoSize = true;
            lblTotalReservations.Location = new Point(75, 519);
            lblTotalReservations.Name = "lblTotalReservations";
            lblTotalReservations.Size = new Size(58, 20);
            lblTotalReservations.TabIndex = 11;
            lblTotalReservations.Text = "label18";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.MediumAquamarine;
            label17.Location = new Point(546, 519);
            label17.Name = "label17";
            label17.Size = new Size(42, 20);
            label17.TabIndex = 10;
            label17.Text = "İptal:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.MediumAquamarine;
            label16.Location = new Point(376, 519);
            label16.Name = "label16";
            label16.Size = new Size(85, 20);
            label16.TabIndex = 9;
            label16.Text = "Reddedildi:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.MediumAquamarine;
            label15.Location = new Point(263, 519);
            label15.Name = "label15";
            label15.Size = new Size(54, 20);
            label15.TabIndex = 8;
            label15.Text = "Onaylı:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.MediumAquamarine;
            label14.Location = new Point(139, 519);
            label14.Name = "label14";
            label14.Size = new Size(65, 20);
            label14.TabIndex = 7;
            label14.Text = "Bekliyor:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.MediumAquamarine;
            label13.Location = new Point(18, 519);
            label13.Name = "label13";
            label13.Size = new Size(62, 20);
            label13.TabIndex = 6;
            label13.Text = "Toplam:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(263, 12);
            label12.Name = "label12";
            label12.Size = new Size(143, 25);
            label12.TabIndex = 5;
            label12.Text = "Rezervasyonlar";
            // 
            // btnDeleteReservation
            // 
            btnDeleteReservation.BackColor = Color.MediumTurquoise;
            btnDeleteReservation.Location = new Point(557, 102);
            btnDeleteReservation.Name = "btnDeleteReservation";
            btnDeleteReservation.Size = new Size(94, 29);
            btnDeleteReservation.TabIndex = 4;
            btnDeleteReservation.Text = "Sil";
            btnDeleteReservation.UseVisualStyleBackColor = false;
            // 
            // btnCancelReservation
            // 
            btnCancelReservation.BackColor = Color.MediumTurquoise;
            btnCancelReservation.Location = new Point(396, 102);
            btnCancelReservation.Name = "btnCancelReservation";
            btnCancelReservation.Size = new Size(94, 29);
            btnCancelReservation.TabIndex = 3;
            btnCancelReservation.Text = "İptal Et";
            btnCancelReservation.UseVisualStyleBackColor = false;
            // 
            // btnRejectReservation
            // 
            btnRejectReservation.BackColor = Color.MediumTurquoise;
            btnRejectReservation.Location = new Point(227, 102);
            btnRejectReservation.Name = "btnRejectReservation";
            btnRejectReservation.Size = new Size(94, 29);
            btnRejectReservation.TabIndex = 2;
            btnRejectReservation.Text = "Reddet";
            btnRejectReservation.UseVisualStyleBackColor = false;
            // 
            // btnApproveReservation
            // 
            btnApproveReservation.BackColor = Color.MediumTurquoise;
            btnApproveReservation.Location = new Point(73, 102);
            btnApproveReservation.Name = "btnApproveReservation";
            btnApproveReservation.Size = new Size(94, 29);
            btnApproveReservation.TabIndex = 1;
            btnApproveReservation.Text = "Onayla";
            btnApproveReservation.UseVisualStyleBackColor = false;
            // 
            // dgvReservations
            // 
            dgvReservations.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.LightCyan;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(3, 137);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.Size = new Size(707, 379);
            dgvReservations.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.Thistle;
            tabPage5.Controls.Add(label18);
            tabPage5.Controls.Add(btnDeleteReview);
            tabPage5.Controls.Add(btnApproveReview);
            tabPage5.Controls.Add(dgvReviews);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(713, 565);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Yorumlar";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label18.Location = new Point(270, 9);
            label18.Name = "label18";
            label18.Size = new Size(97, 28);
            label18.TabIndex = 3;
            label18.Text = "Yorumlar";
            // 
            // btnDeleteReview
            // 
            btnDeleteReview.BackColor = Color.LavenderBlush;
            btnDeleteReview.Location = new Point(547, 99);
            btnDeleteReview.Name = "btnDeleteReview";
            btnDeleteReview.Size = new Size(94, 29);
            btnDeleteReview.TabIndex = 2;
            btnDeleteReview.Text = "Yorumu Sil";
            btnDeleteReview.UseVisualStyleBackColor = false;
            // 
            // btnApproveReview
            // 
            btnApproveReview.BackColor = Color.LavenderBlush;
            btnApproveReview.Location = new Point(347, 99);
            btnApproveReview.Name = "btnApproveReview";
            btnApproveReview.Size = new Size(153, 29);
            btnApproveReview.TabIndex = 1;
            btnApproveReview.Text = "Yorumu Onayla";
            btnApproveReview.UseVisualStyleBackColor = false;
            // 
            // dgvReviews
            // 
            dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReviews.BackgroundColor = Color.Plum;
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Dock = DockStyle.Bottom;
            dgvReviews.Location = new Point(0, 134);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowHeadersWidth = 51;
            dgvReviews.Size = new Size(713, 431);
            dgvReviews.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(713, 565);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Raporlar";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(721, 598);
            Controls.Add(bb);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            bb.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnLogout;
        private TabControl bb;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvUsers;
        private ComboBox cmbUserFilter;
        private Button btnToggleUserStatus;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnAddUser;
        private Label label4;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label lblPassiveUsers;
        private Label lblActiveUsers;
        private Label lblTotalUsers;
        private DataGridView dgvHouses;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button btnEditHouse;
        private Button btnDeleteHouse;
        private Button btnToggleHouseStatus;
        private Button btnAddHouse;
        private Label lblPassiveHouses;
        private Label lblActiveHouses;
        private Label lblTotalHouses;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Button btnDeleteReservation;
        private Button btnCancelReservation;
        private Button btnRejectReservation;
        private Button btnApproveReservation;
        private DataGridView dgvReservations;
        private Label lblCancelledReservations;
        private Label lblRejectedReservations;
        private Label lblApprovedReservations;
        private Label lblPendingReservations;
        private Label lblTotalReservations;
        private TabPage tabPage5;
        private Button btnDeleteReview;
        private Button btnApproveReview;
        private DataGridView dgvReviews;
        private Label label18;
    }
}