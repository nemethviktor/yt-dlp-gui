namespace YtDlpGUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            lbl_YTDLP_Location = new Label();
            tbx_YTDLP_Location = new TextBox();
            btn_LocateYTDLP = new Button();
            ofd_Main = new OpenFileDialog();
            tbx_URL = new TextBox();
            lbl_URL = new Label();
            gbx_DownloadSettings = new GroupBox();
            rbt_DownloadSetting_VideoAsWell = new RadioButton();
            rbt_DownloadSetting_AudioOnly = new RadioButton();
            btn_OK = new Button();
            btn_Cancel = new Button();
            tbx_SaveWhere = new TextBox();
            lbl_Save_Where = new Label();
            btn_Save_Where = new Button();
            fbd_SaveWhere = new FolderBrowserDialog();
            gbx_Language = new GroupBox();
            rbt_Lang_hu = new RadioButton();
            rbt_Lang_en = new RadioButton();
            cbx_DarkMode = new CheckBox();
            tbx_Log = new TextBox();
            lbl_VideoFormat = new Label();
            cbo_VideoFormat = new ComboBox();
            lbl_VideoQuality = new Label();
            cbo_VideoQuality = new ComboBox();
            gbx_DownloadSettings.SuspendLayout();
            gbx_Language.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_YTDLP_Location
            // 
            lbl_YTDLP_Location.AutoSize = true;
            lbl_YTDLP_Location.Location = new Point(22, 54);
            lbl_YTDLP_Location.Margin = new Padding(5, 0, 5, 0);
            lbl_YTDLP_Location.Name = "lbl_YTDLP_Location";
            lbl_YTDLP_Location.Size = new Size(192, 30);
            lbl_YTDLP_Location.TabIndex = 0;
            lbl_YTDLP_Location.Text = "lbl_YTDLP_Location";
            // 
            // tbx_YTDLP_Location
            // 
            tbx_YTDLP_Location.Location = new Point(189, 48);
            tbx_YTDLP_Location.Margin = new Padding(5, 6, 5, 6);
            tbx_YTDLP_Location.Name = "tbx_YTDLP_Location";
            tbx_YTDLP_Location.Size = new Size(616, 35);
            tbx_YTDLP_Location.TabIndex = 1;
            // 
            // btn_LocateYTDLP
            // 
            btn_LocateYTDLP.Location = new Point(857, 48);
            btn_LocateYTDLP.Margin = new Padding(5, 6, 5, 6);
            btn_LocateYTDLP.Name = "btn_LocateYTDLP";
            btn_LocateYTDLP.Size = new Size(129, 46);
            btn_LocateYTDLP.TabIndex = 2;
            btn_LocateYTDLP.Text = "btn_LocateYTDLP";
            btn_LocateYTDLP.UseVisualStyleBackColor = true;
            btn_LocateYTDLP.Click += btn_Locate_Click;
            // 
            // ofd_Main
            // 
            ofd_Main.FileName = "openFileDialog1";
            ofd_Main.FileOk += ofd_Main_FileOk;
            // 
            // tbx_URL
            // 
            tbx_URL.Location = new Point(189, 126);
            tbx_URL.Margin = new Padding(5, 6, 5, 6);
            tbx_URL.Name = "tbx_URL";
            tbx_URL.Size = new Size(616, 35);
            tbx_URL.TabIndex = 4;
            // 
            // lbl_URL
            // 
            lbl_URL.AutoSize = true;
            lbl_URL.Location = new Point(22, 132);
            lbl_URL.Margin = new Padding(5, 0, 5, 0);
            lbl_URL.Name = "lbl_URL";
            lbl_URL.Size = new Size(81, 30);
            lbl_URL.TabIndex = 3;
            lbl_URL.Text = "lbl_URL";
            // 
            // gbx_DownloadSettings
            // 
            gbx_DownloadSettings.Controls.Add(rbt_DownloadSetting_VideoAsWell);
            gbx_DownloadSettings.Controls.Add(rbt_DownloadSetting_AudioOnly);
            gbx_DownloadSettings.Location = new Point(189, 312);
            gbx_DownloadSettings.Margin = new Padding(5, 6, 5, 6);
            gbx_DownloadSettings.Name = "gbx_DownloadSettings";
            gbx_DownloadSettings.Padding = new Padding(5, 6, 5, 6);
            gbx_DownloadSettings.Size = new Size(343, 172);
            gbx_DownloadSettings.TabIndex = 5;
            gbx_DownloadSettings.TabStop = false;
            gbx_DownloadSettings.Text = "gbx_DownloadSettings";
            // 
            // rbt_DownloadSetting_VideoAsWell
            // 
            rbt_DownloadSetting_VideoAsWell.AutoSize = true;
            rbt_DownloadSetting_VideoAsWell.Location = new Point(17, 112);
            rbt_DownloadSetting_VideoAsWell.Margin = new Padding(5, 6, 5, 6);
            rbt_DownloadSetting_VideoAsWell.Name = "rbt_DownloadSetting_VideoAsWell";
            rbt_DownloadSetting_VideoAsWell.Size = new Size(357, 34);
            rbt_DownloadSetting_VideoAsWell.TabIndex = 1;
            rbt_DownloadSetting_VideoAsWell.Text = "rbt_DownloadSetting_VideoAsWell";
            rbt_DownloadSetting_VideoAsWell.UseVisualStyleBackColor = true;
            // 
            // rbt_DownloadSetting_AudioOnly
            // 
            rbt_DownloadSetting_AudioOnly.AutoSize = true;
            rbt_DownloadSetting_AudioOnly.Checked = true;
            rbt_DownloadSetting_AudioOnly.Location = new Point(17, 44);
            rbt_DownloadSetting_AudioOnly.Margin = new Padding(5, 6, 5, 6);
            rbt_DownloadSetting_AudioOnly.Name = "rbt_DownloadSetting_AudioOnly";
            rbt_DownloadSetting_AudioOnly.Size = new Size(339, 34);
            rbt_DownloadSetting_AudioOnly.TabIndex = 0;
            rbt_DownloadSetting_AudioOnly.TabStop = true;
            rbt_DownloadSetting_AudioOnly.Text = "rbt_DownloadSetting_AudioOnly";
            rbt_DownloadSetting_AudioOnly.UseVisualStyleBackColor = true;
            rbt_DownloadSetting_AudioOnly.CheckedChanged += rbt_DownloadSetting_CheckedChanged;
            // 
            // btn_OK
            // 
            btn_OK.Location = new Point(506, 530);
            btn_OK.Margin = new Padding(5, 6, 5, 6);
            btn_OK.Name = "btn_OK";
            btn_OK.Size = new Size(129, 46);
            btn_OK.TabIndex = 6;
            btn_OK.Text = "btn_OK";
            btn_OK.UseVisualStyleBackColor = true;
            btn_OK.Click += btn_OK_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(345, 530);
            btn_Cancel.Margin = new Padding(5, 6, 5, 6);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(129, 46);
            btn_Cancel.TabIndex = 7;
            btn_Cancel.Text = "btn_Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // tbx_SaveWhere
            // 
            tbx_SaveWhere.Location = new Point(189, 208);
            tbx_SaveWhere.Margin = new Padding(5, 6, 5, 6);
            tbx_SaveWhere.Name = "tbx_SaveWhere";
            tbx_SaveWhere.Size = new Size(616, 35);
            tbx_SaveWhere.TabIndex = 9;
            // 
            // lbl_Save_Where
            // 
            lbl_Save_Where.AutoSize = true;
            lbl_Save_Where.Location = new Point(22, 214);
            lbl_Save_Where.Margin = new Padding(5, 0, 5, 0);
            lbl_Save_Where.Name = "lbl_Save_Where";
            lbl_Save_Where.Size = new Size(157, 30);
            lbl_Save_Where.TabIndex = 8;
            lbl_Save_Where.Text = "lbl_Save_Where";
            // 
            // btn_Save_Where
            // 
            btn_Save_Where.Location = new Point(857, 208);
            btn_Save_Where.Margin = new Padding(5, 6, 5, 6);
            btn_Save_Where.Name = "btn_Save_Where";
            btn_Save_Where.Size = new Size(129, 46);
            btn_Save_Where.TabIndex = 10;
            btn_Save_Where.Text = "btn_Save_Where";
            btn_Save_Where.UseVisualStyleBackColor = true;
            btn_Save_Where.Click += btn_SaveWhere_Click;
            // 
            // gbx_Language
            // 
            gbx_Language.Controls.Add(rbt_Lang_hu);
            gbx_Language.Controls.Add(rbt_Lang_en);
            gbx_Language.Location = new Point(576, 312);
            gbx_Language.Margin = new Padding(5, 6, 5, 6);
            gbx_Language.Name = "gbx_Language";
            gbx_Language.Padding = new Padding(5, 6, 5, 6);
            gbx_Language.Size = new Size(343, 172);
            gbx_Language.TabIndex = 6;
            gbx_Language.TabStop = false;
            gbx_Language.Text = "gbx_Language";
            // 
            // rbt_Lang_hu
            // 
            rbt_Lang_hu.AutoSize = true;
            rbt_Lang_hu.Location = new Point(17, 112);
            rbt_Lang_hu.Margin = new Padding(5, 6, 5, 6);
            rbt_Lang_hu.Name = "rbt_Lang_hu";
            rbt_Lang_hu.Size = new Size(224, 34);
            rbt_Lang_hu.TabIndex = 1;
            rbt_Lang_hu.Text = "rbt_Lang_Hungarian";
            rbt_Lang_hu.UseVisualStyleBackColor = true;
            rbt_Lang_hu.CheckedChanged += rbt_Lang_CheckedChanged;
            // 
            // rbt_Lang_en
            // 
            rbt_Lang_en.AutoSize = true;
            rbt_Lang_en.Checked = true;
            rbt_Lang_en.Location = new Point(17, 44);
            rbt_Lang_en.Margin = new Padding(5, 6, 5, 6);
            rbt_Lang_en.Name = "rbt_Lang_en";
            rbt_Lang_en.Size = new Size(193, 34);
            rbt_Lang_en.TabIndex = 0;
            rbt_Lang_en.TabStop = true;
            rbt_Lang_en.Text = "rbt_Lang_English";
            rbt_Lang_en.UseVisualStyleBackColor = true;
            rbt_Lang_en.CheckedChanged += rbt_Lang_CheckedChanged;
            // 
            // cbx_DarkMode
            // 
            cbx_DarkMode.AutoSize = true;
            cbx_DarkMode.Location = new Point(194, 620);
            cbx_DarkMode.Margin = new Padding(5, 6, 5, 6);
            cbx_DarkMode.Name = "cbx_DarkMode";
            cbx_DarkMode.Size = new Size(177, 34);
            cbx_DarkMode.TabIndex = 11;
            cbx_DarkMode.Text = "cbx_DarkMode";
            cbx_DarkMode.UseVisualStyleBackColor = true;
            cbx_DarkMode.CheckedChanged += cbx_DarkMode_CheckedChanged;
            // 
            // lbl_VideoFormat
            //
            lbl_VideoFormat.AutoSize = true;
            lbl_VideoFormat.Location = new Point(22, 272);
            lbl_VideoFormat.Margin = new Padding(5, 0, 5, 0);
            lbl_VideoFormat.Name = "lbl_VideoFormat";
            lbl_VideoFormat.Size = new Size(160, 30);
            lbl_VideoFormat.TabIndex = 13;
            lbl_VideoFormat.Text = "lbl_VideoFormat";
            //
            // cbo_VideoFormat
            //
            cbo_VideoFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_VideoFormat.Location = new Point(189, 266);
            cbo_VideoFormat.Margin = new Padding(5, 6, 5, 6);
            cbo_VideoFormat.Name = "cbo_VideoFormat";
            cbo_VideoFormat.Size = new Size(160, 38);
            cbo_VideoFormat.TabIndex = 14;
            //
            // lbl_VideoQuality
            //
            lbl_VideoQuality.AutoSize = true;
            lbl_VideoQuality.Location = new Point(400, 272);
            lbl_VideoQuality.Margin = new Padding(5, 0, 5, 0);
            lbl_VideoQuality.Name = "lbl_VideoQuality";
            lbl_VideoQuality.Size = new Size(160, 30);
            lbl_VideoQuality.TabIndex = 15;
            lbl_VideoQuality.Text = "lbl_VideoQuality";
            //
            // cbo_VideoQuality
            //
            cbo_VideoQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_VideoQuality.Location = new Point(576, 266);
            cbo_VideoQuality.Margin = new Padding(5, 6, 5, 6);
            cbo_VideoQuality.Name = "cbo_VideoQuality";
            cbo_VideoQuality.Size = new Size(229, 38);
            cbo_VideoQuality.TabIndex = 16;
            //
            // tbx_Log
            // 
            tbx_Log.Location = new Point(22, 680);
            tbx_Log.Margin = new Padding(5, 6, 5, 6);
            tbx_Log.Multiline = true;
            tbx_Log.Name = "tbx_Log";
            tbx_Log.ReadOnly = true;
            tbx_Log.ScrollBars = ScrollBars.Both;
            tbx_Log.Size = new Size(964, 230);
            tbx_Log.TabIndex = 12;
            tbx_Log.WordWrap = false;
            // 
            // frmMain
            // 
            AcceptButton = btn_OK;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(1039, 940);
            Controls.Add(cbo_VideoQuality);
            Controls.Add(lbl_VideoQuality);
            Controls.Add(cbo_VideoFormat);
            Controls.Add(lbl_VideoFormat);
            Controls.Add(tbx_Log);
            Controls.Add(cbx_DarkMode);
            Controls.Add(gbx_Language);
            Controls.Add(btn_Save_Where);
            Controls.Add(tbx_SaveWhere);
            Controls.Add(lbl_Save_Where);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_OK);
            Controls.Add(gbx_DownloadSettings);
            Controls.Add(tbx_URL);
            Controls.Add(lbl_URL);
            Controls.Add(btn_LocateYTDLP);
            Controls.Add(tbx_YTDLP_Location);
            Controls.Add(lbl_YTDLP_Location);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmMain";
            Text = "yt-dlp GUI";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            gbx_DownloadSettings.ResumeLayout(false);
            gbx_DownloadSettings.PerformLayout();
            gbx_Language.ResumeLayout(false);
            gbx_Language.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_YTDLP_Location;
        private TextBox tbx_YTDLP_Location;
        private Button btn_LocateYTDLP;
        private OpenFileDialog ofd_Main;
        private TextBox tbx_URL;
        private Label lbl_URL;
        private GroupBox gbx_DownloadSettings;
        private RadioButton rbt_DownloadSetting_VideoAsWell;
        private RadioButton rbt_DownloadSetting_AudioOnly;
        private Button btn_OK;
        private Button btn_Cancel;
        private TextBox tbx_SaveWhere;
        private Label lbl_Save_Where;
        private Button btn_Save_Where;
        private FolderBrowserDialog fbd_SaveWhere;
        private GroupBox gbx_Language;
        private RadioButton rbt_Lang_hu;
        private RadioButton rbt_Lang_en;
        private CheckBox cbx_DarkMode;
        private TextBox tbx_Log;
        private Label lbl_VideoFormat;
        private ComboBox cbo_VideoFormat;
        private Label lbl_VideoQuality;
        private ComboBox cbo_VideoQuality;
    }
}
