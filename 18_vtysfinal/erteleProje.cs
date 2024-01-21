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
    public partial class erteleProje : Form
    {
        StoredProcedure sp = new StoredProcedure();
        private int projeId;
        DateTime oldTarih;
        public erteleProje(int projeId)
        {
            InitializeComponent();
            this.projeId = projeId;
        }

        private void erteleProje_Load(object sender, EventArgs e)
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

            sp.projeErtele(projeId, yeniTarih);
            int daysDifference = (yeniTarih - oldTarih).Days;
            MessageBox.Show($"Proje {daysDifference} gün ertelendi");
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
                MySqlCommand cmd = new MySqlCommand("SELECT bitisTarihi FROM proje WHERE projeId = @projeId", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oldTarih = reader.GetDateTime("bitisTarihi");
                    }
                }
            }
        }

    }
}
