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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _18_vtysfinal
{

    public partial class guncelleGorev : Form
    {
        StoredProcedure sp = new StoredProcedure();
        private int projeId, calisanId, gorevId;

        private string oldAd;
        private DateTime oldTarih;
        private DateTime bitisTarihi;

        public guncelleGorev(int projeId, int calisanId, int gorevId)
        {
            InitializeComponent();
            this.projeId = projeId;
            this.calisanId = calisanId;
            this.gorevId = gorevId;
        }

        private void guncelleGorev_Load(object sender, EventArgs e)
        {
            getOldData();
            textBoxAd.Text = oldAd;
            dateTimePicker.Value = oldTarih;
            sp.görevListeleTek(dataGridGuncelleGorev, projeId, calisanId, gorevId);
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            string yeniAd = string.IsNullOrEmpty(textBoxAd.Text) ? null : textBoxAd.Text;
            yeniAd = (yeniAd != oldAd) ? yeniAd : null;
            if (yeniAd != null && yeniAd.Length > 40)
            {
                MessageBox.Show("Görev adı maksimum 40 karakter içerebilir.");
                return;
            }

            DateTime? yeniTarih = dateTimePicker.Value;
            yeniTarih = (yeniTarih != oldTarih) ? yeniTarih : default(DateTime?);
            if (yeniTarih != null)
            {
                if (yeniTarih > bitisTarihi)
                {
                    MessageBox.Show("Görev başlangıç tarihi bitişinden sonra olamaz.");
                    return;
                }
                else if (yeniTarih < getProjeDate())
                {
                    MessageBox.Show("Görev başlangıç tarihi, projeninkinden önce olamaz");
                    return;
                }
                
            }

            sp.güncelleGörev(projeId, calisanId, gorevId, yeniAd, yeniTarih);
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
                MySqlCommand cmd = new MySqlCommand("SELECT gorevAd, baslangicTarihi, bitisTarihi, gorevDurum FROM görev WHERE projeId = @projeId AND calisanId = @calisanId AND gorevId = @gorevId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);
                cmd.Parameters.AddWithValue("@calisanId", calisanId);
                cmd.Parameters.AddWithValue("@gorevId", gorevId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oldAd = reader.GetString("gorevAd");
                        oldTarih = reader.GetDateTime("baslangicTarihi");
                        bitisTarihi = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }

        private DateTime getProjeDate()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT baslangicTarihi FROM proje WHERE projeId = @projeId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDateTime(projeId);
                    }
                }
                return DateTime.Today;
            }
        }
    }
}
