namespace _18_vtysfinal
{
    partial class erteleProje
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
            this.buttonErtele = new System.Windows.Forms.Button();
            this.buttonİptal = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yeni Bitiş Tarihi";
            // 
            // buttonErtele
            // 
            this.buttonErtele.Location = new System.Drawing.Point(38, 4);
            this.buttonErtele.Name = "buttonErtele";
            this.buttonErtele.Size = new System.Drawing.Size(75, 23);
            this.buttonErtele.TabIndex = 4;
            this.buttonErtele.Text = "Ertele";
            this.buttonErtele.UseVisualStyleBackColor = true;
            this.buttonErtele.Click += new System.EventHandler(this.buttonErtele_Click);
            // 
            // buttonİptal
            // 
            this.buttonİptal.Location = new System.Drawing.Point(144, 4);
            this.buttonİptal.Name = "buttonİptal";
            this.buttonİptal.Size = new System.Drawing.Size(75, 23);
            this.buttonİptal.TabIndex = 5;
            this.buttonİptal.Text = "İptal";
            this.buttonİptal.UseVisualStyleBackColor = true;
            this.buttonİptal.Click += new System.EventHandler(this.buttonİptal_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(89, 10);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(145, 20);
            this.dateTimePicker.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 39);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonİptal);
            this.panel2.Controls.Add(this.buttonErtele);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 37);
            this.panel2.TabIndex = 8;
            // 
            // erteleProje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 74);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "erteleProje";
            this.Text = "erteleProje";
            this.Load += new System.EventHandler(this.erteleProje_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonErtele;
        private System.Windows.Forms.Button buttonİptal;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}