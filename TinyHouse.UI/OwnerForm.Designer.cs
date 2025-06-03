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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMyHouses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(328, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(134, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "İlanlarım";
            // 
            // dgvMyHouses
            // 
            dgvMyHouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMyHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyHouses.BackgroundColor = SystemColors.ActiveCaption;
            dgvMyHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyHouses.Location = new Point(-1, 62);
            dgvMyHouses.Name = "dgvMyHouses";
            dgvMyHouses.ReadOnly = true;
            dgvMyHouses.RowHeadersWidth = 51;
            dgvMyHouses.Size = new Size(848, 310);
            dgvMyHouses.TabIndex = 1;
            dgvMyHouses.CellClick += dgvMyHouses_CellClick;
            // 
            // btnAddHouse
            // 
            btnAddHouse.BackColor = Color.LemonChiffon;
            btnAddHouse.Location = new Point(51, 378);
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
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LemonChiffon;
            btnUpdate.Location = new Point(247, 378);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(168, 34);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "İlan güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LemonChiffon;
            button1.Location = new Point(669, 383);
            button1.Name = "button1";
            button1.Size = new Size(178, 29);
            button1.TabIndex = 7;
            button1.Text = "Toplam Geliri Göster";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // OwnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(855, 493);
            Controls.Add(button1);
            Controls.Add(btnUpdate);
            Controls.Add(btnLogout);
            Controls.Add(btnAddHouse);
            Controls.Add(dgvMyHouses);
            Controls.Add(lblTitle);
            Name = "OwnerForm";
            Text = "OwnerForm";
            ((System.ComponentModel.ISupportInitialize)dgvMyHouses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvMyHouses;
        private Button btnAddHouse;
        private Button button3;
        private Button btnLogout;
        private Button btnUpdate;
        private Button button1;
    }
}