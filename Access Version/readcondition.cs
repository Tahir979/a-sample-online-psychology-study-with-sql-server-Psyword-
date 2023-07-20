using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO
{
    public partial class readcondition : Form
    {
        public readcondition()
        {
            InitializeComponent();
        }

        OleDbConnection con_sql = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kullanici.accdb");
        OleDbCommand cmd_sql;
        DataTable tablo_sql, tablo2_sql;
        OleDbDataAdapter da_sql, da2_sql;

        gamecondition xxx = new gamecondition();
        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        TextBox txt_basla = new TextBox();
        TextBox txt_basla_guncel = new TextBox();
        TextBox txt_bitir = new TextBox();
        ListBox time = new ListBox();

        List<int> kelimesiralari = new List<int>(); //gelecek kelimelerin kaç harfli olacağı bu listede
        List<string> kelimeler = new List<string>();
        List<int> kelimeler_id = new List<int>();
        List<int> kelimeler_kelimesayisi = new List<int>();
        List<string> kelimeler_soru = new List<string>();

        List<int> xpoint = new List<int>();
        //OKUMA GRUBU VERİTABANI HAZIR, LİSTTE TUTULACAK VERİLER EN SON AKTARILACAK VERİTABANINA İNTERNETİN DURUMUNA GÖRE
        List<float> time_total = new List<float>();
        List<int> font = new List<int>();
        List<string> k = new List<string>();
        string[] words;

        float basla_float, bitir_float, bitir_total_float, bbbbb, add_dk, ort = 0, toplam = 0;
        int kelimesayac = 0, kelimeindex = 0, oturum, baslangic = 0;
        string kullaniciadi, kullanicigrup, ifade, timestamp, timestamp_guncel, basla, bitir, girisdatetime, anlamli_RT_95;
        int  sorusayi = 1;
        private void pnl_ilerle_Click(object sender, EventArgs e)
        {
            bas();

            timestamp = DateTime.UtcNow.ToString("mm:ss.fff");
            txt_bitir.Text = timestamp;

            basla = txt_basla_guncel.Text.Substring(txt_basla_guncel.Text.Length - 9); //42:12.772 (saat yok, en baştaki dakika)
            bitir = txt_bitir.Text.Substring(txt_bitir.Text.Length - 9);

            string d1 = basla.Substring(0, 2); //dakikalar
            string d2 = bitir.Substring(0, 2); //dakikalar
            int d1_int = Convert.ToInt32(d1);
            int d2_int = Convert.ToInt32(d2);

            string s1 = basla.Substring(3, 2); //saniyeler
            string s2 = bitir.Substring(3, 2); //saniyeler
            int s1_int = Convert.ToInt32(s1);
            int s2_int = Convert.ToInt32(s2);

            if (d1_int == d2_int)
            {
                basla = txt_basla_guncel.Text.Substring(txt_basla_guncel.Text.Length - 6); //12.772
                bitir = txt_bitir.Text.Substring(txt_bitir.Text.Length - 6);

                basla_float = (float)Convert.ToDouble(basla);
                bitir_float = (float)Convert.ToDouble(bitir);

                if (bitir_float < basla_float)
                {
                    bbbbb = bitir_float + 60; // 4.949
                    bitir_total_float = bbbbb - basla_float; //total sürenin ilk 4 hanesini almak lazım
                }
                else
                {
                    bitir_total_float = bitir_float - basla_float; //total sürenin ilk 4 hanesini almak lazım
                }
            }
            else if (d2_int > d1_int)
            {
                basla = txt_basla_guncel.Text.Substring(txt_basla_guncel.Text.Length - 6); //12.772
                bitir = txt_bitir.Text.Substring(txt_bitir.Text.Length - 6);

                basla_float = (float)Convert.ToDouble(basla);
                bitir_float = (float)Convert.ToDouble(bitir);

                if (bitir_float < basla_float)
                {
                    bbbbb = bitir_float + 60; // 4.949
                    bitir_total_float = bbbbb - basla_float; //total sürenin ilk 4 hanesini almak lazım
                }
                else
                {
                    bitir_total_float = bitir_float - basla_float; //total sürenin ilk 4 hanesini almak lazım
                }


                if (s2_int >= s1_int)
                {
                    add_dk = (float)(60.000 * (d2_int - d1_int));
                    bitir_total_float += add_dk;
                }
                else if (s1_int > s2_int)
                {
                    add_dk = (float)(60.000 * (d2_int - d1_int - 1));
                    bitir_total_float += add_dk;
                }
            }

            time_total.Add(bitir_total_float);

            line1.AutoSize = false;
            line21.AutoSize = false;
            line22.AutoSize = false;
            line31.AutoSize = false;
            line32.AutoSize = false;
            line33.AutoSize = false;

            line1.Text = "";
            line21.Text = "";
            line22.Text = "";
            line31.Text = "";
            line32.Text = "";
            line33.Text = "";

            k.Clear();
            yenisoru();
            pctscreen.Image = Properties.Resources.arayuz_min;
        }

        private void pnl_kapa_Click(object sender, EventArgs e)
        {
            loginscreen y = new loginscreen();
            y.Show();
            this.Hide();
        }

        void griddoldur()
        {
            try
            {
                con_sql.Close();
                con_sql.Open();

                tablo2_sql = new DataTable();

                da_sql = new OleDbDataAdapter("select * from girisPsyword order by id asc", con_sql);
                tablo2_sql.Clear();
                da_sql.Fill(tablo2_sql);
                girisPsyword.Invoke((MethodInvoker)(() => girisPsyword.DataSource = tablo2_sql));

                con_sql.Close();
            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı kurulamadı ancak veriler kurtarıldı, lütfen durumu araştırmacılara haber veriniz... (hata kodu: ilkgungörev, griddoldur1)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daylogin t = new daylogin();
                t.Show();
                this.Hide();
            }
        }
        void bas()
        {
            xxx.muzikler();
            string yol = xxx.sesler[11].ToString();
            player.SoundLocation = yol;
            player.Play();
        }
        gamecondition oyun = new gamecondition();
        void netcheck()
        {
            try
            {
                bool durum = true;
                do
                {
                    if (NetworkInterface.GetIsNetworkAvailable() == true)
                    {
                        durum = !durum;
                    }
                }
                while (durum);
            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı kurulamadı ancak veriler kurtarıldı, lütfen durumu araştırmacılara haber veriniz... (hata kodu: ilkgungörev, netcheck)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daylogin t = new daylogin();
                t.Show();
                this.Hide();
            }
        }
        void kelimeekle()
        {
            DataView dv3 = tablo_sql.DefaultView;
            dv3.RowFilter = "gosterge Like '" + ifade + "%'";
            gridword.DataSource = dv3;

            kelimeler.Add(gridword.Rows[0].Cells[0].Value.ToString());
            kelimeler_kelimesayisi.Add(Convert.ToInt32(gridword.Rows[0].Cells[1].Value.ToString()));
            kelimeler_soru.Add(gridword.Rows[0].Cells[4].Value.ToString());
            kelimeler_id.Add(Convert.ToInt32(gridword.Rows[0].Cells[5].Value.ToString()));
            font.Add(Convert.ToInt32(gridword.Rows[0].Cells[6].Value.ToString()));
        }
        void yenisoru()
        {
            //eğer uygulama bitmişse
            #region
            if (kelimesayac == 24)
            {
                //şimdi burada veriler alınacak

                for (int b = 0; b < time_total.Count; b++)
                {
                    time.Items.Add(time_total[b]);
                }

                for (var i = 0; i < time_total.Count; i++)
                {
                    toplam += time_total[i];
                }
                ort = toplam / time_total.Count;


                List<float> floattotal_RT = new List<float>();
                for (int m = 0; m < time.Items.Count; m++)
                {
                    float tpl = ((float)time.Items[m] - ort) * ((float)time.Items[m] - ort);
                    floattotal_RT.Add(tpl);
                }
                float total_RT = floattotal_RT.Sum();
                float varyans_RT = total_RT / 23;
                double d_RT = Convert.ToDouble(varyans_RT);
                double standartsapma_RT = Math.Sqrt(d_RT);

                //90 güven aralığı: ort + (std * 3.29 [1.645 * 2]), iki kuyruklu hipotezler için
                //95 güven aralığı: ort + (std * 3.29 [1.96 * 2]), iki kuyruklu hipotezler için
                double lower = ort - (standartsapma_RT * 3.29);
                double upper = ort + (standartsapma_RT * 3.29);

                double aralik = 0;
                for (int g = 0; g < time.Items.Count; g++)
                {
                    if (upper < Convert.ToDouble(time.Items[g]) || Convert.ToDouble(time.Items[g]) < lower)
                    {
                        aralik++;
                    }
                }

                anlamli_RT_95 = "oran: %" + aralik / 24;

                basla = girisdatetime;
                bitir = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
                string bt = bitir;

                basla = basla.Substring(11, 12);
                bitir = bitir.Substring(11, 12);

                string d1 = basla.Substring(3, 2); //dakikalar
                string d2 = bitir.Substring(3, 2); //dakikalar
                int d1_int = Convert.ToInt32(d1);
                int d2_int = Convert.ToInt32(d2);

                string s1 = basla.Substring(6, 2); //saniyeler
                string s2 = bitir.Substring(6, 2); //saniyeler
                int s1_int = Convert.ToInt32(s1);
                int s2_int = Convert.ToInt32(s2);

                if (d1_int == d2_int)
                {
                    basla = txt_basla.Text.Substring(txt_basla.Text.Length - 6); //12.772
                    bitir = txt_bitir.Text.Substring(txt_bitir.Text.Length - 6);

                    basla_float = (float)Convert.ToDouble(basla);
                    bitir_float = (float)Convert.ToDouble(bitir);

                    if (bitir_float < basla_float)
                    {
                        bbbbb = bitir_float + 60; // 4.949
                        bitir_total_float = bbbbb - basla_float; //total sürenin ilk 4 hanesini almak lazım
                    }
                    else
                    {
                        bitir_total_float = bitir_float - basla_float; //total sürenin ilk 4 hanesini almak lazım
                    }
                }
                else if (d2_int > d1_int)
                {
                    basla = txt_basla.Text.Substring(txt_basla.Text.Length - 6); //12.772
                    bitir = txt_bitir.Text.Substring(txt_bitir.Text.Length - 6);

                    basla_float = (float)Convert.ToDouble(basla);
                    bitir_float = (float)Convert.ToDouble(bitir);

                    if (bitir_float < basla_float)
                    {
                        bbbbb = bitir_float + 60; // 4.949
                        bitir_total_float = bbbbb - basla_float; //total sürenin ilk 4 hanesini almak lazım
                    }
                    else
                    {
                        bitir_total_float = bitir_float - basla_float; //total sürenin ilk 4 hanesini almak lazım
                    }


                    if (s2_int >= s1_int)
                    {
                        add_dk = (float)(60.000 * (d2_int - d1_int));
                        bitir_total_float += add_dk;
                    }
                    else if (s1_int > s2_int)
                    {
                        add_dk = (float)(60.000 * (d2_int - d1_int - 1));
                        bitir_total_float += add_dk;
                    }
                }

                string mevcut_x = DateTime.Now.ToString("dd/MM/yyyy");
                string mevcut = mevcut_x.Substring(0, 10);

                if (NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    netcheck();
                }
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    con_sql.Close();

                    cmd_sql = new OleDbCommand();
                    con_sql.Open();
                    cmd_sql.Connection = con_sql;

                    cmd_sql.CommandText = "insert into okumaGroup (kAdi,kGrup,oturum,soru1RT,soru2RT,soru3RT,soru4RT,soru5RT,soru6RT,soru7RT,soru8RT,soru9RT,soru10RT,soru11RT,soru12RT,soru13RT,soru14RT,soru15RT,soru16RT,soru17RT,soru18RT,soru19RT,soru20RT,soru21RT,soru22RT,soru23RT,soru24RT,soruOrtRT,standartSapmaRT,guvenAraligiRT95,ucveriRT95) values (@kAdi,@kGrup,@oturum,@soru1RT,@soru2RT,@soru3RT,@soru4RT,@soru5RT,@soru6RT,@soru7RT,@soru8RT,@soru9RT,@soru10RT,@soru11RT,@soru12RT,@soru13RT,@soru14RT,@soru15RT,@soru16RT,@soru17RT,@soru18RT,@soru19RT,@soru20RT,@soru21RT,@soru22RT,@soru23RT,@soru24RT,@soruOrtRT,@standartSapmaRT,@guvenAraligiRT95,@ucveriRT95)";

                    cmd_sql.Parameters.AddWithValue("@kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("@kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("@oturum", oturum);
                    cmd_sql.Parameters.AddWithValue("@soru1RT", time.Items[0]);
                    cmd_sql.Parameters.AddWithValue("@soru2RT", time.Items[1]);
                    cmd_sql.Parameters.AddWithValue("@soru3RT", time.Items[2]);
                    cmd_sql.Parameters.AddWithValue("@soru4RT", time.Items[3]);
                    cmd_sql.Parameters.AddWithValue("@soru5RT", time.Items[4]);
                    cmd_sql.Parameters.AddWithValue("@soru6RT", time.Items[5]);
                    cmd_sql.Parameters.AddWithValue("@soru7RT", time.Items[6]);
                    cmd_sql.Parameters.AddWithValue("@soru8RT", time.Items[7]);
                    cmd_sql.Parameters.AddWithValue("@soru9RT", time.Items[8]);
                    cmd_sql.Parameters.AddWithValue("@soru10RT", time.Items[9]);
                    cmd_sql.Parameters.AddWithValue("@soru11RT", time.Items[10]);
                    cmd_sql.Parameters.AddWithValue("@soru12RT", time.Items[11]);
                    cmd_sql.Parameters.AddWithValue("@soru13RT", time.Items[12]);
                    cmd_sql.Parameters.AddWithValue("@soru14RT", time.Items[13]);
                    cmd_sql.Parameters.AddWithValue("@soru15RT", time.Items[14]);
                    cmd_sql.Parameters.AddWithValue("@soru16RT", time.Items[15]);
                    cmd_sql.Parameters.AddWithValue("@soru17RT", time.Items[16]);
                    cmd_sql.Parameters.AddWithValue("@soru18RT", time.Items[17]);
                    cmd_sql.Parameters.AddWithValue("@soru19RT", time.Items[18]);
                    cmd_sql.Parameters.AddWithValue("@soru20RT", time.Items[19]);
                    cmd_sql.Parameters.AddWithValue("@soru21RT", time.Items[20]);
                    cmd_sql.Parameters.AddWithValue("@soru22RT", time.Items[21]);
                    cmd_sql.Parameters.AddWithValue("@soru23RT", time.Items[22]);
                    cmd_sql.Parameters.AddWithValue("@soru24RT", time.Items[23]);
                    cmd_sql.Parameters.AddWithValue("@soruOrtRT", ort);
                    cmd_sql.Parameters.AddWithValue("@standartSapmaRT", standartsapma_RT);
                    cmd_sql.Parameters.AddWithValue("@guvenAraligiRT95", "Lower: " + lower + " Upper: " + upper);
                    cmd_sql.Parameters.AddWithValue("@ucveriRT95", anlamli_RT_95);
                    cmd_sql.ExecuteNonQuery();
                    con_sql.Close();

                    griddoldur();

                    DataView dv = tablo2_sql.DefaultView;
                    dv.RowFilter = "kAdi Like '" + dilandlocate.Default.kullaniciadi + "%'";
                    girisPsyword.DataSource = dv;
                    int c = girisPsyword.Rows.Count;

                    con_sql.Close();

                    cmd_sql = new OleDbCommand();
                    con_sql.Open();
                    cmd_sql.Connection = con_sql;

                    cmd_sql.CommandText = "update girisPsyword set kAdi=@kAdi, kGrup=@kGrup, oturum=@oturum, girisDatetime=@girisDatetime, cikisDatetime=@cikisDatetime, totalsure=@totalsure, mevcutDatetime=@mevcutDatetime, kayittamam=@kayittamam where ID=@ID";

                    cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("oturum", oturum);
                    cmd_sql.Parameters.AddWithValue("girisDatetime", girisdatetime);
                    cmd_sql.Parameters.AddWithValue("cikisDatetime", bt);
                    cmd_sql.Parameters.AddWithValue("totalsure", bitir_total_float);
                    cmd_sql.Parameters.AddWithValue("mevcutDatetime", mevcut);
                    cmd_sql.Parameters.AddWithValue("kayittamam", "evet");
                    cmd_sql.Parameters.AddWithValue("id", girisPsyword.Rows[c - 1].Cells[8].Value.ToString());

                    cmd_sql.ExecuteNonQuery();

                    con_sql.Close();

                    griddoldur();

                    DataView dv2 = tablo2_sql.DefaultView;
                    dv2.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + mevcut + "%'";
                    girisPsyword.DataSource = dv2;
                    int c2 = girisPsyword.Rows.Count;

                    if (c2 == 2)
                    {
                        string xx = DateTime.Now.ToString("dd/MM/yyyy");
                        DateTime myDate = DateTime.Parse(xx);
                        string jj = myDate.AddDays(1).ToString();
                        string j = jj.Substring(0, 10);
                        int y = oturum + 1;

                        con_sql.Close();

                        cmd_sql = new OleDbCommand();
                        con_sql.Open();
                        cmd_sql.Connection = con_sql;

                        cmd_sql.CommandText = "insert into girisPsyword (kAdi,kGrup,oturum,girisDatetime,cikisDatetime,totalsure,mevcutDatetime,kayittamam) values (@kAdi,@kGrup,@oturum,@girisDatetime,@cikisDatetime,@totalsure,@mevcutDatetime,@kayittamam)";
                        cmd_sql.Parameters.AddWithValue("@kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("@kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("@oturum", y);
                        cmd_sql.Parameters.AddWithValue("@girisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("@cikisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("@totalsure", "");
                        cmd_sql.Parameters.AddWithValue("@mevcutDatetime", j);
                        cmd_sql.Parameters.AddWithValue("@kayittamam", "hayir");

                        cmd_sql.ExecuteNonQuery();

                        con_sql.Close();
                    }
                    else
                    {
                        int y = oturum + 1;

                        con_sql.Close();

                        cmd_sql = new OleDbCommand();
                        con_sql.Open();
                        cmd_sql.Connection = con_sql;

                        cmd_sql.CommandText = "insert into girisPsyword (kAdi,kGrup,oturum,girisDatetime,cikisDatetime,totalsure,mevcutDatetime,kayittamam) values (@kAdi,@kGrup,@oturum,@girisDatetime,@cikisDatetime,@totalsure,@mevcutDatetime,@kayittamam)";
                        cmd_sql.Parameters.AddWithValue("@kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("@kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("@oturum", y);
                        cmd_sql.Parameters.AddWithValue("@girisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("@cikisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("@totalsure", "");
                        cmd_sql.Parameters.AddWithValue("@mevcutDatetime", mevcut);
                        cmd_sql.Parameters.AddWithValue("@kayittamam", "hayir");

                        cmd_sql.ExecuteNonQuery();

                        con_sql.Close();
                    }

                    daylogin f = new daylogin();
                    f.Show();
                    this.Hide();
                }
            }
            #endregion

            //eğer uygulama bitmemişse
            #region
            else
            {
                try
                {

                }
                catch
                {
                    MessageBox.Show("Garip bir hata ile karşılaşıldı, ana menüye iletilmektesiniz eğer oturumunuz tamamlanmadıysa tamamlamanız bizim açımızdan oldukça kritiktir...(hata kodu: yenikelime, ilkgun_gorev)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    daylogin t = new daylogin();
                    t.Show();
                    this.Hide();
                }

                if (font[kelimeindex] == 30)
                {
                    line1.Text = kelimeler_soru.ElementAt(kelimeindex).ToString();

                    line1.Enabled = true;
                    line1.BringToFront();
                    line1.Visible = true;

                    line21.Enabled = false;
                    line22.Enabled = false;
                    line21.SendToBack();
                    line22.SendToBack();
                    line21.Visible = false;
                    line22.Visible = false;

                    line31.Enabled = false;
                    line32.Enabled = false;
                    line33.Enabled = false;
                    line31.SendToBack();
                    line32.SendToBack();
                    line33.SendToBack();
                    line31.Visible = false;
                    line32.Visible = false;
                    line33.Visible = false;

                    line1.Location = new Point(232, 455);
                    line1.Size = new Size(1457, 162);

                    line21.Location = new Point(0, 0);
                    line21.Size = new Size(1457, 81);
                    line22.Location = new Point(0, 0);
                    line22.Size = new Size(1457, 81);

                    line31.Location = new Point(0, 0);
                    line31.Size = new Size(1457, 54);
                    line32.Location = new Point(0, 0);
                    line32.Size = new Size(1457, 54);
                    line33.Location = new Point(0, 0);
                    line33.Size = new Size(1457, 54);
                    
                    float font_oran = (30 * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        line1.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }
                    
                    line1.AutoSize = true;
                    int uckisim = line1.Location.X + line1.Size.Width;
                    int eklenecek = (1689 - uckisim) / 2;
                    line1.Width += eklenecek;
                    line1.Location = new Point(line1.Location.X + eklenecek, line1.Location.Y);
                }
                else if (font[kelimeindex] == 28)
                {
                    int harfsayisi = kelimeler_soru.ElementAt(kelimeindex).Length;

                    words = kelimeler_soru.ElementAt(kelimeindex).Split(' ');
                    foreach (string word in words)
                    {
                        k.Add(word);
                    }

                    Array.Clear(words, 0, words.Length);

                    int oran = (k.Count / 3) * 2;

                    for (int e = 0; e < oran; e++)
                    {
                        line21.Text += k.ElementAt(e).ToString() + " ";
                    }
                    for (int f = oran; f < k.Count; f++)
                    {
                        line22.Text += k.ElementAt(f).ToString() + " ";
                    }

                    line1.Enabled = false;
                    line1.SendToBack();
                    line1.Visible = false;

                    line21.Enabled = true;
                    line22.Enabled = true;
                    line21.BringToFront();
                    line22.BringToFront();
                    line21.Visible = true;
                    line22.Visible = true;

                    line31.Enabled = false;
                    line32.Enabled = false;
                    line33.Enabled = false;
                    line31.SendToBack();
                    line32.SendToBack();
                    line33.SendToBack();
                    line31.Visible = false;
                    line32.Visible = false;
                    line33.Visible = false;

                    line1.Location = new Point(0, 0);
                    line1.Size = new Size(1457, 162);

                    line21.Location = new Point(232, 455);
                    line21.Size = new Size(1457, 81);
                    line22.Location = new Point(232, 536);
                    line22.Size = new Size(1457, 81);

                    line31.Location = new Point(0, 0);
                    line31.Size = new Size(1457, 54);
                    line32.Location = new Point(0, 0);
                    line32.Size = new Size(1457, 54);
                    line33.Location = new Point(0, 0);
                    line33.Size = new Size(1457, 54);
                    
                    float font_oran = (28 * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        line21.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                        line22.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }
                    
                    line21.AutoSize = true;
                    int uckisim = line21.Location.X + line21.Size.Width;
                    int eklenecek = (1689 - uckisim) / 2;
                    line21.Width += eklenecek;
                    line21.Location = new Point(line21.Location.X + eklenecek, line21.Location.Y);

                    line22.AutoSize = true;
                    int uckisim_ = line22.Location.X + line22.Size.Width;
                    int eklenecek_ = (1689 - uckisim_) / 2;
                    line22.Width += eklenecek;
                    line22.Location = new Point(line22.Location.X + eklenecek_, line22.Location.Y);
                }
                else if (font[kelimeindex] == 24)
                {
                    int harfsayisi = kelimeler_soru.ElementAt(kelimeindex).Length;

                    words = kelimeler_soru.ElementAt(kelimeindex).Split(' ');
                    foreach (string word in words)
                    {
                        k.Add(word);
                    }

                    Array.Clear(words, 0, words.Length);

                    int meh = k.Count / 3;

                    for (int e = 0; e < meh; e++)
                    {
                        line31.Text += k.ElementAt(e).ToString() + " ";
                    }
                    for (int f = meh; f < meh * 2; f++)
                    {
                        line32.Text += k.ElementAt(f).ToString() + " ";
                    }
                    for (int f = meh * 2; f < k.Count; f++)
                    {
                        line33.Text += k.ElementAt(f).ToString() + " ";
                    }

                    line1.Enabled = false;
                    line1.SendToBack();
                    line1.Visible = false;

                    line21.Enabled = false;
                    line22.Enabled = false;
                    line21.SendToBack();
                    line22.SendToBack();
                    line21.Visible = false;
                    line22.Visible = false;

                    line31.Enabled = true;
                    line32.Enabled = true;
                    line33.Enabled = true;
                    line31.BringToFront();
                    line32.BringToFront();
                    line33.BringToFront();
                    line31.Visible = true;
                    line32.Visible = true;
                    line33.Visible = true;

                    line1.Location = new Point(0, 0);
                    line1.Size = new Size(1457, 162);

                    line21.Location = new Point(0, 0);
                    line21.Size = new Size(1457, 81);
                    line22.Location = new Point(0, 0);
                    line22.Size = new Size(1457, 81);

                    line31.Location = new Point(232, 455);
                    line31.Size = new Size(1457, 54);
                    line32.Location = new Point(232, 509);
                    line32.Size = new Size(1457, 54);
                    line33.Location = new Point(232, 563);
                    line33.Size = new Size(1457, 54);

                    float font_oran = (24 * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        line31.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                        line32.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                        line33.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    line31.AutoSize = true;
                    int uckisim = line31.Location.X + line31.Size.Width;
                    int eklenecek = (1689 - uckisim) / 2;
                    line31.Width += eklenecek;
                    line31.Location = new Point(line31.Location.X + eklenecek, line31.Location.Y);

                    line32.AutoSize = true;
                    int uckisim_ = line32.Location.X + line32.Size.Width;
                    int eklenecek_ = (1689 - uckisim_) / 2;
                    line32.Width += eklenecek;
                    line32.Location = new Point(line32.Location.X + eklenecek_, line32.Location.Y);

                    line33.AutoSize = true;
                    int _uckisim_ = line33.Location.X + line33.Size.Width;
                    int _eklenecek_ = (1689 - _uckisim_) / 2;
                    line33.Width += eklenecek;
                    line33.Location = new Point(line33.Location.X + _eklenecek_, line33.Location.Y);
                }

                lblwordcount.Invoke((MethodInvoker)(() => lblwordcount.Text = Convert.ToString(sorusayi) + "/24"));
                lslword.Invoke((MethodInvoker)(() => lslword.Text = kelimeler.ElementAt(kelimeindex).ToString()));
                kelimeindex++;
                kelimesayac++;
                sorusayi++;

                pctscreen.Image = Properties.Resources.arayuz_min;
                //parametre geçerli mi değil resources için?

                if (baslangic == 0)
                {
                    timestamp = DateTime.Now.ToString("mm:ss.fff");
                    txt_basla.Text = timestamp;
                    baslangic++;
                }

                timestamp_guncel = DateTime.Now.ToString("mm:ss.fff");
                txt_basla_guncel.Text = timestamp_guncel;
            }
            #endregion
        }
        private float GetNewPixels(float pixelsDPI96, float dpi)
        {
            return pixelsDPI96 * 96 / dpi;
        }
        private void ilkgun_gorev_Load(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                float dpii = g.DpiY;
                float newFontSize = GetNewPixels(53f, dpii);
                lblwordcount.Font = new Font("Alata", 82f, GraphicsUnit.Pixel);
                lslword.Font = new Font("Alata", 40f, GraphicsUnit.Pixel);
            }

            lslword.Parent = pctscreen;
            lblwordcount.Parent = pctscreen;
            pnlclose.Parent = pctscreen;
            pnlcontinue.Parent = pctscreen;
            line1.Parent = pctscreen;
            line21.Parent = pctscreen;
            line22.Parent = pctscreen;
            line31.Parent = pctscreen;
            line32.Parent = pctscreen;
            line33.Parent = pctscreen;

            int arttir = 1;

            for (int i = 3; i < 15;)
            {
                if (arttir == 3)
                {
                    arttir = 1;
                    i++;
                }
                else
                {
                    arttir++;
                    kelimesiralari.Add(i);
                }
            }

            con_sql.Close();
            con_sql.Open();

            tablo_sql = new DataTable();

            da_sql = new OleDbDataAdapter("select * from kelimeler order by id", con_sql);
            tablo_sql.Clear();
            da_sql.Fill(tablo_sql);
            gridword.DataSource = tablo_sql;

            tablo2_sql = new DataTable();

            da2_sql = new OleDbDataAdapter("select * from girisPsyword order by id asc", con_sql);
            tablo2_sql.Clear();
            da2_sql.Fill(tablo2_sql);
            gridparticipant.DataSource = tablo2_sql;

            con_sql.Close();

            kullaniciadi = dilandlocate.Default.kullaniciadi;
            kullanicigrup = dilandlocate.Default.kullanicigrup;

            griddoldur();

            DataView dv2 = tablo2_sql.DefaultView;
            dv2.RowFilter = "kAdi Like '" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv2;

            if (girisPsyword.Rows.Count == 1) //AB
            {
                oturum = 1;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "A"; //3A

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "B"; //3B

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 2)//CD
            {
                oturum = 2;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "C"; //3C

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "D"; //3D

                        kelimeekle();
                    }
                }
            }

            else if (girisPsyword.Rows.Count == 3) //AB
            {
                oturum = 3;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "A"; //3A

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "B"; //3B

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 4)//CD
            {
                oturum = 4;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "C"; //3C

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "D"; //3D

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 5)//AC
            {
                oturum = 5;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "A"; //3A

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "C"; //3C

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 6)//BD
            {
                oturum = 6;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "B"; //3B

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "D"; //3D

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 7)//BC
            {
                oturum = 7;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "B"; //3B

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "C"; //3C

                        kelimeekle();
                    }
                }
            }
            else if (girisPsyword.Rows.Count == 8)//AD
            {
                oturum = 8;

                for (int i = 0; i < kelimesiralari.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ifade = kelimesiralari[i].ToString() + "A"; //3A

                        kelimeekle();
                    }
                    else
                    {
                        ifade = kelimesiralari[i].ToString() + "D"; //3D

                        kelimeekle();
                    }
                }
            }

            girisdatetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
            oyun.muzikler();
            yenisoru();
        }
    }
}
