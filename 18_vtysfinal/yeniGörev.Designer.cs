namespace _18_vtysfinal
{
    partial class yeniGörev
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPID = new System.Windows.Forms.TextBox();
            this.textBoxCID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.buttonYeni = new System.Windows.Forms.Button();
            this.buttonİptal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Kodu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Çalışan No";
            // 
            // textBoxPID
            // 
            this.textBoxPID.Location = new System.Drawing.Point(69, 9);
            this.textBoxPID.Name = "textBoxPID";
            this.textBoxPID.Size = new System.Drawing.Size(34, 20);
            this.textBoxPID.TabIndex = 2;
            // 
            // textBoxCID
            // 
            this.textBoxCID.Location = new System.Drawing.Point(71, 47);
            this.textBoxCID.Name = "textBoxCID";
            this.textBoxCID.Size = new System.Drawing.Size(32, 20);
            this.textBoxCID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Görev Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Başlangıç Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bitiş Tarihi";
            // 
            // textBoxAd
            // 
            this.textBoxAd.Location = new System.Drawing.Point(91, 3);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(145, 20);
            this.textBoxAd.TabIndex = 7;
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(90, 38);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerBaslangic.TabIndex = 8;
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Location = new System.Drawing.Point(90, 76);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerBitis.TabIndex = 9;
            // 
            // buttonYeni
            // 
            this.buttonYeni.Location = new System.Drawing.Point(91, 10);
            this.buttonYeni.Name = "buttonYeni";
            this.buttonYeni.Size = new System.Drawing.Size(75, 23);
            this.buttonYeni.TabIndex = 10;
            this.buttonYeni.Text = "Oluştur";
            this.buttonYeni.UseVisualStyleBackColor = true;
            this.buttonYeni.Click += new System.EventHandler(this.buttonYeni_Click);
            // 
            // buttonİptal
            // 
            this.buttonİptal.Location = new System.Drawing.Point(181, 10);
            this.buttonİptal.Name = "buttonİptal";
            this.buttonİptal.Size = new System.Drawing.Size(75, 23);
            this.buttonİptal.TabIndex = 11;
            this.buttonİptal.Text = "İptal";
            this.buttonİptal.UseVisualStyleBackColor = true;
            this.buttonİptal.Click += new System.EventHandler(this.buttonİptal_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerBitis);
            this.panel1.Controls.Add(this.dateTimePickerBaslangic);
            this.panel1.Controls.Add(this.textBoxAd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(113, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 142);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxCID);
            this.panel2.Controls.Add(this.textBoxPID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 142);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.buttonİptal);
            this.panel3.Controls.Add(this.buttonYeni);
            this.panel3.Location = new System.Drawing.Point(0, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 40);
            this.panel3.TabIndex = 14;
            // 
            // yeniGörev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 142);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "yeniGörev";
            this.Text = "\"";
            this.Load += new System.EventHandler(this.yeniGörev_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPID;
        private System.Windows.Forms.TextBox textBoxCID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.Button buttonYeni;
        private System.Windows.Forms.Button buttonİptal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}