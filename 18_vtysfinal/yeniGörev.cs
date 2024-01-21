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
    public partial class yeniGörev : Form
    {
        StoredProcedure sp = new StoredProcedure();
        int projeId, calisanId;
        
        private DateTime projeBaslangic;
        private DateTime projeBitis;

        public yeniGörev(int projeId, int calisanId)
        {
            InitializeComponent();
            this.projeId = projeId;
            this.calisanId = calisanId;
        }
        private void yeniGörev_Load(object sender, EventArgs e)
        {
            if (projeId != -1)
            {
                textBoxPID.Text = projeId.ToString();
                getProjeDates(projeId);
                dateTimePickerBaslangic.Value = projeBaslangic;
                dateTimePickerBitis.Value = projeBitis;
            }
            if (calisanId != -1)
            {
                textBoxCID.Text = calisanId.ToString();
                dateTimePickerBaslangic.Value = getHireDate();
            }
        }

        private void buttonYeni_Click(object sender, EventArgs e)
        {
            int intProjeId = 0;
            int intCalisanId = 0;

            try
            {
                intProjeId = int.Parse(textBoxPID.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine("Lütfen sayı giriniz.");
            }

            try
            {
                intCalisanId = int.Parse(textBoxCID.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine("Lütfen sayı giriniz.");
            }

            string ad = textBoxAd.Text;
            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Proje için lütfen bir isim giriniz");
                return;
            }

            DateTime baslangicTarihi = dateTimePickerBaslangic.Value;
            DateTime bitisTarihi = dateTimePickerBitis.Value;

            if (projeBaslangic == null || projeBitis == null)
            {
                getProjeDates(projeId);
            }

            if (baslangicTarihi > bitisTarihi)
            {
                MessageBox.Show("Başlangıç tarihi, bitiş tarihinden sonra olamaz.");
                return;
            }
            else if (baslangicTarihi < projeBaslangic || bitisTarihi > projeBitis)
            {
                MessageBox.Show("Görevlerin başlangıç ve bitiş tarihleri, projenin tarihleri arasında olmalıdır.");
                return;
            }
            
            if (intProjeId > 0 && intCalisanId > 0)
            {
                sp.yeniGörev(intProjeId, intCalisanId, ad, baslangicTarihi, bitisTarihi);
            }
            else
            {
                MessageBox.Show("Error");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void getProjeDates(int projeId)
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();

                string cmd = "SELECT baslangicTarihi, bitisTarihi FROM proje WHERE projeId = @projeId";
                MySqlCommand tarihler = new MySqlCommand(cmd, cn);
                tarihler.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = tarihler.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        projeBaslangic = reader.GetDateTime("baslangicTarihi");
                        projeBitis = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }

        private DateTime getHireDate()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT iseAlinmaTarihi FROM çalışan WHERE calisanId = @calisanId", cn);
                cmd.Parameters.AddWithValue("@calisanId", calisanId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDateTime("iseAlinmaTarihi");
                    }
                }
            }
            return DateTime.Today;
        }
    }
}
