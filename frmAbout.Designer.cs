namespace YtDlpGUI
{
    partial class frmAbout
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
            lbl_About_Title = new Label();
            lbl_About_Version = new Label();
            lbl_About_Description = new Label();
            lbl_About_Copyright = new Label();
            lnk_About_GitHub = new LinkLabel();
            lnk_About_YtDlp = new LinkLabel();
            lbl_About_Disclaimer = new Label();
            btn_About_Close = new Button();
            SuspendLayout();
            //
            // lbl_About_Title
            //
            lbl_About_Title.AutoSize = true;
            lbl_About_Title.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_About_Title.Location = new Point(24, 24);
            lbl_About_Title.Margin = new Padding(5, 0, 5, 0);
            lbl_About_Title.Name = "lbl_About_Title";
            lbl_About_Title.Size = new Size(140, 45);
            lbl_About_Title.TabIndex = 0;
            lbl_About_Title.Text = "yt-dlp GUI";
            //
            // lbl_About_Version
            //
            lbl_About_Version.AutoSize = true;
            lbl_About_Version.Location = new Point(24, 82);
            lbl_About_Version.Margin = new Padding(5, 0, 5, 0);
            lbl_About_Version.Name = "lbl_About_Version";
            lbl_About_Version.Size = new Size(170, 30);
            lbl_About_Version.TabIndex = 1;
            lbl_About_Version.Text = "lbl_About_Version";
            //
            // lbl_About_Description
            //
            lbl_About_Description.AutoSize = true;
            lbl_About_Description.Location = new Point(24, 132);
            lbl_About_Description.Margin = new Padding(5, 0, 5, 0);
            lbl_About_Description.MaximumSize = new Size(592, 0);
            lbl_About_Description.Name = "lbl_About_Description";
            lbl_About_Description.Size = new Size(200, 30);
            lbl_About_Description.TabIndex = 2;
            lbl_About_Description.Text = "lbl_About_Description";
            //
            // lbl_About_Copyright
            //
            lbl_About_Copyright.AutoSize = true;
            lbl_About_Copyright.Location = new Point(24, 182);
            lbl_About_Copyright.Margin = new Padding(5, 0, 5, 0);
            lbl_About_Copyright.Name = "lbl_About_Copyright";
            lbl_About_Copyright.Size = new Size(430, 30);
            lbl_About_Copyright.TabIndex = 3;
            lbl_About_Copyright.Text = "Copyright (c) 2026 Viktor Nemeth. MIT License.";
            //
            // lnk_About_GitHub
            //
            lnk_About_GitHub.AutoSize = true;
            lnk_About_GitHub.Location = new Point(24, 232);
            lnk_About_GitHub.Margin = new Padding(5, 0, 5, 0);
            lnk_About_GitHub.Name = "lnk_About_GitHub";
            lnk_About_GitHub.Size = new Size(420, 30);
            lnk_About_GitHub.TabIndex = 4;
            lnk_About_GitHub.TabStop = true;
            lnk_About_GitHub.Text = "github.com/nemethviktor/yt-dlp-gui";
            lnk_About_GitHub.LinkClicked += lnk_About_GitHub_LinkClicked;
            //
            // lnk_About_YtDlp
            //
            lnk_About_YtDlp.AutoSize = true;
            lnk_About_YtDlp.Location = new Point(24, 276);
            lnk_About_YtDlp.Margin = new Padding(5, 0, 5, 0);
            lnk_About_YtDlp.Name = "lnk_About_YtDlp";
            lnk_About_YtDlp.Size = new Size(320, 30);
            lnk_About_YtDlp.TabIndex = 5;
            lnk_About_YtDlp.TabStop = true;
            lnk_About_YtDlp.Text = "github.com/yt-dlp/yt-dlp";
            lnk_About_YtDlp.LinkClicked += lnk_About_YtDlp_LinkClicked;
            //
            // lbl_About_Disclaimer
            //
            lbl_About_Disclaimer.AutoSize = true;
            lbl_About_Disclaimer.Location = new Point(24, 330);
            lbl_About_Disclaimer.Margin = new Padding(5, 0, 5, 0);
            lbl_About_Disclaimer.MaximumSize = new Size(592, 0);
            lbl_About_Disclaimer.Name = "lbl_About_Disclaimer";
            lbl_About_Disclaimer.Size = new Size(200, 30);
            lbl_About_Disclaimer.TabIndex = 6;
            lbl_About_Disclaimer.Text = "lbl_About_Disclaimer";
            //
            // btn_About_Close
            //
            btn_About_Close.DialogResult = DialogResult.Cancel;
            btn_About_Close.Location = new Point(487, 500);
            btn_About_Close.Margin = new Padding(5, 6, 5, 6);
            btn_About_Close.Name = "btn_About_Close";
            btn_About_Close.Size = new Size(129, 46);
            btn_About_Close.TabIndex = 7;
            btn_About_Close.Text = "btn_About_Close";
            btn_About_Close.UseVisualStyleBackColor = true;
            //
            // frmAbout
            //
            AcceptButton = btn_About_Close;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_About_Close;
            ClientSize = new Size(640, 570);
            Controls.Add(btn_About_Close);
            Controls.Add(lbl_About_Disclaimer);
            Controls.Add(lnk_About_YtDlp);
            Controls.Add(lnk_About_GitHub);
            Controls.Add(lbl_About_Copyright);
            Controls.Add(lbl_About_Description);
            Controls.Add(lbl_About_Version);
            Controls.Add(lbl_About_Title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmAbout";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_About_Title;
        private Label lbl_About_Version;
        private Label lbl_About_Description;
        private Label lbl_About_Copyright;
        private LinkLabel lnk_About_GitHub;
        private LinkLabel lnk_About_YtDlp;
        private Label lbl_About_Disclaimer;
        private Button btn_About_Close;
    }
}
