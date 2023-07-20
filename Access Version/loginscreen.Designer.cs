
namespace DEMO
{
    partial class loginscreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginscreen));
            this.gridparticipants = new System.Windows.Forms.DataGridView();
            this.sessiontext = new System.Windows.Forms.TextBox();
            this.girisPsyword = new System.Windows.Forms.DataGridView();
            this.sessionnumber = new System.Windows.Forms.TextBox();
            this.pctscreen = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblinternetcondition = new System.Windows.Forms.Label();
            this.pnlgame = new System.Windows.Forms.Panel();
            this.pnllogin = new System.Windows.Forms.Panel();
            this.pnlerror = new System.Windows.Forms.Panel();
            this.pnlclosesession = new System.Windows.Forms.Panel();
            this.pnlcontact = new System.Windows.Forms.Panel();
            this.pnlcloseprogram = new System.Windows.Forms.Panel();
            this.password = new DEMO.UserControl_aa();
            this.username = new DEMO.UserControl_aa();
            ((System.ComponentModel.ISupportInitialize)(this.gridparticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.girisPsyword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctscreen)).BeginInit();
            this.SuspendLayout();
            // 
            // gridparticipants
            // 
            this.gridparticipants.AllowUserToAddRows = false;
            this.gridparticipants.AllowUserToDeleteRows = false;
            this.gridparticipants.AllowUserToOrderColumns = true;
            this.gridparticipants.AllowUserToResizeColumns = false;
            this.gridparticipants.AllowUserToResizeRows = false;
            this.gridparticipants.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.gridparticipants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridparticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridparticipants.ColumnHeadersVisible = false;
            this.gridparticipants.Location = new System.Drawing.Point(1, 1);
            this.gridparticipants.MultiSelect = false;
            this.gridparticipants.Name = "gridparticipants";
            this.gridparticipants.ReadOnly = true;
            this.gridparticipants.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridparticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridparticipants.Size = new System.Drawing.Size(261, 290);
            this.gridparticipants.TabIndex = 27;
            this.gridparticipants.Visible = false;
            // 
            // sessiontext
            // 
            this.sessiontext.Location = new System.Drawing.Point(897, 538);
            this.sessiontext.Name = "sessiontext";
            this.sessiontext.Size = new System.Drawing.Size(1, 20);
            this.sessiontext.TabIndex = 59;
            this.sessiontext.Visible = false;
            // 
            // girisPsyword
            // 
            this.girisPsyword.AllowUserToAddRows = false;
            this.girisPsyword.AllowUserToDeleteRows = false;
            this.girisPsyword.AllowUserToOrderColumns = true;
            this.girisPsyword.AllowUserToResizeColumns = false;
            this.girisPsyword.AllowUserToResizeRows = false;
            this.girisPsyword.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.girisPsyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.girisPsyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.girisPsyword.ColumnHeadersVisible = false;
            this.girisPsyword.Location = new System.Drawing.Point(268, 1);
            this.girisPsyword.MultiSelect = false;
            this.girisPsyword.Name = "girisPsyword";
            this.girisPsyword.ReadOnly = true;
            this.girisPsyword.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.girisPsyword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.girisPsyword.Size = new System.Drawing.Size(261, 290);
            this.girisPsyword.TabIndex = 60;
            this.girisPsyword.Visible = false;
            // 
            // sessionnumber
            // 
            this.sessionnumber.Location = new System.Drawing.Point(897, 564);
            this.sessionnumber.Name = "sessionnumber";
            this.sessionnumber.Size = new System.Drawing.Size(1, 20);
            this.sessionnumber.TabIndex = 61;
            this.sessionnumber.Visible = false;
            // 
            // pctscreen
            // 
            this.pctscreen.Location = new System.Drawing.Point(0, 0);
            this.pctscreen.Name = "pctscreen";
            this.pctscreen.Size = new System.Drawing.Size(1920, 1080);
            this.pctscreen.TabIndex = 0;
            this.pctscreen.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblinternetcondition
            // 
            this.lblinternetcondition.BackColor = System.Drawing.Color.Transparent;
            this.lblinternetcondition.Font = new System.Drawing.Font("Big Shoulders Display", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblinternetcondition.Location = new System.Drawing.Point(30, 996);
            this.lblinternetcondition.Margin = new System.Windows.Forms.Padding(0);
            this.lblinternetcondition.Name = "lblinternetcondition";
            this.lblinternetcondition.Size = new System.Drawing.Size(703, 54);
            this.lblinternetcondition.TabIndex = 62;
            this.lblinternetcondition.Text = "Pasif, lütfen internete bağlı olduğunuzdan emin olunuz...";
            this.lblinternetcondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlgame
            // 
            this.pnlgame.BackColor = System.Drawing.Color.Transparent;
            this.pnlgame.Location = new System.Drawing.Point(221, 816);
            this.pnlgame.Name = "pnlgame";
            this.pnlgame.Size = new System.Drawing.Size(335, 71);
            this.pnlgame.TabIndex = 67;
            this.pnlgame.Click += new System.EventHandler(this.pnl_oyun_Click);
            // 
            // pnllogin
            // 
            this.pnllogin.BackColor = System.Drawing.Color.Transparent;
            this.pnllogin.Location = new System.Drawing.Point(221, 729);
            this.pnllogin.Name = "pnllogin";
            this.pnllogin.Size = new System.Drawing.Size(298, 65);
            this.pnllogin.TabIndex = 68;
            this.pnllogin.Click += new System.EventHandler(this.pnl_giris_Click);
            // 
            // pnlerror
            // 
            this.pnlerror.BackColor = System.Drawing.Color.Transparent;
            this.pnlerror.Location = new System.Drawing.Point(567, 692);
            this.pnlerror.Name = "pnlerror";
            this.pnlerror.Size = new System.Drawing.Size(66, 66);
            this.pnlerror.TabIndex = 69;
            this.pnlerror.Click += new System.EventHandler(this.pnl_girishata_Click);
            // 
            // pnlclosesession
            // 
            this.pnlclosesession.BackColor = System.Drawing.Color.Transparent;
            this.pnlclosesession.Location = new System.Drawing.Point(1339, 173);
            this.pnlclosesession.Name = "pnlclosesession";
            this.pnlclosesession.Size = new System.Drawing.Size(25, 25);
            this.pnlclosesession.TabIndex = 70;
            this.pnlclosesession.Click += new System.EventHandler(this.pnl_kapa_Click);
            // 
            // pnlcontact
            // 
            this.pnlcontact.BackColor = System.Drawing.Color.Transparent;
            this.pnlcontact.Location = new System.Drawing.Point(1497, 115);
            this.pnlcontact.Name = "pnlcontact";
            this.pnlcontact.Size = new System.Drawing.Size(103, 35);
            this.pnlcontact.TabIndex = 71;
            this.pnlcontact.Click += new System.EventHandler(this.pnl_iletisim_Click);
            // 
            // pnlcloseprogram
            // 
            this.pnlcloseprogram.BackColor = System.Drawing.Color.Transparent;
            this.pnlcloseprogram.Location = new System.Drawing.Point(1676, 113);
            this.pnlcloseprogram.Name = "pnlcloseprogram";
            this.pnlcloseprogram.Size = new System.Drawing.Size(42, 42);
            this.pnlcloseprogram.TabIndex = 72;
            this.pnlcloseprogram.Click += new System.EventHandler(this.pnl_cikis_Click);
            // 
            // password
            // 
            this.password.AcceptsTab = false;
            this.password.BackColor = System.Drawing.SystemColors.Window;
            this.password.BorderColor = System.Drawing.Color.White;
            this.password.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.password.BorderRadius = 15;
            this.password.BorderSize = 2;
            this.password.Font = new System.Drawing.Font("Alata", 18F);
            this.password.IsFocused = false;
            this.password.Location = new System.Drawing.Point(292, 592);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Multiline = false;
            this.password.Name = "password";
            this.password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.password.readonly_x = false;
            this.password.SelectionLength = 0;
            this.password.SelectionStart = 0;
            this.password.Size = new System.Drawing.Size(229, 54);
            this.password.TabIndex = 74;
            this.password.Texts = "";
            this.password.UnderlinedStyle = false;
            this.password.Visible = false;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kullanici_sifre_KeyPress);
            // 
            // username
            // 
            this.username.AcceptsTab = false;
            this.username.BackColor = System.Drawing.SystemColors.Window;
            this.username.BorderColor = System.Drawing.Color.White;
            this.username.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(27)))));
            this.username.BorderRadius = 15;
            this.username.BorderSize = 2;
            this.username.Font = new System.Drawing.Font("Alata", 18F);
            this.username.IsFocused = false;
            this.username.Location = new System.Drawing.Point(428, 515);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Multiline = false;
            this.username.Name = "username";
            this.username.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.username.readonly_x = false;
            this.username.SelectionLength = 0;
            this.username.SelectionStart = 0;
            this.username.Size = new System.Drawing.Size(229, 54);
            this.username.TabIndex = 73;
            this.username.Texts = "";
            this.username.UnderlinedStyle = false;
            this.username.Visible = false;
            // 
            // loginscreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.pnlcloseprogram);
            this.Controls.Add(this.pnlcontact);
            this.Controls.Add(this.pnlclosesession);
            this.Controls.Add(this.pnlerror);
            this.Controls.Add(this.pnllogin);
            this.Controls.Add(this.pnlgame);
            this.Controls.Add(this.lblinternetcondition);
            this.Controls.Add(this.sessionnumber);
            this.Controls.Add(this.girisPsyword);
            this.Controls.Add(this.sessiontext);
            this.Controls.Add(this.gridparticipants);
            this.Controls.Add(this.pctscreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.kullanici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridparticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.girisPsyword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctscreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctscreen;
        private System.Windows.Forms.DataGridView gridparticipants;
        private System.Windows.Forms.TextBox sessiontext;
        private System.Windows.Forms.DataGridView girisPsyword;
        private System.Windows.Forms.TextBox sessionnumber;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblinternetcondition;
        private System.Windows.Forms.Panel pnlgame;
        private System.Windows.Forms.Panel pnllogin;
        private System.Windows.Forms.Panel pnlerror;
        private System.Windows.Forms.Panel pnlclosesession;
        private System.Windows.Forms.Panel pnlcontact;
        private System.Windows.Forms.Panel pnlcloseprogram;
        private UserControl_aa username;
        private UserControl_aa password;
    }
}