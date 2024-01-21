using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_vtysfinal
{
    internal class StoredProcedure
    {
        private MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler");
        private MySqlCommand cmd = new MySqlCommand();
        /* Listele Start */
        public void projeListele(DataGridView dataGridView)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "projeListele";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void çalışanListele(DataGridView dataGridView)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "çalışanListele";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void görevListele(DataGridView dataGridView)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "görevListele";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }
        /* Listele End */

        /* Specific Info Start */
        public void projeInfo(DataGridView dataGridView, int projeId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "projeInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", projeId);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void çalışanInfo(DataGridView dataGridView, int id)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "çalışanInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void projeListeleTek(DataGridView dataGridView, int id)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "projeListeleTek";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void çalışanListeleTek(DataGridView dataGridView, int id)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "çalışanListeleTek";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }

        public void görevListeleTek(DataGridView dataGridView, int projeId, int calisanId, int gorevId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "görevListeleTek";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@gprojeId", projeId);
            cmd.Parameters.AddWithValue("@gcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@ggorevId", gorevId);


            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }
        
        public void çalışanBitGörKıyas(DataGridView dataGridView, int calisanId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "çalışanBitGörKıyas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", calisanId);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cn.Close();
        }
        
        /* Specific Info End */

        /* Insert, Update, Delete Start */
        /* proje */
        public void yeniProje(string ad, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "yeniProje";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@newprojeAd", ad);
            cmd.Parameters.AddWithValue("@newbaslangicTarihi", baslangicTarihi);
            cmd.Parameters.AddWithValue("@newbitisTarihi", bitisTarihi);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void güncelleProje(int projeId, string ad, DateTime? baslangicTarihi)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "güncelleProje";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@gprojeId", projeId);
            cmd.Parameters.AddWithValue("@newprojeAd", ad);

            if (baslangicTarihi.HasValue)
            {
                cmd.Parameters.AddWithValue("@newbaslangicTarihi", baslangicTarihi.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@newbaslangicTarihi", DBNull.Value);
            }

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void silProje(int projeId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "silProje";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sprojeId", projeId);

            cmd.ExecuteNonQuery();
            cn.Close();
        }
            /* proje */

            /* çalışan */
        public void yeniÇalışan(string ad, string soyad, DateTime alTar)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "yeniÇalışan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@newad", ad);
            cmd.Parameters.AddWithValue("@newsoyad", soyad);
            cmd.Parameters.AddWithValue("@newiseAlinmaTarihi", alTar);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void güncelleÇalışan(int calisanId, string ad, string soyad, DateTime? iseAlinmaTarihi)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "güncelleÇalışan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@gcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@newad", ad);
            cmd.Parameters.AddWithValue("@newsoyad", soyad);
            cmd.Parameters.AddWithValue("@newiseAlinmaTarihi", iseAlinmaTarihi);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void silÇalışan(int no)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "silÇalışan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@scalisanId", no);

            cmd.ExecuteNonQuery();
            cn.Close();
        }
            /* çalışan */

            /* görev */
        public void yeniGörev(int projeId, int calisanId, string ad, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "yeniGörev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@newprojeId", projeId);
            cmd.Parameters.AddWithValue("@newcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@newgorevAd", ad);
            cmd.Parameters.AddWithValue("@newbaslangicTarihi", baslangicTarihi);
            cmd.Parameters.AddWithValue("@newbitisTarihi", bitisTarihi);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void güncelleGörev(int projeId, int calisanId, int gorevId, string ad, DateTime? baslangicTarihi)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "güncelleGörev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@gprojeId", projeId);
            cmd.Parameters.AddWithValue("@gcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@ggorevId", gorevId);
            cmd.Parameters.AddWithValue("@newgorevAd", ad);
            cmd.Parameters.AddWithValue("@newbaslangicTarihi", baslangicTarihi);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void silGörev(int projeId, int calisanId, int gorevId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "silGörev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@sprojeId", projeId);
            cmd.Parameters.AddWithValue("@scalisanId", calisanId);
            cmd.Parameters.AddWithValue("@sgorevId", gorevId);

            cmd.ExecuteNonQuery();
            cn.Close();
        }
            /* görev */
        /* Insert, Update, Delete End */

        public void görevErtele(int projeId, int calisanId, int gorevId, DateTime tarih)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "görevErtele";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@dprojeId", projeId);
            cmd.Parameters.AddWithValue("@dcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@dgorevId", gorevId);
            cmd.Parameters.AddWithValue("@newtarih", tarih);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void projeErtele(int projeId , DateTime tarih)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "projeErtele";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@dprojeId", projeId);
            cmd.Parameters.AddWithValue("@newtarih", tarih);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void tamamlaGörev(int projeId, int calisanId, int gorevId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "tamamlaGörev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@tprojeId", projeId);
            cmd.Parameters.AddWithValue("@tcalisanId", calisanId);
            cmd.Parameters.AddWithValue("@tgorevId", gorevId);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void tamamlaProje(int projeId)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "tamamlaProje";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tprojeId", projeId);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public bool tumGorevlerTamam(int projeId)
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM görev WHERE projeId = @projeId AND gorevDurum != 'Tamamlandı'", cn);
                cmd.Parameters.AddWithValue("@projeId", projeId);

                int incompleteGorevCount = Convert.ToInt32(cmd.ExecuteScalar());
                return incompleteGorevCount == 0;
            }
        }
    }
}
