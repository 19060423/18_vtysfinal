namespace _18_vtysfinal
{
    partial class guncelleGorev
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
            this.buttonGuncelle = new System.Windows.Forms.Button();
            this.buttonİptal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridGuncelleGorev = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuncelleGorev)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yeni Görev Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yeni Başlangıç Tarihi";
            // 
            // textBoxAd
            // 
            this.textBoxAd.Location = new System.Drawing.Point(117, 10);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(141, 20);
            this.textBoxAd.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(117, 36);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // buttonGuncelle
            // 
            this.buttonGuncelle.Location = new System.Drawing.Point(37, 15);
            this.buttonGuncelle.Name = "buttonGuncelle";
            this.buttonGuncelle.Size = new System.Drawing.Size(75, 23);
            this.buttonGuncelle.TabIndex = 6;
            this.buttonGuncelle.Text = "Güncelle";
            this.buttonGuncelle.UseVisualStyleBackColor = true;
            this.buttonGuncelle.Click += new System.EventHandler(this.buttonGuncelle_Click);
            // 
            // buttonİptal
            // 
            this.buttonİptal.Location = new System.Drawing.Point(166, 15);
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
            this.panel1.Controls.Add(this.buttonGuncelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 54);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker);
            this.panel2.Controls.Add(this.textBoxAd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 70);
            this.panel2.TabIndex = 9;
            // 
            // dataGridGuncelleGorev
            // 
            this.dataGridGuncelleGorev.AllowUserToAddRows = false;
            this.dataGridGuncelleGorev.AllowUserToDeleteRows = false;
            this.dataGridGuncelleGorev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGuncelleGorev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGuncelleGorev.Location = new System.Drawing.Point(0, 0);
            this.dataGridGuncelleGorev.Name = "dataGridGuncelleGorev";
            this.dataGridGuncelleGorev.ReadOnly = true;
            this.dataGridGuncelleGorev.Size = new System.Drawing.Size(280, 84);
            this.dataGridGuncelleGorev.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridGuncelleGorev);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 84);
            this.panel3.TabIndex = 11;
            // 
            // guncelleGorev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 208);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "guncelleGorev";
            this.Text = "guncelleGorev";
            this.Load += new System.EventHandler(this.guncelleGorev_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuncelleGorev)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonGuncelle;
        private System.Windows.Forms.Button buttonİptal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridGuncelleGorev;
        private System.Windows.Forms.Panel panel3;
    }
}