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
    public partial class yeniProje : Form
    {
        StoredProcedure sp = new StoredProcedure();

        public yeniProje()
        {
            InitializeComponent();
        }

        private void buttonYeni_Click(object sender, EventArgs e)
        {
            string ad = textBoxAd.Text;
            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Proje için lütfen bir isim giriniz");
                return;
            }
            else if(ad.Length > 20)
            {
                MessageBox.Show("Proje adı maksimum 20 karakter içerebilir.");
                return;
            }

            DateTime baslangicTarihi = dateTimePickerBaslangic.Value;
            DateTime bitisTarihi = dateTimePickerBitis.Value;

            if (baslangicTarihi > bitisTarihi)
            {
                MessageBox.Show("Başlangıç tarihi, bitiş tarihinden sonra olamaz.");
                return;
            }

            sp.yeniProje(ad, baslangicTarihi, bitisTarihi);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
