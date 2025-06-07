namespace TinyHouse.UI
{
    partial class AdminForm
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
            label5 = new Label();
            btnUsers = new Button();
            btnHouses = new Button();
            btnRes = new Button();
            btnLogout = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(82, 24);
            label1.Name = "label1";
            label1.Size = new Size(283, 28);
            label1.TabIndex = 0;
            label1.Text = "Admin Paneline Hoşgeldiniz.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(40, 77);
            label2.Name = "label2";
            label2.Size = new Size(118, 23);
            label2.TabIndex = 1;
            label2.Text = "Sistem özeti :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGreen;
            label3.Location = new Point(61, 115);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 2;
            label3.Text = "Kullanıcı Sayısı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightGreen;
            label4.Location = new Point(61, 158);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 3;
            label4.Text = "İlan Sayısı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightGreen;
            label5.Location = new Point(61, 202);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 4;
            label5.Text = "Rezervasyon Sayısı :";
            // 
            // btnUsers
            // 
            btnUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUsers.BackColor = Color.LemonChiffon;
            btnUsers.Location = new Point(128, 274);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(173, 29);
            btnUsers.TabIndex = 5;
            btnUsers.Text = "Kullanıcıları Görüntüle";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnHouses
            // 
            btnHouses.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHouses.BackColor = Color.LemonChiffon;
            btnHouses.Location = new Point(128, 326);
            btnHouses.Name = "btnHouses";
            btnHouses.Size = new Size(173, 29);
            btnHouses.TabIndex = 6;
            btnHouses.Text = "İlanları Yönet";
            btnHouses.UseVisualStyleBackColor = false;
            btnHouses.Click += btnHouses_Click;
            // 
            // btnRes
            // 
            btnRes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRes.BackColor = Color.LemonChiffon;
            btnRes.Location = new Point(128, 375);
            btnRes.Name = "btnRes";
            btnRes.Size = new Size(173, 29);
            btnRes.TabIndex = 7;
            btnRes.Text = "Rezervasyonları Yönet";
            btnRes.UseVisualStyleBackColor = false;
            btnRes.Click += btnRes_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(164, 423);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Çıkış Yap";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(177, 115);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(151, 158);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(206, 202);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 11;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            ClientSize = new Size(582, 508);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnLogout);
            Controls.Add(btnRes);
            Controls.Add(btnHouses);
            Controls.Add(btnUsers);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnUsers;
        private Button btnHouses;
        private Button btnRes;
        private Button btnLogout;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}