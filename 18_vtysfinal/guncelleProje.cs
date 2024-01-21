using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_vtysfinal
{
    public partial class guncelleProje : Form
    {
        StoredProcedure sp = new StoredProcedure();
        private int projeId;
        private string oldAd;
        private DateTime oldTarih;
        private DateTime bitisTarihi;

        public guncelleProje(int projeId)
        {
            InitializeComponent();
            this.projeId = projeId;
        }

        private void guncelleProje_Load(object sender, EventArgs e)
        {
            getOldData();
            textBoxAd.Text = oldAd;
            dateTimePicker.Value = oldTarih;
            sp.projeListeleTek(dataGridGuncelleProje, projeId);
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            string yeniAd = string.IsNullOrEmpty(textBoxAd.Text) ? null : textBoxAd.Text;
            yeniAd = (yeniAd != oldAd) ? yeniAd : null;
            if (yeniAd != null && yeniAd.Length > 20)
            {
                MessageBox.Show("Proje adı maksimum 20 karakter içerebilir.");
                return;
            }
            
            DateTime? yeniTarih = dateTimePicker.Value;
            yeniTarih = (yeniTarih != oldTarih) ? yeniTarih : default(DateTime?);
            if (yeniTarih != null)
            {
                if (yeniTarih > bitisTarihi)
                {
                    MessageBox.Show("Proje başlangıç tarihi bitişinden sonra olamaz.");
                    return;
                }
                else if (yeniTarih > minGorevDate())
                {
                    MessageBox.Show("Proje başlangıç tarihi görevlerinden sonra olamaz.");
                    return;
                }
            }

            sp.güncelleProje(projeId, yeniAd, yeniTarih);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void getOldData()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT projeAd, baslangicTarihi, bitisTarihi FROM proje WHERE projeId = @projeId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oldAd = reader.GetString("projeAd");
                        oldTarih = reader.GetDateTime("baslangicTarihi");
                        bitisTarihi = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }

        private DateTime minGorevDate()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MIN(baslangicTarihi) FROM görev WHERE projeId = @projeId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDateTime(0);
                    }
                }
                return DateTime.Today;
            }
        }
    }
}