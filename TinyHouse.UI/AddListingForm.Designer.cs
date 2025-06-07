namespace TinyHouse.UI
{
    partial class AddListingForm
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
            txtTitle = new TextBox();
            txtDescription = new RichTextBox();
            nudPrice = new NumericUpDown();
            txtLocation = new TextBox();
            btnAddListing = new Button();
            btnBack = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPhotoUrls = new TextBox();
            label5 = new Label();
            dtpAvailableFrom = new DateTimePicker();
            dtpAvailableTo = new DateTimePicker();
            lblFromText = new Label();
            lblToText = new Label();
            chbIsActive = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(182, 45);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(182, 78);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(250, 67);
            txtDescription.TabIndex = 1;
            txtDescription.Text = "";
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(182, 149);
            nudPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(165, 27);
            nudPrice.TabIndex = 2;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(182, 177);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(250, 27);
            txtLocation.TabIndex = 3;
            // 
            // btnAddListing
            // 
            btnAddListing.BackColor = Color.LemonChiffon;
            btnAddListing.Location = new Point(374, 438);
            btnAddListing.Name = "btnAddListing";
            btnAddListing.Size = new Size(94, 29);
            btnAddListing.TabIndex = 4;
            btnAddListing.Text = "İlan ekle";
            btnAddListing.UseVisualStyleBackColor = false;
            btnAddListing.Click += btnAddListing_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LemonChiffon;
            btnBack.Location = new Point(12, 438);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 5;
            btnBack.Text = "Geri";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 6;
            label1.Text = "İlan başlığı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 7;
            label2.Text = "İlan açıklaması :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Location = new Point(12, 151);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 8;
            label3.Text = "Gecelik fiyat :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Location = new Point(12, 184);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 9;
            label4.Text = "Konum :";
            // 
            // txtPhotoUrls
            // 
            txtPhotoUrls.Location = new Point(210, 231);
            txtPhotoUrls.Multiline = true;
            txtPhotoUrls.Name = "txtPhotoUrls";
            txtPhotoUrls.Size = new Size(222, 34);
            txtPhotoUrls.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Location = new Point(12, 234);
            label5.Name = "label5";
            label5.Size = new Size(176, 20);
            label5.TabIndex = 11;
            label5.Text = "Fotoğraf URL’leri (JSON) :";
            // 
            // dtpAvailableFrom
            // 
            dtpAvailableFrom.Location = new Point(182, 294);
            dtpAvailableFrom.Name = "dtpAvailableFrom";
            dtpAvailableFrom.Size = new Size(250, 27);
            dtpAvailableFrom.TabIndex = 12;
            // 
            // dtpAvailableTo
            // 
            dtpAvailableTo.Location = new Point(182, 327);
            dtpAvailableTo.Name = "dtpAvailableTo";
            dtpAvailableTo.Size = new Size(250, 27);
            dtpAvailableTo.TabIndex = 13;
            // 
            // lblFromText
            // 
            lblFromText.AutoSize = true;
            lblFromText.BackColor = SystemColors.ActiveCaption;
            lblFromText.Location = new Point(12, 299);
            lblFromText.Name = "lblFromText";
            lblFromText.Size = new Size(144, 20);
            lblFromText.TabIndex = 14;
            lblFromText.Text = "Geçerlilik başlangıcı:";
            // 
            // lblToText
            // 
            lblToText.AutoSize = true;
            lblToText.BackColor = SystemColors.ActiveCaption;
            lblToText.Location = new Point(12, 334);
            lblToText.Name = "lblToText";
            lblToText.Size = new Size(106, 20);
            lblToText.TabIndex = 15;
            lblToText.Text = "Geçerlilik bitişi";
            // 
            // chbIsActive
            // 
            chbIsActive.AutoSize = true;
            chbIsActive.BackColor = SystemColors.ActiveCaption;
            chbIsActive.Location = new Point(12, 369);
            chbIsActive.Name = "chbIsActive";
            chbIsActive.Size = new Size(90, 24);
            chbIsActive.TabIndex = 16;
            chbIsActive.Text = "Aktif mi?";
            chbIsActive.UseVisualStyleBackColor = false;
            // 
            // AddListingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(480, 479);
            Controls.Add(chbIsActive);
            Controls.Add(lblToText);
            Controls.Add(lblFromText);
            Controls.Add(dtpAvailableTo);
            Controls.Add(dtpAvailableFrom);
            Controls.Add(label5);
            Controls.Add(txtPhotoUrls);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnAddListing);
            Controls.Add(txtLocation);
            Controls.Add(nudPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Name = "AddListingForm";
            Text = "AddListingForm";
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private RichTextBox txtDescription;
        private NumericUpDown nudPrice;
        private TextBox txtLocation;
        private Button btnAddListing;
        private Button btnBack;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPhotoUrls;
        private Label label5;
        private DateTimePicker dtpAvailableFrom;
        private DateTimePicker dtpAvailableTo;
        private Label lblFromText;
        private Label lblToText;
        private CheckBox chbIsActive;
    }
}