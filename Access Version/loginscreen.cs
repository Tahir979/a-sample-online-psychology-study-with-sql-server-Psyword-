using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Media;
using System.IO;
using System.Drawing.Text;
using Microsoft.Win32;
using System.Diagnostics;

namespace DEMO
{
    public partial class loginscreen : Form
    {
        public loginscreen()
        {
            InitializeComponent();
        }

        //DEĞİŞKENLER
        #region
        int gecis = 0, hayir = 0;
        public int genislik, yukseklik;
        string fontlar;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kullanici.accdb");
        OleDbCommand cmd;
        DataTable tablo, tablo2;
        OleDbDataAdapter da;

        gamecondition xxx = new gamecondition();
        SoundPlayer player = new SoundPlayer(); //sesler için gerekli olan ses çalar

        public List<int> res = new List<int>();
        #endregion

        //METOTLAR
        #region
        //Normal Metotlar
        #region
        void giris()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                bas();

                pctscreen.Image = Properties.Resources.netyok_min_min;

                username.Visible = false;
                password.Visible = false;
            }
            else
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "kAdi Like '" + username.Texts + "%'";
                gridparticipants.DataSource = dv;

                if (username.Texts.ToString() == "" || password.Texts.ToString() == "")
                {
                    bas();

                    pctscreen.Image = Properties.Resources.kullaniciadi_sifre_hatali_min_min;

                    username.Visible = false;
                    password.Visible = false;
                }
                else
                {
                    if (gridparticipants.Rows.Count == 0)
                    {
                        bas();

                        pctscreen.Image = Properties.Resources.kullaniciadi_sifre_hatali_min_min;

                        username.Visible = false;
                        password.Visible = false;
                    }
                    else
                    {
                        if (gridparticipants.Rows[0].Cells[0].Value.ToString() == username.Texts)
                        {
                            if (gridparticipants.Rows[0].Cells[0].Value.ToString() == username.Texts && gridparticipants.Rows[0].Cells[1].Value.ToString() == password.Texts)
                            {
                                sessiontext.Text = gridparticipants.Rows[0].Cells[3].Value.ToString();

                                griddoldur();

                                DataView dv2 = tablo2.DefaultView;
                                dv2.RowFilter = "kAdi like '%" + username.Texts + "%'";
                                girisPsyword.DataSource = dv2;

                                if (girisPsyword.Rows.Count == 0)
                                {
                                    con.Close();

                                    cmd = new OleDbCommand();
                                    con.Open();
                                    cmd.Connection = con;

                                    cmd.CommandText = "insert into girisPsyword (kAdi,kGrup,oturum,girisDatetime,cikisDatetime,totalsure,mevcutDatetime,kayittamam) values (@kAdi,@kGrup,@oturum,@girisDatetime,@cikisDatetime,@totalsure,@mevcutDatetime,@kayittamam)";
                                    cmd.Parameters.AddWithValue("@kAdi", username.Texts);
                                    cmd.Parameters.AddWithValue("@kGrup", sessiontext.Text);
                                    cmd.Parameters.AddWithValue("@oturum", 1);
                                    cmd.Parameters.AddWithValue("@girisDatetime", "");
                                    cmd.Parameters.AddWithValue("@cikisDatetime", "");
                                    cmd.Parameters.AddWithValue("@totalsure", "");
                                    cmd.Parameters.AddWithValue("@mevcutDatetime", DateTime.Now.ToString("dd/MM/yyyy"));
                                    cmd.Parameters.AddWithValue("@kayittamam", "hayir");

                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    tablo.Clear();

                                    dilandlocate.Default.kullaniciadi = username.Texts;
                                    dilandlocate.Default.Save();
                                    dilandlocate.Default.kullanicigrup = sessiontext.Text;
                                    dilandlocate.Default.Save();

                                    daylogin x_ = new daylogin();
                                    x_.Show();
                                    this.Hide();
                                }
                                else if (girisPsyword.Rows.Count == 1)
                                {
                                    string mevcut_xx = DateTime.Now.ToString("dd/MM/yyyy");
                                    string mevcut_xxx = mevcut_xx.Substring(0, 2); //28 
                                    int cevir_mevcut_x = Convert.ToInt32(mevcut_xxx);

                                    string t = girisPsyword.Rows[0].Cells[6].Value.ToString();
                                    string h = t.Substring(0, 2);
                                    int cevir = Convert.ToInt32(h);

                                    if (cevir + 1 == cevir_mevcut_x)
                                    {
                                        pctscreen.Image = Properties.Resources.kullanici_elendi_min_min;

                                        username.Visible = false;
                                        password.Visible = false;
                                    }
                                    else
                                    {
                                        dilandlocate.Default.kullaniciadi = username.Texts;
                                        dilandlocate.Default.Save();
                                        dilandlocate.Default.kullanicigrup = sessiontext.Text;
                                        dilandlocate.Default.Save();

                                        daylogin x_ = new daylogin();
                                        x_.Show();
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    string mevcut_x = DateTime.Now.ToString("dd/MM/yyyy");
                                    string mevcut = mevcut_x.Substring(0, 10);

                                    griddoldur();

                                    DataView dv3 = tablo2.DefaultView;
                                    dv3.RowFilter = "mevcutDatetime Like '%" + mevcut + "%' and kAdi like '%" + username.Texts + "%'";
                                    girisPsyword.DataSource = dv3;

                                    if (girisPsyword.Rows.Count != 0)
                                    {
                                        dilandlocate.Default.kullaniciadi = username.Texts;
                                        dilandlocate.Default.Save();
                                        dilandlocate.Default.kullanicigrup = sessiontext.Text;
                                        dilandlocate.Default.Save();

                                        daylogin x_ = new daylogin();
                                        x_.Show();
                                        this.Hide();
                                    }
                                    else
                                    {

                                        string xx = DateTime.Now.ToString("dd/MM/yyyy");
                                        DateTime myDate = DateTime.Parse(xx);
                                        string jj = myDate.AddDays(-1).ToString();
                                        string j = jj.Substring(0, 10);

                                        griddoldur();

                                        DataView dv7 = tablo2.DefaultView;
                                        dv7.RowFilter = "mevcutDatetime Like '%" + j + "%' and kAdi like '%" + username.Texts + "%'";
                                        girisPsyword.DataSource = dv7;

                                        string[] dizi = new string[girisPsyword.Rows.Count];

                                        for (int r = 0; r < girisPsyword.Rows.Count; r++)
                                        {
                                            dizi[r] = girisPsyword.Rows[r].Cells[7].Value.ToString();
                                        }

                                        for (int u = 0; u < dizi.Length; u++)
                                        {
                                            if (dizi[u].Contains("hayir") == true)
                                            {
                                                hayir++;
                                            }
                                        }

                                        if(girisPsyword.Rows.Count == 0)
                                        {
                                            pctscreen.Image = Properties.Resources.kullanici_elendi_min_min;

                                            username.Visible = false;
                                            password.Visible = false;
                                        }
                                        else
                                        {
                                            string gunumuz = mevcut_x.Substring(0, 10);
                                            string t = girisPsyword.Rows[0].Cells[6].Value.ToString(); //hatayı burada alıyoruz, boş işte diyor datagrid
                                            string h = t.Substring(0, 2);
                                            int cevir = Convert.ToInt32(h);

                                            griddoldur();

                                            DataView dv4 = tablo2.DefaultView;
                                            dv4.RowFilter = "kayittamam Like '" + "evet" + "%' and kAdi like '%" + username.Texts + "%' and mevcutDatetime like '%" + j + "%'";
                                            girisPsyword.DataSource = dv4;

                                            if (girisPsyword.Rows.Count == 0)
                                            {
                                                pctscreen.Image = Properties.Resources.kullanici_elendi_min_min;

                                                username.Visible = false;
                                                password.Visible = false;
                                            }
                                            else
                                            {
                                                string b = "";
                                                for (int r = 0; r < girisPsyword.Rows.Count; r++)
                                                {
                                                    b = girisPsyword.Rows[r].Cells[6].Value.ToString();
                                                }

                                                b = b.Substring(0, 2);

                                                if (Convert.ToInt32(mevcut) == Convert.ToInt32(b) + 2 && Convert.ToInt32(mevcut) == Convert.ToInt32(b) + 3)
                                                {
                                                    pctscreen.Image = Properties.Resources.kullanici_elendi_min_min;

                                                    username.Visible = false;
                                                    password.Visible = false;
                                                }

                                                else
                                                {
                                                    dilandlocate.Default.kullaniciadi = username.Texts;
                                                    dilandlocate.Default.Save();
                                                    dilandlocate.Default.kullanicigrup = sessiontext.Text;
                                                    dilandlocate.Default.Save();

                                                    daylogin x_ = new daylogin();
                                                    x_.Show();
                                                    this.Hide();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bas();

                                pctscreen.Image = Properties.Resources.kullaniciadi_sifre_hatali_min_min;

                                username.Visible = false;
                                password.Visible = false;
                            }
                        }
                    }
                }
            }
        }
        void netkontrol()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

                if (reply.Status == IPStatus.Success)
                {
                    lblinternetcondition.Text = "Aktif, internet bağlantısı kuruldu.";

                    con.Close();
                    con.Open();

                    tablo = new DataTable();
                    //
                    da = new OleDbDataAdapter("select * from katilimcilar order by id asc", con);
                    tablo.Clear();
                    da.Fill(tablo);
                    gridparticipants.DataSource = tablo;

                    con.Close();
                }
                else
                {
                    lblinternetcondition.Text = "Pasif, lütfen internete bağlı olduğunuzdan emin olunuz...";
                }
            }
            catch
            {
                lblinternetcondition.Text = "Pasif, lütfen internete bağlı olduğunuzdan emin olunuz...";
            }
        }
        void griddoldur()
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
        void bas()
        {
            xxx.muzikler();
            string yol = xxx.sesler[11].ToString();
            player.SoundLocation = yol;
            player.Play();
        }
        #endregion

        //Font Metotları
        #region
        private float GetNewPixels(float pixelsDPI96, float dpi)
        {
            return pixelsDPI96 * 96 / dpi;
        }
        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpszFilename);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int CreateScalableFontResource(uint fdwHidden, string lpszFontRes, string lpszFontFile, string lpszCurrentPath);
        private static void RegisterFont(string contentFontName)
        {
            // Creates the full path where your font will be installed
            var fontDestination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts), contentFontName);

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
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", actualFontName, contentFontName, RegistryValueKind.String);
            }
        }
        
        #endregion

        //Alt + Tab İptal Metotları
        #region
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;
        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }
        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
        #endregion
        #endregion

        //EVENTLER
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            netkontrol();
        }
        private void pnl_cikis_Click(object sender, EventArgs e)
        {
            try
            {
                bas();
                new CResolution(genislik, yukseklik);
                Environment.Exit(0);
            }
            catch
            {

            }
        }
        private void pnl_iletisim_Click(object sender, EventArgs e)
        {
            if (gecis == 0) //giriş ekranı
            {
                bas();

                pctscreen.Image = Properties.Resources.kullanici_giris_iletisimmmmm_min_min;
            }
            else if (gecis == 1) //account ekranı
            {
                bas();

                pctscreen.Image = Properties.Resources.kullanici_giris_iletisimmmm_2_min_min;


                username.Visible = false;
                password.Visible = false;
            }
        }
        private void pnl_girishata_Click(object sender, EventArgs e)
        {
            if (gecis == 1)
            {
                bas();

                pctscreen.Image = Properties.Resources.kullanici_giris_hataaa_min_min;

                username.Visible = false;
                password.Visible = false;
            }
        }

        private void kullanici_sifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bas();
                giris();
            }
        }

        private void pnl_giris_Click(object sender, EventArgs e)
        {
            if (gecis == 0)
            {
                bas();

                gecis = 1;

                username.Visible = true;
                password.Visible = true;

                pnllogin.Location = new Point(0, 0);
                pnllogin.Enabled = false;

                pnlgame.Location = new Point(212, 692);
                pnlgame.Enabled = true;

                pctscreen.Image = Properties.Resources.account_min_min;
            }
        }

        private void pnl_oyun_Click(object sender, EventArgs e)
        {
            bas();

            giris();
        }
        private void pnl_kapa_Click(object sender, EventArgs e)
        {
            if (gecis == 0)
            {
                bas();

                pctscreen.Image = Properties.Resources.giris_min_min;
            }
            else if (gecis == 1)
            {
                bas();

                pctscreen.Image = Properties.Resources.account_min_min;

                username.Visible = true;
                password.Visible = true;
            }
        }

        private void kullanici_Load(object sender, EventArgs e)
        {
            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;

            if (genislik == 1366)
            {
                MessageBox.Show("Uygulamamız için yeterli çözünürlük bulunamamaktadır, çalışmaya olan ilginiz için teşekkür ederiz", "Bilgilendirme", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                new CResolution(1920, 1080);

                using (Graphics g = this.CreateGraphics())
                {
                    float dpii = g.DpiY;
                    float newFontSize = GetNewPixels(40f, dpii);
                    lblinternetcondition.Font = new Font("Big Shoulders Display", 40f, GraphicsUnit.Pixel);
                    username.Font = new Font("Alata", 24f, GraphicsUnit.Pixel);
                    password.Font = new Font("Alata", 24f, GraphicsUnit.Pixel);
                }

                ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
                objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
                ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);

                pctscreen.Image = Properties.Resources.giris_min_min;

                pnllogin.Location = new Point(221, 729);
                pnllogin.Enabled = true;

                pnlgame.Location = new Point(0, 0);
                pnlgame.Enabled = false;

                lblinternetcondition.Parent = pctscreen;
                pnllogin.Parent = pctscreen;
                pnlcontact.Parent = pctscreen;
                pnlcloseprogram.Parent = pctscreen;
                pnlerror.Parent = pctscreen;
                pnlclosesession.Parent = pctscreen;
                pnlgame.Parent = pctscreen;

                password.Parent = pctscreen;
                username.Parent = pctscreen;
                username.Visible = false;
                password.Visible = false;

                netkontrol();

                FontFamily[] ffArray = FontFamily.Families;
                foreach (FontFamily ff in ffArray)
                {
                    fontlar += string.Join(",", ff.Name.ToString());
                }

                if (fontlar.Contains("Alata") == false)
                {
                    RegisterFont("Alata.ttf");
                }
                if (fontlar.Contains("Montserrat") == false)
                {
                    RegisterFont("Montserrat.ttf");
                }
                if (fontlar.Contains("Big Shoulders Display") == false)
                {
                    RegisterFont("BigShouldersDisplay.ttf");
                }
                if (fontlar.Contains("Book Antiqua") == false)
                {
                    RegisterFont("Antique.ttf");
                }
            }
        }
        #endregion
    }
}
