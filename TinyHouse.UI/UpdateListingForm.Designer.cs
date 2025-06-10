namespace TinyHouse.UI
{
    partial class UpdateListingForm
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
            label3 = new Label();
            label4 = new Label();
            txtTitle = new TextBox();
            txtDescription = new RichTextBox();
            btnCancel = new Button();
            btnUpdate = new Button();
            nudPrice = new NumericUpDown();
            txtLocation = new TextBox();
            label5 = new Label();
            lblphotourl = new Label();
            label7 = new Label();
            txtPhotoUrls_ = new TextBox();
            dtpAvailableFrom = new DateTimePicker();
            dtpAvailableTo = new DateTimePicker();
            chbIsActive = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Thistle;
            label1.Location = new Point(21, 27);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 0;
            label1.Text = "İlan başlığı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Thistle;
            label2.Location = new Point(21, 66);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "İlan açıklaması :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Thistle;
            label3.Location = new Point(21, 152);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Gecelik fiyat :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Thistle;
            label4.Location = new Point(21, 183);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 3;
            label4.Text = "Konum :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(142, 24);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(243, 27);
            txtTitle.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(142, 63);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(243, 77);
            txtDescription.TabIndex = 5;
            txtDescription.Text = "";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LemonChiffon;
            btnCancel.Location = new Point(12, 459);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LemonChiffon;
            btnUpdate.Location = new Point(365, 459);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(142, 150);
            nudPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(150, 27);
            nudPrice.TabIndex = 8;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(142, 183);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(243, 27);
            txtLocation.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Thistle;
            label5.Location = new Point(21, 319);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 10;
            label5.Text = "Geçerlilik bitişi :";
            // 
            // lblphotourl
            // 
            lblphotourl.AutoSize = true;
            lblphotourl.BackColor = Color.Thistle;
            lblphotourl.Location = new Point(21, 241);
            lblphotourl.Name = "lblphotourl";
            lblphotourl.Size = new Size(172, 20);
            lblphotourl.TabIndex = 11;
            lblphotourl.Text = "Fotoğraf URL'leri(JSON) :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Thistle;
            label7.Location = new Point(21, 280);
            label7.Name = "label7";
            label7.Size = new Size(148, 20);
            label7.TabIndex = 12;
            label7.Text = "Geçerlilik başlangıcı :";
            // 
            // txtPhotoUrls_
            // 
            txtPhotoUrls_.Location = new Point(209, 238);
            txtPhotoUrls_.Multiline = true;
            txtPhotoUrls_.Name = "txtPhotoUrls_";
            txtPhotoUrls_.Size = new Size(250, 27);
            txtPhotoUrls_.TabIndex = 13;
            // 
            // dtpAvailableFrom
            // 
            dtpAvailableFrom.Location = new Point(209, 280);
            dtpAvailableFrom.Name = "dtpAvailableFrom";
            dtpAvailableFrom.Size = new Size(250, 27);
            dtpAvailableFrom.TabIndex = 14;
            // 
            // dtpAvailableTo
            // 
            dtpAvailableTo.Location = new Point(209, 314);
            dtpAvailableTo.Name = "dtpAvailableTo";
            dtpAvailableTo.Size = new Size(250, 27);
            dtpAvailableTo.TabIndex = 15;
            // 
            // chbIsActive
            // 
            chbIsActive.AutoSize = true;
            chbIsActive.BackColor = Color.Thistle;
            chbIsActive.Location = new Point(21, 381);
            chbIsActive.Name = "chbIsActive";
            chbIsActive.Size = new Size(90, 24);
            chbIsActive.TabIndex = 16;
            chbIsActive.Text = "Aktif mi?";
            chbIsActive.UseVisualStyleBackColor = false;
            // 
            // UpdateListingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(471, 500);
            Controls.Add(chbIsActive);
            Controls.Add(dtpAvailableTo);
            Controls.Add(dtpAvailableFrom);
            Controls.Add(txtPhotoUrls_);
            Controls.Add(label7);
            Controls.Add(lblphotourl);
            Controls.Add(label5);
            Controls.Add(txtLocation);
            Controls.Add(nudPrice);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateListingForm";
            Text = "UpdateListingForm";
            Load += UpdateListingForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTitle;
        private RichTextBox txtDescription;
        private Button btnCancel;
        private Button btnUpdate;
        private NumericUpDown nudPrice;
        private TextBox txtLocation;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblphotourl;
        private TextBox txtPhotoUrls_;
        private DateTimePicker dtpAvailableFrom;
        private DateTimePicker dtpAvailableTo;
        private CheckBox chbIsActive;
    }
}