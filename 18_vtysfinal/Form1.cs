using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _18_vtysfinal
{
    public partial class Form1 : Form
    {
        private MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler");
        private MySqlCommand cmd = new MySqlCommand();
        StoredProcedure sp = new StoredProcedure();
        private int dgv1Id = -1;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proje.Focus();
            sp.projeListele(dataGridView1);
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[0].Cells["Proje Kodu"].Value == null)
            {
                MessageBox.Show("Veri tabanında proje olmadığı gözüküyor, lütfen yeni proje oluşturunuz.");
                yeniProje yeniProjeForm = new yeniProje();
                yeniProjeForm.Show();
            }
            projeBitisTarihKontrol();
            gorevBitisTarihKontrol();
        }

        // ***** DATAGRIDVIEW1 START ***** //

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                if (dt.Columns.Contains("Proje Kodu"))
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        int projeId = Convert.ToInt32(row.Cells["Proje Kodu"].Value);
                        dgv1Id = projeId;
                        sp.projeInfo(dataGridView2 ,projeId);
                    }
                }
                if (dt.Columns.Contains("Çalışan No"))
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        int calisanId = Convert.ToInt32(row.Cells["Çalışan No"].Value);
                        dgv1Id = calisanId;
                        sp.çalışanInfo(dataGridView2, calisanId);
                    }
                }
            }
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {  
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (dataGridView1.DataSource is DataTable dt)
                {
                    if (dt.Columns.Contains("Proje Kodu"))
                    {
                        e.ContextMenuStrip = projeContext;
                    }
                    else if (dt.Columns.Contains("Çalışan No"))
                    {
                        e.ContextMenuStrip = çalışanContext;
                    }
                    else if (dt.Columns.Contains("Proje, Eleman ve Görev Kodları"))
                    {
                        e.ContextMenuStrip = görevContext;
                    }
                }
            }
        }

        // ***** DATAGRIDVIEW1 END ***** //

        // ***** DATAGRIDVIEW2 START ***** //

        private void dataGridView2_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                if (dataGridView2.DataSource is DataTable dt)
                {
                    if (dt.Columns.Contains("Eleman ve Görev Kodları"))
                    {
                        e.ContextMenuStrip = görevProjeContext;
                    }
                    else if (dt.Columns.Contains("Proje ve Görev Kodları"))
                    {
                        e.ContextMenuStrip = görevÇalışanContext;
                    }
                }
            }
        }

        // ***** DATAGRIDVIEW2 END ***** //

        // ***** BUTTONS START ***** //
        private void proje_Click(object sender, EventArgs e)
        {
            sp.projeListele(dataGridView1);
            dataGridView2.DataSource = null;
            dgv1Id = -1;
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[0].Cells["Proje Kodu"].Value == null)
            {
                MessageBox.Show("Veri tabanında proje olmadığı gözüküyor, lütfen yeni proje oluşturunuz.");
                yeniProje yeniProjeForm = new yeniProje();
                yeniProjeForm.Show();
            }
        }

        private void çalışan_Click(object sender, EventArgs e)
        {
            sp.çalışanListele(dataGridView1);
            dataGridView2.DataSource = null;
            dgv1Id = -1;
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[0].Cells["Çalışan No"].Value == null)
            {
                MessageBox.Show("Veri tabanında çalışan olmadığı gözüküyor, lütfen yeni çalışanlar oluşturunuz.");
                yeniCalisan yeniCalisanForm = new yeniCalisan();
                yeniCalisanForm.Show();
            }
        }

        private void görev_Click(object sender, EventArgs e)
        {
            sp.görevListele(dataGridView1);
            dataGridView2.DataSource = null;
            dgv1Id = -1;
        }
        // ***** BUTTONS END  ***** //

        // ***** CONTEXT MENU START  ***** //
                /* proje */
        private void projeyiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();
            if (projeId != -1)
            {
                guncelleProje guncelleProjeForm = new guncelleProje(projeId);
                guncelleProjeForm.FormClosed += (s, args) => sp.projeListele(dataGridView1);
                guncelleProjeForm.Show();
            }
        }

        private void projeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();
            if (projeId != -1)
            {
                sp.silProje(projeId);
                sp.projeListele(dataGridView1);
            }   
        }

        private void projeyeYeniGörevEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();
            if (projeId != -1)
            {
                yeniGörev yeniGörevForm = new yeniGörev(projeId, -1);
                yeniGörevForm.FormClosed += (s, args) =>
                {
                    sp.projeListele(dataGridView1);
                    sp.projeInfo(dataGridView2, projeId);
                };
                yeniGörevForm.Show();
            }
        }

        private void projeGörevleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();
            if (projeId != -1)
            {
                dgv1Id = projeId;
                sp.projeInfo(dataGridView2, projeId);
            }
        }

        private void yeniProjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yeniProje yeniProjeForm = new yeniProje();
            yeniProjeForm.FormClosed += (s, args) => sp.projeListele(dataGridView1);
            yeniProjeForm.Show();
        }

        private void projeyiErteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();
            if (projeId != -1)
            {
                erteleProje erteleProjeForm = new erteleProje(projeId);
                erteleProjeForm.FormClosed += (s, args) => sp.projeListele(dataGridView1);
                erteleProjeForm.Show();
            }
        }

        private void projeyiBitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projeId = getProjeId();

            if (projeId != -1)
            {
                if (sp.tumGorevlerTamam(projeId))
                {
                    DataGridViewRow row = null;
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        row = dataGridView1.SelectedRows[0];
                    }
                    else if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                        row = dataGridView1.Rows[rowIndex];
                    }

                    if (row != null)
                    {
                        string gorevDurum = Convert.ToString(row.Cells["Proje Durumu"].Value);

                        if (gorevDurum.Equals("Aktif", StringComparison.OrdinalIgnoreCase))
                        {
                            sp.tamamlaProje(projeId);
                            sp.projeListele(dataGridView1);
                        }
                        else
                        {
                            MessageBox.Show("Bu işlem yalnızca aktif projeler için gerçekleştirilebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen önce tüm görevleri tamamlayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
                /* proje */

                /* çalışan */
        private void çalışanıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int calisanId = getCalisanId();

            if (calisanId != -1)
            {
                guncelleCalisan guncelleCalisanForm = new guncelleCalisan(calisanId);
                guncelleCalisanForm.FormClosed += (s, args) => sp.çalışanListele(dataGridView1);
                guncelleCalisanForm.Show();
            }
        }

        private void çalışanaYeniGörevAtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int calisanId = getCalisanId();

            if (calisanId != -1)
            {
                yeniGörev yeniGörevForm = new yeniGörev(-1, calisanId);
                yeniGörevForm.FormClosed += (s, args) => sp.çalışanListele(dataGridView1);
                yeniGörevForm.Show();
            }
        }

        private void çalışanıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int calisanId = getCalisanId();

            if (calisanId != -1)
            {
                sp.silÇalışan(calisanId);
                sp.çalışanListele(dataGridView1);
            }
        }

        private void çalışanGeçmişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int calisanId = getCalisanId();

            if (calisanId != -1)
            {
                dgv1Id = calisanId;
                sp.çalışanInfo(dataGridView2, calisanId);
            }
        }

        private void çalışanaYeniGörevAtaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (getGorevId(out _, out int calisanId, out _))
            {
                yeniGörev yeniGörevForm = new yeniGörev(-1, calisanId);
                yeniGörevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
                yeniGörevForm.Show();
            }
        }

        private void tamamlanmışGörevleriKıyaslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int calisanId = getCalisanId();

            if (calisanId != -1)
            {
                sp.çalışanBitGörKıyas(dataGridView2, calisanId);
            }
        }

        private void yeniÇalışanOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yeniCalisan yeniCalisanForm = new yeniCalisan();
            yeniCalisanForm.FormClosed += (s, args) => sp.çalışanListele(dataGridView1);
            yeniCalisanForm.Show();
        }
                /* çalışan */

                /* görev */
        private void göreviSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out int calisanId, out int gorevId))
            {
                sp.silGörev(projeId, calisanId, gorevId);
                sp.görevListele(dataGridView1);
            }
        }

        private void yeniGörevOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yeniGörev yeniGörevForm = new yeniGörev(-1, -1);
            yeniGörevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
            yeniGörevForm.Show();
        }

        private void proToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out _, out _))
            {
                yeniGörev yeniGörevForm = new yeniGörev(projeId, -1);
                yeniGörevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
                yeniGörevForm.Show();
            }
        }

        private void projeVeÇalışanİçinYeniGörevOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out int calisanId, out _))
            {
                yeniGörev yeniGörevForm = new yeniGörev(projeId, calisanId);
                yeniGörevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
                yeniGörevForm.Show();
            }
        }

        private void göreviDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out int calisanId, out int gorevId))
            {
                guncelleGorev guncelleGörevForm = new guncelleGorev(projeId, calisanId, gorevId);
                guncelleGörevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
                guncelleGörevForm.Show();
            }
        }

        private void göreviErteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out int calisanId, out int gorevId))
            {
                erteleGorev erteleGorevForm = new erteleGorev(projeId, calisanId, gorevId);
                erteleGorevForm.FormClosed += (s, args) => sp.görevListele(dataGridView1);
                erteleGorevForm.Show();
            }
        }

        private void göreviTamamlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getGorevId(out int projeId, out int calisanId, out int gorevId))
            {
                string gorevDurum = Convert.ToString(dataGridView1.SelectedRows.Count > 0
                    ? dataGridView1.SelectedRows[0].Cells["Görev Durumu"].Value
                    : dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Görev Durumu"].Value);

                if (gorevDurum.Equals("Aktif", StringComparison.OrdinalIgnoreCase))
                {
                    sp.tamamlaGörev(projeId, calisanId, gorevId);
                    sp.görevListele(dataGridView1);
                }
                else
                {
                    MessageBox.Show("Bu işlem yalnızca aktif görevler için gerçekleştirilebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
                /* görev */

            /* dataGridView2 */

                /* projeInfo */
        private void göreviDüzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getCalisanGorevId((projeId, calisanId, gorevId) =>
            {
                guncelleGorev guncelleGörevForm = new guncelleGorev(projeId, calisanId, gorevId);
                guncelleGörevForm.FormClosed += (s, args) => sp.projeInfo(dataGridView2, projeId);
                guncelleGörevForm.Show();
            });
        }

        private void göreviSilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getCalisanGorevId((projeId, calisanId, gorevId) =>
            {
                sp.silGörev(projeId, calisanId, gorevId);
                sp.projeInfo(dataGridView2, projeId);
            });
        }

        private void projeyeYeniGörevEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yeniGörev yeniGörevForm = new yeniGörev(dgv1Id, -1);
            yeniGörevForm.FormClosed += (s, args) => sp.projeInfo(dataGridView2, dgv1Id);
            yeniGörevForm.Show();
        }

        private void göreviErteleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getCalisanGorevId((projeId, calisanId, gorevId) =>
            {
                erteleGorev erteleGorevForm = new erteleGorev(projeId, calisanId, gorevId);
                erteleGorevForm.FormClosed += (s, args) => sp.projeInfo(dataGridView2, projeId);
                erteleGorevForm.Show();
            });
        }

        private void göreviTamamlaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getCalisanGorevId((projeId, calisanId, gorevId) =>
            {
                string gorevDurum = Convert.ToString(dataGridView2.SelectedRows.Count > 0
                    ? dataGridView2.SelectedRows[0].Cells["Görev Durumu"].Value
                    : dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Görev Durumu"].Value);

                if (gorevDurum.Equals("Aktif", StringComparison.OrdinalIgnoreCase))
                {
                    sp.tamamlaGörev(projeId, calisanId, gorevId);
                    sp.projeListele(dataGridView1);
                }
                else
                {
                    MessageBox.Show("Bu işlem yalnızca aktif görevler için gerçekleştirilebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
                /* projeInfo */

                /* çalışanInfo */
        private void göreviDüzenleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            getProjeGorevId((pId, cId, gId) =>
            {
                guncelleGorev guncelleGörevForm = new guncelleGorev(pId, cId, gId);
                guncelleGörevForm.FormClosed += (s, args) => sp.çalışanInfo(dataGridView2, dgv1Id);
                guncelleGörevForm.Show();
            });
        }

        private void göreviSilToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            getProjeGorevId((pId, cId, gId) =>
            {
                sp.silGörev(pId, cId, gId);
                sp.çalışanInfo(dataGridView2, dgv1Id);
            });
        }

        private void çalışanaYeniGörevAtaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            yeniGörev yeniGörevForm = new yeniGörev(-1, dgv1Id);
            yeniGörevForm.FormClosed += (s, args) => sp.çalışanInfo(dataGridView2, dgv1Id);
            yeniGörevForm.Show();
        }

        private void göreviTamamlaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            getProjeGorevId((pId, cId, gId) =>
            {
                string gorevDurum = Convert.ToString(dataGridView2.SelectedRows.Count > 0
                    ? dataGridView2.SelectedRows[0].Cells["Görev Durumu"].Value
                    : dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Görev Durumu"].Value);

                if (gorevDurum.Equals("Aktif", StringComparison.OrdinalIgnoreCase))
                {
                    sp.tamamlaGörev(pId, dgv1Id, gId);
                    sp.çalışanListele(dataGridView1);
                }
                else
                {
                    MessageBox.Show("Bu işlem yalnızca aktif görevler için gerçekleştirilebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
                /* çalışanInfo */
            /* dataGridView2 */
        // ***** CONTEXT MENU END  ***** //

        private void gorevBitisTarihKontrol()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT projeId, calisanId, gorevId FROM görev WHERE bitisTarihi = CURDATE() AND gorevDurum != 'Tamamlandı'", cn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int projeId = reader.GetInt32("projeId");
                            int calisanId = reader.GetInt32("calisanId");
                            int gorevId = reader.GetInt32("gorevId");

                            DialogResult result = MessageBox.Show($"Proje ID: {projeId}, Çalışan ID: {calisanId}, Görev ID: {gorevId}'in bitiş tarihi bugün. Görev tamamlansın mı yoksa ertelensin mi?", "Görev Bitiş Bildirimi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                sp.tamamlaGörev(projeId, calisanId, gorevId);
                                sp.görevListele(dataGridView2);
                            }
                            else if (result == DialogResult.No)
                            {
                                erteleGorev erteleForm = new erteleGorev(projeId, calisanId, gorevId);
                                erteleForm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void projeBitisTarihKontrol()
        {
            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=19060423;database=projeler"))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT projeId, projeAd FROM proje WHERE bitisTarihi = CURDATE() AND projeDurum != 'Tamamlandı'", cn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int projeId = reader.GetInt32("projeId");
                            string projeAd = reader.GetString("projeAd");

                            DialogResult result = MessageBox.Show($"Proje '{projeAd}' bugün sona eriyor. Proje tamamlansın mı yoksa ertelensin mi?", "Proje Bitiş Bildirimi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                if (sp.tumGorevlerTamam(projeId))
                                {
                                    sp.tamamlaProje(projeId);
                                    sp.projeListele(dataGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Proje tamamlanamaz. Tüm görevlerin tamamlandığından emin olun.");
                                }
                            }
                            else if (result == DialogResult.No)
                            {
                                erteleProje erteleForm = new erteleProje(projeId);
                                erteleForm.ShowDialog();
                            }
                        }
                    }
                }

            }
        }

        // ***** GET ID START ***** //
        private int getProjeId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Proje Kodu"].Value);
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                return Convert.ToInt32(dataGridView1.Rows[row].Cells["Proje Kodu"].Value);
            }

            return -1; // Indicate that no valid selection was found
        }

        private int getCalisanId()
        {
            int calisanId = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                calisanId = Convert.ToInt32(row.Cells["Çalışan No"].Value);
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                calisanId = Convert.ToInt32(dataGridView1.Rows[row].Cells["Çalışan No"].Value);
            }

            return calisanId;
        }

        private bool getGorevId(out int projeId, out int calisanId, out int gorevId)
        {
            projeId = calisanId = gorevId = -1;

            if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows.Count > 0
                    ? dataGridView1.SelectedRows[0]
                    : dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

                string IDs = Convert.ToString(row.Cells["Proje, Eleman ve Görev Kodları"].Value);
                string[] ids = IDs.Split('-');

                if (ids.Length == 3 &&
                    int.TryParse(ids[0], out projeId) &&
                    int.TryParse(ids[1], out calisanId) &&
                    int.TryParse(ids[2], out gorevId))
                {
                    return true;
                }
            }

            return false;
        }

        private void getCalisanGorevId(Action<int, int, int> action)
        {
            if (dataGridView2.SelectedRows.Count > 0 || dataGridView2.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows.Count > 0
                    ? dataGridView2.SelectedRows[0]
                    : dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex];

                string IDs = Convert.ToString(row.Cells["Eleman ve Görev Kodları"].Value);
                string[] ids = IDs.Split('-');

                if (int.TryParse(ids[0], out int calisanId) && int.TryParse(ids[1], out int gorevId))
                {
                    action.Invoke(dgv1Id, calisanId, gorevId);
                    sp.projeListele(dataGridView1);
                }
            }
        }

        private void getProjeGorevId(Action<int, int, int> action)
        {
            if (dataGridView2.SelectedRows.Count > 0 || dataGridView2.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows.Count > 0
                    ? dataGridView2.SelectedRows[0]
                    : dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex];

                string IDs = Convert.ToString(row.Cells["Proje ve Görev Kodları"].Value);
                string[] ids = IDs.Split('-');

                if (int.TryParse(ids[0], out int projeId) && int.TryParse(ids[1], out int gorevId))
                {
                    action.Invoke(projeId, dgv1Id, gorevId);
                    sp.çalışanListele(dataGridView1);
                }
            }
        }
        // ***** GET ID END ***** //
    }
}
