
namespace DEMO
{
    partial class gamecondition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gamecondition));
            this.gridwords = new System.Windows.Forms.DataGridView();
            this.lblremainingtime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblwordpoint = new System.Windows.Forms.Label();
            this.lbremainingpoint = new System.Windows.Forms.Label();
            this.lblword = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gridunnecessaryfocus = new System.Windows.Forms.DataGridView();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblbesttotalpoint = new System.Windows.Forms.Label();
            this.lbltotalpoint = new System.Windows.Forms.Label();
            this.load = new System.Windows.Forms.Button();
            this.gridparticipants = new System.Windows.Forms.DataGridView();
            this.pctscreen = new System.Windows.Forms.PictureBox();
            this.girisPsyword = new System.Windows.Forms.DataGridView();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.whiteprogress = new DEMO.NewProgressBar();
            this.progres_siyah = new DEMO.progres_siyah();
            this.tahir1 = new DEMO.textbox_tahir();
            this.tahir15 = new DEMO.textbox_tahir();
            this.tahir14 = new DEMO.textbox_tahir();
            this.tahir13 = new DEMO.textbox_tahir();
            this.tahir12 = new DEMO.textbox_tahir();
            this.tahir11 = new DEMO.textbox_tahir();
            this.tahir10 = new DEMO.textbox_tahir();
            this.tahir9 = new DEMO.textbox_tahir();
            this.tahir8 = new DEMO.textbox_tahir();
            this.tahir7 = new DEMO.textbox_tahir();
            this.tahir6 = new DEMO.textbox_tahir();
            this.tahir5 = new DEMO.textbox_tahir();
            this.tahir4 = new DEMO.textbox_tahir();
            this.tahir3 = new DEMO.textbox_tahir();
            this.tahir2 = new DEMO.textbox_tahir();
            this.tahir0 = new DEMO.textbox_tahir();
            ((System.ComponentModel.ISupportInitialize)(this.gridwords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridunnecessaryfocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridparticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctscreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.girisPsyword)).BeginInit();
            this.SuspendLayout();
            // 
            // gridwords
            // 
            this.gridwords.AllowUserToAddRows = false;
            this.gridwords.AllowUserToDeleteRows = false;
            this.gridwords.AllowUserToOrderColumns = true;
            this.gridwords.AllowUserToResizeColumns = false;
            this.gridwords.AllowUserToResizeRows = false;
            this.gridwords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridwords.ColumnHeadersVisible = false;
            this.gridwords.Location = new System.Drawing.Point(1637, 12);
            this.gridwords.MultiSelect = false;
            this.gridwords.Name = "gridwords";
            this.gridwords.ReadOnly = true;
            this.gridwords.RowHeadersVisible = false;
            this.gridwords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridwords.Size = new System.Drawing.Size(1, 1);
            this.gridwords.TabIndex = 50;
            // 
            // lblremainingtime
            // 
            this.lblremainingtime.BackColor = System.Drawing.Color.Transparent;
            this.lblremainingtime.Font = new System.Drawing.Font("Big Shoulders Display", 40F);
            this.lblremainingtime.Location = new System.Drawing.Point(1465, 138);
            this.lblremainingtime.Name = "lblremainingtime";
            this.lblremainingtime.Size = new System.Drawing.Size(120, 72);
            this.lblremainingtime.TabIndex = 60;
            this.lblremainingtime.Text = "3:00";
            this.lblremainingtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblremainingtime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblwordpoint
            // 
            this.lblwordpoint.BackColor = System.Drawing.Color.Transparent;
            this.lblwordpoint.Font = new System.Drawing.Font("Big Shoulders Display", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblwordpoint.Location = new System.Drawing.Point(473, 134);
            this.lblwordpoint.Margin = new System.Windows.Forms.Padding(0);
            this.lblwordpoint.Name = "lblwordpoint";
            this.lblwordpoint.Size = new System.Drawing.Size(120, 54);
            this.lblwordpoint.TabIndex = 53;
            this.lblwordpoint.Text = "000";
            this.lblwordpoint.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblwordpoint.Visible = false;
            // 
            // lbremainingpoint
            // 
            this.lbremainingpoint.BackColor = System.Drawing.Color.Transparent;
            this.lbremainingpoint.Font = new System.Drawing.Font("Big Shoulders Display", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbremainingpoint.Location = new System.Drawing.Point(447, 180);
            this.lbremainingpoint.Margin = new System.Windows.Forms.Padding(0);
            this.lbremainingpoint.Name = "lbremainingpoint";
            this.lbremainingpoint.Size = new System.Drawing.Size(120, 54);
            this.lbremainingpoint.TabIndex = 54;
            this.lbremainingpoint.Text = "000";
            this.lbremainingpoint.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbremainingpoint.UseCompatibleTextRendering = true;
            this.lbremainingpoint.Visible = false;
            // 
            // lblword
            // 
            this.lblword.BackColor = System.Drawing.Color.Transparent;
            this.lblword.Font = new System.Drawing.Font("Alata", 24F);
            this.lblword.Location = new System.Drawing.Point(368, 580);
            this.lblword.Name = "lblword";
            this.lblword.Size = new System.Drawing.Size(1185, 160);
            this.lblword.TabIndex = 55;
            this.lblword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblword.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gridunnecessaryfocus
            // 
            this.gridunnecessaryfocus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridunnecessaryfocus.Location = new System.Drawing.Point(1881, 564);
            this.gridunnecessaryfocus.Name = "gridunnecessaryfocus";
            this.gridunnecessaryfocus.Size = new System.Drawing.Size(1, 1);
            this.gridunnecessaryfocus.TabIndex = 102;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(33, 350);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1, 1);
            this.axWindowsMediaPlayer1.TabIndex = 105;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // lblbesttotalpoint
            // 
            this.lblbesttotalpoint.BackColor = System.Drawing.Color.Transparent;
            this.lblbesttotalpoint.Font = new System.Drawing.Font("Montserrat", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbesttotalpoint.Location = new System.Drawing.Point(1629, 592);
            this.lblbesttotalpoint.Name = "lblbesttotalpoint";
            this.lblbesttotalpoint.Size = new System.Drawing.Size(163, 46);
            this.lblbesttotalpoint.TabIndex = 227;
            this.lblbesttotalpoint.Text = "0000";
            this.lblbesttotalpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblbesttotalpoint.Visible = false;
            // 
            // lbltotalpoint
            // 
            this.lbltotalpoint.BackColor = System.Drawing.Color.Transparent;
            this.lbltotalpoint.Font = new System.Drawing.Font("Montserrat", 27.75F, System.Drawing.FontStyle.Bold);
            this.lbltotalpoint.Location = new System.Drawing.Point(1629, 514);
            this.lbltotalpoint.Name = "lbltotalpoint";
            this.lbltotalpoint.Size = new System.Drawing.Size(163, 46);
            this.lbltotalpoint.TabIndex = 226;
            this.lbltotalpoint.Text = "0000";
            this.lbltotalpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltotalpoint.Visible = false;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(239, 212);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(1, 1);
            this.load.TabIndex = 228;
            this.load.Text = "button1";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // gridparticipants
            // 
            this.gridparticipants.AllowUserToAddRows = false;
            this.gridparticipants.AllowUserToDeleteRows = false;
            this.gridparticipants.AllowUserToOrderColumns = true;
            this.gridparticipants.AllowUserToResizeColumns = false;
            this.gridparticipants.AllowUserToResizeRows = false;
            this.gridparticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridparticipants.ColumnHeadersVisible = false;
            this.gridparticipants.Location = new System.Drawing.Point(960, 540);
            this.gridparticipants.MultiSelect = false;
            this.gridparticipants.Name = "gridparticipants";
            this.gridparticipants.ReadOnly = true;
            this.gridparticipants.RowHeadersVisible = false;
            this.gridparticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridparticipants.Size = new System.Drawing.Size(1, 1);
            this.gridparticipants.TabIndex = 229;
            // 
            // pctscreen
            // 
            this.pctscreen.Image = global::DEMO.Properties.Resources.yeni_oyun_sonu_min;
            this.pctscreen.Location = new System.Drawing.Point(0, 0);
            this.pctscreen.Name = "pctscreen";
            this.pctscreen.Size = new System.Drawing.Size(1920, 1080);
            this.pctscreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctscreen.TabIndex = 52;
            this.pctscreen.TabStop = false;
            this.pctscreen.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // girisPsyword
            // 
            this.girisPsyword.AllowUserToAddRows = false;
            this.girisPsyword.AllowUserToDeleteRows = false;
            this.girisPsyword.AllowUserToOrderColumns = true;
            this.girisPsyword.AllowUserToResizeColumns = false;
            this.girisPsyword.AllowUserToResizeRows = false;
            this.girisPsyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.girisPsyword.ColumnHeadersVisible = false;
            this.girisPsyword.Location = new System.Drawing.Point(968, 548);
            this.girisPsyword.MultiSelect = false;
            this.girisPsyword.Name = "girisPsyword";
            this.girisPsyword.ReadOnly = true;
            this.girisPsyword.RowHeadersVisible = false;
            this.girisPsyword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.girisPsyword.Size = new System.Drawing.Size(1, 1);
            this.girisPsyword.TabIndex = 230;
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 1000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Interval = 1000;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // whiteprogress
            // 
            this.whiteprogress.BackColor = System.Drawing.Color.White;
            this.whiteprogress.ForeColor = System.Drawing.Color.White;
            this.whiteprogress.Location = new System.Drawing.Point(720, 346);
            this.whiteprogress.Name = "whiteprogress";
            this.whiteprogress.Size = new System.Drawing.Size(480, 20);
            this.whiteprogress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.whiteprogress.TabIndex = 99;
            this.whiteprogress.Value = 100;
            this.whiteprogress.Visible = false;
            // 
            // progres_siyah
            // 
            this.progres_siyah.BackColor = System.Drawing.Color.Black;
            this.progres_siyah.ForeColor = System.Drawing.Color.Black;
            this.progres_siyah.Location = new System.Drawing.Point(720, 346);
            this.progres_siyah.Name = "progres_siyah";
            this.progres_siyah.Size = new System.Drawing.Size(480, 20);
            this.progres_siyah.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progres_siyah.TabIndex = 106;
            this.progres_siyah.Value = 100;
            this.progres_siyah.Visible = false;
            // 
            // tahir1
            // 
            this.tahir1.AcceptsTab = false;
            this.tahir1.BackColor = System.Drawing.Color.White;
            this.tahir1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir1.BorderRadius = 15;
            this.tahir1.BorderSize = 2;
            this.tahir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir1.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir1.IsFocused = false;
            this.tahir1.Location = new System.Drawing.Point(0, 0);
            this.tahir1.Margin = new System.Windows.Forms.Padding(4);
            this.tahir1.Multiline = true;
            this.tahir1.Name = "tahir1";
            this.tahir1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir1.readonly_x = false;
            this.tahir1.SelectionLength = 0;
            this.tahir1.SelectionStart = 0;
            this.tahir1.Size = new System.Drawing.Size(96, 96);
            this.tahir1.TabIndex = 1;
            this.tahir1.Texts = "";
            this.tahir1.UnderlinedStyle = false;
            this.tahir1.Visible = false;
            this.tahir1._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir1.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir1.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir15
            // 
            this.tahir15.AcceptsTab = false;
            this.tahir15.BackColor = System.Drawing.Color.White;
            this.tahir15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir15.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir15.BorderRadius = 15;
            this.tahir15.BorderSize = 2;
            this.tahir15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir15.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir15.IsFocused = false;
            this.tahir15.Location = new System.Drawing.Point(0, 0);
            this.tahir15.Margin = new System.Windows.Forms.Padding(4);
            this.tahir15.Multiline = true;
            this.tahir15.Name = "tahir15";
            this.tahir15.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir15.readonly_x = false;
            this.tahir15.SelectionLength = 0;
            this.tahir15.SelectionStart = 0;
            this.tahir15.Size = new System.Drawing.Size(96, 96);
            this.tahir15.TabIndex = 15;
            this.tahir15.Texts = "";
            this.tahir15.UnderlinedStyle = false;
            this.tahir15.Visible = false;
            this.tahir15._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir15.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir15.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir15.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir14
            // 
            this.tahir14.AcceptsTab = false;
            this.tahir14.BackColor = System.Drawing.Color.White;
            this.tahir14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir14.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir14.BorderRadius = 15;
            this.tahir14.BorderSize = 2;
            this.tahir14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir14.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir14.IsFocused = false;
            this.tahir14.Location = new System.Drawing.Point(0, 0);
            this.tahir14.Margin = new System.Windows.Forms.Padding(4);
            this.tahir14.Multiline = true;
            this.tahir14.Name = "tahir14";
            this.tahir14.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir14.readonly_x = false;
            this.tahir14.SelectionLength = 0;
            this.tahir14.SelectionStart = 0;
            this.tahir14.Size = new System.Drawing.Size(96, 96);
            this.tahir14.TabIndex = 14;
            this.tahir14.Texts = "";
            this.tahir14.UnderlinedStyle = false;
            this.tahir14.Visible = false;
            this.tahir14._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir14.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir14.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir13
            // 
            this.tahir13.AcceptsTab = false;
            this.tahir13.BackColor = System.Drawing.Color.White;
            this.tahir13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir13.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir13.BorderRadius = 15;
            this.tahir13.BorderSize = 2;
            this.tahir13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir13.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir13.IsFocused = false;
            this.tahir13.Location = new System.Drawing.Point(0, 0);
            this.tahir13.Margin = new System.Windows.Forms.Padding(4);
            this.tahir13.Multiline = true;
            this.tahir13.Name = "tahir13";
            this.tahir13.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir13.readonly_x = false;
            this.tahir13.SelectionLength = 0;
            this.tahir13.SelectionStart = 0;
            this.tahir13.Size = new System.Drawing.Size(96, 96);
            this.tahir13.TabIndex = 13;
            this.tahir13.Texts = "";
            this.tahir13.UnderlinedStyle = false;
            this.tahir13.Visible = false;
            this.tahir13._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir13.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir13.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir12
            // 
            this.tahir12.AcceptsTab = false;
            this.tahir12.BackColor = System.Drawing.Color.White;
            this.tahir12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir12.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir12.BorderRadius = 15;
            this.tahir12.BorderSize = 2;
            this.tahir12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir12.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir12.IsFocused = false;
            this.tahir12.Location = new System.Drawing.Point(0, 0);
            this.tahir12.Margin = new System.Windows.Forms.Padding(4);
            this.tahir12.Multiline = true;
            this.tahir12.Name = "tahir12";
            this.tahir12.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir12.readonly_x = false;
            this.tahir12.SelectionLength = 0;
            this.tahir12.SelectionStart = 0;
            this.tahir12.Size = new System.Drawing.Size(96, 96);
            this.tahir12.TabIndex = 12;
            this.tahir12.Texts = "";
            this.tahir12.UnderlinedStyle = false;
            this.tahir12.Visible = false;
            this.tahir12._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir12.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir12.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir11
            // 
            this.tahir11.AcceptsTab = false;
            this.tahir11.BackColor = System.Drawing.Color.White;
            this.tahir11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir11.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir11.BorderRadius = 15;
            this.tahir11.BorderSize = 2;
            this.tahir11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir11.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir11.IsFocused = false;
            this.tahir11.Location = new System.Drawing.Point(0, 0);
            this.tahir11.Margin = new System.Windows.Forms.Padding(4);
            this.tahir11.Multiline = true;
            this.tahir11.Name = "tahir11";
            this.tahir11.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir11.readonly_x = false;
            this.tahir11.SelectionLength = 0;
            this.tahir11.SelectionStart = 0;
            this.tahir11.Size = new System.Drawing.Size(96, 96);
            this.tahir11.TabIndex = 11;
            this.tahir11.Texts = "";
            this.tahir11.UnderlinedStyle = false;
            this.tahir11.Visible = false;
            this.tahir11._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir11.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir11.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir10
            // 
            this.tahir10.AcceptsTab = false;
            this.tahir10.BackColor = System.Drawing.Color.White;
            this.tahir10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir10.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir10.BorderRadius = 15;
            this.tahir10.BorderSize = 2;
            this.tahir10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir10.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir10.IsFocused = false;
            this.tahir10.Location = new System.Drawing.Point(0, 0);
            this.tahir10.Margin = new System.Windows.Forms.Padding(4);
            this.tahir10.Multiline = true;
            this.tahir10.Name = "tahir10";
            this.tahir10.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir10.readonly_x = false;
            this.tahir10.SelectionLength = 0;
            this.tahir10.SelectionStart = 0;
            this.tahir10.Size = new System.Drawing.Size(96, 96);
            this.tahir10.TabIndex = 10;
            this.tahir10.Texts = "";
            this.tahir10.UnderlinedStyle = false;
            this.tahir10.Visible = false;
            this.tahir10._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir10.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir10.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir9
            // 
            this.tahir9.AcceptsTab = false;
            this.tahir9.BackColor = System.Drawing.Color.White;
            this.tahir9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir9.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir9.BorderRadius = 15;
            this.tahir9.BorderSize = 2;
            this.tahir9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir9.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir9.IsFocused = false;
            this.tahir9.Location = new System.Drawing.Point(0, 0);
            this.tahir9.Margin = new System.Windows.Forms.Padding(4);
            this.tahir9.Multiline = true;
            this.tahir9.Name = "tahir9";
            this.tahir9.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir9.readonly_x = false;
            this.tahir9.SelectionLength = 0;
            this.tahir9.SelectionStart = 0;
            this.tahir9.Size = new System.Drawing.Size(96, 96);
            this.tahir9.TabIndex = 9;
            this.tahir9.Texts = "";
            this.tahir9.UnderlinedStyle = false;
            this.tahir9.Visible = false;
            this.tahir9._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir9.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir9.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir8
            // 
            this.tahir8.AcceptsTab = false;
            this.tahir8.BackColor = System.Drawing.Color.White;
            this.tahir8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir8.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir8.BorderRadius = 15;
            this.tahir8.BorderSize = 2;
            this.tahir8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir8.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir8.IsFocused = false;
            this.tahir8.Location = new System.Drawing.Point(0, 0);
            this.tahir8.Margin = new System.Windows.Forms.Padding(4);
            this.tahir8.Multiline = true;
            this.tahir8.Name = "tahir8";
            this.tahir8.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir8.readonly_x = false;
            this.tahir8.SelectionLength = 0;
            this.tahir8.SelectionStart = 0;
            this.tahir8.Size = new System.Drawing.Size(96, 96);
            this.tahir8.TabIndex = 8;
            this.tahir8.Texts = "";
            this.tahir8.UnderlinedStyle = false;
            this.tahir8.Visible = false;
            this.tahir8._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir8.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir8.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir7
            // 
            this.tahir7.AcceptsTab = false;
            this.tahir7.BackColor = System.Drawing.Color.White;
            this.tahir7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir7.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir7.BorderRadius = 15;
            this.tahir7.BorderSize = 2;
            this.tahir7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir7.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir7.IsFocused = false;
            this.tahir7.Location = new System.Drawing.Point(0, 0);
            this.tahir7.Margin = new System.Windows.Forms.Padding(4);
            this.tahir7.Multiline = true;
            this.tahir7.Name = "tahir7";
            this.tahir7.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir7.readonly_x = false;
            this.tahir7.SelectionLength = 0;
            this.tahir7.SelectionStart = 0;
            this.tahir7.Size = new System.Drawing.Size(96, 96);
            this.tahir7.TabIndex = 7;
            this.tahir7.Texts = "";
            this.tahir7.UnderlinedStyle = false;
            this.tahir7.Visible = false;
            this.tahir7._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir7.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir7.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir6
            // 
            this.tahir6.AcceptsTab = false;
            this.tahir6.BackColor = System.Drawing.Color.White;
            this.tahir6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir6.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir6.BorderRadius = 15;
            this.tahir6.BorderSize = 2;
            this.tahir6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir6.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir6.IsFocused = false;
            this.tahir6.Location = new System.Drawing.Point(0, 0);
            this.tahir6.Margin = new System.Windows.Forms.Padding(4);
            this.tahir6.Multiline = true;
            this.tahir6.Name = "tahir6";
            this.tahir6.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir6.readonly_x = false;
            this.tahir6.SelectionLength = 0;
            this.tahir6.SelectionStart = 0;
            this.tahir6.Size = new System.Drawing.Size(96, 96);
            this.tahir6.TabIndex = 6;
            this.tahir6.Texts = "";
            this.tahir6.UnderlinedStyle = false;
            this.tahir6.Visible = false;
            this.tahir6._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir6.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir6.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir5
            // 
            this.tahir5.AcceptsTab = false;
            this.tahir5.BackColor = System.Drawing.Color.White;
            this.tahir5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir5.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir5.BorderRadius = 15;
            this.tahir5.BorderSize = 2;
            this.tahir5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir5.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir5.IsFocused = false;
            this.tahir5.Location = new System.Drawing.Point(0, 0);
            this.tahir5.Margin = new System.Windows.Forms.Padding(4);
            this.tahir5.Multiline = true;
            this.tahir5.Name = "tahir5";
            this.tahir5.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir5.readonly_x = false;
            this.tahir5.SelectionLength = 0;
            this.tahir5.SelectionStart = 0;
            this.tahir5.Size = new System.Drawing.Size(96, 96);
            this.tahir5.TabIndex = 5;
            this.tahir5.Texts = "";
            this.tahir5.UnderlinedStyle = false;
            this.tahir5.Visible = false;
            this.tahir5._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir5.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir5.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir4
            // 
            this.tahir4.AcceptsTab = false;
            this.tahir4.BackColor = System.Drawing.Color.White;
            this.tahir4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir4.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir4.BorderRadius = 15;
            this.tahir4.BorderSize = 2;
            this.tahir4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir4.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir4.IsFocused = false;
            this.tahir4.Location = new System.Drawing.Point(0, 0);
            this.tahir4.Margin = new System.Windows.Forms.Padding(4);
            this.tahir4.Multiline = true;
            this.tahir4.Name = "tahir4";
            this.tahir4.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir4.readonly_x = false;
            this.tahir4.SelectionLength = 0;
            this.tahir4.SelectionStart = 0;
            this.tahir4.Size = new System.Drawing.Size(96, 96);
            this.tahir4.TabIndex = 4;
            this.tahir4.Texts = "";
            this.tahir4.UnderlinedStyle = false;
            this.tahir4.Visible = false;
            this.tahir4._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir4.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir4.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir3
            // 
            this.tahir3.AcceptsTab = false;
            this.tahir3.BackColor = System.Drawing.Color.White;
            this.tahir3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir3.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir3.BorderRadius = 15;
            this.tahir3.BorderSize = 2;
            this.tahir3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir3.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir3.IsFocused = false;
            this.tahir3.Location = new System.Drawing.Point(0, 0);
            this.tahir3.Margin = new System.Windows.Forms.Padding(4);
            this.tahir3.Multiline = true;
            this.tahir3.Name = "tahir3";
            this.tahir3.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir3.readonly_x = false;
            this.tahir3.SelectionLength = 0;
            this.tahir3.SelectionStart = 0;
            this.tahir3.Size = new System.Drawing.Size(96, 96);
            this.tahir3.TabIndex = 3;
            this.tahir3.Texts = "";
            this.tahir3.UnderlinedStyle = false;
            this.tahir3.Visible = false;
            this.tahir3._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir3.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir3.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir2
            // 
            this.tahir2.AcceptsTab = false;
            this.tahir2.BackColor = System.Drawing.Color.White;
            this.tahir2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir2.BorderRadius = 15;
            this.tahir2.BorderSize = 2;
            this.tahir2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir2.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir2.IsFocused = false;
            this.tahir2.Location = new System.Drawing.Point(0, 0);
            this.tahir2.Margin = new System.Windows.Forms.Padding(4);
            this.tahir2.Multiline = true;
            this.tahir2.Name = "tahir2";
            this.tahir2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir2.readonly_x = false;
            this.tahir2.SelectionLength = 0;
            this.tahir2.SelectionStart = 0;
            this.tahir2.Size = new System.Drawing.Size(96, 96);
            this.tahir2.TabIndex = 2;
            this.tahir2.Texts = "";
            this.tahir2.UnderlinedStyle = false;
            this.tahir2.Visible = false;
            this.tahir2._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir2.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir2.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // tahir0
            // 
            this.tahir0.AcceptsTab = false;
            this.tahir0.BackColor = System.Drawing.Color.White;
            this.tahir0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir0.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir0.BorderRadius = 15;
            this.tahir0.BorderSize = 2;
            this.tahir0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tahir0.Font = new System.Drawing.Font("Alata", 36F);
            this.tahir0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.tahir0.IsFocused = false;
            this.tahir0.Location = new System.Drawing.Point(0, 0);
            this.tahir0.Margin = new System.Windows.Forms.Padding(4);
            this.tahir0.Multiline = true;
            this.tahir0.Name = "tahir0";
            this.tahir0.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tahir0.readonly_x = false;
            this.tahir0.SelectionLength = 0;
            this.tahir0.SelectionStart = 0;
            this.tahir0.Size = new System.Drawing.Size(96, 96);
            this.tahir0.TabIndex = 0;
            this.tahir0.Texts = "";
            this.tahir0.UnderlinedStyle = false;
            this.tahir0.Visible = false;
            this.tahir0._TextChanged += new System.EventHandler(this.Dinamik__TextChanged);
            this.tahir0.Enter += new System.EventHandler(this.Dinamik_Enter);
            this.tahir0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dinamik_KeyPress);
            this.tahir0.MouseEnter += new System.EventHandler(this.Dinamik_MouseEnter);
            // 
            // gamecondition
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.girisPsyword);
            this.Controls.Add(this.gridparticipants);
            this.Controls.Add(this.load);
            this.Controls.Add(this.lblbesttotalpoint);
            this.Controls.Add(this.lbltotalpoint);
            this.Controls.Add(this.whiteprogress);
            this.Controls.Add(this.lblwordpoint);
            this.Controls.Add(this.lbremainingpoint);
            this.Controls.Add(this.progres_siyah);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.gridunnecessaryfocus);
            this.Controls.Add(this.gridwords);
            this.Controls.Add(this.tahir1);
            this.Controls.Add(this.tahir15);
            this.Controls.Add(this.tahir14);
            this.Controls.Add(this.tahir13);
            this.Controls.Add(this.tahir12);
            this.Controls.Add(this.tahir11);
            this.Controls.Add(this.tahir10);
            this.Controls.Add(this.tahir9);
            this.Controls.Add(this.tahir8);
            this.Controls.Add(this.tahir7);
            this.Controls.Add(this.tahir6);
            this.Controls.Add(this.tahir5);
            this.Controls.Add(this.tahir4);
            this.Controls.Add(this.tahir3);
            this.Controls.Add(this.tahir2);
            this.Controls.Add(this.tahir0);
            this.Controls.Add(this.lblword);
            this.Controls.Add(this.lblremainingtime);
            this.Controls.Add(this.pctscreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "gamecondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.oyun_FormClosing);
            this.Load += new System.EventHandler(this.oyun_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.oyun_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gridwords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridunnecessaryfocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridparticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctscreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.girisPsyword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridwords;
        private System.Windows.Forms.Label lblremainingtime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblwordpoint;
        private System.Windows.Forms.Label lbremainingpoint;
        private System.Windows.Forms.Label lblword;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.PictureBox pctscreen;
        private textbox_tahir tahir0;
        private textbox_tahir tahir2;
        private textbox_tahir tahir3;
        private textbox_tahir tahir4;
        private textbox_tahir tahir5;
        private textbox_tahir tahir6;
        private textbox_tahir tahir7;
        private textbox_tahir tahir8;
        private textbox_tahir tahir9;
        private textbox_tahir tahir10;
        private textbox_tahir tahir11;
        private textbox_tahir tahir12;
        private textbox_tahir tahir13;
        private textbox_tahir tahir14;
        private textbox_tahir tahir15;
        private textbox_tahir tahir1;
        private NewProgressBar whiteprogress;
        private System.Windows.Forms.DataGridView gridunnecessaryfocus;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private progres_siyah progres_siyah;
        private System.Windows.Forms.Label lblbesttotalpoint;
        private System.Windows.Forms.Label lbltotalpoint;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.DataGridView gridparticipants;
        private System.Windows.Forms.DataGridView girisPsyword;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
    }
}