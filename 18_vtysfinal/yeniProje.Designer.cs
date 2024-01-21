namespace _18_vtysfinal
{
    partial class yeniProje
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.buttonYeni = new System.Windows.Forms.Button();
            this.buttonİptal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // textBoxAd
            // 
            this.textBoxAd.Location = new System.Drawing.Point(105, 9);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(145, 20);
            this.textBoxAd.TabIndex = 3;
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(105, 35);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(145, 20);
            this.dateTimePickerBaslangic.TabIndex = 4;
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Location = new System.Drawing.Point(105, 61);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(145, 20);
            this.dateTimePickerBitis.TabIndex = 5;
            // 
            // buttonYeni
            // 
            this.buttonYeni.Location = new System.Drawing.Point(47, 19);
            this.buttonYeni.Name = "buttonYeni";
            this.buttonYeni.Size = new System.Drawing.Size(75, 23);
            this.buttonYeni.TabIndex = 6;
            this.buttonYeni.Text = "Oluştur";
            this.buttonYeni.UseVisualStyleBackColor = true;
            this.buttonYeni.Click += new System.EventHandler(this.buttonYeni_Click);
            // 
            // buttonİptal
            // 
            this.buttonİptal.Location = new System.Drawing.Point(143, 19);
            this.buttonİptal.Name = "buttonİptal";
            this.buttonİptal.Size = new System.Drawing.Size(75, 23);
            this.buttonİptal.TabIndex = 7;
            this.buttonİptal.Text = "İptal";
            this.buttonİptal.UseVisualStyleBackColor = true;
            this.buttonİptal.Click += new System.EventHandler(this.buttonİptal_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonİptal);
            this.panel1.Controls.Add(this.buttonYeni);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 51);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerBitis);
            this.panel2.Controls.Add(this.dateTimePickerBaslangic);
            this.panel2.Controls.Add(this.textBoxAd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 90);
            this.panel2.TabIndex = 9;
            // 
            // yeniProje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 127);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "yeniProje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "yeniProje";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.Button buttonYeni;
        private System.Windows.Forms.Button buttonİptal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}