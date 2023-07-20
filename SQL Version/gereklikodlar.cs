using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO
{
    class gereklikodlar
    {
        /*
         * GUNCELLEME KODU!!!!
         *                                                     cmd = new SqlCommand("guncelleGirisPsyword", con);
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    cmd.Parameters.AddWithValue("kGrup", "");
                                                    cmd.Parameters.AddWithValue("girisDatetime", "");
                                                    cmd.Parameters.AddWithValue("cikisDatetime", "");
                                                    cmd.Parameters.AddWithValue("totalsureDatetime", "");
                                                    cmd.Parameters.AddWithValue("mevcutDatetime", "");
                                                    cmd.Parameters.AddWithValue("kayittamam", "");
                                                    cmd.Parameters.AddWithValue("kAdi", kullanici_adi.Texts);
                                                    cmd.Parameters.AddWithValue("oturum", Convert.ToInt32(oturumsayisi.Text));
                                                    cmd.ExecuteNonQuery();
         * 
         * 
         * 
         *                                      mevcut_x = DateTime.Now.ToString();
                                                mevcut = mevcut_x.Substring(0, 10);

                                                string veritabani_mevcut = girisPsyword.Rows[rowcount - 1].Cells[6].Value.ToString();

                                                if (veritabani_mevcut == mevcut)
                                                {

                                                    MessageBox.Show("Giriş başarılı!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    gecis = 5;
                                                    oyun x_ = new oyun();
                                                    x_.Show();
                                                    this.Hide();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Uygulamaya iki oturum boyunca katılım sağlayamadığınız için artık uygulamaya giriş yapamazsınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
         * 
         * 
         */


        /*
         * 
         * 
         *             if (dakika == "00")
            {
                if (saat == "00")
                {
                    timer1.Stop();
                }
                else
                {
                    dakika = "59";
                    saniye = "59";

                    int sa = Convert.ToInt32(saat);
                    sa--;

                    if (sa == 9 || sa == 8 || sa == 7 || sa == 6 || sa == 5 || sa == 4 || sa == 3 || sa == 2 || sa == 1 || sa == 0)
                    {
                        saat = "0" + sa;
                    }
                    else
                    {
                        saat = Convert.ToString(sa);
                    }
                }
            }
            else
            {
                saniye = "59";
                cikar_dk--;

                if (cikar_dk == 9 || cikar_dk == 8 || cikar_dk == 7 || cikar_dk == 6 || cikar_dk == 5 || cikar_dk == 4 || cikar_dk == 3 || cikar_dk == 2 || cikar_dk == 1 || cikar_dk == 0)
                {
                    dakika = "0" + cikar_dk;
                }
                else
                {
                    dakika = Convert.ToString(cikar_dk);
                }
            }

            if (cikar_dk == 9 || cikar_dk == 8 || cikar_dk == 7 || cikar_dk == 6 || cikar_dk == 5 || cikar_dk == 4 || cikar_dk == 3 || cikar_dk == 2 || cikar_dk == 1 || cikar_dk == 0)
            {
                dakika = "0" + cikar_dk;
            }
            else
            {
                dakika = Convert.ToString(cikar_dk);
            }

            if (cikar_saa == 9 || cikar_saa == 8 || cikar_saa == 7 || cikar_saa == 6 || cikar_saa == 5 || cikar_saa == 4 || cikar_saa == 3 || cikar_saa == 2 || cikar_saa == 1 || cikar_saa == 0)
            {
                saat = "0" + cikar_saa;
            }
            else
            {
                saat = Convert.ToString(cikar_saa);
            }

            saniye = Convert.ToString(cikar_sa);
            dakika = Convert.ToString(cikar_dk);
            saat = Convert.ToString(cikar_saa);

            if(cikar_sa == 0)
            {
                if(cikar_dk == 0)
                {
                    if(cikar_saa == 0)
                    {
                        timer1.Stop();
                    }
                    else
                    {
                        dakika = "59";
                        saniye = "59";

                        cikar_saa--;

                        if (cikar_saa == 9 || cikar_saa == 8 || cikar_saa == 7 || cikar_saa == 6 || cikar_saa == 5 || cikar_saa == 4 || cikar_saa == 3 || cikar_saa == 2 || cikar_saa == 1 || cikar_saa == 0)
                        {
                            saat = "0" + cikar_saa;
                        }
                        else
                        {
                            saat = Convert.ToString(cikar_saa);
                        }
                    }
                }
                else
                {
                    saniye = "59";
                    cikar_dk--;

                    if (cikar_dk == 9 || cikar_dk == 8 || cikar_dk == 7 || cikar_dk == 6 || cikar_dk == 5 || cikar_dk == 4 || cikar_dk == 3 || cikar_dk == 2 || cikar_dk == 1 || cikar_dk == 0)
                    {
                        dakika = "0" + cikar_dk;
                    }
                    else
                    {
                        dakika = Convert.ToString(cikar_dk);
                    }
                }
            }
            else
            {
                cikar_sa--;

                if (cikar_sa == 9 || cikar_sa == 8 || cikar_sa == 7 || cikar_sa == 6 || cikar_sa == 5 || cikar_sa == 4 || cikar_sa == 3 || cikar_sa == 2 || cikar_sa == 1 || cikar_sa == 0)
                {
                    saniye = "0" + cikar_sa;
                }
                else
                {
                    saniye = Convert.ToString(cikar_sa);
                }
            }
         * 
         * 
         * 
         * 
            if (saniye == "00")
            {
                if (dakika == "00")
                {
                    if (saat == "00")
                    {
                        //ana menüye at
                    }
                }
            }


            if (saniye == "00")
            {

                saniye = "59";
                dakika = "59";

                cikar_saa--;
            }
         * 
         * 
         * 
         * 
         * 
         * 
         *             //oyun sonu
            else if (mod == 3)
            {
                //MENÜYE DÖNÜŞ
                if (x >= 1543 * (genislik_koordinatx / 1920) / scale && x <= 1618 * (genislik_koordinatx / 1920) / scale && y >= 686 * (yukseklik_koordinaty / 1080) / scale && y <= 761 * (yukseklik_koordinaty / 1080) / scale)
                {
                    if (dilandlocate.Default.ses == 1)
                    {
                        bas();
                    }

                    ilkgun f = new ilkgun();
                    f.Show();
                    this.Close();

                    mod = 1;
                }

                //OYUNDAN ÇIK
                if (x >= 1636 * (genislik_koordinatx / 1920) / scale && x <= 1711 * (genislik_koordinatx / 1920) / scale && y >= 686 * (yukseklik_koordinaty / 1080) / scale && y <= 761 * (yukseklik_koordinaty / 1080) / scale)
                {
                    bas();

                    Application.Exit();
                }
            }
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         *                     else if(b == "1")
                    {
                        tahir1.BackColor = Color.Red;
                        tahir1.ForeColor = Color.White;
                        tahir1.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "2")
                    {
                        tahir2.BackColor = Color.Red;
                        tahir2.ForeColor = Color.White;
                        tahir2.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "3")
                    {
                        tahir3.BackColor = Color.Red;
                        tahir3.ForeColor = Color.White;
                        tahir3.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "4")
                    {
                        tahir4.BackColor = Color.Red;
                        tahir4.ForeColor = Color.White;
                        tahir4.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "5")
                    {
                        tahir5.BackColor = Color.Red;
                        tahir5.ForeColor = Color.White;
                        tahir5.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "6")
                    {
                        tahir6.BackColor = Color.Red;
                        tahir6.ForeColor = Color.White;
                        tahir6.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "7")
                    {
                        tahir7.BackColor = Color.Red;
                        tahir7.ForeColor = Color.White;
                        tahir7.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "8")
                    {
                        tahir8.BackColor = Color.Red;
                        tahir8.ForeColor = Color.White;
                        tahir8.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "9")
                    {
                        tahir9.BackColor = Color.Red;
                        tahir9.ForeColor = Color.White;
                        tahir9.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "10")
                    {
                        tahir10.BackColor = Color.Red;
                        tahir10.ForeColor = Color.White;
                        tahir10.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "11")
                    {
                        tahir11.BackColor = Color.Red;
                        tahir11.ForeColor = Color.White;
                        tahir11.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "12")
                    {
                        tahir12.BackColor = Color.Red;
                        tahir12.ForeColor = Color.White;
                        tahir12.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "13")
                    {
                        tahir13.BackColor = Color.Red;
                        tahir13.ForeColor = Color.White;
                        tahir13.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "14")
                    {
                        tahir14.BackColor = Color.Red;
                        tahir14.ForeColor = Color.White;
                        tahir14.Texts = harfler_index[i].Substring(0, 1);
                    }
                    else if (b == "15")
                    {
                        tahir15.BackColor = Color.Red;
                        tahir15.ForeColor = Color.White;
                        tahir15.Texts = harfler_index[i].Substring(0, 1);
                    }
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         *                                                 griddoldur();

                                                DataView dv3 = tablo2.DefaultView;
                                                dv3.RowFilter = "mevcutDatetime Like '%" + mevcut + "%' and kAdi like '%" + kullanici_adi.Texts + "%'";
                                                girisPsyword.DataSource = dv3;

                                                int rowcount = girisPsyword.Rows.Count;

                                                if(rowcount == 0)
                                                {
                                                    griddoldur();

                                                    DataView dv5 = tablo2.DefaultView;
                                                    dv5.RowFilter = "kAdi like '%" + kullanici_adi.Texts + "%'";
                                                    girisPsyword.DataSource = dv5;

                                                    int d = girisPsyword.Rows.Count;

                                                    mevcut_x = DateTime.Now.ToString();
                                                    mevcut = mevcut_x.Substring(0, 10);

                                                    con.Close();
                                                    con.Open();

                                                    cmd = new SqlCommand("ekleGirisPsyword", con);
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    cmd.Parameters.AddWithValue("kAdi", kullanici_adi.Texts);
                                                    cmd.Parameters.AddWithValue("kGrup", txt_oturum.Text);
                                                    cmd.Parameters.AddWithValue("oturum", Convert.ToInt32(d++));
                                                    cmd.Parameters.AddWithValue("girisDatetime", "");
                                                    cmd.Parameters.AddWithValue("cikisDatetime", "");
                                                    cmd.Parameters.AddWithValue("totalsureDatetime", "");
                                                    cmd.Parameters.AddWithValue("mevcutDatetime", mevcut);
                                                    cmd.Parameters.AddWithValue("kayittamam", "hayir");
                                                    cmd.ExecuteNonQuery();

                                                    con.Close();
                                                    tablo.Clear();

                                                    dilandlocate.Default.kullaniciadi = kullanici_adi.Texts;
                                                    dilandlocate.Default.Save();
                                                    dilandlocate.Default.kullanicigrup = txt_oturum.Text;
                                                    dilandlocate.Default.Save();

                                                    ilkgun x_ = new ilkgun();
                                                    x_.Show();
                                                    this.Hide();
                                                }
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         *                                                 else if (girisPsyword.Rows.Count == 2 && Convert.ToInt32(mevcut) != Convert.ToInt32(b))
                                                {
                                                    pictureBox1.Image = Properties.Resources.kullanici_elendi;

                                                    kullanici_adi.Visible = false;
                                                    kullanici_sifre.Visible = false;
                                                }
         * 
         * 
         * 
         * 
         * 
         * 
         *  /*
                                                     * MEVCUT GÜNDEN ÖNCE İÇİN 1 HAYIR VARSA EĞER, SON OTURUM SAYISINA 
                                                     * İKİ EKLENEREK Mİ KAYDEDİLMESİ SİSTEME ACABA; EVET EKLEMELİYİZ ÇÜNKÜ BUNU GÜNCELLİYOR 
                                                     * VE SONRA DİĞER GÜN YA DA OTURUM İÇİN EKLİYOR
                                                     * 1 HAYIR VAR VE KENDİ GÜNÜNDEYSE SORUN YOK ONU 
                                                     * GÜNCELLEMESİ GEREKİYOR ZATEN VE ÖYLE DEVAM EDİYOR
                                                     * 
                                                     * 
                                                     * YANİ
                                                     * 1 tane hayır varsa ve güncel tarihte bir kaydı yoksa bu yukarıdakini yapacağız
                                                     * 
                                                     * hayır yoksa eğer zaten sistemde kaydı tutulmuştur, onu güncelleyecek o kadar
                                                     * 
                                                     * 
                                                     * aradığım kod kesinlikle buydu
                                                     */




        /*
         * 
         * 
         * 
         *     double guven_RT_90 = standartsapma_RT / (Math.Sqrt(24));
                double hatapayi_90 = ((float)1.645) * (guven_RT_90);
                double guvenaraliği_RT_1_90 = ort - hatapayi_90;
                double guvenaraliği_RT_2_90 = ort + hatapayi_90;

                string guvenaraligi_RT_90 = guvenaraliği_RT_1_90 + " ve " + guvenaraliği_RT_2_90;

                int aralik_2 = 0;
                for (int f = 0; f < time.Items.Count; f++)
                {
                    if (guvenaraliği_RT_1_90 < Convert.ToDouble(time.Items[f]))
                    {
                        if (Convert.ToDouble(time.Items[f]) < guvenaraliği_RT_2_90)
                        {
                            aralik_2++;
                        }
                    }
                }

                double oran_2 = aralik_2 / 24;
                if (oran_2 > 0.90)
                {
                    anlamli_RT_90 = "anlamlı, kişi sağlıklı bir oturum geçirmiş;  yani yaptığı işi anlamış / yapmış (yüzde 90)";
                }
                else
                {
                    anlamli_RT_90 = "anlamsız, kişi sağlıklı bir oturum geçirmemiş; yani yaptığı işi anlayamamış / yapamamış (yüzde 90)";
                }
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         *         [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpszFilename);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int CreateScalableFontResource(uint fdwHidden, string
        lpszFontRes, string lpszFontFile, string lpszCurrentPath);
        /// <summary>
        /// Installs font on the user's system and adds it to the registry so it's available on the next session
        /// Your font must be included in your project with its build path set to 'Content' and its Copy property
        /// set to 'Copy Always'
        /// </summary>
        /// <param name="contentFontName">Your font to be passed as a resource (i.e. "myfont.tff")</param>
        private static void RegisterFont(string contentFontName)
        {
            // Creates the full path where your font will be installed
            var fontDestination = Path.Combine(System.Environment.GetFolderPath
                                              (System.Environment.SpecialFolder.Fonts), contentFontName);

            if (!File.Exists(fontDestination))
            {
                // Copies font to destination
                System.IO.File.Copy(Path.Combine(System.IO.Directory.GetCurrentDirectory(), contentFontName), fontDestination);

                // Retrieves font name
                // Makes sure you reference System.Drawing
                PrivateFontCollection fontCol = new PrivateFontCollection();
                fontCol.AddFontFile(fontDestination);
                var actualFontName = fontCol.Families[0].Name;

                //Add font
                AddFontResource(fontDestination);
                //Add registry entry  
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts",
                actualFontName, contentFontName, RegistryValueKind.String);
            }
        }

         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */













        /*
         * 
         * 
         * 
         * 
         * 
         * for (int i = 0; i < DYBos.Count; i++)
                    {
                        if(DYBos.ElementAt(i) == "doğru")
                        {
                            if(i == 0)
                            {
                                label1.ForeColor = Color.Green;
                                underlineTextbox2.BorderColor = Color.Green;
                            }
                            else if (i == 1)
                            {
                                label2.ForeColor = Color.Green;
                                underlineTextbox3.BorderColor = Color.Green;
                            }
                            else if (i == 2)
                            {
                                label3.ForeColor = Color.Green;
                                underlineTextbox4.BorderColor = Color.Green;
                            }
                            else if (i == 3)
                            {
                                label4.ForeColor = Color.Green;
                                underlineTextbox5.BorderColor = Color.Green;
                            }
                            else if (i == 4)
                            {
                                label5.ForeColor = Color.Green;
                                underlineTextbox6.BorderColor = Color.Green;
                            }
                            else if (i == 5)
                            {
                                label6.ForeColor = Color.Green;
                                underlineTextbox7.BorderColor = Color.Green;
                            }
                            else if (i == 6)
                            {
                                label7.ForeColor = Color.Green;
                                underlineTextbox8.BorderColor = Color.Green;
                            }
                            else if (i == 7)
                            {
                                label8.ForeColor = Color.Green;
                                underlineTextbox9.BorderColor = Color.Green;
                            }
                            else if (i == 8)
                            {
                                label9.ForeColor = Color.Green;
                                underlineTextbox10.BorderColor = Color.Green;
                            }
                            else if (i == 9)
                            {
                                label10.ForeColor = Color.Green;
                                underlineTextbox11.BorderColor = Color.Green;
                            }
                            else if (i == 10)
                            {
                                label11.ForeColor = Color.Green;
                                underlineTextbox12.BorderColor = Color.Green;
                            }
                            else if (i == 11)
                            {
                                label12.ForeColor = Color.Green;
                                underlineTextbox13.BorderColor = Color.Green;
                            }
                            else if (i == 12)
                            {
                                label13.ForeColor = Color.Green;
                                underlineTextbox14.BorderColor = Color.Green;
                            }
                            else if (i == 13)
                            {
                                label14.ForeColor = Color.Green;
                                underlineTextbox15.BorderColor = Color.Green;
                            }
                            else if (i == 14)
                            {
                                label15.ForeColor = Color.Green;
                                underlineTextbox16.BorderColor = Color.Green;
                            }
                            else if (i == 15)
                            {
                                label16.ForeColor = Color.Green;
                                underlineTextbox17.BorderColor = Color.Green;
                            }
                            else if (i == 16)
                            {
                                label17.ForeColor = Color.Green;
                                underlineTextbox18.BorderColor = Color.Green;
                            }
                            else if (i == 17)
                            {
                                label18.ForeColor = Color.Green;
                                underlineTextbox19.BorderColor = Color.Green;
                            }
                            else if (i == 18)
                            {
                                label19.ForeColor = Color.Green;
                                underlineTextbox20.BorderColor = Color.Green;
                            }
                            else if (i == 19)
                            {
                                label20.ForeColor = Color.Green;
                                underlineTextbox21.BorderColor = Color.Green;
                            }
                            else if (i == 20)
                            {
                                label21.ForeColor = Color.Green;
                                underlineTextbox22.BorderColor = Color.Green;
                            }
                            else if (i == 21)
                            {
                                label22.ForeColor = Color.Green;
                                underlineTextbox23.BorderColor = Color.Green;
                            }
                            else if (i == 22)
                            {
                                label23.ForeColor = Color.Green;
                                underlineTextbox24.BorderColor = Color.Green;
                            }
                            else if (i == 23)
                            {
                                label24.ForeColor = Color.Green;
                                underlineTextbox25.BorderColor = Color.Green;
                            }
                        }
                        else if (DYBos.ElementAt(i) == "yanlis")
                        {
                            if (i == 0)
                            {
                                label1.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox2.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 1)
                            {
                                label2.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox3.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 2)
                            {
                                label3.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox4.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 3)
                            {
                                label4.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox5.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 4)
                            {
                                label5.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox6.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 5)
                            {
                                label6.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox7.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 6)
                            {
                                label7.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox8.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 7)
                            {
                                label8.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox9.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 8)
                            {
                                label9.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox10.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 9)
                            {
                                label10.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox11.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 10)
                            {
                                label11.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox12.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 11)
                            {
                                label12.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox13.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 12)
                            {
                                label13.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox14.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 13)
                            {
                                label14.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox15.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 14)
                            {
                                label15.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox16.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 15)
                            {
                                label16.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox17.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 16)
                            {
                                label17.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox18.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 17)
                            {
                                label18.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox19.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 18)
                            {
                                label19.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox20.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 19)
                            {
                                label20.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox21.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 20)
                            {
                                label21.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox22.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 21)
                            {
                                label22.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox23.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 22)
                            {
                                label23.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox24.BorderColor = Color.FromArgb(228,1,11);
                            }
                            else if (i == 23)
                            {
                                label24.ForeColor = Color.FromArgb(228,1,11);
                                underlineTextbox25.BorderColor = Color.FromArgb(228,1,11);
                            }
                        }
                        else if (DYBos.ElementAt(i) == "bos")
                        {
                            if (i == 0)
                            {
                                label1.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox2.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 1)
                            {
                                label2.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox3.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 2)
                            {
                                label3.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox4.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 3)
                            {
                                label4.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox5.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 4)
                            {
                                label5.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox6.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 5)
                            {
                                label6.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox7.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 6)
                            {
                                label7.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox8.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 7)
                            {
                                label8.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox9.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 8)
                            {
                                label9.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox10.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 9)
                            {
                                label10.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox11.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 10)
                            {
                                label11.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox12.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 11)
                            {
                                label12.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox13.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 12)
                            {
                                label13.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox14.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 13)
                            {
                                label14.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox15.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 14)
                            {
                                label15.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox16.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 15)
                            {
                                label16.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox17.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 16)
                            {
                                label17.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox18.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 17)
                            {
                                label18.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox19.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 18)
                            {
                                label19.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox20.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 19)
                            {
                                label20.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox21.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 20)
                            {
                                label21.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox22.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 21)
                            {
                                label22.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox23.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 22)
                            {
                                label23.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox24.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                            else if (i == 23)
                            {
                                label24.ForeColor = Color.FromArgb(251, 134, 0);
                                underlineTextbox25.BorderColor = Color.FromArgb(251, 134, 0);
                            }
                        }
                    }

                    underlineTextbox1.Texts = "";
                    lsl_aciklama.Text = "";
                    lbl_punto.Text = "";
                    underlineTextbox1.SendToBack();
                    lbl_punto.SendToBack();
                    lsl_aciklama.SendToBack();
                    underlineTextbox1.Location = new Point(0,0);
                    lsl_aciklama.Location = new Point(0,0);
                    lbl_punto.Location = new Point(0,0);


                    underlineTextbox1.Visible = false;
                    lsl_aciklama.Visible = false;
                    lbl_punto.Visible = false;

                    underlineTextbox2.BringToFront();
                    underlineTextbox3.BringToFront();
                    underlineTextbox4.BringToFront();
                    underlineTextbox5.BringToFront();
                    underlineTextbox6.BringToFront();
                    underlineTextbox7.BringToFront();
                    underlineTextbox8.BringToFront();
                    underlineTextbox9.BringToFront();
                    underlineTextbox10.BringToFront();
                    underlineTextbox11.BringToFront();
                    underlineTextbox12.BringToFront();
                    underlineTextbox13.BringToFront();
                    underlineTextbox14.BringToFront();
                    underlineTextbox15.BringToFront();
                    underlineTextbox16.BringToFront();
                    underlineTextbox17.BringToFront();
                    underlineTextbox18.BringToFront();
                    underlineTextbox19.BringToFront();
                    underlineTextbox20.BringToFront();
                    underlineTextbox21.BringToFront();
                    underlineTextbox22.BringToFront();
                    underlineTextbox23.BringToFront();
                    underlineTextbox24.BringToFront();
                    underlineTextbox25.BringToFront();

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;
                    label19.Visible = true;
                    label20.Visible = true;
                    label21.Visible = true;
                    label22.Visible = true;
                    label23.Visible = true;
                    label24.Visible = true;

                    underlineTextbox1.Visible = false;
                    underlineTextbox2.Visible = true;
                    underlineTextbox3.Visible = true;
                    underlineTextbox4.Visible = true;
                    underlineTextbox5.Visible = true;
                    underlineTextbox6.Visible = true;
                    underlineTextbox7.Visible = true;
                    underlineTextbox8.Visible = true;
                    underlineTextbox9.Visible = true;
                    underlineTextbox10.Visible = true;
                    underlineTextbox11.Visible = true;
                    underlineTextbox12.Visible = true;
                    underlineTextbox13.Visible = true;
                    underlineTextbox14.Visible = true;
                    underlineTextbox15.Visible = true;
                    underlineTextbox16.Visible = true;
                    underlineTextbox17.Visible = true;
                    underlineTextbox18.Visible = true;
                    underlineTextbox19.Visible = true;
                    underlineTextbox20.Visible = true;
                    underlineTextbox21.Visible = true;
                    underlineTextbox22.Visible = true;
                    underlineTextbox23.Visible = true;
                    underlineTextbox24.Visible = true;
                    underlineTextbox25.Visible = true;

                    label1.BringToFront();
                    label2.BringToFront();
                    label3.BringToFront();
                    label4.BringToFront();
                    label5.BringToFront();
                    label6.BringToFront();
                    label7.BringToFront();
                    label8.BringToFront();
                    label9.BringToFront();
                    label10.BringToFront();
                    label11.BringToFront();
                    label12.BringToFront();
                    label13.BringToFront();
                    label14.BringToFront();
                    label15.BringToFront();
                    label16.BringToFront();
                    label17.BringToFront();
                    label18.BringToFront();
                    label19.BringToFront();
                    label20.BringToFront();
                    label21.BringToFront();
                    label22.BringToFront();
                    label23.BringToFront();
                    label24.BringToFront();

                    pictureBox1.Image = Properties.Resources.geridonut_2_min;
         */



    }
}
