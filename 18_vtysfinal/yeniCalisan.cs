using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_vtysfinal
{
    public partial class yeniCalisan : Form
    {
        StoredProcedure sp = new StoredProcedure();
        public yeniCalisan()
        {
            InitializeComponent();
        }

        private void buttonYeni_Click(object sender, EventArgs e)
        {
            string ad = textBoxAd.Text;
            string soyad = textBoxSoyad.Text;
            DateTime tarih = dateTimePicker.Value;

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Lütfen ad ve soyad yazınız");
                return;
            }
            else if (ad.Length > 20 || soyad.Length > 20)
            {
                MessageBox.Show("Ad ve soyad maksimum 20 karakter içerebilir");
                return;
            }

            if(tarih > DateTime.Today)
            {
                MessageBox.Show("Çalışanın işe alınma tarihi gelecekte olamaz.");
            }

            sp.yeniÇalışan(ad, soyad, tarih);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
