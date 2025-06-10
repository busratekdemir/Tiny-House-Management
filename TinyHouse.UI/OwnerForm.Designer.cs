namespace TinyHouse.UI
{
    partial class OwnerForm
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
            lblTitle = new Label();
            dgvMyHouses = new DataGridView();
            btnAddHouse = new Button();
            btnLogout = new Button();
            btnUpdate = new Button();
            btnShowIncome = new Button();
            tabControlOwner = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btn_logOut = new Button();
            label1 = new Label();
            dgvRequests = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMyHouses).BeginInit();
            tabControlOwner.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(24, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "İlanlarım";
            // 
            // dgvMyHouses
            // 
            dgvMyHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyHouses.BackgroundColor = SystemColors.ActiveCaption;
            dgvMyHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyHouses.Location = new Point(8, 37);
            dgvMyHouses.Name = "dgvMyHouses";
            dgvMyHouses.ReadOnly = true;
            dgvMyHouses.RowHeadersWidth = 51;
            dgvMyHouses.Size = new Size(940, 336);
            dgvMyHouses.TabIndex = 1;
            dgvMyHouses.CellClick += dgvMyHouses_CellClick;
            // 
            // btnAddHouse
            // 
            btnAddHouse.BackColor = Color.LemonChiffon;
            btnAddHouse.Location = new Point(6, 379);
            btnAddHouse.Name = "btnAddHouse";
            btnAddHouse.Size = new Size(168, 32);
            btnAddHouse.TabIndex = 2;
            btnAddHouse.Text = "İlan ekle";
            btnAddHouse.UseVisualStyleBackColor = false;
            btnAddHouse.Click += btnAddHouse_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(753, 452);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Çıkış yap";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LemonChiffon;
            btnUpdate.Location = new Point(8, 417);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(168, 35);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "İlan güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnShowIncome
            // 
            btnShowIncome.BackColor = Color.LemonChiffon;
            btnShowIncome.Location = new Point(763, 379);
            btnShowIncome.Name = "btnShowIncome";
            btnShowIncome.Size = new Size(178, 29);
            btnShowIncome.TabIndex = 7;
            btnShowIncome.Text = "Toplam Geliri Göster";
            btnShowIncome.UseVisualStyleBackColor = false;
            btnShowIncome.Click += btnShowIncome_Click;
            // 
            // tabControlOwner
            // 
            tabControlOwner.Controls.Add(tabPage1);
            tabControlOwner.Controls.Add(tabPage2);
            tabControlOwner.Dock = DockStyle.Fill;
            tabControlOwner.Location = new Point(0, 0);
            tabControlOwner.Name = "tabControlOwner";
            tabControlOwner.SelectedIndex = 0;
            tabControlOwner.Size = new Size(952, 493);
            tabControlOwner.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnShowIncome);
            tabPage1.Controls.Add(btnUpdate);
            tabPage1.Controls.Add(dgvMyHouses);
            tabPage1.Controls.Add(btnAddHouse);
            tabPage1.Controls.Add(lblTitle);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(944, 460);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "İlanlarım";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btn_logOut);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(dgvRequests);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(944, 460);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Talepler";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_logOut
            // 
            btn_logOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_logOut.BackColor = Color.LemonChiffon;
            btn_logOut.Location = new Point(849, 411);
            btn_logOut.Name = "btn_logOut";
            btn_logOut.Size = new Size(94, 29);
            btn_logOut.TabIndex = 2;
            btn_logOut.Text = "Çıkış";
            btn_logOut.UseVisualStyleBackColor = false;
            btn_logOut.Click += btn_logOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(21, 3);
            label1.Name = "label1";
            label1.Size = new Size(93, 31);
            label1.TabIndex = 1;
            label1.Text = "Talepler";
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.BackgroundColor = SystemColors.ActiveCaption;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.GridColor = SystemColors.InactiveCaption;
            dgvRequests.Location = new Point(3, 35);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(945, 370);
            dgvRequests.TabIndex = 0;
            // 
            // OwnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(952, 493);
            Controls.Add(tabControlOwner);
            Controls.Add(btnLogout);
            Name = "OwnerForm";
            Text = "OwnerForm";
            Load += OwnerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMyHouses).EndInit();
            tabControlOwner.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvMyHouses;
        private Button btnAddHouse;
        private Button btnLogout;
        private Button btnUpdate;
        private Button btnShowIncome;
        private TabControl tabControlOwner;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private DataGridView dgvRequests;
        private Button btn_logOut;
    }
}