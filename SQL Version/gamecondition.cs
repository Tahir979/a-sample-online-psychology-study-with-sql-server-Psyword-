using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

//SERVER BİLGİLERİ!!!
#region
//kullancı adı: CloudSA20449c06

//şifre: Hardwawerware1

//server name: psywordserver.database.windows.net

//connection string: Server=tcp:psywordserver.database.windows.net,1433;Initial Catalog=newpsyword;Persist Security Info=False;User ID=CloudSA20449c06;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3;


/**Programın bağlantı bilgileri;
78.135.105.180
1433
psyword
Hardwawerware1.**/
#endregion

//test sqlserver
#region
/*
using (SqlConnection con = new SqlConnection("Server=tcp:psywordserver.database.windows.net,1433;Initial Catalog=newpsyword;Persist Security Info=False;User ID=CloudSA20449c06;Password=Hardwawerware1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=3"))
{
    try
    {
        con.Open();
        MessageBox.Show("true");
    }
    catch (SqlException)
    {
        MessageBox.Show("false");
    }
}
*/
#endregion

namespace DEMO
{
    public partial class gamecondition : Form
    {
        //DEĞİŞKENLER
        #region
        SqlConnection con_sql = new SqlConnection("Server=tcp:78.135.105.180,1433;Initial Catalog=newpsyword;Persist Security Info=False;User ID=psyword;Password=HARDWAWERWARE1.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30");
        SqlCommand cmd_sql;
        DataTable tablo_sql, tablo2_sql;
        SqlDataAdapter da_sql, da2_sql;

        Random rastgele = new Random();

        int popupsayac = 0, ipucusayac = 0, kelimesayac = 0, anahtar = 0, harf_sayisi = 3, saylan = 0, check = 0, tiklandim_soru = 0, tiklandim_harfalma = 0, kelimeindex = 0, birincikelimeharfsayisi, ikincikelimeharfsayisi, ucuncukelimeharfsayisi, hafiza, pozisyonbelirleyici_x, pozisyon, sayi, satir, deger, location_x, kutucuk, wmplayer, genislik, yukseklik, progres, sonuncukutu, tabindex, odak, oturum, saaat = 0, ddd = 0, yyy = 0, aaaaaaaaaaa = 0;
        float scale, genislik_koordinatx, yukseklik_koordinaty, basla_float, bitir_float, bitir_total_float, bbbbb, add_dk, ort = 0, toplam = 0, ort_popup = 0, toplam_popup = 0;
        string kelime, birincikelime, ikincikelime, ucuncukelime, focuss, namecheck, tus, substring, teyit, harf, harfsayisi, timestamp, basla, bitir, kullaniciadi, kullanicigrup, ifade, girisdatetime;
        string dogruidtotal, yanlisidtotal, harfsayilaritotal, anlamli_RT_95, anlamli_Popup_95,j;
        #endregion

        //ARKAPLAN NESNELERİ VE ÖZELLİKLERİ
        #region
        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        TextBox txt_basla = new TextBox();
        TextBox txt_bitir = new TextBox();

        void griddoldur()
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
        void ilkasama()
        {
            lblwordpoint.Invoke((MethodInvoker)(() => lblwordpoint.Visible = false));
            lbremainingpoint.Invoke((MethodInvoker)(() => lbremainingpoint.Visible = false));
            lblremainingtime.Invoke((MethodInvoker)(() => lblremainingtime.Visible = false));
            lblword.Invoke((MethodInvoker)(() => lblword.Visible = false));
            whiteprogress.Invoke((MethodInvoker)(() => whiteprogress.Visible = false));
            blackprogress.Invoke((MethodInvoker)(() => blackprogress.Visible = false));

            for (int b = 0; b < time_total.Count; b++)
            {
                time.Items.Add(time_total[b]);
            }

            for (int f = 0; f < popup_count.Count; f++)
            {
                popup.Items.Add(popup_count[f]);
            }

            for (var i = 0; i < time_total.Count; i++)
            {
                toplam += time_total[i];
            }
            ort = toplam / time_total.Count;

            for (int e = 0; e < popup_count.Count; e++)
            {
                toplam_popup += popup_count[e];
            }
            ort_popup = toplam_popup / popup_count.Count;

            dogruidtotal = string.Join(",", dogruYanitId.ToArray());
            yanlisidtotal = string.Join(",", yanlisYanitId.ToArray());
            harfsayilaritotal = string.Join(",", harfsayilarii.ToArray());
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
        private void timer3_Tick(object sender, EventArgs e)
        {
            if(lblremainingtime.Text == "0:00")
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", "");
                        cmd_sql.Parameters.AddWithValue("soru2RT", "");
                        cmd_sql.Parameters.AddWithValue("soru3RT", "");
                        cmd_sql.Parameters.AddWithValue("soru4RT", "");
                        cmd_sql.Parameters.AddWithValue("soru5RT", "");
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", "");
                        cmd_sql.Parameters.AddWithValue("soru3RT", "");
                        cmd_sql.Parameters.AddWithValue("soru4RT", "");
                        cmd_sql.Parameters.AddWithValue("soru5RT", "");
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", "");
                        cmd_sql.Parameters.AddWithValue("soru4RT", "");
                        cmd_sql.Parameters.AddWithValue("soru5RT", "");
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", "");
                        cmd_sql.Parameters.AddWithValue("soru5RT", "");
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", "");
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", "");
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", "");
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", "");
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", "");
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", "");
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", "");
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", "");
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", "");
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", "");
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", "");
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", "");
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", "");
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", "");
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", "");
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                        cmd_sql.Parameters.AddWithValue("soru20RT", "");
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                        cmd_sql.Parameters.AddWithValue("soru20RT", time.Items[19]);
                        cmd_sql.Parameters.AddWithValue("soru21RT", "");
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                        cmd_sql.Parameters.AddWithValue("soru20RT", time.Items[19]);
                        cmd_sql.Parameters.AddWithValue("soru21RT", time.Items[20]);
                        cmd_sql.Parameters.AddWithValue("soru22RT", "");
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                        cmd_sql.Parameters.AddWithValue("soru20RT", time.Items[19]);
                        cmd_sql.Parameters.AddWithValue("soru21RT", time.Items[20]);
                        cmd_sql.Parameters.AddWithValue("soru22RT", time.Items[21]);
                        cmd_sql.Parameters.AddWithValue("soru23RT", "");
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
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

                        cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                        cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                        cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                        cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                        cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                        cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                        cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                        cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                        cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                        cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                        cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                        cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                        cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                        cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                        cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                        cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                        cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                        cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                        cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                        cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                        cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                        cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                        cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                        cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                        cmd_sql.Parameters.AddWithValue("soru20RT", time.Items[19]);
                        cmd_sql.Parameters.AddWithValue("soru21RT", time.Items[20]);
                        cmd_sql.Parameters.AddWithValue("soru22RT", time.Items[21]);
                        cmd_sql.Parameters.AddWithValue("soru23RT", time.Items[22]);
                        cmd_sql.Parameters.AddWithValue("soru24RT", "");
                        cmd_sql.ExecuteNonQuery();

                        con_sql.Close();
                    }

                    ikinciasama();
                }

                time_total.Clear();
                timer3.Stop();
            }
        }

        ListBox time = new ListBox();
        ListBox popup = new ListBox();

        List<string> keys = new List<string>(); //klavyede kutucuklar arasında gezinme
        List<int> kullanici_index = new List<int>(); //kullanıcının girmesi gereken harflerin indeksleri
        List<string> harfler_index = new List<string>(); //harf + index birleşim list'i
        List<string> harfler_kullanici = new List<string>(); //kullanıcının girmesi gereken harfler
        List<string> kullanici = new List<string>(); //kullancının girdiği harfler

        public List<string> sesler = new List<string>(); //oyun içi kullanılacak olan müzikleri listesi
        List<string> renkler = new List<string>(); //kullanıcı harf aldığı zaman arkası yeşil olan kutucukların listesi
        List<int> kelimesiralari = new List<int>(); //gelecek kelimelerin kaç harfli olacağı bu listede
        List<int> kullanilanlar = new List<int>(); //veritabanındaki kullanılmamış kelimeleri yarışmada kullanmamızı sağlayacak olan liste
        List<int> cikarilanlar = new List<int>(); //kelimelerin arasındaki visible = false olan textboxların index değerlerinin listesi
        List<int> acilanlarcopy = new List<int>(); //kutucuklara harf girildikçe girilen harfleri yok ediyoruz ya onlara ipucu filan açmayalım diye, işte tüm açılmış olanların kopyasının listesi bunda
        List<int> acilanlar = new List<int>(); //bunlarda kelimenin kelime sayısı harf sayısı vb. şartlarına göre açılma durumunu belirten liste
        List<int> acilanlar_visible = new List<int>();
        List<string> kelimeler = new List<string>();
        List<int> kelimeler_id = new List<int>();
        List<int> kelimeler_kelimesayisi = new List<int>();
        List<string> kelimeler_soru = new List<string>();
        List<string> time_basla = new List<string>();
        List<string> time_bitir = new List<string>();
        List<float> time_total = new List<float>();
        List<float> popup_count = new List<float>();
        List<int> harfsayilarii = new List<int>();
        List<int> harfsayilarii_gecici = new List<int>();

        List<int> dogruYanit = new List<int>();
        List<int> dogruYanitId = new List<int>();
        List<int> yanlisYanit = new List<int>();
        List<int> yanlisYanitId = new List<int>();
        List<int> harftotal = new List<int>();

        void ozellikler()
        {
            tahir0.Parent = pictureBox1;
            tahir1.Parent = pictureBox1;
            tahir2.Parent = pictureBox1;
            tahir3.Parent = pictureBox1;
            tahir4.Parent = pictureBox1;
            tahir5.Parent = pictureBox1;
            tahir6.Parent = pictureBox1;
            tahir7.Parent = pictureBox1;
            tahir8.Parent = pictureBox1;
            tahir9.Parent = pictureBox1;
            tahir10.Parent = pictureBox1;
            tahir11.Parent = pictureBox1;
            tahir12.Parent = pictureBox1;
            tahir13.Parent = pictureBox1;
            tahir14.Parent = pictureBox1;
            tahir15.Parent = pictureBox1;

            lblwordpoint.Parent = pictureBox1;
            lbremainingpoint.Parent = pictureBox1;
            lblword.Parent = pictureBox1;
            lblremainingtime.Parent = pictureBox1;
            lbltotalpoint.Parent = pictureBox1;
            lblbesttotalpoint.Parent = pictureBox1;
            whiteprogress.Parent = pictureBox1;
            blackprogress.Parent = pictureBox1;

            tahir0.Invoke((MethodInvoker)(() => tahir0.BringToFront()));
            tahir1.Invoke((MethodInvoker)(() => tahir1.BringToFront()));
            tahir2.Invoke((MethodInvoker)(() => tahir2.BringToFront()));
            tahir3.Invoke((MethodInvoker)(() => tahir3.BringToFront()));
            tahir4.Invoke((MethodInvoker)(() => tahir4.BringToFront()));
            tahir5.Invoke((MethodInvoker)(() => tahir5.BringToFront()));
            tahir6.Invoke((MethodInvoker)(() => tahir6.BringToFront()));
            tahir7.Invoke((MethodInvoker)(() => tahir7.BringToFront()));
            tahir8.Invoke((MethodInvoker)(() => tahir8.BringToFront()));
            tahir9.Invoke((MethodInvoker)(() => tahir9.BringToFront()));
            tahir10.Invoke((MethodInvoker)(() => tahir10.BringToFront()));
            tahir11.Invoke((MethodInvoker)(() => tahir11.BringToFront()));
            tahir12.Invoke((MethodInvoker)(() => tahir12.BringToFront()));
            tahir13.Invoke((MethodInvoker)(() => tahir13.BringToFront()));
            tahir14.Invoke((MethodInvoker)(() => tahir14.BringToFront()));
            tahir15.Invoke((MethodInvoker)(() => tahir15.BringToFront()));

            tahir0.Invoke((MethodInvoker)(() => tahir0.Texts = ""));
            tahir1.Invoke((MethodInvoker)(() => tahir1.Texts = ""));
            tahir2.Invoke((MethodInvoker)(() => tahir2.Texts = ""));
            tahir3.Invoke((MethodInvoker)(() => tahir3.Texts = ""));
            tahir4.Invoke((MethodInvoker)(() => tahir4.Texts = ""));
            tahir5.Invoke((MethodInvoker)(() => tahir5.Texts = ""));
            tahir6.Invoke((MethodInvoker)(() => tahir6.Texts = ""));
            tahir7.Invoke((MethodInvoker)(() => tahir7.Texts = ""));
            tahir8.Invoke((MethodInvoker)(() => tahir8.Texts = ""));
            tahir9.Invoke((MethodInvoker)(() => tahir9.Texts = ""));
            tahir10.Invoke((MethodInvoker)(() => tahir10.Texts = ""));
            tahir11.Invoke((MethodInvoker)(() => tahir11.Texts = ""));
            tahir12.Invoke((MethodInvoker)(() => tahir12.Texts = ""));
            tahir13.Invoke((MethodInvoker)(() => tahir13.Texts = ""));
            tahir14.Invoke((MethodInvoker)(() => tahir14.Texts = ""));
            tahir15.Invoke((MethodInvoker)(() => tahir15.Texts = ""));

            tahir0.Invoke((MethodInvoker)(() => tahir0.Visible = false));
            tahir1.Invoke((MethodInvoker)(() => tahir1.Visible = false));
            tahir2.Invoke((MethodInvoker)(() => tahir2.Visible = false));
            tahir3.Invoke((MethodInvoker)(() => tahir3.Visible = false));
            tahir4.Invoke((MethodInvoker)(() => tahir4.Visible = false));
            tahir5.Invoke((MethodInvoker)(() => tahir5.Visible = false));
            tahir6.Invoke((MethodInvoker)(() => tahir6.Visible = false));
            tahir7.Invoke((MethodInvoker)(() => tahir7.Visible = false));
            tahir8.Invoke((MethodInvoker)(() => tahir8.Visible = false));
            tahir9.Invoke((MethodInvoker)(() => tahir9.Visible = false));
            tahir10.Invoke((MethodInvoker)(() => tahir10.Visible = false));
            tahir11.Invoke((MethodInvoker)(() => tahir11.Visible = false));
            tahir12.Invoke((MethodInvoker)(() => tahir12.Visible = false));
            tahir13.Invoke((MethodInvoker)(() => tahir13.Visible = false));
            tahir14.Invoke((MethodInvoker)(() => tahir14.Visible = false));
            tahir15.Invoke((MethodInvoker)(() => tahir15.Visible = false));

            tahir0.Invoke((MethodInvoker)(() => tahir0.Location = new Point(0, 0)));
            tahir1.Invoke((MethodInvoker)(() => tahir1.Location = new Point(0, 0)));
            tahir2.Invoke((MethodInvoker)(() => tahir2.Location = new Point(0, 0)));
            tahir3.Invoke((MethodInvoker)(() => tahir3.Location = new Point(0, 0)));
            tahir4.Invoke((MethodInvoker)(() => tahir4.Location = new Point(0, 0)));
            tahir5.Invoke((MethodInvoker)(() => tahir5.Location = new Point(0, 0)));
            tahir6.Invoke((MethodInvoker)(() => tahir6.Location = new Point(0, 0)));
            tahir7.Invoke((MethodInvoker)(() => tahir7.Location = new Point(0, 0)));
            tahir8.Invoke((MethodInvoker)(() => tahir8.Location = new Point(0, 0)));
            tahir9.Invoke((MethodInvoker)(() => tahir9.Location = new Point(0, 0)));
            tahir10.Invoke((MethodInvoker)(() => tahir10.Location = new Point(0, 0)));
            tahir11.Invoke((MethodInvoker)(() => tahir11.Location = new Point(0, 0)));
            tahir12.Invoke((MethodInvoker)(() => tahir12.Location = new Point(0, 0)));
            tahir13.Invoke((MethodInvoker)(() => tahir13.Location = new Point(0, 0)));
            tahir14.Invoke((MethodInvoker)(() => tahir14.Location = new Point(0, 0)));
            tahir15.Invoke((MethodInvoker)(() => tahir15.Location = new Point(0, 0)));

            lblremainingtime.Invoke((MethodInvoker)(() => lblremainingtime.ForeColor = Color.FromArgb(29, 29, 27)));
            lbremainingpoint.Invoke((MethodInvoker)(() => lbremainingpoint.ForeColor = Color.FromArgb(29, 29, 27)));
            lblwordpoint.Invoke((MethodInvoker)(() => lblwordpoint.ForeColor = Color.FromArgb(29, 29, 27)));
            lblword.Invoke((MethodInvoker)(() => lblword.ForeColor = Color.FromArgb(29, 29, 27)));
            lbltotalpoint.Invoke((MethodInvoker)(() => lbltotalpoint.ForeColor = Color.FromArgb(29, 29, 27)));
            lblbesttotalpoint.Invoke((MethodInvoker)(() => lblbesttotalpoint.ForeColor = Color.FromArgb(29, 29, 27)));

            tahir0.Invoke((MethodInvoker)(() => tahir0.BackColor = Color.White));
            tahir1.Invoke((MethodInvoker)(() => tahir1.BackColor = Color.White));
            tahir2.Invoke((MethodInvoker)(() => tahir2.BackColor = Color.White));
            tahir3.Invoke((MethodInvoker)(() => tahir3.BackColor = Color.White));
            tahir4.Invoke((MethodInvoker)(() => tahir4.BackColor = Color.White));
            tahir5.Invoke((MethodInvoker)(() => tahir5.BackColor = Color.White));
            tahir6.Invoke((MethodInvoker)(() => tahir6.BackColor = Color.White));
            tahir7.Invoke((MethodInvoker)(() => tahir7.BackColor = Color.White));
            tahir8.Invoke((MethodInvoker)(() => tahir8.BackColor = Color.White));
            tahir9.Invoke((MethodInvoker)(() => tahir9.BackColor = Color.White));
            tahir10.Invoke((MethodInvoker)(() => tahir10.BackColor = Color.White));
            tahir11.Invoke((MethodInvoker)(() => tahir11.BackColor = Color.White));
            tahir12.Invoke((MethodInvoker)(() => tahir12.BackColor = Color.White));
            tahir13.Invoke((MethodInvoker)(() => tahir13.BackColor = Color.White));
            tahir14.Invoke((MethodInvoker)(() => tahir14.BackColor = Color.White));
            tahir15.Invoke((MethodInvoker)(() => tahir15.BackColor = Color.White));

            tahir0.Invoke((MethodInvoker)(() => tahir0.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir1.Invoke((MethodInvoker)(() => tahir1.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir2.Invoke((MethodInvoker)(() => tahir2.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir3.Invoke((MethodInvoker)(() => tahir3.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir4.Invoke((MethodInvoker)(() => tahir4.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir5.Invoke((MethodInvoker)(() => tahir5.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir6.Invoke((MethodInvoker)(() => tahir6.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir7.Invoke((MethodInvoker)(() => tahir7.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir8.Invoke((MethodInvoker)(() => tahir8.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir9.Invoke((MethodInvoker)(() => tahir9.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir10.Invoke((MethodInvoker)(() => tahir10.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir11.Invoke((MethodInvoker)(() => tahir11.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir12.Invoke((MethodInvoker)(() => tahir12.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir13.Invoke((MethodInvoker)(() => tahir13.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir14.Invoke((MethodInvoker)(() => tahir14.ForeColor = Color.FromArgb(29, 29, 27)));
            tahir15.Invoke((MethodInvoker)(() => tahir15.ForeColor = Color.FromArgb(29, 29, 27)));

            tahir0.Invoke((MethodInvoker)(() => tahir0.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir0.Invoke((MethodInvoker)(() => tahir0.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir1.Invoke((MethodInvoker)(() => tahir1.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir1.Invoke((MethodInvoker)(() => tahir1.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir2.Invoke((MethodInvoker)(() => tahir2.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir2.Invoke((MethodInvoker)(() => tahir2.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir3.Invoke((MethodInvoker)(() => tahir3.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir3.Invoke((MethodInvoker)(() => tahir3.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir4.Invoke((MethodInvoker)(() => tahir4.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir4.Invoke((MethodInvoker)(() => tahir4.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir5.Invoke((MethodInvoker)(() => tahir5.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir5.Invoke((MethodInvoker)(() => tahir5.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir6.Invoke((MethodInvoker)(() => tahir6.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir6.Invoke((MethodInvoker)(() => tahir6.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir7.Invoke((MethodInvoker)(() => tahir7.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir7.Invoke((MethodInvoker)(() => tahir7.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir8.Invoke((MethodInvoker)(() => tahir8.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir8.Invoke((MethodInvoker)(() => tahir8.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir9.Invoke((MethodInvoker)(() => tahir9.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir9.Invoke((MethodInvoker)(() => tahir9.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir10.Invoke((MethodInvoker)(() => tahir10.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir10.Invoke((MethodInvoker)(() => tahir10.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir11.Invoke((MethodInvoker)(() => tahir11.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir11.Invoke((MethodInvoker)(() => tahir11.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir12.Invoke((MethodInvoker)(() => tahir12.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir12.Invoke((MethodInvoker)(() => tahir12.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir13.Invoke((MethodInvoker)(() => tahir13.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir13.Invoke((MethodInvoker)(() => tahir13.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir14.Invoke((MethodInvoker)(() => tahir14.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir14.Invoke((MethodInvoker)(() => tahir14.BorderFocusColor = Color.FromArgb(29, 29, 27)));
            tahir15.Invoke((MethodInvoker)(() => tahir15.BorderColor = Color.FromArgb(29, 29, 27)));
            tahir15.Invoke((MethodInvoker)(() => tahir15.BorderFocusColor = Color.FromArgb(29, 29, 27)));

            tahir0.Invoke((MethodInvoker)(() => tahir0.readonly_x = false));
            tahir1.Invoke((MethodInvoker)(() => tahir1.readonly_x = false));
            tahir2.Invoke((MethodInvoker)(() => tahir2.readonly_x = false));
            tahir3.Invoke((MethodInvoker)(() => tahir3.readonly_x = false));
            tahir4.Invoke((MethodInvoker)(() => tahir4.readonly_x = false));
            tahir5.Invoke((MethodInvoker)(() => tahir5.readonly_x = false));
            tahir6.Invoke((MethodInvoker)(() => tahir6.readonly_x = false));
            tahir7.Invoke((MethodInvoker)(() => tahir7.readonly_x = false));
            tahir8.Invoke((MethodInvoker)(() => tahir8.readonly_x = false));
            tahir9.Invoke((MethodInvoker)(() => tahir9.readonly_x = false));
            tahir10.Invoke((MethodInvoker)(() => tahir10.readonly_x = false));
            tahir11.Invoke((MethodInvoker)(() => tahir11.readonly_x = false));
            tahir12.Invoke((MethodInvoker)(() => tahir12.readonly_x = false));
            tahir13.Invoke((MethodInvoker)(() => tahir13.readonly_x = false));
            tahir14.Invoke((MethodInvoker)(() => tahir14.readonly_x = false));
            tahir15.Invoke((MethodInvoker)(() => tahir15.readonly_x = false));
        }
        void design_two(int x)
        {
            if (x == 1)
            {
                tahir1.Invoke((MethodInvoker)(() => tahir1.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir1.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(1);
                renkler[1] = "white and visible";
            }
            else if (x == 2)
            {
                tahir2.Invoke((MethodInvoker)(() => tahir2.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir2.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(2);
                renkler[2] = "white and visible";
            }
            else if (x == 3)
            {
                tahir3.Invoke((MethodInvoker)(() => tahir3.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir3.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(3);
                renkler[3] = "white and visible";
            }
            else if (x == 4)
            {
                tahir4.Invoke((MethodInvoker)(() => tahir4.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir4.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(4);
                renkler[4] = "white and visible";
            }
            else if (x == 5)
            {
                tahir5.Invoke((MethodInvoker)(() => tahir5.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir5.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(5);
                renkler[5] = "white and visible";
            }
            else if (x == 6)
            {
                tahir6.Invoke((MethodInvoker)(() => tahir6.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir6.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(6);
                renkler[6] = "white and visible";
            }
            else if (x == 7)
            {
                tahir7.Invoke((MethodInvoker)(() => tahir7.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir7.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(7);
                renkler[7] = "white and visible";
            }
            else if (x == 8)
            {
                tahir8.Invoke((MethodInvoker)(() => tahir8.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir8.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(8);
                renkler[8] = "white and visible";
            }
            else if (x == 9)
            {
                tahir9.Invoke((MethodInvoker)(() => tahir9.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir9.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(9);
                renkler[9] = "white and visible";
            }
            else if (x == 10)
            {
                tahir10.Invoke((MethodInvoker)(() => tahir10.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir10.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(10);
                renkler[10] = "white and visible";
            }
            else if (x == 11)
            {
                tahir11.Invoke((MethodInvoker)(() => tahir11.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir11.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(11);
                renkler[11] = "white and visible";
            }
            else if (x == 12)
            {
                tahir12.Invoke((MethodInvoker)(() => tahir12.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir12.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(12);
                renkler[12] = "white and visible";
            }
            else if (x == 13)
            {
                tahir13.Invoke((MethodInvoker)(() => tahir13.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir13.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(13);
                renkler[13] = "white and visible";
            }
            else if (x == 14)
            {
                tahir14.Invoke((MethodInvoker)(() => tahir14.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir14.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(14);
                renkler[14] = "white and visible";
            }
            else if (x == 15)
            {
                tahir15.Invoke((MethodInvoker)(() => tahir15.Location = new Point(dilandlocate.Default.xvalue += Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                location_x = tahir15.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                acilanlar_visible.Add(15);
                renkler[15] = "white and visible";
            }
        }
        void design_one()
        {
            if (hafiza == 1)
            {
                tahir1.Invoke((MethodInvoker)(() => tahir1.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir1.Location.X;
                tahir1.Invoke((MethodInvoker)(() => tahir1.Visible = false));
                renkler[1] = "invisible";
            }
            else if (hafiza == 2)
            {
                tahir2.Invoke((MethodInvoker)(() => tahir2.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir2.Location.X;
                tahir2.Invoke((MethodInvoker)(() => tahir2.Visible = false));
                renkler[2] = "invisible";
            }
            else if (hafiza == 3)
            {
                tahir3.Invoke((MethodInvoker)(() => tahir3.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir3.Location.X;
                tahir3.Invoke((MethodInvoker)(() => tahir3.Visible = false));
                renkler[3] = "invisible";
            }
            else if (hafiza == 4)
            {
                tahir4.Invoke((MethodInvoker)(() => tahir4.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir4.Location.X;
                tahir4.Invoke((MethodInvoker)(() => tahir4.Visible = false));
                renkler[4] = "invisible";
            }
            else if (hafiza == 5)
            {
                tahir5.Invoke((MethodInvoker)(() => tahir5.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir5.Location.X;
                tahir5.Invoke((MethodInvoker)(() => tahir5.Visible = false));
                renkler[5] = "invisible";
            }
            else if (hafiza == 6)
            {
                tahir6.Invoke((MethodInvoker)(() => tahir6.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir6.Location.X;
                tahir6.Invoke((MethodInvoker)(() => tahir6.Visible = false));
                renkler[6] = "invisible";
            }
            else if (hafiza == 7)
            {
                tahir7.Invoke((MethodInvoker)(() => tahir7.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir7.Location.X;
                tahir7.Invoke((MethodInvoker)(() => tahir7.Visible = false));
                renkler[7] = "invisible";
            }
            else if (hafiza == 8)
            {
                tahir8.Invoke((MethodInvoker)(() => tahir8.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir8.Location.X;
                tahir8.Invoke((MethodInvoker)(() => tahir8.Visible = false));
                renkler[8] = "invisible";
            }
            else if (hafiza == 9)
            {
                tahir9.Invoke((MethodInvoker)(() => tahir9.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir9.Location.X;
                tahir9.Invoke((MethodInvoker)(() => tahir9.Visible = false));
                renkler[9] = "invisible";
            }
            else if (hafiza == 10)
            {
                tahir10.Invoke((MethodInvoker)(() => tahir10.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir10.Location.X;
                tahir10.Invoke((MethodInvoker)(() => tahir10.Visible = false));
                renkler[10] = "invisible";
            }
            else if (hafiza == 11)
            {
                tahir11.Invoke((MethodInvoker)(() => tahir11.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir11.Location.X;
                tahir11.Invoke((MethodInvoker)(() => tahir11.Visible = false));
                renkler[11] = "invisible";
            }
            else if (hafiza == 12)
            {
                tahir12.Invoke((MethodInvoker)(() => tahir12.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir12.Location.X;
                tahir12.Invoke((MethodInvoker)(() => tahir12.Visible = false));
                renkler[12] = "invisible";
            }
            else if (hafiza == 13)
            {
                tahir13.Invoke((MethodInvoker)(() => tahir13.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir13.Location.X;
                tahir13.Invoke((MethodInvoker)(() => tahir13.Visible = false));
                renkler[13] = "invisible";
            }
            else if (hafiza == 14)
            {
                tahir14.Invoke((MethodInvoker)(() => tahir14.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir14.Location.X;
                tahir14.Invoke((MethodInvoker)(() => tahir14.Visible = false));
                renkler[14] = "invisible";
            }
            else if (hafiza == 15)
            {
                tahir15.Invoke((MethodInvoker)(() => tahir15.Location = new Point(location_x, Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                dilandlocate.Default.xvalue = tahir15.Location.X;
                tahir15.Invoke((MethodInvoker)(() => tahir15.Visible = false));
                renkler[15] = "invisible";
            }
        }

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }
        private float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            return ScreenScalingFactor;
        }
        void netcheck()
        {
            try
            {
                bool durum = true;
                do
                {
                    if(NetworkInterface.GetIsNetworkAvailable() == true)
                    {
                        durum = !durum;
                    }
                }
                while (durum);
            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı kurulamadı ancak veriler kurtarıldı, lütfen durumu araştırmacılara haber veriniz... (hata kodu: oyun, netcheck)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daylogin t = new daylogin();
                t.Show();
                this.Hide();
            }
        }
        void kelimeekle()
        {
            DataView dv3 = tablo_sql.DefaultView;
            dv3.RowFilter = "gosterge Like '" + ifade + "%'";
            gridwords.DataSource = dv3;

            kelimeler.Add(gridwords.Rows[0].Cells[0].Value.ToString());
            kelimeler_kelimesayisi.Add(Convert.ToInt32(gridwords.Rows[0].Cells[1].Value.ToString()));
            kelimeler_soru.Add(gridwords.Rows[0].Cells[4].Value.ToString());
            kelimeler_id.Add(Convert.ToInt32(gridwords.Rows[0].Cells[5].Value.ToString()));
        }
        void oyunload()
        {
            scale = getScalingFactor();

            //ekran genişliği
            genislik = Screen.PrimaryScreen.Bounds.Width; //1920
            yukseklik = Screen.PrimaryScreen.Bounds.Height; //1080

            //çözünürlük
            genislik_koordinatx = genislik * scale; // 1920 * 2 atıyorum
            yukseklik_koordinaty = yukseklik * scale; // 1080 * 2 atıyorum

            pictureBox1.Image = Properties.Resources.yeni_oyun_ici_min;

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
            gridwords.DataSource = tablo_sql;

            tablo2_sql = new DataTable();

            da2_sql = new SqlDataAdapter("filterGirisPsyword", con_sql);
            tablo2_sql.Clear();
            da2_sql.Fill(tablo2_sql);
            gridparticipants.DataSource = tablo2_sql;

            con_sql.Close();

            kullaniciadi = dilandlocate.Default.kullaniciadi;
            kullanicigrup = dilandlocate.Default.kullanicigrup;

            con_sql.Close();
            con_sql.Open();

            tablo2_sql = new DataTable();

            da_sql = new SqlDataAdapter("filterGirisPsyword", con_sql);
            tablo2_sql.Clear();
            da_sql.Fill(tablo2_sql);
            girisPsyword.DataSource = tablo2_sql;

            con_sql.Close();

            DataView dv2 = tablo2_sql.DefaultView;
            dv2.RowFilter = "kAdi Like '" + dilandlocate.Default.kullaniciadi + "%'";
            girisPsyword.DataSource = dv2;

            if (girisPsyword.Rows.Count == 3) //AB
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

            muzikler();
            ozellikler();
            yenisoru();
        }
        #endregion
        public gamecondition()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
        }
        void bekle()
        {
            lblword.Invoke((MethodInvoker)(() => lblword.Text = ""));

            check++;
            cikarilanlar.Clear();
            kelimesayac++;
            ozellikler();
            //griddoldur();
            yenisoru();
            check = 0;
        }
        public void muzikler()
        {
            //yanit sesi, sesler[0]
            string path = Application.StartupPath;
            string x = path.Substring(0, path.Length - 9);
            string y = "Resources";
            string z = @"\yanit_muzik.wav";
            string topla = x + y + z;

            sesler.Add(topla);

            //harfalma sesi, sesler[1]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\harfalma_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //ipucualma sesi, sesler[2]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\ipucu_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //reklamlagecme sesi, sesler[3]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\reklam_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //pes sesi, sesler[4]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\pes_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //kutucukgecme, sesler[5]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\kutucuk_gecme.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //dogrucevap, sesler[6]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\dogrucevap_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //yanliscevap, sesler[7]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\yanliscevap_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //timer, sesler[8]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\timer.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //süre bitimi, sesler[9]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\sürebitimi_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //oyunsonumüziği, sesler[10]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\oyunsonu_ses.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //anamenü tuşları, sesler[11]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\anamenu_tus.wav";
            topla = x + y + z;

            sesler.Add(topla);

            //giriş müziği, sesler[12]
            path = Application.StartupPath;
            x = path.Substring(0, path.Length - 9);
            y = "Resources";
            z = @"\giris_muzik.wav";
            topla = x + y + z;

            sesler.Add(topla);
        }
        void bas()
        {
            string yol = sesler[11].ToString();
            player.SoundLocation = yol;
            player.Play();
        }
        void timer()
        {
            if(dilandlocate.Default.ses == 1)
            {
                string yol = sesler[8].ToString();
                axWindowsMediaPlayer1.URL = yol;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                wmplayer++;
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            gridunnecessaryfocus.Focus();

            ddd++;
            timer5.Stop();
            cevapcheck();

            gridunnecessaryfocus.Focus();
        }
        void cevapcheck()
        {
            for (int i = 0; i < kullanici.Count; i++)
            {
                string b = kullanici.ElementAt(i).ToString();
                if (String.IsNullOrEmpty(b) == true)
                {
                    kullanici.RemoveAt(i);
                }
            }

            saylan = 0;

            for (int i = 0; i < harfler_kullanici.Count; i++)
            {
                if (harfler_kullanici.ElementAt(i).ToString() == kullanici.ElementAt(i).ToString())
                {
                    saylan++;
                }
            }

            if(saylan != Convert.ToInt32(harfsayisi))
            {
                if (dilandlocate.Default.ses == 1)
                {
                    string yol = sesler[7].ToString();
                    player.SoundLocation = yol;
                    player.Play();
                }

                acilanlar.Clear();
                kullanici.Clear();

                for (int i = 0; i <= kelime.Length; i++)
                {
                    kullanici.Add("");
                }

                //yeşil ve beyaz oluşlarına göre geri eklememiz lazım ama, ipuçları için giden puanın manası olmaz yoksa
                #region
                if (tahir0.Visible == true)
                {
                    if (tahir0.BackColor == Color.White)
                    {
                        tahir0.Texts = "";
                        acilanlar.Add(0);
                    }
                    else if (tahir0.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[0] = tahir0.Texts;
                    }
                }
                if (tahir1.Visible == true)
                {
                    if (tahir1.BackColor == Color.White)
                    {
                        tahir1.Texts = "";
                        acilanlar.Add(1);
                    }
                    else if (tahir1.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[1] = tahir1.Texts;
                    }
                }
                if (tahir2.Visible == true)
                {
                    if (tahir2.BackColor == Color.White)
                    {
                        tahir2.Texts = "";
                        acilanlar.Add(2);
                    }
                    else if (tahir2.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[2] = tahir2.Texts;
                    }
                }
                if (tahir3.Visible == true)
                {
                    if (tahir3.BackColor == Color.White)
                    {
                        tahir3.Texts = "";
                        acilanlar.Add(3);
                    }
                    else if (tahir3.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[3] = tahir3.Texts;
                    }
                }
                if (tahir4.Visible == true)
                {
                    if (tahir4.BackColor == Color.White)
                    {
                        tahir4.Texts = "";
                        acilanlar.Add(4);
                    }
                    else if (tahir4.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[4] = tahir4.Texts;
                    }
                }
                if (tahir5.Visible == true)
                {
                    if (tahir5.BackColor == Color.White)
                    {
                        tahir5.Texts = "";
                        acilanlar.Add(5);
                    }
                    else if (tahir5.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[5] = tahir5.Texts;
                    }
                }
                if (tahir6.Visible == true)
                {
                    if (tahir6.BackColor == Color.White)
                    {
                        tahir6.Texts = "";
                        acilanlar.Add(6);
                    }
                    else if (tahir6.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[6] = tahir6.Texts;
                    }
                }
                if (tahir7.Visible == true)
                {
                    if (tahir7.BackColor == Color.White)
                    {
                        tahir7.Texts = "";
                        acilanlar.Add(7);
                    }
                    else if (tahir7.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[7] = tahir7.Texts;
                    }
                }
                if (tahir8.Visible == true)
                {
                    if (tahir8.BackColor == Color.White)
                    {
                        tahir8.Texts = "";
                        acilanlar.Add(8);
                    }
                    else if (tahir8.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[8] = tahir8.Texts;
                    }
                }
                if (tahir9.Visible == true)
                {
                    if (tahir9.BackColor == Color.White)
                    {
                        tahir9.Texts = "";
                        acilanlar.Add(9);
                    }
                    else if (tahir9.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[9] = tahir9.Texts;
                    }
                }
                if (tahir10.Visible == true)
                {
                    if (tahir10.BackColor == Color.White)
                    {
                        tahir10.Texts = "";
                        acilanlar.Add(10);
                    }
                    else if (tahir10.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[10] = tahir10.Texts;
                    }
                }
                if (tahir11.Visible == true)
                {
                    if (tahir11.BackColor == Color.White)
                    {
                        tahir11.Texts = "";
                        acilanlar.Add(11);
                    }
                    else if (tahir11.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[11] = tahir11.Texts;
                    }
                }
                if (tahir12.Visible == true)
                {
                    if (tahir12.BackColor == Color.White)
                    {
                        tahir12.Texts = "";
                        acilanlar.Add(12);
                    }
                    else if (tahir12.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[12] = tahir12.Texts;
                    }
                }
                if (tahir13.Visible == true)
                {
                    if (tahir13.BackColor == Color.White)
                    {
                        tahir13.Texts = "";
                        acilanlar.Add(13);
                    }
                    else if (tahir13.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[13] = tahir13.Texts;
                    }
                }
                if (tahir14.Visible == true)
                {
                    if (tahir14.BackColor == Color.White)
                    {
                        tahir14.Texts = "";
                        acilanlar.Add(14);
                    }
                    else if (tahir14.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[14] = tahir14.Texts;
                    }
                }
                if (tahir15.Visible == true)
                {
                    if (tahir15.BackColor == Color.White)
                    {
                        tahir15.Texts = "";
                        acilanlar.Add(15);
                    }
                    else if (tahir15.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        kullanici[15] = tahir15.Texts;
                    }
                }
                #endregion

                //yanlış cevap ardından hangi kutucuğa odaklanacak?
                #region
                if (tahir0.BackColor == Color.White && tahir0.Visible == true)
                {
                    tahir0.Focus();
                    tahir0.select(0, 0);
                    kutucuk = 0;
                }
                else if (tahir1.BackColor == Color.White && tahir1.Visible == true)
                {
                    tahir1.Focus();
                    tahir1.select(0, 0);
                    kutucuk = 1;
                }
                else if (tahir2.BackColor == Color.White && tahir2.Visible == true)
                {
                    tahir2.Focus();
                    tahir2.select(0, 0);
                    kutucuk = 2;
                }
                else if (tahir3.BackColor == Color.White && tahir3.Visible == true)
                {
                    tahir3.Focus();
                    tahir3.select(0, 0);
                    kutucuk = 3;
                }
                else if (tahir4.BackColor == Color.White && tahir4.Visible == true)
                {
                    tahir4.Focus();
                    tahir4.select(0, 0);
                    kutucuk = 4;
                }
                else if (tahir5.BackColor == Color.White && tahir5.Visible == true)
                {
                    tahir5.Focus();
                    tahir5.select(0, 0);
                    kutucuk = 5;
                }
                else if (tahir6.BackColor == Color.White && tahir6.Visible == true)
                {
                    tahir6.Focus();
                    tahir6.select(0, 0);
                    kutucuk = 6;
                }
                else if (tahir7.BackColor == Color.White && tahir7.Visible == true)
                {
                    tahir7.Focus();
                    tahir7.select(0, 0);
                    kutucuk = 7;
                }
                else if (tahir8.BackColor == Color.White && tahir8.Visible == true)
                {
                    tahir8.Focus();
                    tahir8.select(0, 0);
                    kutucuk = 8;
                }
                else if (tahir9.BackColor == Color.White && tahir9.Visible == true)
                {
                    tahir9.Focus();
                    tahir9.select(0, 0);
                    kutucuk = 9;
                }
                else if (tahir10.BackColor == Color.White && tahir10.Visible == true)
                {
                    tahir10.Focus();
                    tahir10.select(0, 0);
                    kutucuk = 10;
                }
                else if (tahir11.BackColor == Color.White && tahir11.Visible == true)
                {
                    tahir11.Focus();
                    tahir11.select(0, 0);
                    kutucuk = 11;
                }
                else if (tahir12.BackColor == Color.White && tahir12.Visible == true)
                {
                    tahir12.Focus();
                    tahir12.select(0, 0);
                    kutucuk = 12;
                }
                else if (tahir13.BackColor == Color.White && tahir13.Visible == true)
                {
                    tahir13.Focus();
                    tahir13.select(0, 0);
                    kutucuk = 13;
                }
                else if (tahir14.BackColor == Color.White && tahir14.Visible == true)
                {
                    tahir14.Focus();
                    tahir14.select(0, 0);
                    kutucuk = 14;
                }
                else if (tahir15.BackColor == Color.White && tahir15.Visible == true)
                {
                    tahir15.Focus();
                    tahir15.select(0, 0);
                    kutucuk = 15;
                }
                #endregion
            }
            else if (saylan == Convert.ToInt32(harfsayisi) && ddd == 3)
            {
                ddd = 0;
                timer5.Stop();
                timer4.Stop();
                load.PerformClick();
                timer1.Start();
                gridunnecessaryfocus.Focus();
            }
            else if (saylan == Convert.ToInt32(harfsayisi))
            {
                gridunnecessaryfocus.Focus();

                if (saylan == 3)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                }
                else if(saylan == 4)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                }
                else if (saylan == 5)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                }
                else if (saylan == 6)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Green;
                }
                else if (saylan == 7)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Green;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Green;
                }
                else if (saylan == 8)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Green;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Green;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Green;
                }
                else if (saylan == 9)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Green;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Green;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Green;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Green;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Green;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Green;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Green;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Green;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Green;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Green;
                    }
                }
                else if (saylan == 10)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Green;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Green;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Green;
                    tahir8.ForeColor = Color.White;
                    tahir8.BackColor = Color.Green;
                    tahir9.ForeColor = Color.White;
                    tahir9.BackColor = Color.Green;
                }
                else if (saylan == 11)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Green;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Green;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Green;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Green;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Green;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Green;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Green;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Green;
                    tahir8.ForeColor = Color.White;
                    tahir8.BackColor = Color.Green;
                    tahir9.ForeColor = Color.White;
                    tahir9.BackColor = Color.Green;
                    tahir10.ForeColor = Color.White;
                    tahir10.BackColor = Color.Green;
                }
                else if (saylan == 12)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Green;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Green;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Green;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Green;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Green;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Green;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Green;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Green;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Green;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Green;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Green;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Green;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Green;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Green;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Green;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Green;
                    }
                }
                else if (saylan == 13)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Green;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Green;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Green;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Green;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Green;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Green;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Green;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Green;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Green;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Green;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Green;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Green;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Green;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Green;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Green;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Green;
                    }
                }
                else if (saylan == 14)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Green;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Green;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Green;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Green;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Green;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Green;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Green;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Green;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Green;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Green;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Green;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Green;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Green;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Green;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Green;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Green;
                    }
                }

                if (ddd == 0)
                {
                    timestamp = DateTime.UtcNow.ToString("mm:ss.fff");
                    txt_bitir.Text = timestamp;

                    timer2.Stop();

                    whiteprogress.Visible = false;
                    blackprogress.Visible = false;

                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    wmplayer = 0;

                    if (dilandlocate.Default.ses == 1)
                    {
                        string yol = sesler[6].ToString();
                        player.SoundLocation = yol;
                        player.Play();
                    }

                    string y = lblwordpoint.Text;
                    int cevir1 = Convert.ToInt32(y);

                    string z = lbremainingpoint.Text;
                    int cevir2 = Convert.ToInt32(z);

                    int toplam = cevir1 + cevir2;
                    lblwordpoint.Text = toplam.ToString();

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

                    //Tepki Sürelerinin Verileri Burada!!
                    time_basla.Add(txt_basla.Text);
                    time_bitir.Add(txt_bitir.Text);
                    time_total.Add(bitir_total_float);
                    dogruYanit.Add(1);
                    dogruYanitId.Add(kelimeler_id[kelimeindex - 1]);
                    harfsayilarii.Add(harfsayilarii_gecici.Count);
                    harfsayilarii_gecici.Clear();
                }

                timer5.Stop();
                timer5.Start();

                gridunnecessaryfocus.Focus();
            }
        }
        void birinci()
        {
            if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "1")
            {
                pozisyon = pozisyonbelirleyici_x - 3;
            }
            else if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "2")
            {
                pozisyon = pozisyonbelirleyici_x + 1 - 3;
            }
            else if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "3")
            {
                pozisyon = pozisyonbelirleyici_x + 2 - 3;
            }


            for (int i = 0; i < birincikelimeharfsayisi; i++)
            {
                if (i == 0)
                {
                    tahir0.Invoke((MethodInvoker)(() => tahir0.Location = new Point(Convert.ToInt32((793 - 60 * pozisyon) * (genislik_koordinatx / 1920) / scale), Convert.ToInt32(432 * (yukseklik_koordinaty / 1080) / scale))));
                    dilandlocate.Default.xvalue = tahir0.Location.X;
                    acilanlar_visible.Add(0);
                    kutucuk = 0;
                    renkler[0] = "white and visible";

                    location_x = tahir0.Location.X + Convert.ToInt32(120 * (genislik_koordinatx / 1920) / scale);
                }
                else
                {
                    hafiza++;
                    design_two(i);
                }

                harfler_kullanici.Add(kelime[i].ToString());
                harfler_index.Add(kelime[i].ToString() + acilanlar[i].ToString());
            }
        }
        void ikinci()
        {
            int uzunluk = Convert.ToInt32(birincikelime.Length);

            for (int i = 0; i < ikincikelimeharfsayisi + 1; i++)
            {
                hafiza++;

                if (i == 0)
                {
                    design_one();
                    cikarilanlar.Add(hafiza);
                    cikarilacaklar();
                }
                else
                {
                    design_two(hafiza);
                }


                if (i == ikincikelimeharfsayisi)
                {

                }
                else
                {
                    uzunluk++;

                    harfler_kullanici.Add(ikincikelime[i].ToString());
                    harfler_index.Add(ikincikelime[i].ToString() + uzunluk.ToString());
                }
            }
        }
        void ucuncu()
        {
            int uzunluk1 = Convert.ToInt32(birincikelime.Length);
            int uzunluk2 = Convert.ToInt32(ikincikelime.Length);
            int topla = uzunluk1 + uzunluk2 + 1;

            for (int i = 0; i < ucuncukelimeharfsayisi + 1; i++)
            {
                hafiza++;

                if (i == 0)
                {
                    design_one();
                    cikarilanlar.Add(hafiza);
                    cikarilacaklar();
                }
                else
                {
                    design_two(hafiza);
                }


                if (i == ucuncukelimeharfsayisi)
                {

                }
                else
                {
                    topla++;

                    harfler_kullanici.Add(ucuncukelime[i].ToString());
                    harfler_index.Add(ucuncukelime[i].ToString() + topla.ToString());
                }
            }
        }
        void cikarilacaklar()
        {
            for (int i = 0; i < cikarilanlar.Count; i++)
            {
                for (int g = 0; g < acilanlar.Count; g++)
                {
                    if (acilanlar[g].ToString() == cikarilanlar.ElementAt(i).ToString())
                    {
                        acilanlar.RemoveAt(g);
                        kullanici_index.RemoveAt(g);
                    }
                }
            }
        }
        void temizlik()
        {
            harfler_kullanici.Clear();
            kullanici_index.Clear();
            harfler_index.Clear();
            kullanici.Clear();
            cikarilanlar.Clear();
            renkler.Clear();
            acilanlar.Clear();
            acilanlarcopy.Clear();
            acilanlar_visible.Clear();
        }
        void yenisoru()
        {
            //değişkenler
            #region
            popupsayac = 0;
            ipucusayac = 0;
            anahtar = 0;
            harf_sayisi = 3;
            hafiza = 0;
            saylan = 0;
            birincikelimeharfsayisi = 0;
            ikincikelimeharfsayisi = 0;
            ucuncukelimeharfsayisi = 0;
            pozisyonbelirleyici_x = 0;
            pozisyon = 0;
            sayi = 0;
            satir = 0;
            tiklandim_harfalma = 0;
            tiklandim_soru = 0;

            whiteprogress.Invoke((MethodInvoker)(() => whiteprogress.Visible = false));
            blackprogress.Invoke((MethodInvoker)(() => blackprogress.Visible = false));

            lblword.Invoke((MethodInvoker)(() => lblword.Text = ""));
            #endregion

            //eğer yarışma bitmişse
            #region
            if (kelimesayac == 24)
            {
                lblwordpoint.Invoke((MethodInvoker)(() => lblwordpoint.Visible = false));
                lbremainingpoint.Invoke((MethodInvoker)(() => lbremainingpoint.Visible = false));
                lblremainingtime.Invoke((MethodInvoker)(() => lblremainingtime.Visible = false));
                lblword.Invoke((MethodInvoker)(() => lblword.Visible = false));
                whiteprogress.Invoke((MethodInvoker)(() => whiteprogress.Visible = false));
                blackprogress.Invoke((MethodInvoker)(() => blackprogress.Visible = false));

                for (int b = 0; b < time_total.Count; b++)
                {
                    time.Items.Add(time_total[b]);
                }

                for (int f = 0; f < popup_count.Count; f++)
                {
                    popup.Items.Add(popup_count[f]);
                }

                for (var i = 0; i < time_total.Count; i++)
                {
                    toplam += time_total[i];
                }
                ort = toplam / time_total.Count;

                for (int e = 0; e < popup_count.Count; e++)
                {
                    toplam_popup += popup_count[e];
                }
                ort_popup = toplam_popup / popup_count.Count;

                dogruidtotal = string.Join(",", dogruYanitId.ToArray());
                yanlisidtotal = string.Join(",", yanlisYanitId.ToArray());
                harfsayilaritotal = string.Join(",", harfsayilarii.ToArray());

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
                    if(guvenaraliği_RT_1_95 < Convert.ToDouble(time.Items[g]))
                    {
                        if(Convert.ToDouble(time.Items[g]) < guvenaraliği_RT_2_95)
                        {
                            aralik++;
                        }
                    }
                }

                double oran = aralik / 24;
                if(oran > 0.95)
                {
                    anlamli_RT_95 = "anlamlı,(mı?) hepsini nasıl eşit dikkat ayırdı? " + "oran: " + oran;
                }
                else
                {
                    anlamli_RT_95 = "anlamsız, " + "oran: " + oran;
                }

                List<float> floattotal_Popup = new List<float>();
                for (int m = 0; m < popup.Items.Count; m++)
                {
                    float tpl = ((float)popup.Items[m] - ort) * ((float)popup.Items[m] - ort);
                    floattotal_Popup.Add(tpl);
                }
                float total_Popup = floattotal_Popup.Sum();
                float varyans_Popup = total_Popup / 23;
                double d_Popup = Convert.ToDouble(varyans_Popup);
                double standartsapma_Popup = Math.Sqrt(d_Popup);

                double guven_Popup_95 = standartsapma_Popup / (Math.Sqrt(24));
                double hatapayi_95_Popup = ((float)1.714) * (guven_Popup_95);
                double guvenaraliği_Popup_1_95 = ort - hatapayi_95_Popup;
                double guvenaraliği_Popup_2_95 = ort + hatapayi_95_Popup;

                string guvenaraligi_Popup_95 = guvenaraliği_Popup_1_95 + " ve " + guvenaraliği_Popup_2_95;

                double aralik_3 = 0;
                for (int t = 0; t < time.Items.Count; t++)
                {
                    if (guvenaraliği_Popup_1_95 < Convert.ToDouble(time.Items[t]))
                    {
                        if (Convert.ToDouble(time.Items[t]) < guvenaraliği_Popup_2_95)
                        {
                            aralik_3++;
                        }
                    }
                }

                double oran_3 = aralik_3 / 24;
                if (oran_3 > 0.95)
                {
                    anlamli_Popup_95 = "anlamlı, evet bunun böyle çıkması ideal " + "oran: " + oran_3;
                }
                else
                {
                    anlamli_Popup_95 = "anlamsız, " + "oran: " + oran_3;
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

                if(NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    netcheck();
                }
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    con_sql.Close();
                    con_sql.Open();

                    cmd_sql = new SqlCommand("ekleGroupPsyword", con_sql)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd_sql.Parameters.AddWithValue("kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("puanTotal", lblwordpoint.Text);
                    cmd_sql.Parameters.AddWithValue("dogruyanitTotal", dogruYanit.Count);
                    cmd_sql.Parameters.AddWithValue("yanlisyanitTotal", yanlisYanit.Count);
                    cmd_sql.Parameters.AddWithValue("harfsayilari", harfsayilaritotal);
                    cmd_sql.Parameters.AddWithValue("alinanipucuTotal", harftotal.Count);
                    cmd_sql.Parameters.AddWithValue("dogruyanitSoruid", dogruidtotal);
                    cmd_sql.Parameters.AddWithValue("yanlisyanitSoruid", yanlisidtotal);
                    cmd_sql.Parameters.AddWithValue("soru1RT", time.Items[0]);
                    cmd_sql.Parameters.AddWithValue("soru2RT", time.Items[1]);
                    cmd_sql.Parameters.AddWithValue("soru3RT", time.Items[2]);
                    cmd_sql.Parameters.AddWithValue("soru4RT", time.Items[3]);
                    cmd_sql.Parameters.AddWithValue("soru5RT", time.Items[4]);
                    cmd_sql.Parameters.AddWithValue("soru6RT", time.Items[5]);
                    cmd_sql.Parameters.AddWithValue("soru7RT", time.Items[6]);
                    cmd_sql.Parameters.AddWithValue("soru8RT", time.Items[7]);
                    cmd_sql.Parameters.AddWithValue("soru9RT", time.Items[8]);
                    cmd_sql.Parameters.AddWithValue("soru10RT", time.Items[9]);
                    cmd_sql.Parameters.AddWithValue("soru11RT", time.Items[10]);
                    cmd_sql.Parameters.AddWithValue("soru12RT", time.Items[11]);
                    cmd_sql.Parameters.AddWithValue("soru13RT", time.Items[12]);
                    cmd_sql.Parameters.AddWithValue("soru14RT", time.Items[13]);
                    cmd_sql.Parameters.AddWithValue("soru15RT", time.Items[14]);
                    cmd_sql.Parameters.AddWithValue("soru16RT", time.Items[15]);
                    cmd_sql.Parameters.AddWithValue("soru17RT", time.Items[16]);
                    cmd_sql.Parameters.AddWithValue("soru18RT", time.Items[17]);
                    cmd_sql.Parameters.AddWithValue("soru19RT", time.Items[18]);
                    cmd_sql.Parameters.AddWithValue("soru20RT", time.Items[19]);
                    cmd_sql.Parameters.AddWithValue("soru21RT", time.Items[20]);
                    cmd_sql.Parameters.AddWithValue("soru22RT", time.Items[21]);
                    cmd_sql.Parameters.AddWithValue("soru23RT", time.Items[22]);
                    cmd_sql.Parameters.AddWithValue("soru24RT", time.Items[23]);
                    cmd_sql.Parameters.AddWithValue("soruOrtRT", ort);
                    cmd_sql.Parameters.AddWithValue("ssRT", standartsapma_RT);
                    cmd_sql.Parameters.AddWithValue("GuvenAraligiRT95", guvenaraligi_RT_95);
                    cmd_sql.Parameters.AddWithValue("AnlamlilikRT95", anlamli_RT_95);
                    cmd_sql.ExecuteNonQuery();

                    con_sql.Close();


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

                    tablo2_sql = new DataTable();

                    da_sql = new SqlDataAdapter("filterveritabaniGroupPsyword", con_sql);
                    tablo2_sql.Clear();
                    da_sql.Fill(tablo2_sql);
                    girisPsyword.Invoke((MethodInvoker)(() => girisPsyword.DataSource = tablo2_sql));

                    con_sql.Close();

                    lbltotalpoint.Invoke((MethodInvoker)(() => lbltotalpoint.Visible = true));
                    lblbesttotalpoint.Invoke((MethodInvoker)(() => lblbesttotalpoint.Visible = true));
                    lbltotalpoint.Invoke((MethodInvoker)(() => lbltotalpoint.Text = lblwordpoint.Text));
                    lblbesttotalpoint.Invoke((MethodInvoker)(() => lblbesttotalpoint.Text = girisPsyword.Rows[0].Cells[2].Value.ToString()));

                    pictureBox1.Image = Properties.Resources.yeni_oyun_sonu_min;
                }
            }
            #endregion

            //eğer yarışma bitmemişse
            #region
            else
            {
                harfsayisi = kelimesiralari[kelimesayac].ToString();
                pozisyonbelirleyici_x = Convert.ToInt32(harfsayisi);

                temizlik();

                kelime = kelimeler.ElementAt(kelimeindex).ToString();


                for (int i = 0; i < kelime.Length; i++)
                {
                    renkler.Add("white");
                }

                if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "1")
                {
                    birincikelimeharfsayisi = kelime.Length;

                    for (int i = 0; i < pozisyonbelirleyici_x; i++)
                    {
                        acilanlar.Add(i);
                        kullanici_index.Add(i);
                    }

                    birinci();
                }
                else if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "2")
                {
                    TextBox x = new TextBox();
                    birincikelime = kelime.Split(' ')[0];
                    string ikincikelime_x = kelime.Substring(birincikelime.Length, kelime.Length - birincikelime.Length);
                    x.Text = ikincikelime_x.Substring(1);
                    ikincikelime = x.Text;

                    birincikelimeharfsayisi = birincikelime.Length;
                    ikincikelimeharfsayisi = ikincikelime.Length;
                    for (int i = 0; i < pozisyonbelirleyici_x + 1; i++)
                    {
                        acilanlar.Add(i);
                        kullanici_index.Add(i);
                    }

                    birinci();
                    ikinci();
                }
                else if (kelimeler_kelimesayisi.ElementAt(kelimeindex).ToString() == "3")
                {
                    TextBox x = new TextBox();
                    TextBox y = new TextBox();
                    birincikelime = kelime.Split(' ')[0];
                    string ikincikelime_x = kelime.Substring(birincikelime.Length, kelime.Length - birincikelime.Length);
                    x.Text = ikincikelime_x.Substring(1);
                    string ikincikelime_y = x.Text;

                    ikincikelime = ikincikelime_y.Split(' ')[0];
                    string ucunkelime_x = ikincikelime_y.Substring(ikincikelime.Length, ikincikelime_y.Length - ikincikelime.Length);
                    y.Text = ucunkelime_x.Substring(1);
                    ucuncukelime = y.Text;

                    birincikelimeharfsayisi = birincikelime.Length;
                    ikincikelimeharfsayisi = ikincikelime.Length;
                    ucuncukelimeharfsayisi = ucuncukelime.Length;

                    for (int i = 0; i < pozisyonbelirleyici_x + 2; i++)
                    {
                        acilanlar.Add(i);
                        kullanici_index.Add(i);
                    }

                    birinci();
                    ikinci();
                    ucuncu();
                }
                #endregion

                //kelime başına ayarlanacak olan puanımız hazır
                #region
                while (true)
                {
                    if (harfsayisi == Convert.ToString(harf_sayisi))
                    {
                        lbremainingpoint.Invoke((MethodInvoker)(() => lbremainingpoint.Text = harf_sayisi + "0"));
                        break;
                    }
                    else
                    {
                        harf_sayisi++;
                    }
                }
                #endregion

                //list indexleri
                #region
                for (int i = 0; i <= kelime.Length; i++)
                {
                    kullanici.Add("");
                }
                #endregion

                //acilanlar_copyayı ekle
                #region
                for (int i = 0; i < acilanlar.Count; i++)
                {
                    acilanlarcopy.Add(Convert.ToInt32(acilanlar[i]));
                }
                #endregion

                //açılması gerekenler
                #region
                for (int i = 0; i < acilanlar_visible.Count; i++)
                {
                    if (acilanlar_visible.ElementAt(i) == 0)
                    {
                        tahir0.Invoke((MethodInvoker)(() => tahir0.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 1)
                    {
                        tahir1.Invoke((MethodInvoker)(() => tahir1.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 2)
                    {
                        tahir2.Invoke((MethodInvoker)(() => tahir2.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 3)
                    {
                        tahir3.Invoke((MethodInvoker)(() => tahir3.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 4)
                    {
                        tahir4.Invoke((MethodInvoker)(() => tahir4.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 5)
                    {
                        tahir5.Invoke((MethodInvoker)(() => tahir5.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 6)
                    {
                        tahir6.Invoke((MethodInvoker)(() => tahir6.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 7)
                    {
                        tahir7.Invoke((MethodInvoker)(() => tahir7.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 8)
                    {
                        tahir8.Invoke((MethodInvoker)(() => tahir8.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 9)
                    {
                        tahir9.Invoke((MethodInvoker)(() => tahir9.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 10)
                    {
                        tahir10.Invoke((MethodInvoker)(() => tahir10.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 11)
                    {
                        tahir11.Invoke((MethodInvoker)(() => tahir11.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 12)
                    {
                        tahir12.Invoke((MethodInvoker)(() => tahir12.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 13)
                    {
                        tahir13.Invoke((MethodInvoker)(() => tahir13.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 14)
                    {
                        tahir14.Invoke((MethodInvoker)(() => tahir14.Visible = true));
                    }
                    else if (acilanlar_visible.ElementAt(i) == 15)
                    {
                        tahir15.Invoke((MethodInvoker)(() => tahir15.Visible = true));
                    }
                }
                #endregion

                //ve soru gelsin
                #region
                blackprogress.Invoke((MethodInvoker)(() => blackprogress.Width = 480));
                blackprogress.Invoke((MethodInvoker)(() => blackprogress.Visible = false));
                lblword.Invoke((MethodInvoker)(() => lblword.Text = kelimeler_soru.ElementAt(kelimeindex).ToString()));
                kelimeindex++;

                timestamp = DateTime.Now.ToString("mm:ss.fff");
                txt_basla.Text = timestamp;

                #endregion
            }
        }
        void focus()
        {
            if (odak == 0)
            {
                tahir0.Focus();
                kutucuk = 0;
            }
            else if (odak == 1)
            {
                tahir1.Focus();
                kutucuk = 1;
            }
            else if (odak == 2)
            {
                tahir2.Focus();
                kutucuk = 2;
            }
            else if (odak == 3)
            {
                tahir3.Focus();
                kutucuk = 3;
            }
            else if (odak == 4)
            {
                tahir4.Focus();
                kutucuk = 4;
            }
            else if (odak == 5)
            {
                tahir5.Focus();
                kutucuk = 5;
            }
            else if (odak == 6)
            {
                tahir6.Focus();
                kutucuk = 6;
            }
            else if (odak == 7)
            {
                tahir7.Focus();
                kutucuk = 7;
            }
            else if (odak == 8)
            {
                tahir8.Focus();
                kutucuk = 8;
            }
            else if (odak == 9)
            {
                tahir9.Focus();
                kutucuk = 9;
            }
            else if (odak == 10)
            {
                tahir10.Focus();
                kutucuk = 10;
            }
            else if (odak == 11)
            {
                tahir11.Focus();
                kutucuk = 11;
            }
            else if (odak == 12)
            {
                tahir12.Focus();
                kutucuk = 12;
            }
            else if (odak == 13)
            {
                tahir13.Focus();
                kutucuk = 13;
            }
            else if (odak == 14)
            {
                tahir14.Focus();
                kutucuk = 14;
            }
            else if (odak == 15)
            {
                tahir15.Focus();
                kutucuk = 15;
            }
        }
        private void oyun_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string saniye = lblremainingtime.Text.Substring(lblremainingtime.Text.Length - 2);
            int sn = Convert.ToInt32(saniye);

            string dakika = lblremainingtime.Text.Substring(0, 1);
            int dk = Convert.ToInt32(dakika);

            if (sn == 0)
            {
                if (dk == 0)
                {
                    timer1.Stop();
                    //MessageBox.Show("Yarışmamıza ayrılan sürenin sonuna gelinmiştir! Ana menüye dönülüyor.");
                }
                else
                {
                    sn = 59;
                    dk -= 1;

                    lblremainingtime.Text = dk + ":" + sn;
                }
            }
            else
            {
                sn -= 1;
                if (sn == 9 || sn == 8 || sn == 7 || sn == 6 || sn == 5 || sn == 4 || sn == 3 || sn == 2 || sn == 1 || sn == 0)
                {
                    lblremainingtime.Text = dk + ":0" + sn;
                }
                else
                {
                    lblremainingtime.Text = dk + ":" + sn;
                }
            }
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            yyy++;
            timer6.Stop();
            yanlis();
        }

        void yanlis()
        {
            gridunnecessaryfocus.Focus();

            if (yyy == 0)
            {
                if (tahir15.Visible == true)
                {
                    aaaaaaaaaaa = 14;
                }
                else if (tahir14.Visible == true)
                {
                    aaaaaaaaaaa = 14;
                }
                else if (tahir13.Visible == true)
                {
                    aaaaaaaaaaa = 13;
                }
                else if (tahir12.Visible == true)
                {
                    aaaaaaaaaaa = 12;
                }
                else if (tahir11.Visible == true)
                {
                    aaaaaaaaaaa = 11;
                }
                else if (tahir10.Visible == true)
                {
                    aaaaaaaaaaa = 10;
                }
                else if (tahir9.Visible == true)
                {
                    aaaaaaaaaaa = 9;
                }
                else if (tahir8.Visible == true)
                {
                    aaaaaaaaaaa = 8;
                }
                else if (tahir7.Visible == true)
                {
                    aaaaaaaaaaa = 7;
                }
                else if (tahir6.Visible == true)
                {
                    aaaaaaaaaaa = 6;
                }
                else if (tahir5.Visible == true)
                {
                    aaaaaaaaaaa = 5;
                }
                else if (tahir4.Visible == true)
                {
                    aaaaaaaaaaa = 4;
                }
                else if (tahir3.Visible == true)
                {
                    aaaaaaaaaaa = 3;
                }
                else if (tahir2.Visible == true)
                {
                    aaaaaaaaaaa = 2;
                }


                if (aaaaaaaaaaa == 2)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                } //3
                else if (aaaaaaaaaaa == 3)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                } //4
                else if (aaaaaaaaaaa == 4)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                } //5
                else if (aaaaaaaaaaa == 5)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Red;
                } //6
                else if (aaaaaaaaaaa == 6)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Red;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Red;
                } //7
                else if (aaaaaaaaaaa == 7)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Red;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Red;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Red;
                } //8
                else if (aaaaaaaaaaa == 8)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Red;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Red;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Red;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Red;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Red;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Red;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Red;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Red;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Red;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Red;
                    }
                } //9
                else if (aaaaaaaaaaa == 9)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Red;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Red;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Red;
                    tahir8.ForeColor = Color.White;
                    tahir8.BackColor = Color.Red;
                    tahir9.ForeColor = Color.White;
                    tahir9.BackColor = Color.Red;
                } //10
                else if (aaaaaaaaaaa == 10)
                {
                    tahir0.ForeColor = Color.White;
                    tahir0.BackColor = Color.Red;
                    tahir1.ForeColor = Color.White;
                    tahir1.BackColor = Color.Red;
                    tahir2.ForeColor = Color.White;
                    tahir2.BackColor = Color.Red;
                    tahir3.ForeColor = Color.White;
                    tahir3.BackColor = Color.Red;
                    tahir4.ForeColor = Color.White;
                    tahir4.BackColor = Color.Red;
                    tahir5.ForeColor = Color.White;
                    tahir5.BackColor = Color.Red;
                    tahir6.ForeColor = Color.White;
                    tahir6.BackColor = Color.Red;
                    tahir7.ForeColor = Color.White;
                    tahir7.BackColor = Color.Red;
                    tahir8.ForeColor = Color.White;
                    tahir8.BackColor = Color.Red;
                    tahir9.ForeColor = Color.White;
                    tahir9.BackColor = Color.Red;
                    tahir10.ForeColor = Color.White;
                    tahir10.BackColor = Color.Red;
                } //11
                else if (aaaaaaaaaaa == 11)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Red;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Red;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Red;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Red;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Red;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Red;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Red;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Red;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Red;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Red;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Red;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Red;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Red;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Red;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Red;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Red;
                    }
                } //12
                else if (aaaaaaaaaaa == 12) //13
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Red;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Red;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Red;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Red;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Red;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Red;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Red;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Red;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Red;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Red;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Red;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Red;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Red;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Red;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Red;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Red;
                    }
                } //13
                else if (aaaaaaaaaaa == 13 ||aaaaaaaaaaa == 14)
                {
                    if (tahir0.Visible == true)
                    {
                        tahir0.ForeColor = Color.White;
                        tahir0.BackColor = Color.Red;
                    }
                    if (tahir1.Visible == true)
                    {
                        tahir1.ForeColor = Color.White;
                        tahir1.BackColor = Color.Red;
                    }
                    if (tahir2.Visible == true)
                    {
                        tahir2.ForeColor = Color.White;
                        tahir2.BackColor = Color.Red;
                    }
                    if (tahir3.Visible == true)
                    {
                        tahir3.ForeColor = Color.White;
                        tahir3.BackColor = Color.Red;
                    }
                    if (tahir4.Visible == true)
                    {
                        tahir4.ForeColor = Color.White;
                        tahir4.BackColor = Color.Red;
                    }
                    if (tahir5.Visible == true)
                    {
                        tahir5.ForeColor = Color.White;
                        tahir5.BackColor = Color.Red;
                    }
                    if (tahir6.Visible == true)
                    {
                        tahir6.ForeColor = Color.White;
                        tahir6.BackColor = Color.Red;
                    }
                    if (tahir7.Visible == true)
                    {
                        tahir7.ForeColor = Color.White;
                        tahir7.BackColor = Color.Red;
                    }
                    if (tahir8.Visible == true)
                    {
                        tahir8.ForeColor = Color.White;
                        tahir8.BackColor = Color.Red;
                    }
                    if (tahir9.Visible == true)
                    {
                        tahir9.ForeColor = Color.White;
                        tahir9.BackColor = Color.Red;
                    }
                    if (tahir10.Visible == true)
                    {
                        tahir10.ForeColor = Color.White;
                        tahir10.BackColor = Color.Red;
                    }
                    if (tahir11.Visible == true)
                    {
                        tahir11.ForeColor = Color.White;
                        tahir11.BackColor = Color.Red;
                    }
                    if (tahir12.Visible == true)
                    {
                        tahir12.ForeColor = Color.White;
                        tahir12.BackColor = Color.Red;
                    }
                    if (tahir13.Visible == true)
                    {
                        tahir13.ForeColor = Color.White;
                        tahir13.BackColor = Color.Red;
                    }
                    if (tahir14.Visible == true)
                    {
                        tahir14.ForeColor = Color.White;
                        tahir14.BackColor = Color.Red;
                    }
                    if (tahir15.Visible == true)
                    {
                        tahir15.ForeColor = Color.White;
                        tahir15.BackColor = Color.Red;
                    }
                } //14

                timer2.Stop();
                timer4.Stop();

                timestamp = DateTime.UtcNow.ToString("mm:ss.fff");
                txt_bitir.Text = timestamp;

                axWindowsMediaPlayer1.Ctlcontrols.stop();

                if (dilandlocate.Default.ses == 1)
                {
                    string yol = sesler[9].ToString();
                    player.SoundLocation = yol;
                    player.Play();
                }

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

                //Tepki Sürelerinin Verileri Burada!!
                time_basla.Add(txt_basla.Text);
                time_bitir.Add(txt_bitir.Text);
                time_total.Add(bitir_total_float);
                yanlisYanit.Add(1);
                yanlisYanitId.Add(kelimeler_id[kelimeindex - 1]);
                harfsayilarii.Add(harfsayilarii_gecici.Count);
                harfsayilarii_gecici.Clear();

                timer6.Stop();
                timer6.Start();
            }
            else if(yyy == 1 || yyy == 2)
            {
                timer6.Stop();
                timer6.Start();
            }
            else if(yyy == 3)
            {
                yyy = 0;
                timer6.Stop();
                load.PerformClick();
                timer1.Start();
                gridunnecessaryfocus.Focus();
            }

            gridunnecessaryfocus.Focus();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            scale = getScalingFactor();

            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;

            genislik_koordinatx = genislik * scale;
            yukseklik_koordinaty = yukseklik * scale;

            if(saaat == 0)
            {
                blackprogress.Visible = true;
                timer4.Start();
            }

            if (wmplayer == 0)
            {
                timer();
            }

            if (whiteprogress.Width == 0 || blackprogress.Width == 0)
            {
                gridunnecessaryfocus.Focus();

                yyy = 1;
                for (int r = 0; r < harfler_index.Count; r++)
                {
                    int sub_index = 0;
                    string t = harfler_index.ElementAt(r).Substring(0);
                    if(t.Length == 2)
                    {
                        sub_index = Convert.ToInt32(harfler_index.ElementAt(r).Substring(1, 1));
                    }
                    else if(t.Length == 3)
                    {
                        sub_index = Convert.ToInt32(harfler_index.ElementAt(r).Substring(1, 2));
                    }

                    string sub_harf = harfler_index.ElementAt(r).Substring(0,1);//harf

                    if (sub_index == 0)
                    {
                        tahir0.Texts = sub_harf;
                    }
                    else if (sub_index == 1)
                    {
                        tahir1.Texts = sub_harf;
                    }
                    else if (sub_index == 2)
                    {
                        tahir2.Texts = sub_harf;
                    }
                    else if (sub_index == 3)
                    {
                        tahir3.Texts = sub_harf;
                    }
                    else if (sub_index == 4)
                    {
                        tahir4.Texts = sub_harf;
                    }
                    else if (sub_index == 5)
                    {
                        tahir5.Texts = sub_harf;
                    }
                    else if (sub_index == 6)
                    {
                        tahir6.Texts = sub_harf;
                    }
                    else if (sub_index == 7)
                    {
                        tahir7.Texts = sub_harf;
                    }
                    else if (sub_index == 8)
                    {
                        tahir8.Texts = sub_harf;
                    }
                    else if (sub_index == 9)
                    {
                        tahir9.Texts = sub_harf;
                    }
                    else if (sub_index == 10)
                    {
                        tahir10.Texts = sub_harf;
                    }
                    else if (sub_index == 11)
                    {
                        tahir11.Texts = sub_harf;
                    }
                    else if (sub_index == 12)
                    {
                        tahir12.Texts = sub_harf;
                    }
                    else if (sub_index == 13)
                    {
                        tahir13.Texts = sub_harf;
                    }
                    else if (sub_index == 14)
                    {
                        tahir14.Texts = sub_harf;
                    }
                    else if (sub_index == 15)
                    {
                        tahir15.Texts = sub_harf;
                    }
                }
                yyy = 0;

                gridunnecessaryfocus.Focus();

                timer2.Stop();
                yanlis();
            }

            saaat++;
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            blackprogress.Width -= Convert.ToInt32((float)3.2 * (genislik_koordinatx / 1920) / scale);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            //Soru cevaplama butonu
            if (x >= 665 * (genislik_koordinatx / 1920) / scale && x <= 946 * (genislik_koordinatx / 1920) / scale && y >= 792 * (yukseklik_koordinaty / 1080) / scale && y <= 875 * (yukseklik_koordinaty / 1080) / scale)
            {
                if (tiklandim_soru != 0)
                {

                }
                else
                {
                    tiklandim_soru++;
                    tiklandim_harfalma++;

                    if (dilandlocate.Default.ses == 1)
                    {
                        string yol = sesler[0].ToString();
                        player.SoundLocation = yol;
                        player.Play();
                    }

                    for (int i = 0; i < renkler.Count; i++)
                    {
                        if (renkler[i].ToString() == "green" + i.ToString())
                        {
                            anahtar++;
                        }
                        else
                        {
                            break;
                            //break döngülerden çıkmak için kullanılır; if else zincirleri için değildir
                        }
                    }

                    while (true)
                    {
                        if (anahtar == 0)
                        {
                            tahir0.Focus();
                            tahir0.select(0, 0);
                            kutucuk = 0;
                            break;
                        }
                        if (anahtar == 1)
                        {
                            if (tahir1.Visible == false)
                            {
                                if (tahir2.BackColor == Color.FromArgb(0,127,0))
                                {
                                    anahtar += 2;

                                    for (int i = 3; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir2.Focus();
                                    tahir2.select(0, 0);
                                    kutucuk = 2;
                                    break;
                                }
                            }
                            else
                            {
                                tahir1.Focus();
                                tahir1.select(0, 0);
                                kutucuk = 1;
                                break;
                            }
                        }
                        if (anahtar == 2)
                        {
                            if (tahir2.Visible == false)
                            {
                                if (tahir3.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 4; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir3.Focus();
                                    tahir3.select(0, 0);
                                    kutucuk = 3;
                                    break;
                                }
                            }
                            else
                            {
                                tahir2.Focus();
                                tahir2.select(0, 0);
                                kutucuk = 2;
                                break;
                            }
                        }
                        if (anahtar == 3)
                        {
                            if (tahir3.Visible == false)
                            {
                                if (tahir4.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 5; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir4.Focus();
                                    tahir4.select(0, 0);
                                    kutucuk = 4;
                                    break;
                                }
                            }
                            else
                            {
                                tahir3.Focus();
                                tahir3.select(0, 0);
                                kutucuk = 3;
                                break;
                            }
                        }
                        if (anahtar == 4)
                        {
                            if (tahir4.Visible == false)
                            {
                                if (tahir5.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 6; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir5.Focus();
                                    tahir5.select(0, 0);
                                    kutucuk = 5;
                                    break;
                                }
                            }
                            else
                            {
                                tahir4.Focus();
                                tahir4.select(0, 0);
                                kutucuk = 4;
                                break;
                            }
                        }
                        if (anahtar == 5)
                        {
                            if (tahir5.Visible == false)
                            {
                                if (tahir6.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 7; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir6.Focus();
                                    tahir6.select(0, 0);
                                    kutucuk = 6;
                                    break;
                                }
                            }
                            else
                            {
                                tahir5.Focus();
                                tahir5.select(0, 0);
                                kutucuk = 5;
                                break;
                            }
                        }
                        if (anahtar == 6)
                        {
                            if (tahir6.Visible == false)
                            {
                                if (tahir7.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 8; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir7.Focus();
                                    tahir7.select(0, 0);
                                    kutucuk = 7;
                                    break;
                                }
                            }
                            else
                            {
                                tahir6.Focus();
                                tahir6.select(0, 0);
                                kutucuk = 6;
                                break;
                            }
                        }
                        if (anahtar == 7)
                        {
                            if (tahir7.Visible == false)
                            {
                                if (tahir8.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 9; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir8.Focus();
                                    tahir8.select(0, 0);
                                    kutucuk = 8;
                                    break;
                                }
                            }
                            else
                            {
                                tahir7.Focus();
                                tahir7.select(0, 0);
                                kutucuk = 7;
                                break;
                            }
                        }
                        if (anahtar == 8)
                        {
                            if (tahir8.Visible == false)
                            {
                                if (tahir9.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 10; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir9.Focus();
                                    tahir9.select(0, 0);
                                    kutucuk = 9;
                                    break;
                                }
                            }
                            else
                            {
                                tahir8.Focus();
                                tahir8.select(0, 0);
                                kutucuk = 8;
                                break;
                            }
                        }
                        if (anahtar == 9)
                        {
                            if (tahir9.Visible == false)
                            {
                                if (tahir10.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 11; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir10.Focus();
                                    tahir10.select(0, 0);
                                    kutucuk = 10;
                                    break;
                                }
                            }
                            else
                            {
                                tahir9.Focus();
                                tahir9.select(0, 0);
                                kutucuk = 9;
                                break;
                            }
                        }
                        if (anahtar == 10)
                        {
                            if (tahir10.Visible == false)
                            {
                                if (tahir11.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 12; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir11.Focus();
                                    tahir11.select(0, 0);
                                    kutucuk = 11;
                                    break;
                                }
                            }
                            else
                            {
                                tahir10.Focus();
                                tahir10.select(0, 0);
                                kutucuk = 10;
                                break;
                            }
                        }
                        if (anahtar == 11)
                        {
                            if (tahir11.Visible == false)
                            {
                                if (tahir12.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 13; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir12.Focus();
                                    tahir12.select(0, 0);
                                    kutucuk = 12;
                                    break;
                                }
                            }
                            else
                            {
                                tahir11.Focus();
                                tahir11.select(0, 0);
                                kutucuk = 11;
                                break;
                            }
                        }
                        if (anahtar == 12)
                        {
                            if (tahir12.Visible == false)
                            {
                                if (tahir13.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 14; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir13.Focus();
                                    tahir13.select(0, 0);
                                    kutucuk = 13;
                                    break;
                                }
                            }
                            else
                            {
                                tahir12.Focus();
                                tahir12.select(0, 0);
                                kutucuk = 12;
                                break;
                            }
                        }
                        if (anahtar == 13)
                        {
                            if (tahir13.Visible == false)
                            {
                                if (tahir14.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 15; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir14.Focus();
                                    tahir14.select(0, 0);
                                    kutucuk = 14;
                                    break;
                                }
                            }
                            else
                            {
                                tahir13.Focus();
                                tahir13.select(0, 0);
                                kutucuk = 13;
                                break;
                            }
                        }
                        if (anahtar == 14)
                        {
                            if (tahir14.Visible == false)
                            {
                                if (tahir15.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar += 2;

                                    for (int i = 16; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir15.Focus();
                                    tahir15.select(0, 0);
                                    kutucuk = 15;
                                    break;
                                }
                            }
                            else
                            {
                                tahir14.Focus();
                                tahir14.select(0, 0);
                                kutucuk = 14;
                                break;
                            }
                        }
                        if (anahtar == 15)
                        {
                            if (tahir15.Visible == false)
                            {
                                if (tahir0.BackColor == Color.FromArgb(0, 127, 0))
                                {
                                    anahtar = 1;

                                    for (int i = 1; i < renkler.Count; i++)
                                    {
                                        if (renkler[i].ToString() == "green" + i.ToString())
                                        {
                                            anahtar++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    tahir0.Focus();
                                    tahir0.select(0, 0);
                                    kutucuk = 0;
                                    break;
                                }
                            }
                            else
                            {
                                tahir15.Focus();
                                tahir15.select(0, 0);
                                kutucuk = 15;
                                break;
                            }
                        }
                    }

                    wmplayer = 0;
                    saaat = 0;
                    timer1.Stop();
                    timer2.Start();
                }
            }

            //Harf alma butonu
            if (x >= 976 * (genislik_koordinatx / 1920) / scale && x <= 1257 * (genislik_koordinatx / 1920) / scale && y >= 792 * (yukseklik_koordinaty / 1080) / scale && y <= 875 * (yukseklik_koordinaty / 1080) / scale)
            {
                if (tiklandim_harfalma != 0)
                {

                }
                else
                {
                    harftotal.Add(1);
                    harfsayilarii_gecici.Add(1);

                    if (dilandlocate.Default.ses == 1)
                    {
                        string yol = sesler[1].ToString();
                        player.SoundLocation = yol;
                        player.Play();
                    }

                    int t = acilanlar.Count;

                    teyit = "teyit";

                    if (acilanlar.Count == 1)
                    {
                        if (dilandlocate.Default.ses == 1)
                        {
                            string yol = sesler[7].ToString();
                            player.SoundLocation = yol;
                            player.Play();
                        }
                    }

                    else
                    {
                        sayi = rastgele.Next(t);

                        int al = Convert.ToInt32(acilanlar[sayi]);

                        for (int i = 0; i < acilanlar.Count; i++)
                        {
                            if (Convert.ToInt32(acilanlar[i]) == al)
                            {
                                deger = Convert.ToInt32(acilanlar[i]);
                                acilanlar.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < harfler_index.Count; i++)
                        {
                            if (harfler_index.ElementAt(i).Length == 2)
                            {
                                substring = harfler_index.ElementAt(i).Substring(harfler_index.ElementAt(i).Length - 1);
                            }
                            else if (harfler_index.ElementAt(i).Length == 3)
                            {
                                substring = harfler_index.ElementAt(i).Substring(harfler_index.ElementAt(i).Length - 2);
                            }

                            if (substring == deger.ToString())
                            {
                                harf = harfler_index.ElementAt(i).Substring(0, 1);
                                break;
                            }
                        }

                        if (Convert.ToInt32(substring) == 0)
                        {
                            tahir0.Texts = harf;
                            tahir0.BackColor = Color.FromArgb(0, 127, 0);
                            tahir0.ForeColor = Color.White;
                            tahir0.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir0.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir0.readonly_x = true;
                            renkler[0] = "green0";

                            kullanici[0] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 1)
                        {
                            tahir1.Texts = harf;
                            tahir1.BackColor = Color.FromArgb(0, 127, 0);
                            tahir1.ForeColor = Color.White;
                            tahir1.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir1.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir1.readonly_x = true;
                            renkler[1] = "green1";

                            kullanici[1] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 2)
                        {
                            tahir2.Texts = harf;
                            tahir2.BackColor = Color.FromArgb(0, 127, 0);
                            tahir2.ForeColor = Color.White;
                            tahir2.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir2.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir2.readonly_x = true;
                            renkler[2] = "green2";

                            kullanici[2] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 3)
                        {
                            tahir3.Texts = harf;
                            tahir3.BackColor = Color.FromArgb(0, 127, 0);
                            tahir3.ForeColor = Color.White;
                            tahir3.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir3.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir3.readonly_x = true;
                            renkler[3] = "green3";

                            kullanici[3] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 4)
                        {
                            tahir4.Texts = harf;
                            tahir4.BackColor = Color.FromArgb(0, 127, 0);
                            tahir4.ForeColor = Color.White;
                            tahir4.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir4.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir4.readonly_x = true;
                            renkler[4] = "green4";

                            kullanici[4] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 5)
                        {
                            tahir5.Texts = harf;
                            tahir5.BackColor = Color.FromArgb(0, 127, 0);
                            tahir5.ForeColor = Color.White;
                            tahir5.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir5.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir5.readonly_x = true;
                            renkler[5] = "green5";

                            kullanici[5] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 6)
                        {
                            tahir6.Texts = harf;
                            tahir6.BackColor = Color.FromArgb(0, 127, 0);
                            tahir6.ForeColor = Color.White;
                            tahir6.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir6.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir6.readonly_x = true;
                            renkler[6] = "green6";

                            kullanici[6] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 7)
                        {
                            tahir7.Texts = harf;
                            tahir7.BackColor = Color.FromArgb(0, 127, 0);
                            tahir7.ForeColor = Color.White;
                            tahir7.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir7.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir7.readonly_x = true;
                            renkler[7] = "green7";

                            kullanici[7] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 8)
                        {
                            tahir8.Texts = harf;
                            tahir8.BackColor = Color.FromArgb(0, 127, 0);
                            tahir8.ForeColor = Color.White;
                            tahir8.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir8.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir8.readonly_x = true;
                            renkler[8] = "green8";

                            kullanici[8] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 9)
                        {
                            tahir9.Texts = harf;
                            tahir9.BackColor = Color.FromArgb(0, 127, 0);
                            tahir9.ForeColor = Color.White;
                            tahir9.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir9.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir9.readonly_x = true;
                            renkler[9] = "green9";

                            kullanici[9] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 10)
                        {
                            tahir10.Texts = harf;
                            tahir10.BackColor = Color.FromArgb(0, 127, 0);
                            tahir10.ForeColor = Color.White;
                            tahir10.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir10.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir10.readonly_x = true;
                            renkler[10] = "green10";

                            kullanici[10] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 11)
                        {
                            tahir11.Texts = harf;
                            tahir11.BackColor = Color.FromArgb(0, 127, 0);
                            tahir11.ForeColor = Color.White;
                            tahir11.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir11.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir11.readonly_x = true;
                            renkler[11] = "green11";

                            kullanici[11] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 12)
                        {
                            tahir12.Texts = harf;
                            tahir12.BackColor = Color.FromArgb(0, 127, 0);
                            tahir12.ForeColor = Color.White;
                            tahir12.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir12.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir12.readonly_x = true;
                            renkler[12] = "green12";

                            kullanici[12] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 13)
                        {
                            tahir13.Texts = harf;
                            tahir13.BackColor = Color.FromArgb(0, 127, 0);
                            tahir13.ForeColor = Color.White;
                            tahir13.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir13.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir13.readonly_x = true;
                            renkler[13] = "green13";

                            kullanici[13] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 14)
                        {
                            tahir14.Texts = harf;
                            tahir14.BackColor = Color.FromArgb(0, 127, 0);
                            tahir14.ForeColor = Color.White;
                            tahir14.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir14.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir14.readonly_x = true;
                            renkler[14] = "green14";

                            kullanici[14] = harf;
                        }
                        else if (Convert.ToInt32(substring) == 15)
                        {
                            tahir15.Texts = harf;
                            tahir15.BackColor = Color.FromArgb(0, 127, 0);
                            tahir15.ForeColor = Color.White;
                            tahir15.BorderColor = Color.FromArgb(0, 127, 0);
                            tahir15.BorderFocusColor = Color.FromArgb(0, 127, 0);
                            tahir15.readonly_x = true;
                            renkler[15] = "green15";

                            kullanici[15] = harf;
                        }

                        int eskipuan = Convert.ToInt32(lbremainingpoint.Text);
                        eskipuan -= 10;
                        lbremainingpoint.Text = Convert.ToString(eskipuan);
                    }
                }
            }

            //cikis butonu
            if(x >= 1818 * (genislik_koordinatx / 1920) / scale && x <= 1893 * (genislik_koordinatx / 1920) / scale && y >= 972 * (yukseklik_koordinaty / 1080) / scale && y <= 1047 * (yukseklik_koordinaty / 1080) / scale)
            {
                bas();

                axWindowsMediaPlayer1.Ctlcontrols.stop();
                wmplayer = 0;

                loginscreen t = new loginscreen();
                t.Show();
                this.Hide();
            }
            
            //oyun sonu
            if(lblbesttotalpoint.Visible == true)
            {
                if(x >= 1543 * (genislik_koordinatx / 1920) / scale && x <= 1618 * (genislik_koordinatx / 1920) / scale && y >= 685 * (yukseklik_koordinaty / 1080) / scale && y <= 760 * (yukseklik_koordinaty / 1080) / scale)
                {
                    daylogin g = new daylogin();
                    g.Show();
                    this.Hide();
                }
                else if (x >= 1636 * (genislik_koordinatx / 1920) / scale && x <= 1711 * (genislik_koordinatx / 1920) / scale && y >= 686 * (yukseklik_koordinaty / 1080) / scale && y <= 761 * (yukseklik_koordinaty / 1080) / scale)
                {
                    bas();
                    new CResolution(genislik, yukseklik);
                    Environment.Exit(0);
                }
            }
        }
        public void Dinamik_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Position = new Point(Cursor.Position.X + 100, Cursor.Position.Y + 100);
        }
        public void Dinamik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar);

            if (e.KeyChar == 'ı')
            {
                if(kutucuk == 0)
                {
                    tahir0.Texts = "I";
                }
                else if (kutucuk == 1)
                {
                    tahir1.Texts = "I";
                }
                else if (kutucuk == 2)
                {
                    tahir2.Texts = "I";
                }
                else if (kutucuk == 3)
                {
                    tahir3.Texts = "I";
                }
                else if (kutucuk == 4)
                {
                    tahir4.Texts = "I";
                }
                else if (kutucuk == 5)
                {
                    tahir5.Texts = "I";
                }
                else if (kutucuk == 6)
                {
                    tahir6.Texts = "I";
                }
                else if (kutucuk == 7)
                {
                    tahir7.Texts = "I";
                }
                else if (kutucuk == 8)
                {
                    tahir8.Texts = "I";
                }
                else if (kutucuk == 9)
                {
                    tahir9.Texts = "I";
                }
                else if (kutucuk == 10)
                {
                    tahir10.Texts = "I";
                }
                else if (kutucuk == 11)
                {
                    tahir11.Texts = "I";
                }
                else if (kutucuk == 12)
                {
                    tahir12.Texts = "I";
                }
                else if (kutucuk == 13)
                {
                    tahir13.Texts = "I";
                }
                else if (kutucuk == 14)
                {
                    tahir14.Texts = "I";
                }
                else if (kutucuk == 15)
                {
                    tahir15.Texts = "I";
                }
            }
            if (e.KeyChar == 'i')
            {
                if (kutucuk == 0)
                {
                    tahir0.Texts = "İ";
                }
                else if (kutucuk == 1)
                {
                    tahir1.Texts = "İ";
                }
                else if (kutucuk == 2)
                {
                    tahir2.Texts = "İ";
                }
                else if (kutucuk == 3)
                {
                    tahir3.Texts = "İ";
                }
                else if (kutucuk == 4)
                {
                    tahir4.Texts = "İ";
                }
                else if (kutucuk == 5)
                {
                    tahir5.Texts = "İ";
                }
                else if (kutucuk == 6)
                {
                    tahir6.Texts = "İ";
                }
                else if (kutucuk == 7)
                {
                    tahir7.Texts = "İ";
                }
                else if (kutucuk == 8)
                {
                    tahir8.Texts = "İ";
                }
                else if (kutucuk == 9)
                {
                    tahir9.Texts = "İ";
                }
                else if (kutucuk == 10)
                {
                    tahir10.Texts = "İ";
                }
                else if (kutucuk == 11)
                {
                    tahir11.Texts = "İ";
                }
                else if (kutucuk == 12)
                {
                    tahir12.Texts = "İ";
                }
                else if (kutucuk == 13)
                {
                    tahir13.Texts = "İ";
                }
                else if (kutucuk == 14)
                {
                    tahir14.Texts = "İ";
                }
                else if (kutucuk == 15)
                {
                    tahir15.Texts = "İ";
                }
            }
        }
        public void Dinamik__TextChanged(object sender, EventArgs e)
        {
            if(yyy != 0)
            {
                
            }
            else
            {

                //eğer ipucu eklenerek text değişmişse herhangi bir aktivite de bulunmasın, daha sonra geri eski haline getirelim ki normal kaydedebilsin harfleri
                if (teyit == "teyit")
                {
                    teyit = "";
                }

                //yeni soru yüklenirken textleri temizliyoruz ya, ya da yanlış cevap olursa kutucukları temizliyoruz ya
                //o yüzden bu olay tetikleniyor, bunu engellemek adına bu koşul var
                else if (check != 0 || ((TextBox)sender).Text == "")
                {

                }

                //harf kaydetme
                else
                {
                    if (dilandlocate.Default.ses == 1)
                    {
                        string yol = sesler[5].ToString();
                        player.SoundLocation = yol;
                        player.Play();
                    }

                    //harf kaydetme ve "büyülü" küçük ı sorununu halletme (nedense kutuya yazıyor aq)
                    #region
                    if (((TextBox)sender).Text.ToString() == "ı")
                    {
                        ((TextBox)sender).Text = "";
                    }
                    else
                    {
                        kullanici[kutucuk] = ((TextBox)sender).Text.ToString();
                    }
                    #endregion

                    //harf dolu kutucuklara odaklanmama, sonraki textbox'ı seçme
                    #region
                    int x = acilanlar.Count;
                    if (x != 0)
                    {
                        if (acilanlar.Contains(kutucuk) == true)
                        {
                            for (int i = 0; i < acilanlar.Count; i++)
                            {
                                if (acilanlar[i].ToString() == kutucuk.ToString())
                                {
                                    acilanlar.RemoveAt(i);
                                }
                            }
                        }
                    }

                    if (((TextBox)sender).Text.Length == 1)
                    {
                        string focusname = "tahir" + focuss;

                        if (tahir0.Name == focusname)
                        {
                            tahir0.Focus();
                            kutucuk = 0;
                        }

                        else if (tahir1.Name == focusname)
                        {
                            tahir1.Focus();
                            kutucuk = 1;
                        }
                        else if (tahir2.Name == focusname)
                        {
                            tahir2.Focus();
                            kutucuk = 2;
                        }
                        else if (tahir3.Name == focusname)
                        {
                            tahir3.Focus();
                            kutucuk = 3;
                        }
                        else if (tahir4.Name == focusname)
                        {
                            tahir4.Focus();
                            kutucuk = 4;
                        }
                        else if (tahir5.Name == focusname)
                        {
                            tahir5.Focus();
                            kutucuk = 5;
                        }
                        else if (tahir6.Name == focusname)
                        {
                            tahir6.Focus();
                            kutucuk = 6;
                        }
                        else if (tahir7.Name == focusname)
                        {
                            tahir7.Focus();
                            kutucuk = 7;
                        }
                        else if (tahir8.Name == focusname)
                        {
                            tahir8.Focus();
                            kutucuk = 8;
                        }
                        else if (tahir9.Name == focusname)
                        {
                            tahir9.Focus();
                            kutucuk = 9;
                        }
                        else if (tahir10.Name == focusname)
                        {
                            tahir10.Focus();
                            kutucuk = 10;
                        }
                        else if (tahir11.Name == focusname)
                        {
                            tahir11.Focus();
                            kutucuk = 11;
                        }
                        else if (tahir12.Name == focusname)
                        {
                            tahir12.Focus();
                            kutucuk = 12;
                        }
                        else if (tahir13.Name == focusname)
                        {
                            tahir13.Focus();
                            kutucuk = 13;
                        }
                        else if (tahir14.Name == focusname)
                        {
                            tahir14.Focus();
                            kutucuk = 14;
                        }
                        else if (tahir15.Name == focusname)
                        {
                            tahir15.Focus();
                            kutucuk = 15;
                        }
                    }
                    #endregion

                    //ve eğer olabilecek en son kutucuk da doldurulmuşsa kelime kontrolü
                    #region
                    if (acilanlar.Count == 0)
                    {
                        cevapcheck();
                    }
                    #endregion
                }
            }
        }
        private void Dinamik_Enter(object sender, EventArgs e)
        {
            if(((textbox_tahir)sender).Texts.Length == 1)
            {
                ((textbox_tahir)sender).SelectionStart = 0;
                ((textbox_tahir)sender).SelectionLength = ((textbox_tahir)sender).Texts.Length;
            }

            namecheck = ((textbox_tahir)sender).Name;
            tabindex = ((textbox_tahir)sender).TabIndex;
            sonuncukutu = Convert.ToInt32(acilanlarcopy[acilanlarcopy.Count - 1].ToString());

            string name = "tahir" + tabindex.ToString();

            while(true)
            {
                if(tahir0.Name == name)
                {
                    if(tahir1.Visible == true && tahir1.BackColor == Color.White)
                    {
                        focuss = "1";
                        break;
                    }
                    else if(tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if(tahir1.Visible == false || tahir1.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir1";
                    }
                }
                if (tahir1.Name == name)
                {
                    if (tahir2.Visible == true && tahir2.BackColor == Color.White)
                    {
                        focuss = "2";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir2.Visible == false || tahir2.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir2";
                    }
                }
                if (tahir2.Name == name)
                {
                    if (tahir3.Visible == true && tahir3.BackColor == Color.White)
                    {
                        focuss = "3";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir3.Visible == false || tahir3.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir3";
                    }
                }
                if (tahir3.Name == name)
                {
                    if (tahir4.Visible == true && tahir4.BackColor == Color.White)
                    {
                        focuss = "4";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir4.Visible == false || tahir4.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir4";
                    }
                }
                if (tahir4.Name == name)
                {
                    if (tahir5.Visible == true && tahir5.BackColor == Color.White)
                    {
                        focuss = "5";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir5.Visible == false || tahir5.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir5";
                    }
                }
                if (tahir5.Name == name)
                {
                    if (tahir6.Visible == true && tahir6.BackColor == Color.White)
                    {
                        focuss = "6";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir6.Visible == false || tahir6.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir6";
                    }
                }
                if (tahir6.Name == name)
                {
                    if (tahir7.Visible == true && tahir7.BackColor == Color.White)
                    {
                        focuss = "7";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir7.Visible == false || tahir7.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir7";
                    }
                }
                if (tahir7.Name == name)
                {
                    if (tahir8.Visible == true && tahir8.BackColor == Color.White)
                    {
                        focuss = "8";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir8.Visible == false || tahir8.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir8";
                    }
                }
                if (tahir8.Name == name)
                {
                    if (tahir9.Visible == true && tahir9.BackColor == Color.White)
                    {
                        focuss = "9";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir9.Visible == false || tahir9.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir9";
                    }
                }
                if (tahir9.Name == name)
                {
                    if (tahir10.Visible == true && tahir10.BackColor == Color.White)
                    {
                        focuss = "10";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir10.Visible == false || tahir10.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir10";
                    }
                }
                if (tahir10.Name == name)
                {
                    if (tahir11.Visible == true && tahir11.BackColor == Color.White)
                    {
                        focuss = "11";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir11.Visible == false || tahir11.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir11";
                    }
                }
                if (tahir11.Name == name)
                {
                    if (tahir12.Visible == true && tahir12.BackColor == Color.White)
                    {
                        focuss = "12";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir12.Visible == false || tahir12.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir12";
                    }
                }
                if (tahir12.Name == name)
                {
                    if (tahir13.Visible == true && tahir13.BackColor == Color.White)
                    {
                        focuss = "13";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir13.Visible == false || tahir13.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir13";
                    }
                }
                if (tahir13.Name == name)
                {
                    if (tahir14.Visible == true && tahir14.BackColor == Color.White)
                    {
                        focuss = "14";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir14.Visible == false || tahir14.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir14";
                    }
                }
                if (tahir14.Name == name)
                {
                    if (tahir15.Visible == true && tahir15.BackColor == Color.White)
                    {
                        focuss = "15";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir15.Visible == false || tahir15.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir15";
                    }
                }
                if (tahir15.Name == name)
                {
                    if (tahir0.Visible == true && tahir0.BackColor == Color.White)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tabindex == sonuncukutu)
                    {
                        focuss = "0";
                        break;
                    }
                    else if (tahir0.Visible == false || tahir0.BackColor == Color.FromArgb(0, 127, 0))
                    {
                        name = "tahir0";
                    }
                }
            }
        }
        private void load_Click(object sender, EventArgs e)
        {
            using (loadingscreen frm = new loadingscreen(bekle))
            {
                frm.ShowDialog(this);
            }
        }
        private float GetNewPixels(float pixelsDPI96, float dpi)
        {
            return pixelsDPI96 * 96 / dpi;
        }
        private void oyun_Load(object sender, EventArgs e)
        {
            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;

            using (Graphics g = this.CreateGraphics())
            {
                float dpii = g.DpiY;
                float newFontSize = GetNewPixels(32f, dpii);
                lblword.Font = new Font("Alata", 32f, GraphicsUnit.Pixel);
                lblwordpoint.Font = new Font("Big Shoulders Display", 38f, GraphicsUnit.Pixel);
                lbremainingpoint.Font = new Font("Big Shoulders Display", 38f, GraphicsUnit.Pixel);
                lblremainingtime.Font = new Font("Big Shoulders Display", 53f, GraphicsUnit.Pixel);
                lbltotalpoint.Font = new Font("Montserrat", 29f, GraphicsUnit.Pixel);
                lblbesttotalpoint.Font = new Font("Montserrat", 29f, GraphicsUnit.Pixel);
                tahir0.Font = new Font("Alata",48f, GraphicsUnit.Pixel);
                tahir1.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir2.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir3.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir4.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir5.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir6.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir7.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir8.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir9.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir10.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir11.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir12.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir13.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir14.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
                tahir15.Font = new Font("Alata", 48f, GraphicsUnit.Pixel);
            }

            lblwordpoint.Text = "000";
            lbremainingpoint.Text = "30";
            lblword.Text = "";
            lblremainingtime.Text = "3:00";

            lblwordpoint.Visible = true;
            lbremainingpoint.Visible = true;
            lblremainingtime.Visible = true;
            lblword.Visible = true;
            whiteprogress.Visible = false;
            blackprogress.Visible = false;

            kelimesayac = 0;
            kelimeindex = 0;
            oyunload();

            timer1.Start();

            pictureBox1.Image = Properties.Resources.yeni_oyun_ici_min;
        }
        private void oyun_KeyUp(object sender, KeyEventArgs e)
        {
            int x = acilanlar.Count;

            keys.Add(e.KeyCode.ToString());
            tus = string.Join("+", keys);
            keys.Clear();

            //SADECE KUTUCUKLARDA YÖN TUŞLARI İLE DOLAŞABİLME VE KLAVYEYİ DEAKTİVE ETME (DAHA DOĞRUSU FOCUSU MANİPÜLE ETME) KODLARINI İÇERİR
            #region
            if (timer2.Enabled == false)
            {
                gridunnecessaryfocus.Focus();
            }
            else if (timer2.Enabled == true)
            {
                if (tus == "Right")
                {
                    while(true)
                    {
                        if (kutucuk == 0)
                        {
                            if (tahir1.Visible == true && tahir1.BackColor == Color.White)
                            {
                                tahir1.Focus();
                                kutucuk = 1;
                                break;
                            }
                            else
                            {
                                kutucuk = 1;
                            }

                            if (acilanlar[x - 1].ToString() == "0")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 1)
                        {
                            if (tahir2.Visible == true && tahir2.BackColor == Color.White)
                            {
                                tahir2.Focus();
                                kutucuk = 2;
                                break;
                            }
                            else
                            {
                                kutucuk = 2;
                            }

                            if (acilanlar[x - 1].ToString() == "1")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 2)
                        {
                            if (tahir3.Visible == true && tahir3.BackColor == Color.White)
                            {
                                tahir3.Focus();
                                kutucuk = 3;
                                break;
                            }
                            else
                            {
                                kutucuk = 3;
                            }

                            if (acilanlar[x - 1].ToString() == "2")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 3)
                        {
                            if (tahir4.Visible == true && tahir4.BackColor == Color.White)
                            {
                                tahir4.Focus();
                                kutucuk = 4;
                                break;
                            }
                            else
                            {
                                kutucuk = 4;
                            }

                            if (acilanlar[x - 1].ToString() == "3")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 4)
                        {
                            if (tahir5.Visible == true && tahir5.BackColor == Color.White)
                            {
                                tahir5.Focus();
                                kutucuk = 5;
                                break;
                            }
                            else
                            {
                                kutucuk = 5;
                            }

                            if (acilanlar[x - 1].ToString() == "4")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 5)
                        {
                            if (tahir6.Visible == true && tahir6.BackColor == Color.White)
                            {
                                tahir6.Focus();
                                kutucuk = 6;
                                break;
                            }
                            else
                            {
                                kutucuk = 6;
                            }

                            if (acilanlar[x - 1].ToString() == "5")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 6)
                        {
                            if (tahir7.Visible == true && tahir7.BackColor == Color.White)
                            {
                                tahir7.Focus();
                                kutucuk = 7;
                                break;
                            }
                            else
                            {
                                kutucuk = 7;
                            }

                            if (acilanlar[x - 1].ToString() == "6")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 7)
                        {
                            if (tahir8.Visible == true && tahir8.BackColor == Color.White)
                            {
                                tahir8.Focus();
                                kutucuk = 8;
                                break;
                            }
                            else
                            {
                                kutucuk = 8;
                            }

                            if (acilanlar[x - 1].ToString() == "7")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 8)
                        {
                            if (tahir9.Visible == true && tahir9.BackColor == Color.White)
                            {
                                tahir9.Focus();
                                kutucuk = 9;
                                break;
                            }
                            else
                            {
                                kutucuk = 9;
                            }

                            if (acilanlar[x - 1].ToString() == "8")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 9)
                        {
                            if (tahir10.Visible == true && tahir10.BackColor == Color.White)
                            {
                                tahir10.Focus();
                                kutucuk = 10;
                                break;
                            }
                            else
                            {
                                kutucuk = 10;
                            }

                            if (acilanlar[x - 1].ToString() == "9")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 10)
                        {
                            if (tahir11.Visible == true && tahir11.BackColor == Color.White)
                            {
                                tahir11.Focus();
                                kutucuk = 11;
                                break;
                            }
                            else
                            {
                                kutucuk = 11;
                            }

                            if (acilanlar[x - 1].ToString() == "10")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 11)
                        {
                            if (tahir12.Visible == true && tahir12.BackColor == Color.White)
                            {
                                tahir12.Focus();
                                kutucuk = 12;
                                break;
                            }
                            else
                            {
                                kutucuk = 12;
                            }

                            if (acilanlar[x - 1].ToString() == "11")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 12)
                        {
                            if (tahir13.Visible == true && tahir13.BackColor == Color.White)
                            {
                                tahir13.Focus();
                                kutucuk = 13;
                                break;
                            }
                            else
                            {
                                kutucuk = 13;
                            }

                            if (acilanlar[x - 1].ToString() == "12")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 13)
                        {
                            if (tahir14.Visible == true && tahir14.BackColor == Color.White)
                            {
                                tahir14.Focus();
                                kutucuk = 14;
                                break;
                            }
                            else
                            {
                                kutucuk = 14;
                            }

                            if (acilanlar[x - 1].ToString() == "13")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 14)
                        {
                            if (tahir15.Visible == true && tahir15.BackColor == Color.White)
                            {
                                tahir15.Focus();
                                kutucuk = 15;
                                break;
                            }
                            else
                            {
                                kutucuk = 15;
                            }

                            if (acilanlar[x - 1].ToString() == "14")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (kutucuk == 15)
                        {
                            if (tahir0.Visible == true && tahir0.BackColor == Color.White)
                            {
                                tahir0.Focus();
                                kutucuk = 0;
                                break;
                            }
                            else
                            {
                                kutucuk = 0;
                            }

                            if (acilanlar[x - 1].ToString() == "15")
                            {
                                for (int i = 0; i < renkler.Count; i++)
                                {
                                    if (renkler[i].ToString() == "white and visible")
                                    {
                                        odak = i;
                                        focus();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                else if (tus == "Left")
                {
                    while(true)
                    {
                        if (kutucuk == 1)
                        {
                            if (tahir0.Visible == true && tahir0.BackColor == Color.White)
                            {
                                tahir0.Focus();
                                kutucuk = 0;
                                break;
                            }
                            else
                            {
                                kutucuk = 0;
                            }
                        }
                        if (kutucuk == 2)
                        {
                            if (tahir1.Visible == true && tahir1.BackColor == Color.White)
                            {
                                tahir1.Focus();
                                kutucuk = 1;
                                break;
                            }
                            else
                            {
                                kutucuk = 1;
                            }
                        }
                        if (kutucuk == 3)
                        {
                            if (tahir2.Visible == true && tahir2.BackColor == Color.White)
                            {
                                tahir2.Focus();
                                kutucuk = 2;
                                break;
                            }
                            else
                            {
                                kutucuk = 2;
                            }
                        }
                        if (kutucuk == 4)
                        {
                            if (tahir3.Visible == true && tahir3.BackColor == Color.White)
                            {
                                tahir3.Focus();
                                kutucuk = 3;
                                break;
                            }
                            else
                            {
                                kutucuk = 3;
                            }
                        }
                        if (kutucuk == 5)
                        {
                            if (tahir4.Visible == true && tahir4.BackColor == Color.White)
                            {
                                tahir4.Focus();
                                kutucuk = 4;
                                break;
                            }
                            else
                            {
                                kutucuk = 4;
                            }
                        }
                        if (kutucuk == 6)
                        {
                            if (tahir5.Visible == true && tahir5.BackColor == Color.White)
                            {
                                tahir5.Focus();
                                kutucuk = 5;
                                break;
                            }
                            else
                            {
                                kutucuk = 5;
                            }
                        }
                        if (kutucuk == 7)
                        {
                            if (tahir6.Visible == true && tahir6.BackColor == Color.White)
                            {
                                tahir6.Focus();
                                kutucuk = 6;
                                break;
                            }
                            else
                            {
                                kutucuk = 6;
                            }
                        }
                        if (kutucuk == 8)
                        {
                            if (tahir7.Visible == true && tahir7.BackColor == Color.White)
                            {
                                tahir7.Focus();
                                kutucuk = 7;
                                break;
                            }
                            else
                            {
                                kutucuk = 7;
                            }
                        }
                        if (kutucuk == 9)
                        {
                            if (tahir8.Visible == true && tahir8.BackColor == Color.White)
                            {
                                tahir8.Focus();
                                kutucuk = 8;
                                break;
                            }
                            else
                            {
                                kutucuk = 8;
                            }
                        }
                        if (kutucuk == 10)
                        {
                            if (tahir9.Visible == true && tahir9.BackColor == Color.White)
                            {
                                tahir9.Focus();
                                kutucuk = 9;
                                break;
                            }
                            else
                            {
                                kutucuk = 9;
                            }
                        }
                        if (kutucuk == 11)
                        {
                            if (tahir10.Visible == true && tahir10.BackColor == Color.White)
                            {
                                tahir10.Focus();
                                kutucuk = 10;
                                break;
                            }
                            else
                            {
                                kutucuk = 10;
                            }
                        }
                        if (kutucuk == 12)
                        {
                            if (tahir11.Visible == true && tahir11.BackColor == Color.White)
                            {
                                tahir11.Focus();
                                kutucuk = 11;
                                break;
                            }
                            else
                            {
                                kutucuk = 11;
                            }
                        }
                        if (kutucuk == 13)
                        {
                            if (tahir12.Visible == true && tahir12.BackColor == Color.White)
                            {
                                tahir12.Focus();
                                kutucuk = 12;
                                break;
                            }
                            else
                            {
                                kutucuk = 12;
                            }
                        }
                        if (kutucuk == 14)
                        {
                            if (tahir13.Visible == true && tahir13.BackColor == Color.White)
                            {
                                tahir13.Focus();
                                kutucuk = 13;
                                break;
                            }
                            else
                            {
                                kutucuk = 13;
                            }
                        }
                        if (kutucuk == 15)
                        {
                            if (tahir14.Visible == true && tahir14.BackColor == Color.White)
                            {
                                tahir14.Focus();
                                kutucuk = 14;
                                break;
                            }
                            else
                            {
                                kutucuk = 14;
                            }
                        }
                        if (kutucuk == 0)
                        {
                            int b = acilanlar.Count;
                            string son = "tahir" + acilanlar[b - 1].ToString();

                            if (tahir0.Name == son)
                            {
                                tahir0.Focus();
                                kutucuk = 0;
                                break;
                            }
                            else if (tahir1.Name == son)
                            {
                                tahir1.Focus();
                                kutucuk = 1;
                                break;
                            }
                            else if (tahir2.Name == son)
                            {
                                tahir2.Focus();
                                kutucuk = 2;
                                break;
                            }
                            else if (tahir3.Name == son)
                            {
                                tahir3.Focus();
                                kutucuk = 3;
                                break;
                            }
                            else if (tahir4.Name == son)
                            {
                                tahir4.Focus();
                                kutucuk = 4;
                                break;
                            }
                            else if (tahir5.Name == son)
                            {
                                tahir5.Focus();
                                kutucuk = 5;
                                break;
                            }
                            else if (tahir6.Name == son)
                            {
                                tahir6.Focus();
                                kutucuk = 6;
                                break;
                            }
                            else if (tahir7.Name == son)
                            {
                                tahir7.Focus();
                                kutucuk = 7;
                                break;
                            }
                            else if (tahir8.Name == son)
                            {
                                tahir8.Focus();
                                kutucuk = 8;
                                break;
                            }
                            else if (tahir9.Name == son)
                            {
                                tahir9.Focus();
                                kutucuk = 9;
                                break;
                            }
                            else if (tahir10.Name == son)
                            {
                                tahir10.Focus();
                                kutucuk = 10;
                                break;
                            }
                            else if (tahir11.Name == son)
                            {
                                tahir11.Focus();
                                kutucuk = 11;
                                break;
                            }
                            else if (tahir12.Name == son)
                            {
                                tahir12.Focus();
                                kutucuk = 12;
                                break;
                            }
                            else if (tahir13.Name == son)
                            {
                                tahir13.Focus();
                                kutucuk = 13;
                                break;
                            }
                            else if (tahir14.Name == son)
                            {
                                tahir14.Focus();
                                kutucuk = 14;
                                break;
                            }
                            else if (tahir15.Name == son)
                            {
                                tahir15.Focus();
                                kutucuk = 15;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
