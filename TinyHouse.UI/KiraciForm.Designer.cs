
namespace TinyHouse.UI
{
    partial class KiraciForm
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
            dgvHouses = new DataGridView();
            Sil = new DataGridViewTextBoxColumn();
            btnLogout = new Button();
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            btnSelectHouse = new Button();
            btnInspect = new Button();
            btnFilter = new Button();
            flpPhotos = new FlowLayoutPanel();
            panel2 = new Panel();
            dtpTo = new DateTimePicker();
            lblBitis = new Label();
            lblBasla = new Label();
            dtpFrom = new DateTimePicker();
            tabPage1 = new TabPage();
            button1 = new Button();
            panelAddComment = new Panel();
            label2 = new Label();
            txtComment = new RichTextBox();
            nudRating = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            btnSubmitComment = new Button();
            label1 = new Label();
            dgvMyReservations = new DataGridView();
            btnCancel = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            tabPage1.SuspendLayout();
            panelAddComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).BeginInit();
            SuspendLayout();
            // 
            // dgvHouses
            // 
            dgvHouses.AllowUserToAddRows = false;
            dgvHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHouses.BackgroundColor = Color.MistyRose;
            dgvHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHouses.Columns.AddRange(new DataGridViewColumn[] { Sil });
            dgvHouses.Dock = DockStyle.Bottom;
            dgvHouses.GridColor = SystemColors.ActiveCaption;
            dgvHouses.Location = new Point(3, 310);
            dgvHouses.MultiSelect = false;
            dgvHouses.Name = "dgvHouses";
            dgvHouses.ReadOnly = true;
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHouses.Size = new Size(981, 352);
            dgvHouses.TabIndex = 0;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.MinimumWidth = 6;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnLogout.Location = new Point(1012, 628);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 31);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Çıkış";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 28);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Tiny House Evleri";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(995, 701);
            tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSelectHouse);
            tabPage2.Controls.Add(btnInspect);
            tabPage2.Controls.Add(btnFilter);
            tabPage2.Controls.Add(flpPhotos);
            tabPage2.Controls.Add(dgvHouses);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(btnLogout);
            tabPage2.Controls.Add(lblTitle);
            tabPage2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(987, 665);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tüm İlanlar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelectHouse
            // 
            btnSelectHouse.BackColor = Color.RosyBrown;
            btnSelectHouse.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSelectHouse.Location = new Point(829, 245);
            btnSelectHouse.Name = "btnSelectHouse";
            btnSelectHouse.Size = new Size(74, 59);
            btnSelectHouse.TabIndex = 10;
            btnSelectHouse.Text = "İlan seç";
            btnSelectHouse.UseVisualStyleBackColor = false;
            // 
            // btnInspect
            // 
            btnInspect.BackColor = Color.RosyBrown;
            btnInspect.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnInspect.Location = new Point(909, 245);
            btnInspect.Name = "btnInspect";
            btnInspect.Size = new Size(78, 59);
            btnInspect.TabIndex = 9;
            btnInspect.Text = "İncele";
            btnInspect.UseVisualStyleBackColor = false;
            btnInspect.Click += btnInspect_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFilter.BackColor = Color.RosyBrown;
            btnFilter.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnFilter.Location = new Point(597, 181);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(181, 31);
            btnFilter.TabIndex = 8;
            btnFilter.Text = "Filtrele";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // flpPhotos
            // 
            flpPhotos.AutoScroll = true;
            flpPhotos.BackColor = Color.MistyRose;
            flpPhotos.ForeColor = SystemColors.ActiveCaptionText;
            flpPhotos.Location = new Point(8, 42);
            flpPhotos.Name = "flpPhotos";
            flpPhotos.Size = new Size(577, 252);
            flpPhotos.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpTo);
            panel2.Controls.Add(lblBitis);
            panel2.Controls.Add(lblBasla);
            panel2.Controls.Add(dtpFrom);
            panel2.Location = new Point(591, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 133);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpTo.Location = new Point(6, 89);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(255, 30);
            dtpTo.TabIndex = 4;
            // 
            // lblBitis
            // 
            lblBitis.AutoSize = true;
            lblBitis.BackColor = Color.MistyRose;
            lblBitis.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBitis.Location = new Point(6, 66);
            lblBitis.Name = "lblBitis";
            lblBitis.Size = new Size(83, 20);
            lblBitis.TabIndex = 3;
            lblBitis.Text = "Bitiş Tarihi :";
            // 
            // lblBasla
            // 
            lblBasla.AutoSize = true;
            lblBasla.BackColor = Color.MistyRose;
            lblBasla.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBasla.Location = new Point(6, 13);
            lblBasla.Name = "lblBasla";
            lblBasla.Size = new Size(118, 20);
            lblBasla.TabIndex = 2;
            lblBasla.Text = "Başlangıç Tarihi :";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpFrom.Location = new Point(6, 36);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(255, 30);
            dtpFrom.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(panelAddComment);
            tabPage1.Controls.Add(btnSubmitComment);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dgvMyReservations);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(987, 665);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Rezervasyonlarım";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(856, 671);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panelAddComment
            // 
            panelAddComment.Controls.Add(label2);
            panelAddComment.Controls.Add(txtComment);
            panelAddComment.Controls.Add(nudRating);
            panelAddComment.Controls.Add(label4);
            panelAddComment.Controls.Add(label3);
            panelAddComment.Location = new Point(8, 330);
            panelAddComment.Name = "panelAddComment";
            panelAddComment.Size = new Size(780, 247);
            panelAddComment.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(100, 10);
            label2.Name = "label2";
            label2.Size = new Size(222, 28);
            label2.TabIndex = 9;
            label2.Text = "YORUM EKLEME PANELİ";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(13, 100);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(575, 141);
            txtComment.TabIndex = 7;
            txtComment.Text = "";
            // 
            // nudRating
            // 
            nudRating.Location = new Point(68, 41);
            nudRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRating.Name = "nudRating";
            nudRating.Size = new Size(49, 30);
            nudRating.TabIndex = 8;
            nudRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(0, 73);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 11;
            label4.Text = "Yorum:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(3, 51);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 10;
            label3.Text = "Puan:";
            // 
            // btnSubmitComment
            // 
            btnSubmitComment.BackColor = Color.Salmon;
            btnSubmitComment.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSubmitComment.Location = new Point(502, 579);
            btnSubmitComment.Name = "btnSubmitComment";
            btnSubmitComment.Size = new Size(94, 32);
            btnSubmitComment.TabIndex = 6;
            btnSubmitComment.Text = "Gönder";
            btnSubmitComment.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(8, 4);
            label1.Name = "label1";
            label1.Size = new Size(164, 28);
            label1.TabIndex = 5;
            label1.Text = "Rezervasyonlarım";
            // 
            // dgvMyReservations
            // 
            dgvMyReservations.BackgroundColor = Color.NavajoWhite;
            dgvMyReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyReservations.Columns.AddRange(new DataGridViewColumn[] { btnCancel });
            dgvMyReservations.Dock = DockStyle.Top;
            dgvMyReservations.Location = new Point(3, 3);
            dgvMyReservations.Name = "dgvMyReservations";
            dgvMyReservations.RowHeadersWidth = 51;
            dgvMyReservations.Size = new Size(981, 321);
            dgvMyReservations.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.HeaderText = "İptal et";
            btnCancel.MinimumWidth = 6;
            btnCancel.Name = "btnCancel";
            btnCancel.Width = 125;
            // 
            // KiraciForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 701);
            Controls.Add(tabControl1);
            Name = "KiraciForm";
            Text = "KiraciForm";
            ((System.ComponentModel.ISupportInitialize)dgvHouses).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panelAddComment.ResumeLayout(false);
            panelAddComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).EndInit();
            ResumeLayout(false);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ReloadHouses();
        }

        #endregion

        private DataGridView dgvHouses;
        private Button btnSubmitComment;
        private Button button2;
        private Button button3;
        private Label lblTitle;
        private Button btnReserve;
        private Button btnLogout;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel2;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpFrom;
        private Label label1;
        private DataGridView dgvMyReservations;
        private DataGridViewButtonColumn btnCancel;
        private FlowLayoutPanel flpPhotos;
        private DataGridViewTextBoxColumn Sil;
        private Label lblBasla;
        private Label lblBitis;
        private Button btnFilter;
        private DateTimePicker dtpTo;
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown nudRating;
        private Button btnInspect;
        private Panel panelAddComment;
        private RichTextBox txtComment;
        private Button btnSelectHouse;
        private Button button1;
    }
}