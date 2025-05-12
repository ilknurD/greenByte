namespace greenByte.Forms
{
    partial class FormMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonLogView = new System.Windows.Forms.Button();
            this.buttonSeraYonetimPage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonDataControlPage = new System.Windows.Forms.Button();
            this.buttonUserControlPage = new System.Windows.Forms.Button();
            this.buttonDashboardPage = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(1633, 46);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "GreenByte Sera Kontrol Paneli";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = global::greenByte.Properties.Resources._24px_close_icon;
            this.buttonClose.Location = new System.Drawing.Point(1588, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.buttonClose.Size = new System.Drawing.Size(40, 46);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelMenu.Controls.Add(this.buttonLogView);
            this.panelMenu.Controls.Add(this.buttonSeraYonetimPage);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.buttonDataControlPage);
            this.panelMenu.Controls.Add(this.buttonUserControlPage);
            this.panelMenu.Controls.Add(this.buttonDashboardPage);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 46);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(284, 795);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonLogView
            // 
            this.buttonLogView.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogView.FlatAppearance.BorderSize = 0;
            this.buttonLogView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonLogView.ForeColor = System.Drawing.Color.White;
            this.buttonLogView.Image = global::greenByte.Properties.Resources.file__2_;
            this.buttonLogView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogView.Location = new System.Drawing.Point(35, 241);
            this.buttonLogView.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogView.Name = "buttonLogView";
            this.buttonLogView.Size = new System.Drawing.Size(198, 46);
            this.buttonLogView.TabIndex = 10;
            this.buttonLogView.Text = "        Hareket Geçmişi";
            this.buttonLogView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLogView.UseVisualStyleBackColor = false;
            this.buttonLogView.Click += new System.EventHandler(this.buttonLogView_Click);
            // 
            // buttonSeraYonetimPage
            // 
            this.buttonSeraYonetimPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonSeraYonetimPage.FlatAppearance.BorderSize = 0;
            this.buttonSeraYonetimPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeraYonetimPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSeraYonetimPage.ForeColor = System.Drawing.Color.White;
            this.buttonSeraYonetimPage.Image = global::greenByte.Properties.Resources.game_icons__greenhouse;
            this.buttonSeraYonetimPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeraYonetimPage.Location = new System.Drawing.Point(35, 187);
            this.buttonSeraYonetimPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeraYonetimPage.Name = "buttonSeraYonetimPage";
            this.buttonSeraYonetimPage.Size = new System.Drawing.Size(183, 46);
            this.buttonSeraYonetimPage.TabIndex = 9;
            this.buttonSeraYonetimPage.Text = "Sera Yönetimi";
            this.buttonSeraYonetimPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSeraYonetimPage.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.labelUsername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 729);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 66);
            this.panel2.TabIndex = 8;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Image = global::greenByte.Properties.Resources.clarity__logout_line;
            this.buttonLogout.Location = new System.Drawing.Point(229, 15);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(47, 41);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::greenByte.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(16, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 42);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(69, 21);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(65, 25);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "admin";
            // 
            // buttonDataControlPage
            // 
            this.buttonDataControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonDataControlPage.FlatAppearance.BorderSize = 0;
            this.buttonDataControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDataControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonDataControlPage.Image = global::greenByte.Properties.Resources.data_manager_icon;
            this.buttonDataControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDataControlPage.Location = new System.Drawing.Point(35, 134);
            this.buttonDataControlPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDataControlPage.Name = "buttonDataControlPage";
            this.buttonDataControlPage.Size = new System.Drawing.Size(183, 46);
            this.buttonDataControlPage.TabIndex = 3;
            this.buttonDataControlPage.Text = "Veri Kontrolü";
            this.buttonDataControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDataControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonUserControlPage
            // 
            this.buttonUserControlPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonUserControlPage.FlatAppearance.BorderSize = 0;
            this.buttonUserControlPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserControlPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonUserControlPage.ForeColor = System.Drawing.Color.White;
            this.buttonUserControlPage.Image = global::greenByte.Properties.Resources.mynaui__users_group_solid;
            this.buttonUserControlPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUserControlPage.Location = new System.Drawing.Point(35, 82);
            this.buttonUserControlPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUserControlPage.Name = "buttonUserControlPage";
            this.buttonUserControlPage.Size = new System.Drawing.Size(215, 44);
            this.buttonUserControlPage.TabIndex = 2;
            this.buttonUserControlPage.Text = "  Kullanıcı Yönetimi";
            this.buttonUserControlPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUserControlPage.UseVisualStyleBackColor = false;
            // 
            // buttonDashboardPage
            // 
            this.buttonDashboardPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashboardPage.FlatAppearance.BorderSize = 0;
            this.buttonDashboardPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboardPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDashboardPage.ForeColor = System.Drawing.Color.White;
            this.buttonDashboardPage.Image = global::greenByte.Properties.Resources.dashboard_icon1;
            this.buttonDashboardPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboardPage.Location = new System.Drawing.Point(35, 32);
            this.buttonDashboardPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDashboardPage.Name = "buttonDashboardPage";
            this.buttonDashboardPage.Size = new System.Drawing.Size(167, 43);
            this.buttonDashboardPage.TabIndex = 1;
            this.buttonDashboardPage.Text = " Dashboard";
            this.buttonDashboardPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDashboardPage.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(284, 46);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(5);
            this.panelMain.Size = new System.Drawing.Size(1349, 795);
            this.panelMain.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1633, 841);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonDashboardPage;
        private System.Windows.Forms.Button buttonUserControlPage;
        private System.Windows.Forms.Button buttonDataControlPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonSeraYonetimPage;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonLogView;
    }
}