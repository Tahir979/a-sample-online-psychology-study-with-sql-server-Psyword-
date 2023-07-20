using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO
{
    public partial class daylogin : Form
    {
        public daylogin()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
        }

        //DEĞİŞKENLER
        #region
        string saniye, dakika, saat;
        int genislik, yukseklik;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kullanici.accdb");
        DataTable tablo2;
        OleDbDataAdapter da;

        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        gamecondition xxx = new gamecondition();
        #endregion

        //METOTLAR
        #region
        void bas()
        {
            gamecondition x = new gamecondition();
            x.muzikler();
            string yol = x.sesler[11].ToString();
            player.SoundLocation = yol;
            player.Play();
        }
        void griddoldur()
        {
            try
            {
                con.Close();
                con.Open();

                tablo2 = new DataTable();

                da = new OleDbDataAdapter("select * from girisPsyword order by id asc", con);
                tablo2.Clear();
                da.Fill(tablo2);
                girisPsyword.DataSource = tablo2;

                con.Close();
            }
            catch
            {
                MessageBox.Show("Lütfen internet bağlantınız olduğundan emin olunuz, devam etmeniz ardından sayfa yeniden yüklenecektir...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daylogin t = new daylogin();
                t.Show();
                this.Hide();
            }
        }
        void time()
        {
            DateTime productLaunchDateTime = Convert.ToDateTime("23:59:59");
            DateTime startDate = DateTime.Now;

            TimeSpan t = productLaunchDateTime - startDate;

            if (t.Hours < 10)
            {
                saat = "0" + t.Hours;
            }
            else
            {
                saat = Convert.ToString(t.Hours);
            }

            if (t.Minutes < 10)
            {
                dakika = "0" + t.Minutes;
            }
            else
            {
                dakika = Convert.ToString(t.Minutes);
            }

            if (t.Seconds < 10)
            {
                saniye = "0" + t.Seconds;
            }
            else
            {
                saniye = Convert.ToString(t.Seconds);
            }

            lsl_time.Text = saat + "." + dakika + "." + saniye;
        }

        void pictureiptal()
        {
            paneltestingeffect_day11.Enabled = false;
            paneltestingeffect_day12.Enabled = false;
            paneltestingeffect_day21.Enabled = false;
            paneltestingeffect_day22.Enabled = false;
            paneltestingeffect_day31.Enabled = false;
            paneltestingeffect_day32.Enabled = false;
            panelread_day11.Enabled = false;
            panelread_day12.Enabled = false;
            panelread_day21.Enabled = false;
            panelread_day22.Enabled = false;
            panelread_day31.Enabled = false;
            panelread_day32.Enabled = false;
            pnl_psyword1.Enabled = false;
            pnl_psyword2.Enabled = false;
            pnl_psywordback.Enabled = false;
            pnl_closethegame.Enabled = false;
            pnl_howtogame.Enabled = false;
            pnl_closehowto.Enabled = false;
        }

        void pictureiptalokuma()
        {
            paneltestingeffect_day11.Enabled = false;
            paneltestingeffect_day12.Enabled = false;
            paneltestingeffect_day21.Enabled = false;
            paneltestingeffect_day22.Enabled = false;
            paneltestingeffect_day31.Enabled = false;
            paneltestingeffect_day32.Enabled = false;
            pnl_psyword1.Enabled = false;
            pnl_psyword2.Enabled = false;
            pnl_psywordback.Enabled = false;
            pnl_closethegame.Enabled = false;
            pnl_howtogame.Enabled = false;
            pnl_closehowto.Enabled = false;
        }

        void pictureiptalsinama()
        {
            panelread_day11.Enabled = false;
            panelread_day12.Enabled = false;
            panelread_day21.Enabled = false;
            panelread_day22.Enabled = false;
            panelread_day31.Enabled = false;
            panelread_day32.Enabled = false;
            pnl_psyword1.Enabled = false;
            pnl_psyword2.Enabled = false;
            pnl_psywordback.Enabled = false;
            pnl_closethegame.Enabled = false;
            pnl_howtogame.Enabled = false;
            pnl_closehowto.Enabled = false;
        }

        void pictureiptalpsyword()
        {
            panelread_day11.Enabled = false;
            panelread_day12.Enabled = false;
            panelread_day21.Enabled = false;
            panelread_day22.Enabled = false;
            panelread_day31.Enabled = false;
            panelread_day32.Enabled = false;
            paneltestingeffect_day11.Enabled = false;
            paneltestingeffect_day12.Enabled = false;
            paneltestingeffect_day21.Enabled = false;
            paneltestingeffect_day22.Enabled = false;
            paneltestingeffect_day31.Enabled = false;
            paneltestingeffect_day32.Enabled = false;

            panelread_day11.Location = new Point(0, 0);
            panelread_day12.Location = new Point(0, 0);
            panelread_day21.Location = new Point(0, 0);
            panelread_day22.Location = new Point(0, 0);
            panelread_day31.Location = new Point(0, 0);
            panelread_day32.Location = new Point(0, 0);
            paneltestingeffect_day11.Location = new Point(0, 0);
            paneltestingeffect_day12.Location = new Point(0, 0);
            paneltestingeffect_day21.Location = new Point(0, 0);
            paneltestingeffect_day22.Location = new Point(0, 0);
            paneltestingeffect_day31.Location = new Point(0, 0);
            paneltestingeffect_day32.Location = new Point(0, 0);
        }
        private float GetNewPixels(float pixelsDPI96, float dpi)
        {
            return pixelsDPI96 * 96 / dpi;
        }
        #endregion

        //EVENTLER
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            time();
        }
        private void panelsinama_test1_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if(girisPsyword.Rows.Count == 2 || girisPsyword.Rows.Count == 3)
            {
                bas();

                testingcondition f = new testingcondition();
                f.Show();
                this.Hide();
            }
        }
        private void panelsinama_test2_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 4)
            {
                bas();

                testingcondition f = new testingcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 4)
            {
                bas();

                pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
            }
        }
        private void panelsinama_test3_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 5)
            {
                griddoldur();

                DataView dv8 = tablo2.DefaultView;
                dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv8;

                if (girisPsyword.Rows.Count == 2)
                {
                    bas();

                    pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
                }
                else
                {
                    bas();

                    testingcondition f = new testingcondition();
                    f.Show();
                    this.Hide();
                }
            }
            else if (girisPsyword.Rows.Count < 5)
            {
                bas();

                pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
            }
        }
        private void panelsinama_test4_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 6)
            {
                bas();

                testingcondition f = new testingcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 6)
            {
                bas();

                pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
            }
        }
        private void panelsinama_test5_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 7)
            {
                griddoldur();

                DataView dv8 = tablo2.DefaultView;
                dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv8;

                if (girisPsyword.Rows.Count == 2)
                {
                    bas();

                    pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
                }
                else
                {
                    bas();

                    testingcondition f = new testingcondition();
                    f.Show();
                    this.Hide();
                }
            }
            else if (girisPsyword.Rows.Count < 7)
            {
                bas();

                pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
            }
        }
        private void panelsinama_test6_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 8)
            {
                bas();

                testingcondition f = new testingcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 8)
            {
                bas();

                pctscreen.Image = Properties.Resources.sinamagrubu_sira_min;
            }
        }
        private void panelokuma_test1_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 2 || girisPsyword.Rows.Count == 3)
            {
                bas();

                readcondition f = new readcondition();
                f.Show();
                this.Hide();
            }
        }
        private void panelokuma_test2_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 4)
            {
                bas();

                readcondition f = new readcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 4)
            {
                bas();

                pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
            }
        }
        private void panelokuma_test3_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 5)
            {
                griddoldur();

                DataView dv8 = tablo2.DefaultView;
                dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv8;

                if (girisPsyword.Rows.Count == 2)
                {
                    bas();

                    pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
                }
                else
                {
                    bas();

                    readcondition f = new readcondition();
                    f.Show();
                    this.Hide();
                }
            }
            else if (girisPsyword.Rows.Count < 5)
            {
                bas();

                pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
            }
        }
        private void panelokuma_test4_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 6)
            {
                bas();

                readcondition f = new readcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 6)
            {
                bas();

                pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
            }
        }
        private void panelokuma_test5_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 7)
            {
                griddoldur();

                DataView dv8 = tablo2.DefaultView;
                dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv8;

                if (girisPsyword.Rows.Count == 2)
                {
                    bas();

                    pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
                }
                else
                {
                    bas();

                    readcondition f = new readcondition();
                    f.Show();
                    this.Hide();
                }
            }
            else if (girisPsyword.Rows.Count < 7)
            {
                bas();

                pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
            }
        }
        private void panelokuma_test6_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count == 8)
            {
                bas();

                readcondition f = new readcondition();
                f.Show();
                this.Hide();
            }
            else if (girisPsyword.Rows.Count < 8)
            {
                bas();

                pctscreen.Image = Properties.Resources.okumagrubu_sira__1__min;
            }
        }
        private void pnl_oyun1_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            int mod = girisPsyword.Rows.Count % 2;

            if (mod == 1)
            {
                griddoldur();

                DataView dv8 = tablo2.DefaultView;
                dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv8;

                if (girisPsyword.Rows.Count == 2)
                {

                }
                else
                {
                 bas();

                gamecondition f = new gamecondition();
                f.Show();
                this.Hide();
                }
            }
        }
        private void pnl_oyun2_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            int mod = girisPsyword.Rows.Count % 2;

            if (mod == 1)
            {
                if(girisPsyword.Rows.Count != 9)
                {
                    griddoldur();

                    DataView dv8 = tablo2.DefaultView;
                    dv8.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                    girisPsyword.DataSource = dv8;

                    if (girisPsyword.Rows.Count == 2)
                    {

                    }
                    else
                    {
                        bas();

                        lsl_time.Visible = false;
                        pctscreen.Image = Properties.Resources.oyun_sira_min;
                    }
                }
            }
            else
            {
                bas();

                gamecondition f = new gamecondition();
                f.Show();
                this.Hide();
            }
        }
        private void panel1_ilkgun_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            int mod = girisPsyword.Rows.Count % 2;

            if (mod == 1)
            {
                griddoldur();

                DataView dv7 = tablo2.DefaultView;
                dv7.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv7;

                if (girisPsyword.Rows.Count == 2)
                {

                }
                else
                {
                    bas();

                    readcondition f = new readcondition();
                    f.Show();
                    this.Hide();
                }
            }
        }
        private void panel2_ilkgun_Click(object sender, EventArgs e)
        {
            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            int mod = girisPsyword.Rows.Count % 2;

            if (mod == 1)
            {
                griddoldur();

                DataView dv7 = tablo2.DefaultView;
                dv7.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
                girisPsyword.DataSource = dv7;

                if(girisPsyword.Rows.Count == 2)
                {

                }
                else
                {
                    bas();

                    pctscreen.Image = Properties.Resources.ilkgun_gorev2erisim_min;
                }
            }
            else
            {
                bas();

                readcondition f = new readcondition();
                f.Show();
                this.Hide();
            }
        }
        private void pnl_howtogame_Click(object sender, EventArgs e)
        {
            bas();

            pctscreen.Image = Properties.Resources.howtopsywordrevise_min;
            lsl_time.Visible = false;
        }
        private void pnl_oyungeridon_Click(object sender, EventArgs e)
        {
            bas();

            loginscreen g = new loginscreen();
            g.Show();
            this.Hide();
        }
        private void pnl_oyunkapa_Click(object sender, EventArgs e)
        {
            bas();
            new CResolution(genislik, yukseklik);
            Environment.Exit(0);
        }
        private void pnl_closehowto_Click(object sender, EventArgs e)
        {
            bas();

            griddoldur();

            DataView dv7 = tablo2.DefaultView;
            dv7.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%'";
            girisPsyword.DataSource = dv7;

            if (girisPsyword.Rows.Count == 0)
            {
                pctscreen.Image = Properties.Resources.oyun1_min;
            }
            else if (girisPsyword.Rows.Count == 1)
            {
                pctscreen.Image = Properties.Resources.oyun2_min;
            }
            else if (girisPsyword.Rows.Count == 2)
            {
                pctscreen.Image = Properties.Resources.oyunson_min;
            }

            lsl_time.Visible = true;
        }

        private void pnl_geri_Click(object sender, EventArgs e)
        {
            bas();

            loginscreen f = new loginscreen();
            f.Show();
            this.Hide();
        }
        private void panel_sirakapa_Click(object sender, EventArgs e)
        {
            bas();

            griddoldur();

            DataView dv3 = tablo2.DefaultView;
            dv3.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv3;

            if (girisPsyword.Rows.Count <= 2)
            {
                if (girisPsyword.Rows.Count == 1)
                {
                    pctscreen.Image = Properties.Resources.ilkgun_1_min;
                }
                else if (girisPsyword.Rows.Count == 2)
                {
                    pctscreen.Image = Properties.Resources.ilkgun_2_min;
                }
            }

            else
            {
                if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Okuma")
                {
                    if (girisPsyword.Rows.Count == 3)
                    {
                        pctscreen.Image = Properties.Resources._1_min;
                    }
                    else if (girisPsyword.Rows.Count == 4)
                    {
                        pctscreen.Image = Properties.Resources._2_min;
                    }
                    else if (girisPsyword.Rows.Count == 5)
                    {
                        pctscreen.Image = Properties.Resources._3_min;
                    }
                    else if (girisPsyword.Rows.Count == 6)
                    {
                        pctscreen.Image = Properties.Resources._4_min;
                    }
                    else if (girisPsyword.Rows.Count == 7)
                    {
                        pctscreen.Image = Properties.Resources._5_min;
                    }
                    else if (girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources._6_min;
                    }
                }
                else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Sinama")
                {
                    if (girisPsyword.Rows.Count == 3)
                    {
                        pctscreen.Image = Properties.Resources.sina1_min;
                    }
                    else if (girisPsyword.Rows.Count == 4)
                    {
                        pctscreen.Image = Properties.Resources.sina2_min;
                    }
                    else if (girisPsyword.Rows.Count == 5)
                    {
                        pctscreen.Image = Properties.Resources.sina3_min;
                    }
                    else if (girisPsyword.Rows.Count == 6)
                    {
                        pctscreen.Image = Properties.Resources.sina4_min;
                    }
                    else if (girisPsyword.Rows.Count == 7)
                    {
                        pctscreen.Image = Properties.Resources.sina5_min;
                    }
                    else if (girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources.sina6_min;
                    }
                }
                else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Psyword")
                {
                    if (girisPsyword.Rows.Count == 3)
                    {
                        pctscreen.Image = Properties.Resources.oyun1_min;
                    }
                    else if (girisPsyword.Rows.Count == 4)
                    {
                        pctscreen.Image = Properties.Resources.oyun2_min;
                    }
                    else if (girisPsyword.Rows.Count == 5)
                    {
                        pctscreen.Image = Properties.Resources.oyun1_min;
                    }
                    else if (girisPsyword.Rows.Count == 6)
                    {
                        pctscreen.Image = Properties.Resources.oyun2_min;
                    }
                    else if (girisPsyword.Rows.Count == 7)
                    {
                        pctscreen.Image = Properties.Resources.oyun1_min;
                    }
                    else if (girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources.oyun2_min;
                    }

                    lsl_time.Visible = true;
                }
            }
        }

        private void ilkgun_Load(object sender, EventArgs e)
        {
            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;

            using (Graphics g = this.CreateGraphics())
            {
                float dpii = g.DpiY;
                float newFontSize = GetNewPixels(32f, dpii);
                lsl_time.Font = new Font("Alata", 32f, GraphicsUnit.Pixel);
            }

            griddoldur();

            DataView dv = tablo2.DefaultView;
            dv.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv;

            if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Psyword")
            {
                panel_close.Location = new Point(1339, 171);
            }
            else
            {
                panel_close.Location = new Point(1349, 171);
            }

            panelread_day11.Parent = pctscreen;
            panelread_day12.Parent = pctscreen;
            panelread_day21.Parent = pctscreen;
            panelread_day22.Parent = pctscreen;
            panelread_day31.Parent = pctscreen;
            panelread_day32.Parent = pctscreen;
            paneltestingeffect_day11.Parent = pctscreen;
            paneltestingeffect_day12.Parent = pctscreen;
            paneltestingeffect_day21.Parent = pctscreen;
            paneltestingeffect_day22.Parent = pctscreen;
            paneltestingeffect_day31.Parent = pctscreen;
            paneltestingeffect_day32.Parent = pctscreen;
            pnl_psyword1.Parent = pctscreen;
            pnl_psyword2.Parent = pctscreen;
            pnl_back.Parent = pctscreen;
            pnl_closethegame.Parent = pctscreen;
            pnl_psywordback.Parent = pctscreen;
            panel_close.Parent = pctscreen;
            pnl_howtogame.Parent = pctscreen;
            firstday_day11.Parent = pctscreen;
            firstday_day12.Parent = pctscreen;
            pnl_closehowto.Parent = pctscreen;
            lsl_time.Parent = pctscreen;

            lsl_time.Parent = pctscreen;

            if (girisPsyword.Rows.Count > 3)
            {
                if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Okuma")
                {
                    pictureiptalokuma();

                    panelread_day11.BringToFront();
                    panelread_day12.BringToFront();
                    panelread_day21.BringToFront();
                    panelread_day22.BringToFront();
                    panelread_day31.BringToFront();
                    panelread_day32.BringToFront();

                    if (girisPsyword.Rows.Count == 4) 
                    {
                        pctscreen.Image = Properties.Resources._2_min;
                    }
                    else if (girisPsyword.Rows.Count == 5)
                    {
                        pctscreen.Image = Properties.Resources._3_min;
                    }
                    else if (girisPsyword.Rows.Count == 6)
                    {
                        pctscreen.Image = Properties.Resources._4_min;
                    }
                    else if (girisPsyword.Rows.Count == 7)
                    {
                        pctscreen.Image = Properties.Resources._5_min;
                    }
                    else if (girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources._6_min;
                    }
                    else if (girisPsyword.Rows.Count == 9)
                    {
                        pctscreen.Image = Properties.Resources._7;
                    }
                }
                else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Psyword")
                {
                    pictureiptalpsyword();

                    griddoldur();

                    DataView dvx = tablo2.DefaultView;
                    dvx.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
                    girisPsyword.DataSource = dvx;

                    if(girisPsyword.Rows.Count > 3)
                    {
                        pnl_back.Enabled = false;
                    }

                    pnl_howtogame.BringToFront();
                    pnl_psyword1.BringToFront();
                    pnl_psyword2.BringToFront();
                    pnl_psywordback.BringToFront();
                    pnl_closethegame.BringToFront();

                    if (girisPsyword.Rows.Count == 4 || girisPsyword.Rows.Count == 6 || girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources.oyun2_min;
                    }
                    else if (girisPsyword.Rows.Count == 5 || girisPsyword.Rows.Count == 7)
                    {
                        string xx = DateTime.Now.ToString("dd/MM/yyyy");
                        DateTime myDate = DateTime.Parse(xx);
                        string jj = myDate.ToString();
                        string j = jj.Substring(0, 10);

                        griddoldur();

                        DataView dvx2 = tablo2.DefaultView;
                        dvx2.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + j + "%'";
                        girisPsyword.DataSource = dvx2;
                        int c2 = girisPsyword.Rows.Count;

                        if (c2 == 2)
                        {
                            pctscreen.Image = Properties.Resources.oyunson_min;
                        }
                        else
                        {
                            pctscreen.Image = Properties.Resources.oyun1_min;
                        }
                    }
                    else if (girisPsyword.Rows.Count == 9)
                    {
                        pctscreen.Image = Properties.Resources.oyunson_min;
                    }

                    lsl_time.Visible = true;
                }
                else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Sinama")
                {
                    pictureiptalsinama();

                    paneltestingeffect_day11.BringToFront();
                    paneltestingeffect_day12.BringToFront();
                    paneltestingeffect_day21.BringToFront();
                    paneltestingeffect_day22.BringToFront();
                    paneltestingeffect_day31.BringToFront();
                    paneltestingeffect_day32.BringToFront();

                    if (girisPsyword.Rows.Count == 4)
                    {
                        pctscreen.Image = Properties.Resources.sina2_min;
                    }
                    if (girisPsyword.Rows.Count == 5)
                    {
                        pctscreen.Image = Properties.Resources.sina3_min;
                    }
                    if (girisPsyword.Rows.Count == 6)
                    {
                        pctscreen.Image = Properties.Resources.sina4_min;
                    }
                    if (girisPsyword.Rows.Count == 7)
                    {
                        pctscreen.Image = Properties.Resources.sina5_min;
                    }
                    if (girisPsyword.Rows.Count == 8)
                    {
                        pctscreen.Image = Properties.Resources.sina6_min;
                    }
                    if (girisPsyword.Rows.Count == 9)
                    {
                        pctscreen.Image = Properties.Resources.sina7_min;
                    }
                }
            }
            else if (girisPsyword.Rows.Count <= 3)
            {
                griddoldur();

                DataView dv2 = tablo2.DefaultView;
                dv2.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
                girisPsyword.DataSource = dv2;

                if(girisPsyword.Rows.Count == 1)
                {
                    pictureiptal();
                    pctscreen.Image = Properties.Resources.ilkgun_1_min;
                }

                else if (girisPsyword.Rows.Count == 2)
                {
                    pictureiptal();
                    pctscreen.Image = Properties.Resources.ilkgun_2_min;
                }

                else if (girisPsyword.Rows.Count == 3)
                {
                    string xx = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime myDate = DateTime.Parse(xx);
                    string jj = myDate.ToString();
                    string j = jj.Substring(0, 10);

                    griddoldur();

                    DataView dv7 = tablo2.DefaultView;
                    dv7.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + j + "%'";
                    girisPsyword.DataSource = dv7;

                    if (girisPsyword.Rows.Count == 2)
                    {
                        pictureiptal();
                        pctscreen.Image = Properties.Resources.ilkgun_3_min;
                    }

                    else
                    {
                        griddoldur();

                        DataView dv8 = tablo2.DefaultView;
                        dv8.RowFilter = "kAdi like '%" + dilandlocate.Default.kullaniciadi + "%'";
                        girisPsyword.DataSource = dv8;

                        if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Okuma")
                        {
                            pictureiptalokuma();
                            pctscreen.Image = Properties.Resources._1_min;
                        }
                        else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Psyword")
                        {
                            pictureiptalpsyword();
                            pctscreen.Image = Properties.Resources.oyun1_min;
                            lsl_time.Visible = true;
                        }
                        else if (girisPsyword.Rows[0].Cells[1].Value.ToString() == "Sinama")
                        {
                            pictureiptalsinama();
                            pctscreen.Image = Properties.Resources.sina1_min;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
