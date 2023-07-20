using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection con_sql = new SqlConnection("Server=tcp:78.135.105.180,1433;Initial Catalog=newpsyword;Persist Security Info=False;User ID=psyword;Password=HARDWAWERWARE1.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30");
        SqlCommand cmd_sql;
        DataTable tablo_sql, tablo2_sql;
        SqlDataAdapter da_sql, da2_sql;

        gamecondition xxx = new gamecondition();
        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        TextBox txt_basla = new TextBox();
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
        int kelimesayac = 0, kelimeindex = 0, oturum, sayyy = 0;
        string kullaniciadi, kullanicigrup, ifade, timestamp, basla, bitir, girisdatetime, anlamli_RT_95, j;
        int  sorusayi = 1;
        private void pnl_ilerle_Click(object sender, EventArgs e)
        {
            bas();

            timestamp = DateTime.UtcNow.ToString("mm:ss.fff");
            txt_bitir.Text = timestamp;

            basla = txt_basla.Text.Substring(txt_basla.Text.Length - 9); //42:12.772 (saat yok, en baştaki dakika)
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

                da_sql = new SqlDataAdapter("filterGirisPsyword", con_sql);
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
        void ilkasama()
        {
            for (int b = 0; b < time_total.Count; b++)
            {
                time.Items.Add(time_total[b]);
            }

            for (var i = 0; i < time_total.Count; i++)
            {
                toplam += time_total[i];
            }
            ort = toplam / time_total.Count;
        }
        void ikinciasama()
        {
            string mevcut_x = DateTime.Now.ToString("dd/MM/yyyy");
            string mevcut = mevcut_x.Substring(0, 10);

            griddoldur();

            DataView dv = tablo2_sql.DefaultView;
            dv.RowFilter = "kAdi Like '" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.Invoke((MethodInvoker)(() => girisPsyword.DataSource = dv));
            int c = girisPsyword.Rows.Count;

            con_sql.Close();
            con_sql.Open();

            cmd_sql = new SqlCommand("guncelleGirisPsyword", con_sql)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
            cmd_sql.Parameters.AddWithValue("oturum", oturum);
            cmd_sql.Parameters.AddWithValue("girisDatetime", girisdatetime);
            cmd_sql.Parameters.AddWithValue("cikisDatetime", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture));
            cmd_sql.Parameters.AddWithValue("totalsureDatetime", "");
            cmd_sql.Parameters.AddWithValue("mevcutDatetime", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd_sql.Parameters.AddWithValue("kayittamam", "evet");
            cmd_sql.Parameters.AddWithValue("id", girisPsyword.Rows[c - 1].Cells[8].Value.ToString());

            cmd_sql.ExecuteNonQuery();

            con_sql.Close();

            griddoldur();

            DataView dv2 = tablo2_sql.DefaultView;
            dv2.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + dilandlocate.Default.kullaniciadi + "%' and mevcutDatetime like '%" + mevcut + "%'";
            girisPsyword.Invoke((MethodInvoker)(() => girisPsyword.DataSource = dv2));
            int c2 = girisPsyword.Rows.Count;

            if (c2 == 2)
            {
                string xx = DateTime.Now.ToString("dd/MM/yyyy");
                string karakter_x = xx.Substring(2, 1);
                string arttir = xx.Substring(0, 2);
                int deg = Convert.ToInt32(arttir);
                int art = deg + 1;

                int y = oturum + 1;

                string mevcut_ay = mevcut_x.Substring(3, 2); //12 ya da 01

                if (mevcut_ay == "12")
                {
                    j = art + karakter_x + "12" + karakter_x + "2022";
                }
                else if (mevcut_ay == "01")
                {
                    j = art + karakter_x + "01" + karakter_x + "2023";
                }

                if (art < 10)
                {
                    j = "0" + art + karakter_x + "01" + karakter_x + "2023";
                }

                con_sql.Close();
                con_sql.Open();

                cmd_sql = new SqlCommand("ekleGirisPsyword", con_sql)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd_sql.CommandType = CommandType.StoredProcedure;
                cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                cmd_sql.Parameters.AddWithValue("oturum", y);
                cmd_sql.Parameters.AddWithValue("girisDatetime", "");
                cmd_sql.Parameters.AddWithValue("cikisDatetime", "");
                cmd_sql.Parameters.AddWithValue("totalsureDatetime", "");
                cmd_sql.Parameters.AddWithValue("mevcutDatetime", j);
                cmd_sql.Parameters.AddWithValue("kayittamam", "hayir");

                cmd_sql.ExecuteNonQuery();

                con_sql.Close();
            }
            else
            {
                int y = oturum + 1;

                con_sql.Close();
                con_sql.Open();

                cmd_sql = new SqlCommand("ekleGirisPsyword", con_sql)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                cmd_sql.Parameters.AddWithValue("oturum", y);
                cmd_sql.Parameters.AddWithValue("girisDatetime", "");
                cmd_sql.Parameters.AddWithValue("cikisDatetime", "");
                cmd_sql.Parameters.AddWithValue("totalsureDatetime", "");
                cmd_sql.Parameters.AddWithValue("mevcutDatetime", mevcut);
                cmd_sql.Parameters.AddWithValue("kayittamam", "hayir");

                cmd_sql.ExecuteNonQuery();

                con_sql.Close();
            }

            con_sql.Close();
            con_sql.Open();

            daylogin t = new daylogin();
            t.Show();
            this.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayyy++;

            try
            {
                if (sayyy == 1800) //yarım saat
                {
                    if (time_total.Count == 0)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    } 
                    else if (time_total.Count == 1)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 2)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 3)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 4)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 5)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 6)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 7)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 8)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 9)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 10)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 11)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 12)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 13)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 14)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 15)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 16)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 17)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 18)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 19)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 20)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", time.Items[19]);
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 21)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", time.Items[19]);
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", time.Items[20]);
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 22)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", time.Items[19]);
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", time.Items[20]);
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", time.Items[21]);
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", "");
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }
                    else if (time_total.Count == 23)
                    {
                        ilkasama();

                        if (NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            netcheck();
                        }
                        if (NetworkInterface.GetIsNetworkAvailable() == true)
                        {
                            con_sql.Close();
                            con_sql.Open();

                            cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                            cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                            cmd_sql.Parameters.AddWithValue("oturum", oturum);
                            cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                            cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                            cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                            cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                            cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                            cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                            cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                            cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                            cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                            cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                            cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                            cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                            cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                            cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                            cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                            cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                            cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                            cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                            cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                            cmd_sql.Parameters.AddWithValue("soru20IdRT", time.Items[19]);
                            cmd_sql.Parameters.AddWithValue("soru21IdRT", time.Items[20]);
                            cmd_sql.Parameters.AddWithValue("soru22IdRT", time.Items[21]);
                            cmd_sql.Parameters.AddWithValue("soru23IdRT", time.Items[22]);
                            cmd_sql.Parameters.AddWithValue("soru24IdRT", "");
                            cmd_sql.ExecuteNonQuery();

                            con_sql.Close();
                        }

                        ikinciasama();
                    }

                    time_total.Clear();
                    timer1.Stop();
                }
            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı kurulamadı ancak veriler kurtarıldı, lütfen durumu araştırmacılara haber veriniz... (hata kodu: ilkgungörev, timer1_tick)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            kelimeler_soru.Add(gridword.Rows[0].Cells[3].Value.ToString());
            kelimeler_id.Add(Convert.ToInt32(gridword.Rows[0].Cells[5].Value.ToString()));
            font.Add(Convert.ToInt32(gridword.Rows[0].Cells[7].Value.ToString()));
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

                double guven_RT_95 = standartsapma_RT / (Math.Sqrt(24));
                double hatapayi_95 = ((float)1.714) * (guven_RT_95);
                double guvenaraliği_RT_1_95 = ort - hatapayi_95;
                double guvenaraliği_RT_2_95 = ort + hatapayi_95;

                string guvenaraligi_RT_95 = guvenaraliği_RT_1_95 + " ve " + guvenaraliği_RT_2_95;

                double aralik = 0;
                for (int g = 0; g < time.Items.Count; g++)
                {
                    if (guvenaraliği_RT_1_95 < time_total.ElementAt(g))
                    {
                        if (time_total.ElementAt(g) < guvenaraliği_RT_2_95)
                        {
                            aralik++;
                        }
                    }
                }

                double oran = aralik / 24;

                if (oran > 0.95)
                {
                    anlamli_RT_95 = "anlamlı,(mı?) hepsini nasıl eşit dikkat ayırdı? " + "oran: " + Convert.ToString(oran);
                }
                else
                {
                    anlamli_RT_95 = "anlamsız, " + "oran: " + Convert.ToString(oran);
                }

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
                    con_sql.Open();

                    cmd_sql = new SqlCommand("ekleOkumaGroup", con_sql)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("oturum", oturum);
                    cmd_sql.Parameters.AddWithValue("soru1IdRT", time.Items[0]);
                    cmd_sql.Parameters.AddWithValue("soru2IdRT", time.Items[1]);
                    cmd_sql.Parameters.AddWithValue("soru3IdRT", time.Items[2]);
                    cmd_sql.Parameters.AddWithValue("soru4IdRT", time.Items[3]);
                    cmd_sql.Parameters.AddWithValue("soru5IdRT", time.Items[4]);
                    cmd_sql.Parameters.AddWithValue("soru6IdRT", time.Items[5]);
                    cmd_sql.Parameters.AddWithValue("soru7IdRT", time.Items[6]);
                    cmd_sql.Parameters.AddWithValue("soru8IdRT", time.Items[7]);
                    cmd_sql.Parameters.AddWithValue("soru9IdRT", time.Items[8]);
                    cmd_sql.Parameters.AddWithValue("soru10IdRT", time.Items[9]);
                    cmd_sql.Parameters.AddWithValue("soru11IdRT", time.Items[10]);
                    cmd_sql.Parameters.AddWithValue("soru12IdRT", time.Items[11]);
                    cmd_sql.Parameters.AddWithValue("soru13IdRT", time.Items[12]);
                    cmd_sql.Parameters.AddWithValue("soru14IdRT", time.Items[13]);
                    cmd_sql.Parameters.AddWithValue("soru15IdRT", time.Items[14]);
                    cmd_sql.Parameters.AddWithValue("soru16IdRT", time.Items[15]);
                    cmd_sql.Parameters.AddWithValue("soru17IdRT", time.Items[16]);
                    cmd_sql.Parameters.AddWithValue("soru18IdRT", time.Items[17]);
                    cmd_sql.Parameters.AddWithValue("soru19IdRT", time.Items[18]);
                    cmd_sql.Parameters.AddWithValue("soru20IdRT", time.Items[19]);
                    cmd_sql.Parameters.AddWithValue("soru21IdRT", time.Items[20]);
                    cmd_sql.Parameters.AddWithValue("soru22IdRT", time.Items[21]);
                    cmd_sql.Parameters.AddWithValue("soru23IdRT", time.Items[22]);
                    cmd_sql.Parameters.AddWithValue("soru24IdRT", time.Items[23]);
                    cmd_sql.ExecuteNonQuery();
                    con_sql.Close();

                    griddoldur();

                    DataView dv = tablo2_sql.DefaultView;
                    dv.RowFilter = "kAdi Like '" + dilandlocate.Default.kullaniciadi + "%'";
                    girisPsyword.DataSource = dv;
                    int c = girisPsyword.Rows.Count;

                    con_sql.Close();
                    con_sql.Open();

                    cmd_sql = new SqlCommand("guncelleGirisPsyword", con_sql)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("oturum", oturum);
                    cmd_sql.Parameters.AddWithValue("girisDatetime", girisdatetime);
                    cmd_sql.Parameters.AddWithValue("cikisDatetime", bt);
                    cmd_sql.Parameters.AddWithValue("totalsureDatetime", bitir_total_float);
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
                        string karakter_x = xx.Substring(2, 1);
                        string arttir = xx.Substring(0, 2);
                        int deg = Convert.ToInt32(arttir);
                        int art = deg + 1;

                        int y = oturum + 1;

                        string mevcut_ay = mevcut_x.Substring(3, 2); //12 ya da 01

                        if (mevcut_ay == "12")
                        {
                            j = art + karakter_x + "12" + karakter_x + "2022";
                        }
                        else if (mevcut_ay == "01")
                        {
                            j = art + karakter_x + "01" + karakter_x + "2023";
                        }

                        if (art < 10)
                        {
                            j = "0" + art + karakter_x + "01" + karakter_x + "2023";
                        }

                        con_sql.Close();
                        con_sql.Open();

                        cmd_sql = new SqlCommand("ekleGirisPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("oturum", y);
                        cmd_sql.Parameters.AddWithValue("girisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("cikisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("totalsureDatetime", "");
                        cmd_sql.Parameters.AddWithValue("mevcutDatetime", j);
                        cmd_sql.Parameters.AddWithValue("kayittamam", "hayir");

                        cmd_sql.ExecuteNonQuery();

                        con_sql.Close();
                    }
                    else
                    {
                        int y = oturum + 1;

                        con_sql.Close();
                        con_sql.Open();

                        cmd_sql = new SqlCommand("ekleGirisPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("oturum", y);
                        cmd_sql.Parameters.AddWithValue("girisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("cikisDatetime", "");
                        cmd_sql.Parameters.AddWithValue("totalsureDatetime", "");
                        cmd_sql.Parameters.AddWithValue("mevcutDatetime", mevcut);
                        cmd_sql.Parameters.AddWithValue("kayittamam", "hayir");

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

                timestamp = DateTime.Now.ToString("mm:ss.fff");
                txt_basla.Text = timestamp;
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

            da_sql = new SqlDataAdapter("filterKelimeler", con_sql);
            tablo_sql.Clear();
            da_sql.Fill(tablo_sql);
            gridword.DataSource = tablo_sql;

            tablo2_sql = new DataTable();

            da2_sql = new SqlDataAdapter("filterGirisPsyword", con_sql);
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
