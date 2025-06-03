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
            dgvHouses.Location = new Point(12, 65);
            dgvHouses.MultiSelect = false;
            dgvHouses.Name = "dgvHouses";
            dgvHouses.ReadOnly = true;
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHouses.Size = new Size(801, 352);
            dgvHouses.TabIndex = 0;
            // 
            // btnMyRes
            // 
            btnMyRes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMyRes.BackColor = Color.LemonChiffon;
            btnMyRes.Location = new Point(12, 423);
            btnMyRes.Name = "btnMyRes";
            btnMyRes.Size = new Size(152, 29);
            btnMyRes.TabIndex = 1;
            btnMyRes.Text = "Rezervasyonlarım";
            btnMyRes.UseVisualStyleBackColor = false;
            btnMyRes.Click += btnMyRes_Click_1;
            // 
            // btnReserve
            // 
            btnReserve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserve.BackColor = Color.LemonChiffon;
            btnReserve.Location = new Point(217, 423);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(152, 29);
            btnReserve.TabIndex = 2;
            btnReserve.Text = "Rezervasyon yap";
            btnReserve.UseVisualStyleBackColor = false;
            btnReserve.Click += btnReserve_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(719, 423);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Çıkış";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.Location = new Point(263, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 38);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Tiny House Evleri";
            // 
            // KiraciForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 490);
            Controls.Add(lblTitle);
            Controls.Add(btnLogout);
            Controls.Add(btnReserve);
            Controls.Add(btnMyRes);
            Controls.Add(dgvHouses);
            Name = "KiraciForm";
            Text = "KiraciForm";
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