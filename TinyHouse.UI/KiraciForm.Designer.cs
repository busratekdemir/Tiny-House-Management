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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvHouses = new DataGridView();
            btnReserve = new Button();
            btnLogout = new Button();
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            flpPhotos = new FlowLayoutPanel();
            panel2 = new Panel();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            tabPage1 = new TabPage();
            label1 = new Label();
            dgvMyReservations = new DataGridView();
            btnCancel = new DataGridViewButtonColumn();
            Sil = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).BeginInit();
            SuspendLayout();
            // 
            // dgvHouses
            // 
            dgvHouses.AllowUserToAddRows = false;
            dgvHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHouses.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHouses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHouses.Columns.AddRange(new DataGridViewColumn[] { Sil });
            dgvHouses.Dock = DockStyle.Top;
            dgvHouses.GridColor = SystemColors.ActiveCaption;
            dgvHouses.Location = new Point(3, 3);
            dgvHouses.MultiSelect = false;
            dgvHouses.Name = "dgvHouses";
            dgvHouses.ReadOnly = true;
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHouses.Size = new Size(791, 403);
            dgvHouses.TabIndex = 0;
            // 
            // btnReserve
            // 
            btnReserve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserve.BackColor = Color.LemonChiffon;
            btnReserve.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnReserve.Location = new Point(262, 451);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(114, 90);
            btnReserve.TabIndex = 2;
            btnReserve.Text = "Rezervasyon yap";
            btnReserve.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnLogout.Location = new Point(262, 545);
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
            lblTitle.Location = new Point(11, 412);
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
            tabControl1.Size = new Size(805, 620);
            tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flpPhotos);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(btnLogout);
            tabPage2.Controls.Add(lblTitle);
            tabPage2.Controls.Add(dgvHouses);
            tabPage2.Controls.Add(btnReserve);
            tabPage2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(797, 584);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tüm İlanlar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpPhotos
            // 
            flpPhotos.AutoScroll = true;
            flpPhotos.BackColor = Color.WhiteSmoke;
            flpPhotos.ForeColor = SystemColors.ActiveCaptionText;
            flpPhotos.Location = new Point(418, 412);
            flpPhotos.Name = "flpPhotos";
            flpPhotos.Size = new Size(371, 164);
            flpPhotos.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpEnd);
            panel2.Controls.Add(dtpStart);
            panel2.Location = new Point(8, 451);
            panel2.Name = "panel2";
            panel2.Size = new Size(235, 104);
            panel2.TabIndex = 5;
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpEnd.Location = new Point(3, 63);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(228, 30);
            dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpStart.Location = new Point(3, 3);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(228, 30);
            dtpStart.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dgvMyReservations);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(797, 584);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Rezervasyonlarım";
            tabPage1.UseVisualStyleBackColor = true;
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
            dgvMyReservations.BackgroundColor = SystemColors.ActiveCaption;
            dgvMyReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyReservations.Columns.AddRange(new DataGridViewColumn[] { btnCancel });
            dgvMyReservations.Dock = DockStyle.Fill;
            dgvMyReservations.Location = new Point(3, 3);
            dgvMyReservations.Name = "dgvMyReservations";
            dgvMyReservations.RowHeadersWidth = 51;
            dgvMyReservations.Size = new Size(791, 578);
            dgvMyReservations.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.HeaderText = "İptal et";
            btnCancel.MinimumWidth = 6;
            btnCancel.Name = "btnCancel";
            btnCancel.Width = 125;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.MinimumWidth = 6;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            // 
            // KiraciForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 620);
            Controls.Add(tabControl1);
            Name = "KiraciForm";
            Text = "KiraciForm";
           
            ((System.ComponentModel.ISupportInitialize)dgvHouses).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHouses;
        private Button button1;
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
        private DateTimePicker dtpStart;
        private Label label1;
        private DataGridView dgvMyReservations;
        private DataGridViewButtonColumn btnCancel;
        private FlowLayoutPanel flpPhotos;
        private DataGridViewTextBoxColumn Sil;
    }
}