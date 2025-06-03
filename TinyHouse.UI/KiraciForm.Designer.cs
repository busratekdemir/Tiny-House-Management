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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHouses).BeginInit();
            SuspendLayout();
            // 
            // dgvHouses
            // 
            dgvHouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHouses.Location = new Point(12, 65);
            dgvHouses.Name = "dgvHouses";
            dgvHouses.ReadOnly = true;
            dgvHouses.RowHeadersWidth = 51;
            dgvHouses.Size = new Size(801, 352);
            dgvHouses.TabIndex = 0;
            dgvHouses.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.LemonChiffon;
            button1.Location = new Point(31, 423);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LemonChiffon;
            button2.Location = new Point(341, 423);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LemonChiffon;
            button3.Location = new Point(719, 423);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
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
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
    }
}