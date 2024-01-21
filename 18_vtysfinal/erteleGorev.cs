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
    public partial class erteleGorev : Form
    {
        StoredProcedure sp = new StoredProcedure();
        private int projeId, calisanId, gorevId;
        DateTime oldTarih, projeTarih;

        public erteleGorev(int projeId, int calisanId, int gorevId)
        {
            InitializeComponent();
            this.projeId = projeId;
            this.calisanId = calisanId;
            this.gorevId = gorevId;
        }

        private void erteleGorev_Load(object sender, EventArgs e)
        {
            getOldData();
            dateTimePicker.Value = oldTarih;
        }

        private void buttonErtele_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dateTimePicker.Value;
            if (yeniTarih <= oldTarih)
            {
                MessageBox.Show("Ertelenilecek tarih, eski bitiş tarihinden sonra olmnadır");
                return;
            }
            
            getProjeDate();
            if (yeniTarih > projeTarih)
            {
                MessageBox.Show("Ertenilen tarih, proje bitiş tarihinden daha sonradır. Görev ve proje tarihi aynı tarihe erteleniyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sp.projeErtele(projeId, yeniTarih);
            }

            sp.görevErtele(projeId, calisanId, gorevId, yeniTarih); 
            int daysDifference = (yeniTarih - oldTarih).Days;
            MessageBox.Show($"Görev {daysDifference} gün ertelendi");
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
                MySqlCommand cmd = new MySqlCommand("SELECT baslangicTarihi, bitisTarihi FROM görev WHERE projeId = @projeId AND calisanId = @calisanId AND gorevId = @gorevId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);
                cmd.Parameters.AddWithValue("@calisanId", calisanId);
                cmd.Parameters.AddWithValue("@gorevId", gorevId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oldTarih = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }

        private void getProjeDate()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT bitisTarihi FROM proje WHERE projeId = @projeId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        projeTarih = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }
    }
}
