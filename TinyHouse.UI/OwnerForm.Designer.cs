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
            lblTitle.Location = new Point(287, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(104, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "İlanlarım";
            // 
            // dgvMyHouses
            // 
            dgvMyHouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMyHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyHouses.BackgroundColor = SystemColors.ActiveCaption;
            dgvMyHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyHouses.Location = new Point(-1, 46);
            dgvMyHouses.Margin = new Padding(3, 2, 3, 2);
            dgvMyHouses.Name = "dgvMyHouses";
            dgvMyHouses.ReadOnly = true;
            dgvMyHouses.RowHeadersWidth = 51;
            dgvMyHouses.Size = new Size(742, 232);
            dgvMyHouses.TabIndex = 1;
            dgvMyHouses.CellClick += dgvMyHouses_CellClick;
            // 
            // btnAddHouse
            // 
            btnAddHouse.BackColor = Color.LemonChiffon;
            btnAddHouse.Location = new Point(45, 284);
            btnAddHouse.Margin = new Padding(3, 2, 3, 2);
            btnAddHouse.Name = "btnAddHouse";
            btnAddHouse.Size = new Size(147, 24);
            btnAddHouse.TabIndex = 2;
            btnAddHouse.Text = "İlan ekle";
            btnAddHouse.UseVisualStyleBackColor = false;
            btnAddHouse.Click += btnAddHouse_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(659, 339);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(82, 22);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Çıkış yap";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LemonChiffon;
            btnUpdate.Location = new Point(216, 284);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(147, 26);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "İlan güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LemonChiffon;
            button1.Location = new Point(585, 287);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(156, 22);
            button1.TabIndex = 7;
            button1.Text = "Toplam Geliri Göster";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // OwnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(748, 370);
            Controls.Add(button1);
            Controls.Add(btnUpdate);
            Controls.Add(btnLogout);
            Controls.Add(btnAddHouse);
            Controls.Add(dgvMyHouses);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OwnerForm";
            Text = "OwnerForm";
            Load += OwnerForm_Load;
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