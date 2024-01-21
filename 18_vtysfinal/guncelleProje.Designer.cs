namespace _18_vtysfinal
{
    partial class guncelleProje
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.guncelle = new System.Windows.Forms.Button();
            this.iptal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridGuncelleProje = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuncelleProje)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yeni Proje Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yeni Proje Başlangıç Tarihi";
            // 
            // textBoxAd
            // 
            this.textBoxAd.Location = new System.Drawing.Point(145, 7);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(153, 20);
            this.textBoxAd.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(145, 30);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // guncelle
            // 
            this.guncelle.Location = new System.Drawing.Point(64, 12);
            this.guncelle.Name = "guncelle";
            this.guncelle.Size = new System.Drawing.Size(75, 23);
            this.guncelle.TabIndex = 6;
            this.guncelle.Text = "Güncelle";
            this.guncelle.UseVisualStyleBackColor = true;
            this.guncelle.Click += new System.EventHandler(this.guncelle_Click);
            // 
            // iptal
            // 
            this.iptal.Location = new System.Drawing.Point(168, 12);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(75, 23);
            this.iptal.TabIndex = 7;
            this.iptal.Text = "İptal Et";
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iptal);
            this.panel1.Controls.Add(this.guncelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 47);
            this.panel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker);
            this.panel3.Controls.Add(this.textBoxAd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 64);
            this.panel3.TabIndex = 0;
            // 
            // dataGridGuncelleProje
            // 
            this.dataGridGuncelleProje.AllowUserToAddRows = false;
            this.dataGridGuncelleProje.AllowUserToDeleteRows = false;
            this.dataGridGuncelleProje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGuncelleProje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGuncelleProje.Location = new System.Drawing.Point(0, 0);
            this.dataGridGuncelleProje.Name = "dataGridGuncelleProje";
            this.dataGridGuncelleProje.ReadOnly = true;
            this.dataGridGuncelleProje.Size = new System.Drawing.Size(313, 74);
            this.dataGridGuncelleProje.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridGuncelleProje);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 74);
            this.panel2.TabIndex = 10;
            // 
            // guncelleProje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 185);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "guncelleProje";
            this.Text = "guncelleProje";
            this.Load += new System.EventHandler(this.guncelleProje_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuncelleProje)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button guncelle;
        private System.Windows.Forms.Button iptal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridGuncelleProje;
        private System.Windows.Forms.Panel panel2;
    }
}