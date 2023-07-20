using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace DEMO
{
    public partial class testingcondition : Form
    {
        public testingcondition()
        {
            InitializeComponent();
        }
        //DEĞİŞKENLER
        #region
        OleDbConnection con_sql = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kullanici.accdb");
        OleDbCommand cmd_sql;
        DataTable tablo_sql, tablo2_sql;
        OleDbDataAdapter da_sql, da2_sql;

        gamecondition xxx = new gamecondition();
        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        gamecondition oyun = new gamecondition();

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

        List<int> dogruYanit = new List<int>();
        List<int> dogruYanitId = new List<int>();
        List<int> yanlisYanit = new List<int>();
        List<int> yanlisYanitId = new List<int>();
        List<int> font = new List<int>();
        List<string> DYBos = new List<string>();

        float basla_float, bitir_float, bitir_total_float, bbbbb, add_dk, ort = 0, toplam = 0;
        int kelimesayac = 0, kelimeindex = 0, oturum, sorusayi = 1, bitti = 0, baslangic = 0;
        string kullaniciadi, kullanicigrup, ifade, timestamp, timestamp_guncel, basla, bitir, girisdatetime, anlamli_RT_95, dogruidtotal, yanlisidtotal;

        private void underlineTextbox1_MouseEnter(object sender, EventArgs e)
        {
            if(enter != 0)
            {
                Cursor.Position = new Point(Cursor.Position.X + 100, Cursor.Position.Y + 100);
            }
        }

        int lbl1 = 0, lbl2 = 0, lbl3 = 0, lbl4 = 0, lbl5 = 0, lbl6 = 0, lbl7 = 0, lbl8 = 0, lbl9 = 0, lbl10 = 0, lbl11 = 0, lbl12 = 0, lbl13 = 0, lbl14 = 0, lbl15 = 0, lbl16 = 0, lbl17 = 0, lbl18 = 0, lbl19 = 0, lbl20 = 0, lbl21 = 0, lbl22 = 0, lbl23 = 0, lbl24 = 0, enter = 0, dogrusayisi = 0;

        void labelcheck()
        {
            dogrusayisi = 0;

            for (int i = 0; i < DYBos.Count; i++)
            {
                if (DYBos.ElementAt(i) == "doğru")
                {
                    if (i == 0)
                    {
                        question1.ForeColor = Color.Green;
                        question1underline.BorderColor = Color.Green;
                    }
                    else if (i == 1)
                    {
                        question2.ForeColor = Color.Green;
                        question2underline.BorderColor = Color.Green;
                    }
                    else if (i == 2)
                    {
                        question3.ForeColor = Color.Green;
                        question3underline.BorderColor = Color.Green;
                    }
                    else if (i == 3)
                    {
                        question4.ForeColor = Color.Green;
                        question4underline.BorderColor = Color.Green;
                    }
                    else if (i == 4)
                    {
                        question5.ForeColor = Color.Green;
                        question5underline.BorderColor = Color.Green;
                    }
                    else if (i == 5)
                    {
                        question6.ForeColor = Color.Green;
                        question6underline.BorderColor = Color.Green;
                    }
                    else if (i == 6)
                    {
                        question7.ForeColor = Color.Green;
                        question7underline.BorderColor = Color.Green;
                    }
                    else if (i == 7)
                    {
                        question8.ForeColor = Color.Green;
                        question8underline.BorderColor = Color.Green;
                    }
                    else if (i == 8)
                    {
                        question9.ForeColor = Color.Green;
                        question9underline.BorderColor = Color.Green;
                    }
                    else if (i == 9)
                    {
                        question10.ForeColor = Color.Green;
                        question10underline.BorderColor = Color.Green;
                    }
                    else if (i == 10)
                    {
                        question11.ForeColor = Color.Green;
                        question11underline.BorderColor = Color.Green;
                    }
                    else if (i == 11)
                    {
                        question12.ForeColor = Color.Green;
                        question12underline.BorderColor = Color.Green;
                    }
                    else if (i == 12)
                    {
                        question13.ForeColor = Color.Green;
                        question13underline.BorderColor = Color.Green;
                    }
                    else if (i == 13)
                    {
                        question14.ForeColor = Color.Green;
                        question14underline.BorderColor = Color.Green;
                    }
                    else if (i == 14)
                    {
                        question15.ForeColor = Color.Green;
                        question15underline.BorderColor = Color.Green;
                    }
                    else if (i == 15)
                    {
                        question16.ForeColor = Color.Green;
                        question16underline.BorderColor = Color.Green;
                    }
                    else if (i == 16)
                    {
                        question17.ForeColor = Color.Green;
                        question17underline.BorderColor = Color.Green;
                    }
                    else if (i == 17)
                    {
                        question18.ForeColor = Color.Green;
                        question18underline.BorderColor = Color.Green;
                    }
                    else if (i == 18)
                    {
                        question19.ForeColor = Color.Green;
                        question19underline.BorderColor = Color.Green;
                    }
                    else if (i == 19)
                    {
                        question20.ForeColor = Color.Green;
                        question20underline.BorderColor = Color.Green;
                    }
                    else if (i == 20)
                    {
                        question21.ForeColor = Color.Green;
                        question21underline.BorderColor = Color.Green;
                    }
                    else if (i == 21)
                    {
                        question22.ForeColor = Color.Green;
                        question22underline.BorderColor = Color.Green;
                    }
                    else if (i == 22)
                    {
                        question23.ForeColor = Color.Green;
                        question23underline.BorderColor = Color.Green;
                    }
                    else if (i == 23)
                    {
                        question24.ForeColor = Color.Green;
                        question24underline.BorderColor = Color.Green;
                    }

                    dogrusayisi++;
                }
                else if (DYBos.ElementAt(i) == "yanlis")
                {
                    if (i == 0)
                    {
                        question1.ForeColor = Color.FromArgb(228, 1, 11);
                        question1underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 1)
                    {
                        question2.ForeColor = Color.FromArgb(228, 1, 11);
                        question2underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 2)
                    {
                        question3.ForeColor = Color.FromArgb(228, 1, 11);
                        question3underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 3)
                    {
                        question4.ForeColor = Color.FromArgb(228, 1, 11);
                        question4underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 4)
                    {
                        question5.ForeColor = Color.FromArgb(228, 1, 11);
                        question5underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 5)
                    {
                        question6.ForeColor = Color.FromArgb(228, 1, 11);
                        question6underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 6)
                    {
                        question7.ForeColor = Color.FromArgb(228, 1, 11);
                        question7underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 7)
                    {
                        question8.ForeColor = Color.FromArgb(228, 1, 11);
                        question8underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 8)
                    {
                        question9.ForeColor = Color.FromArgb(228, 1, 11);
                        question9underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 9)
                    {
                        question10.ForeColor = Color.FromArgb(228, 1, 11);
                        question10underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 10)
                    {
                        question11.ForeColor = Color.FromArgb(228, 1, 11);
                        question11underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 11)
                    {
                        question12.ForeColor = Color.FromArgb(228, 1, 11);
                        question12underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 12)
                    {
                        question13.ForeColor = Color.FromArgb(228, 1, 11);
                        question13underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 13)
                    {
                        question14.ForeColor = Color.FromArgb(228, 1, 11);
                        question14underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 14)
                    {
                        question15.ForeColor = Color.FromArgb(228, 1, 11);
                        question15underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 15)
                    {
                        question16.ForeColor = Color.FromArgb(228, 1, 11);
                        question16underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 16)
                    {
                        question17.ForeColor = Color.FromArgb(228, 1, 11);
                        question17underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 17)
                    {
                        question18.ForeColor = Color.FromArgb(228, 1, 11);
                        question18underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 18)
                    {
                        question19.ForeColor = Color.FromArgb(228, 1, 11);
                        question19underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 19)
                    {
                        question20.ForeColor = Color.FromArgb(228, 1, 11);
                        question20underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 20)
                    {
                        question21.ForeColor = Color.FromArgb(228, 1, 11);
                        question21underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 21)
                    {
                        question22.ForeColor = Color.FromArgb(228, 1, 11);
                        question22underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 22)
                    {
                        question23.ForeColor = Color.FromArgb(228, 1, 11);
                        question23underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                    else if (i == 23)
                    {
                        question24.ForeColor = Color.FromArgb(228, 1, 11);
                        question24underline.BorderColor = Color.FromArgb(228, 1, 11);
                    }
                }
                else if (DYBos.ElementAt(i) == "bos")
                {
                    if (i == 0)
                    {
                        question1.ForeColor = Color.FromArgb(251, 134, 0);
                        question1underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 1)
                    {
                        question2.ForeColor = Color.FromArgb(251, 134, 0);
                        question2underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 2)
                    {
                        question3.ForeColor = Color.FromArgb(251, 134, 0);
                        question3underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 3)
                    {
                        question4.ForeColor = Color.FromArgb(251, 134, 0);
                        question4underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 4)
                    {
                        question5.ForeColor = Color.FromArgb(251, 134, 0);
                        question5underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 5)
                    {
                        question6.ForeColor = Color.FromArgb(251, 134, 0);
                        question6underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 6)
                    {
                        question7.ForeColor = Color.FromArgb(251, 134, 0);
                        question7underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 7)
                    {
                        question8.ForeColor = Color.FromArgb(251, 134, 0);
                        question8underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 8)
                    {
                        question9.ForeColor = Color.FromArgb(251, 134, 0);
                        question9underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 9)
                    {
                        question10.ForeColor = Color.FromArgb(251, 134, 0);
                        question10underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 10)
                    {
                        question11.ForeColor = Color.FromArgb(251, 134, 0);
                        question11underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 11)
                    {
                        question12.ForeColor = Color.FromArgb(251, 134, 0);
                        question12underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 12)
                    {
                        question13.ForeColor = Color.FromArgb(251, 134, 0);
                        question13underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 13)
                    {
                        question14.ForeColor = Color.FromArgb(251, 134, 0);
                        question14underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 14)
                    {
                        question15.ForeColor = Color.FromArgb(251, 134, 0);
                        question15underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 15)
                    {
                        question16.ForeColor = Color.FromArgb(251, 134, 0);
                        question16underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 16)
                    {
                        question17.ForeColor = Color.FromArgb(251, 134, 0);
                        question17underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 17)
                    {
                        question18.ForeColor = Color.FromArgb(251, 134, 0);
                        question18underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 18)
                    {
                        question19.ForeColor = Color.FromArgb(251, 134, 0);
                        question19underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 19)
                    {
                        question20.ForeColor = Color.FromArgb(251, 134, 0);
                        question20underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 20)
                    {
                        question21.ForeColor = Color.FromArgb(251, 134, 0);
                        question21underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 21)
                    {
                        question22.ForeColor = Color.FromArgb(251, 134, 0);
                        question22underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 22)
                    {
                        question23.ForeColor = Color.FromArgb(251, 134, 0);
                        question23underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                    else if (i == 23)
                    {
                        question24.ForeColor = Color.FromArgb(251, 134, 0);
                        question24underline.BorderColor = Color.FromArgb(251, 134, 0);
                    }
                }
            }

            pctscreen.Image = Properties.Resources.sinamaoyunsonurevise_min;
            lbltest.Visible = true;
            lbltest.Text = dogrusayisi + "/24";
            questionnowunderline.Texts = "";
            lslword.Text = "";
            lblwordnumber.Text = "";
            questionnowunderline.SendToBack();
            lblwordnumber.SendToBack();
            lslword.SendToBack();
            questionnowunderline.Visible = false;
            lslword.Visible = false;
            lblwordnumber.Visible = false;
            questionnowunderline.Location = new Point(0, 0);
            lslword.Location = new Point(0, 0);
            lblwordnumber.Location = new Point(0, 0);

            question1underline.BringToFront();
            question2underline.BringToFront();
            question3underline.BringToFront();
            question4underline.BringToFront();
            question5underline.BringToFront();
            question6underline.BringToFront();
            question7underline.BringToFront();
            question8underline.BringToFront();
            question9underline.BringToFront();
            question10underline.BringToFront();
            question11underline.BringToFront();
            question12underline.BringToFront();
            question13underline.BringToFront();
            question14underline.BringToFront();
            question15underline.BringToFront();
            question16underline.BringToFront();
            question17underline.BringToFront();
            question18underline.BringToFront();
            question19underline.BringToFront();
            question20underline.BringToFront();
            question21underline.BringToFront();
            question22underline.BringToFront();
            question23underline.BringToFront();
            question24underline.BringToFront();

            question1.Visible = true;
            question2.Visible = true;
            question3.Visible = true;
            question4.Visible = true;
            question5.Visible = true;
            question6.Visible = true;
            question7.Visible = true;
            question8.Visible = true;
            question9.Visible = true;
            question10.Visible = true;
            question11.Visible = true;
            question12.Visible = true;
            question13.Visible = true;
            question14.Visible = true;
            question15.Visible = true;
            question16.Visible = true;
            question17.Visible = true;
            question18.Visible = true;
            question19.Visible = true;
            question20.Visible = true;
            question21.Visible = true;
            question22.Visible = true;
            question23.Visible = true;
            question24.Visible = true;

            questionnowunderline.Visible = false;
            question1underline.Visible = true;
            question2underline.Visible = true;
            question3underline.Visible = true;
            question4underline.Visible = true;
            question5underline.Visible = true;
            question6underline.Visible = true;
            question7underline.Visible = true;
            question8underline.Visible = true;
            question9underline.Visible = true;
            question10underline.Visible = true;
            question11underline.Visible = true;
            question12underline.Visible = true;
            question13underline.Visible = true;
            question14underline.Visible = true;
            question15underline.Visible = true;
            question16underline.Visible = true;
            question17underline.Visible = true;
            question18underline.Visible = true;
            question19underline.Visible = true;
            question20underline.Visible = true;
            question21underline.Visible = true;
            question22underline.Visible = true;
            question23underline.Visible = true;
            question24underline.Visible = true;

            question1.BringToFront();
            question2.BringToFront();
            question3.BringToFront();
            question4.BringToFront();
            question5.BringToFront();
            question6.BringToFront();
            question7.BringToFront();
            question8.BringToFront();
            question9.BringToFront();
            question10.BringToFront();
            question11.BringToFront();
            question12.BringToFront();
            question13.BringToFront();
            question14.BringToFront();
            question15.BringToFront();
            question16.BringToFront();
            question17.BringToFront();
            question18.BringToFront();
            question19.BringToFront();
            question20.BringToFront();
            question21.BringToFront();
            question22.BringToFront();
            question23.BringToFront();
            question24.BringToFront();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pctscreen.Image = Properties.Resources.sinamaoyunsonurevise_min;
            labelcheck();
            timer2.Stop();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if(((Label)sender).Name.ToString() == "question1")
            {
                if(lbl1 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[0] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(0).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(0).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl1++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question2")
            {
                if(lbl2 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[1] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(1).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(1).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl2++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question3")
            {
                if(lbl3 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[2] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(2).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(2).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl3++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question4")
            {
                if(lbl4 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[3] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(3).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(3).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl4++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question5")
            {
                if (lbl5 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[4] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(4).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(4).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl5++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question6")
            {
                if(lbl6 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[5] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(5).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(5).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl6++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question7")
            {
                if(lbl7 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[6] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(6).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(6).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl7++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question8")
            {
                if (lbl8 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[7] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(7).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(7).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl8++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question9")
            {
                if (lbl9 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[8] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(8).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(8).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl9++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question10")
            {
                if(lbl10 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[9] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(9).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(9).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl10++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question11")
            {
                if(lbl11 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[10] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(10).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(10).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl11++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question12")
            {
                if(lbl12 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[11] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(11).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(11).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl12++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question13")
            {
                if(lbl13 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[12] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(12).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(12).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl13++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question14")
            {
                if(lbl14 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[13] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(13).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(13).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl14++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question15")
            {
                if(lbl15 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[14] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(14).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(14).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl15++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question16")
            {
                if(lbl16 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[15] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(15).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(15).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl16++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question17")
            {
                if(lbl17 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[16] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(16).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(16).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl17++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question18")
            {
                if(lbl18 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[17] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(17).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(17).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl18++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question19")
            {
                if(lbl19 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[18] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(18).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(18).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl19++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question20")
            {
                if(lbl20 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[19] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(19).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(19).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl20++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question21")
            {
                if(lbl21 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[20] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(20).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(20).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl21++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question22")
            {
                if(lbl22 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[21] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(21).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(21).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl22++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "question23")
            {
                if(lbl23 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[22] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(22).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(22).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl23++;
                    timer2.Start();
                }
            }
            else if (((Label)sender).Name.ToString() == "label24")
            {
                if (lbl24 == 1)
                {

                }
                else
                {
                    bitti++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunsonu_min;
                    lbltest.Visible = false;
                    pctscreen.BringToFront();
                    questionnowunderline.BringToFront();
                    lslword.BringToFront();
                    questionnowunderline.ForeColor = Color.Green;

                    float font_oran = (font[23] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Text = kelimeler_soru.ElementAt(23).ToString();
                    questionnowunderline.Texts = kelimeler.ElementAt(23).ToString();

                    lslword.Location = new Point(224, 460);
                    questionnowunderline.Location = new Point(619, 661);

                    lslword.Visible = true;
                    questionnowunderline.Visible = true;

                    lbl24++;
                    timer2.Start();
                }
            }
        }
        #endregion

        //METOTLAR
        #region
        private float GetNewPixels(float pixelsDPI96, float dpi)
        {
            return pixelsDPI96 * 96 / dpi;
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
            gridwords.DataSource = dv3;

            kelimeler.Add(gridwords.Rows[0].Cells[0].Value.ToString());
            kelimeler_kelimesayisi.Add(Convert.ToInt32(gridwords.Rows[0].Cells[1].Value.ToString()));
            kelimeler_soru.Add(gridwords.Rows[0].Cells[4].Value.ToString());
            kelimeler_id.Add(Convert.ToInt32(gridwords.Rows[0].Cells[5].Value.ToString()));
            font.Add(Convert.ToInt32(gridwords.Rows[0].Cells[6].Value));
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

                dogruidtotal = string.Join(",", dogruYanitId.ToArray());
                yanlisidtotal = string.Join(",", yanlisYanitId.ToArray());

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

                    cmd_sql.CommandText = "insert into sinamaGroup (kAdi,kGrup,oturum,dogruyanitTotal,yanlisyanitTotal,soru1RT,soru2RT,soru3RT,soru4RT,soru5RT,soru6RT,soru7RT,soru8RT,soru9RT,soru10RT,soru11RT,soru12RT,soru13RT,soru14RT,soru15RT,soru16RT,soru17RT,soru18RT,soru19RT,soru20RT,soru21RT,soru22RT,soru23RT,soru24RT,soruOrtRT,standartSapmaRT,guvenAraligiRT95,ucveriRT95) values (@kAdi,@kGrup,@oturum,@dogruyanitTotal,@yanlisyanitTotal,@soru1RT,@soru2RT,@soru3RT,@soru4RT,@soru5RT,@soru6RT,@soru7RT,@soru8RT,@soru9RT,@soru10RT,@soru11RT,@soru12RT,@soru13RT,@soru14RT,@soru15RT,@soru16RT,@soru17RT,@soru18RT,@soru19RT,@soru20RT,@soru21RT,@soru22RT,@soru23RT,@soru24RT,@soruOrtRT,@standartSapmaRT,@guvenAraligiRT95,@ucveriRT95)";
                    cmd_sql.Parameters.AddWithValue("@kAdi", dilandlocate.Default.kullaniciadi);
                    cmd_sql.Parameters.AddWithValue("@kGrup", dilandlocate.Default.kullanicigrup);
                    cmd_sql.Parameters.AddWithValue("@oturum", oturum);
                    cmd_sql.Parameters.AddWithValue("@dogruyanitTotal", dogruYanit.Count);
                    cmd_sql.Parameters.AddWithValue("@yanlisyanitTotal", yanlisYanit.Count);
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

                    labelcheck();
                    enter++;
                    lslword.Enabled = true;
                    pctscreen.Image = Properties.Resources.sinamaoyunsonurevise_min;
                }
            }
            #endregion

            //eğer uygulama bitmemişse
            #region
            else
            {
                try
                {
                    float font_oran = (font[kelimeindex] * 40) / 30;

                    using (Graphics g = this.CreateGraphics())
                    {
                        float dpii = g.DpiY;
                        float newFontSize = GetNewPixels(font_oran, dpii);
                        lslword.Font = new Font("Alata", font_oran, GraphicsUnit.Pixel);
                    }

                    lslword.Invoke((MethodInvoker)(() => lslword.Text = kelimeler_soru.ElementAt(kelimeindex).ToString()));
                    lblwordnumber.Invoke((MethodInvoker)(() => lblwordnumber.Text = Convert.ToString(sorusayi) + "/24"));
                    kelimeindex++;
                    sorusayi++;
                    kelimesayac++;

                    pctscreen.Image = Properties.Resources.sinama_arayüz_oyunici_min;
                    //parametre geçerli mi değil resources için?
                    lslword.Enabled = true;
                    lslword.Visible = true;

                    if (baslangic == 0)
                    {
                        timestamp = DateTime.Now.ToString("mm:ss.fff");
                        txt_basla.Text = timestamp;
                        baslangic++;
                    }

                    timestamp_guncel = DateTime.Now.ToString("mm:ss.fff");
                    txt_basla_guncel.Text = timestamp_guncel;
                }
                catch
                {
                    MessageBox.Show("Çok garip bir hata ile karşılaşıldı, ana menüye iletilmektesiniz eğer oturumunuz tamamlanmadıysa tamamlamanız bizim açımızdan oldukça kritiktir...(hata kodu: yenikelime, ilkgun_gorev)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    daylogin t = new daylogin();
                    t.Show();
                    this.Hide();
                }
            }
            #endregion
        }
        void tikla()
        {
            bas();

            //cevapcheck();

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

            if (kelimeler[kelimeindex - 1].ToString() == questionnowunderline.Texts)
            {
                time_total.Add(bitir_total_float);
                dogruYanit.Add(1);
                dogruYanitId.Add(kelimeler_id[kelimeindex - 1]);
                DYBos.Add("doğru");
            }
            else
            {
                string trimmed = String.Concat(questionnowunderline.Texts.Where(c => !Char.IsWhiteSpace(c)));
                if (trimmed == "")
                {
                    time_total.Add(bitir_total_float);
                    yanlisYanit.Add(1);
                    yanlisYanitId.Add(kelimeler_id[kelimeindex - 1]);
                    DYBos.Add("bos");
                }
                else
                {
                    time_total.Add(bitir_total_float);
                    yanlisYanit.Add(1);
                    yanlisYanitId.Add(kelimeler_id[kelimeindex - 1]);
                    DYBos.Add("yanlis");
                }
            }

            lslword.Visible = false;
            lslword.Enabled = false;
            questionnowunderline.Texts = "";
            yenisoru();
        }
        #endregion

        //EVENTLER
        #region
        private void pnl_kapa_Click(object sender, EventArgs e)
        {
            if(bitti == 1)
            {
                labelcheck();
                pctscreen.Image = Properties.Resources.sinamaoyunsonurevise_min;
                timer2.Stop();
                bitti = 0;
            }
            else
            {
                daylogin f = new daylogin();
                f.Show();
                this.Hide();
            }
        }
        private void pnl_bas_Click(object sender, EventArgs e)
        {
            bas();
            tikla();
        }
        private void sinama_Load(object sender, EventArgs e)
        {
            lslword.Location = new Point(232, 437);
            lslword.Size = new Size(1457, 160);
            questionnowunderline.Location = new Point(626, 640);
            questionnowunderline.Size = new Size(669, 104);
            lblwordnumber.Location = new Point(815, 250);
            lblwordnumber.Size = new Size(290, 112);
            lbltest.Location = new Point(1310, 243);
            lbltest.Size = new Size(332, 135);


            using (Graphics g = this.CreateGraphics())
            {
                float dpii = g.DpiY;
                float newFontSize = GetNewPixels(53f, dpii);
                questionnowunderline.Font = new Font("Alata", 53f, GraphicsUnit.Pixel);
                lblwordnumber.Font = new Font("Book Antiqua", 82f,GraphicsUnit.Pixel);
                lbltest.Font = new Font("Alata", 82f, GraphicsUnit.Pixel);
                question1.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question2.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question3.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question4.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question5.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question6.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question7.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question8.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question9.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question10.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question11.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question12.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question13.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question14.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question15.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question16.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question17.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question18.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question19.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question20.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question21.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question22.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question23.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question24.Font = new Font("Alata", 35f, GraphicsUnit.Pixel);
                question1underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question2underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question3underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question4underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question5underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question6underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question7underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question8underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question9underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question10underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question11underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question12underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question13underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question14underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question15underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question16underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question17underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question18underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question19underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question20underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question21underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question22underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question23underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
                question24underline.Font = new Font("Microsoft Sans Serif", 32f, GraphicsUnit.Pixel);
            }

            questionnowunderline.Focus();
            questionnowunderline.Parent = pctscreen;
            lslword.Parent = pctscreen;
            pnlcontinue.Parent = pctscreen;
            pnlclose.Parent = pctscreen;
            lblwordnumber.Parent = pctscreen;
            lbltest.Parent = pctscreen;

            question1.Visible = false;
            question2.Visible = false;
            question3.Visible = false;
            question4.Visible = false;
            question5.Visible = false;
            question6.Visible = false;
            question7.Visible = false;
            question8.Visible = false;
            question9.Visible = false;
            question10.Visible = false;
            question11.Visible = false;
            question12.Visible = false;
            question13.Visible = false;
            question14.Visible = false;
            question15.Visible = false;
            question16.Visible = false;
            question17.Visible = false;
            question18.Visible = false;
            question19.Visible = false;
            question20.Visible = false;
            question21.Visible = false;
            question22.Visible = false;
            question23.Visible = false;
            question24.Visible = false;

            question1underline.Visible = false;
            question2underline.Visible = false;
            question3underline.Visible = false;
            question4underline.Visible = false;
            question5underline.Visible = false;
            question6underline.Visible = false;
            question7underline.Visible = false;
            question8underline.Visible = false;
            question9underline.Visible = false;
            question10underline.Visible = false;
            question11underline.Visible = false;
            question12underline.Visible = false;
            question13underline.Visible = false;
            question14underline.Visible = false;
            question15underline.Visible = false;
            question16underline.Visible = false;
            question17underline.Visible = false;
            question18underline.Visible = false;
            question19underline.Visible = false;
            question20underline.Visible = false;
            question21underline.Visible = false;
            question22underline.Visible = false;
            question23underline.Visible = false;
            question24underline.Visible = false;

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
            gridwords.DataSource = tablo_sql;

            tablo2_sql = new DataTable();

            da2_sql = new OleDbDataAdapter("select * from girisPsyword order by id asc", con_sql);
            tablo2_sql.Clear();
            da2_sql.Fill(tablo2_sql);
            gridparticipants.DataSource = tablo2_sql;

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
        #endregion
    }
}
