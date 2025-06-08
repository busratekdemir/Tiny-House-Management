namespace TinyHouse.UI
{
    partial class ReviewForm
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
            lblCaptionTitle = new Label();
            txtDescription = new TextBox();
            label5 = new Label();
            dgvReviews = new DataGridView();
            label6 = new Label();
            btnBack = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblTitle = new Label();
            lblPrice = new Label();
            lblLocation = new Label();
            btnReserve = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // lblCaptionTitle
            // 
            lblCaptionTitle.AutoSize = true;
            lblCaptionTitle.BackColor = Color.YellowGreen;
            lblCaptionTitle.Location = new Point(70, 58);
            lblCaptionTitle.Name = "lblCaptionTitle";
            lblCaptionTitle.Size = new Size(50, 20);
            lblCaptionTitle.TabIndex = 0;
            lblCaptionTitle.Text = "Başlık:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(149, 89);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(438, 34);
            txtDescription.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(12, 227);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 5;
            label5.Text = "YORUMLAR:";
            // 
            // dgvReviews
            // 
            dgvReviews.BackgroundColor = Color.DarkSeaGreen;
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.GridColor = SystemColors.ScrollBar;
            dgvReviews.Location = new Point(0, 262);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowHeadersWidth = 51;
            dgvReviews.Size = new Size(597, 249);
            dgvReviews.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(203, 9);
            label6.Name = "label6";
            label6.Size = new Size(193, 31);
            label6.TabIndex = 7;
            label6.Text = "İLAN İNCELEMESİ";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(192, 255, 192);
            btnBack.Location = new Point(503, 517);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 30);
            btnBack.TabIndex = 8;
            btnBack.Text = "Geri";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.YellowGreen;
            label1.Location = new Point(70, 92);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 9;
            label1.Text = "Açıklama:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.YellowGreen;
            label2.Location = new Point(70, 124);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 10;
            label2.Text = "Fiyat:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.YellowGreen;
            label3.Location = new Point(70, 156);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 11;
            label3.Text = "Konum";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(149, 58);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 20);
            lblTitle.TabIndex = 12;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(149, 124);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(0, 20);
            lblPrice.TabIndex = 13;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(149, 156);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 14;
            // 
            // btnReserve
            // 
            btnReserve.BackColor = Color.FromArgb(192, 255, 192);
            btnReserve.Location = new Point(485, 182);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(102, 74);
            btnReserve.TabIndex = 16;
            btnReserve.Text = "Rezervasyon Yap";
            btnReserve.UseVisualStyleBackColor = false;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 546);
            Controls.Add(btnReserve);
            Controls.Add(lblLocation);
            Controls.Add(lblPrice);
            Controls.Add(lblTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(label6);
            Controls.Add(dgvReviews);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(lblCaptionTitle);
            Name = "ReviewForm";
            Text = "ReviewForm";
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaptionTitle;
        private TextBox txtDescription;
        private Label label5;
        private DataGridView dgvReviews;
        private Label label6;
        private Button btnBack;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTitle;
        private Label lblPrice;
        private Label lblLocation;
        private Button btnReserve;
    }
}