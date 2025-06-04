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
            btnMyRes = new Button();
            btnReserve = new Button();
            btnLogout = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).BeginInit();
            SuspendLayout();
            // 
            // dgvHouses
            // 
            dgvHouses.AllowUserToAddRows = false;
            dgvHouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHouses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHouses.Location = new Point(10, 49);
            dgvHouses.Margin = new Padding(3, 2, 3, 2);
            dgvHouses.MultiSelect = false;
            dgvHouses.Name = "dgvHouses";
            dgvHouses.ReadOnly = true;
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHouses.Size = new Size(701, 264);
            dgvHouses.TabIndex = 0;
            dgvHouses.CellContentClick += dgvHouses_CellContentClick;
            // 
            // btnMyRes
            // 
            btnMyRes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMyRes.BackColor = Color.LemonChiffon;
            btnMyRes.Location = new Point(10, 317);
            btnMyRes.Margin = new Padding(3, 2, 3, 2);
            btnMyRes.Name = "btnMyRes";
            btnMyRes.Size = new Size(133, 22);
            btnMyRes.TabIndex = 1;
            btnMyRes.Text = "Rezervasyonlarım";
            btnMyRes.UseVisualStyleBackColor = false;
            btnMyRes.Click += btnMyRes_Click_1;
            // 
            // btnReserve
            // 
            btnReserve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserve.BackColor = Color.LemonChiffon;
            btnReserve.Location = new Point(190, 317);
            btnReserve.Margin = new Padding(3, 2, 3, 2);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(133, 22);
            btnReserve.TabIndex = 2;
            btnReserve.Text = "Rezervasyon yap";
            btnReserve.UseVisualStyleBackColor = false;
            btnReserve.Click += btnReserve_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(629, 317);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(82, 22);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Çıkış";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(230, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(179, 30);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Tiny House Evleri";
            // 
            // KiraciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 368);
            Controls.Add(lblTitle);
            Controls.Add(btnLogout);
            Controls.Add(btnReserve);
            Controls.Add(btnMyRes);
            Controls.Add(dgvHouses);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KiraciForm";
            Text = "KiraciForm";
            Load += KiraciForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHouses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHouses;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblTitle;
        private Button btnMyRes;
        private Button btnReserve;
        private Button btnLogout;
    }
}