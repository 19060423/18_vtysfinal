using MySql.Data.MySqlClient;
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
    public partial class guncelleCalisan : Form
    {
        StoredProcedure sp = new StoredProcedure();
        private int calisanId;
        private string oldAd;
        private string oldSoyad;
        private DateTime oldTarih;

        public guncelleCalisan(int calisanId)
        {
            InitializeComponent();
            this.calisanId = calisanId;
        }

        private void guncelleCalisan_Load(object sender, EventArgs e)
        {
            getOldData();
            dateTimePicker.Value = oldTarih;
            textBoxAd.Text = oldAd;
            textBoxSoyad.Text = oldSoyad;
            sp.çalışanListeleTek(dataGridGuncelleCalisan, calisanId);
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            string yeniAd = string.IsNullOrEmpty(textBoxAd.Text) ? null : textBoxAd.Text;
            string yeniSoyad = string.IsNullOrEmpty(textBoxSoyad.Text) ? null : textBoxSoyad.Text;
            yeniAd = (yeniAd != oldAd) ? yeniAd : null;
            yeniSoyad = (yeniSoyad != oldSoyad) ? yeniSoyad : null;
            
            if ((yeniAd != null && yeniAd.Length > 20) || ( yeniSoyad != null && yeniSoyad.Length > 20))
            {
                MessageBox.Show("Ad ve soyad maksimum 20 karakter içerebilir");
                return;
            }

            DateTime? yeniTarih = dateTimePicker.Value;
            yeniTarih = (yeniTarih != oldTarih) ? yeniTarih : default(DateTime?);

            if (yeniTarih != null && yeniTarih > getMinGorevDate())
            {
                MessageBox.Show("Çalışan, çalıştığı bir görevin başlamasında sonra işe alınamaz");
                return;
            }

            sp.güncelleÇalışan(calisanId, yeniAd, yeniSoyad, yeniTarih);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void getOldData()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ad, soyad, iseAlinmaTarihi FROM çalışan WHERE calisanId = @calisanId", cn);
                cmd.Parameters.AddWithValue("@calisanId", calisanId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oldAd = reader.GetString("ad");
                        oldSoyad = reader.GetString("soyad");
                        oldTarih = reader.GetDateTime("iseAlinmaTarihi");
                    }
                }
            }
        }

        private DateTime getMinGorevDate()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MIN(baslangicTarihi) FROM görev WHERE calisanId = @calisanId", cn);
                cmd.Parameters.AddWithValue("@calisanId", calisanId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDateTime(0);
                    }
                }
            }
            return DateTime.Today;
        }
    }
}
