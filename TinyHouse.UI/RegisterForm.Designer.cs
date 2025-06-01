namespace TinyHouse.UI
{
    partial class RegisterForm
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
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightCoral;
            label1.Location = new Point(48, 69);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad  Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightCoral;
            label2.Location = new Point(48, 135);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "E-mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightCoral;
            label3.Location = new Point(48, 193);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "Şifre";
            label3.Click += label3_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(212, 62);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(206, 27);
            txtFullName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(212, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(212, 186);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(206, 27);
            txtPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightCoral;
            label4.Location = new Point(48, 250);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 6;
            label4.Text = "Rol";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(212, 242);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(151, 28);
            cmbRole.TabIndex = 7;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.LightCoral;
            btnRegister.Location = new Point(324, 311);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 47);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 383);
            Controls.Add(btnRegister);
            Controls.Add(cmbRole);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label label4;
        private ComboBox cmbRole;
        private Button btnRegister;
    }
}