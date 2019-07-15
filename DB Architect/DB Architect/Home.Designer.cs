namespace DB_Architect
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.Status = new System.Windows.Forms.Label();
            this.StatusList = new System.Windows.Forms.ImageList(this.components);
            this.StatusPic = new System.Windows.Forms.PictureBox();
            this.AddMenu = new System.Windows.Forms.Panel();
            this.QueryBtn = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TableBtn = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DatabaseBtn = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ArchitectLogo = new System.Windows.Forms.PictureBox();
            this.Menu = new System.Windows.Forms.Panel();
            this.Disconnect = new System.Windows.Forms.Panel();
            this.Man_lbl4 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.Options = new System.Windows.Forms.Panel();
            this.Men_lbl3 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.About = new System.Windows.Forms.Panel();
            this.Men_lbl2 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.AddNew = new System.Windows.Forms.Panel();
            this.Arrow_lbl = new System.Windows.Forms.Label();
            this.Men_lbl1 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ServerData = new System.Windows.Forms.Panel();
            this.ChangePass = new System.Windows.Forms.Label();
            this.IPA = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).BeginInit();
            this.AddMenu.SuspendLayout();
            this.QueryBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.TableBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DatabaseBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchitectLogo)).BeginInit();
            this.Menu.SuspendLayout();
            this.Disconnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.AddNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ServerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Server)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Gray;
            this.Status.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Status.Location = new System.Drawing.Point(1218, 714);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(95, 13);
            this.Status.TabIndex = 5;
            this.Status.Text = "DBA Studio Offline";
            this.Status.Visible = false;
            // 
            // StatusList
            // 
            this.StatusList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusList.ImageStream")));
            this.StatusList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusList.Images.SetKeyName(0, "Server.png");
            this.StatusList.Images.SetKeyName(1, "Database Activity.png");
            this.StatusList.Images.SetKeyName(2, "Database Frameless.png");
            this.StatusList.Images.SetKeyName(3, "Activity.png");
            this.StatusList.Images.SetKeyName(4, "Question.png");
            // 
            // StatusPic
            // 
            this.StatusPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusPic.BackColor = System.Drawing.Color.Gray;
            this.StatusPic.Location = new System.Drawing.Point(1199, 713);
            this.StatusPic.Name = "StatusPic";
            this.StatusPic.Size = new System.Drawing.Size(15, 15);
            this.StatusPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatusPic.TabIndex = 12;
            this.StatusPic.TabStop = false;
            // 
            // AddMenu
            // 
            this.AddMenu.BackgroundImage = global::DB_Architect.Properties.Resources.MenuBG;
            this.AddMenu.Controls.Add(this.QueryBtn);
            this.AddMenu.Controls.Add(this.TableBtn);
            this.AddMenu.Controls.Add(this.DatabaseBtn);
            this.AddMenu.Location = new System.Drawing.Point(201, 88);
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(200, 157);
            this.AddMenu.TabIndex = 10;
            this.AddMenu.Visible = false;
            // 
            // QueryBtn
            // 
            this.QueryBtn.BackColor = System.Drawing.Color.Transparent;
            this.QueryBtn.Controls.Add(this.pictureBox7);
            this.QueryBtn.Controls.Add(this.label3);
            this.QueryBtn.Location = new System.Drawing.Point(3, 106);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(188, 45);
            this.QueryBtn.TabIndex = 15;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            this.QueryBtn.MouseEnter += new System.EventHandler(this.QueryBtn_MouseEnter);
            this.QueryBtn.MouseLeave += new System.EventHandler(this.QueryBtn_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DB_Architect.Properties.Resources.Query;
            this.pictureBox7.Location = new System.Drawing.Point(7, 7);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 9;
            this.pictureBox7.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(43, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Query";
            // 
            // TableBtn
            // 
            this.TableBtn.BackColor = System.Drawing.Color.Transparent;
            this.TableBtn.Controls.Add(this.pictureBox1);
            this.TableBtn.Controls.Add(this.label2);
            this.TableBtn.Location = new System.Drawing.Point(3, 56);
            this.TableBtn.Name = "TableBtn";
            this.TableBtn.Size = new System.Drawing.Size(188, 45);
            this.TableBtn.TabIndex = 14;
            this.TableBtn.Click += new System.EventHandler(this.TableBtn_Click);
            this.TableBtn.MouseEnter += new System.EventHandler(this.TableBtn_MouseEnter);
            this.TableBtn.MouseLeave += new System.EventHandler(this.TableBtn_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_Architect.Properties.Resources.Table;
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table";
            // 
            // DatabaseBtn
            // 
            this.DatabaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseBtn.Controls.Add(this.pictureBox6);
            this.DatabaseBtn.Controls.Add(this.label1);
            this.DatabaseBtn.Location = new System.Drawing.Point(4, 5);
            this.DatabaseBtn.Name = "DatabaseBtn";
            this.DatabaseBtn.Size = new System.Drawing.Size(188, 45);
            this.DatabaseBtn.TabIndex = 13;
            this.DatabaseBtn.Click += new System.EventHandler(this.DatabaseBtn_Click);
            this.DatabaseBtn.MouseEnter += new System.EventHandler(this.DatabaseBtn_MouseEnter);
            this.DatabaseBtn.MouseLeave += new System.EventHandler(this.DatabaseBtn_MouseLeave);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DB_Architect.Properties.Resources.Database;
            this.pictureBox6.Location = new System.Drawing.Point(8, 7);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database";
            // 
            // ArchitectLogo
            // 
            this.ArchitectLogo.Enabled = false;
            this.ArchitectLogo.Image = global::DB_Architect.Properties.Resources.Architect_Logo;
            this.ArchitectLogo.Location = new System.Drawing.Point(13, 14);
            this.ArchitectLogo.Name = "ArchitectLogo";
            this.ArchitectLogo.Size = new System.Drawing.Size(60, 60);
            this.ArchitectLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArchitectLogo.TabIndex = 0;
            this.ArchitectLogo.TabStop = false;
            this.ArchitectLogo.Click += new System.EventHandler(this.ArchitectLogo_Click);
            this.ArchitectLogo.MouseEnter += new System.EventHandler(this.ArchitectLogo_MouseEnter);
            this.ArchitectLogo.MouseLeave += new System.EventHandler(this.ArchitectLogo_MouseLeave);
            // 
            // Menu
            // 
            this.Menu.BackgroundImage = global::DB_Architect.Properties.Resources.MenuBG;
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Menu.Controls.Add(this.Disconnect);
            this.Menu.Controls.Add(this.Options);
            this.Menu.Controls.Add(this.About);
            this.Menu.Controls.Add(this.AddNew);
            this.Menu.Location = new System.Drawing.Point(0, 50);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(200, 250);
            this.Menu.TabIndex = 9;
            this.Menu.Visible = false;
            // 
            // Disconnect
            // 
            this.Disconnect.BackColor = System.Drawing.Color.Transparent;
            this.Disconnect.Controls.Add(this.Man_lbl4);
            this.Disconnect.Controls.Add(this.pictureBox11);
            this.Disconnect.Location = new System.Drawing.Point(5, 182);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(188, 45);
            this.Disconnect.TabIndex = 13;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            this.Disconnect.MouseEnter += new System.EventHandler(this.Disconnect_MouseEnter);
            this.Disconnect.MouseLeave += new System.EventHandler(this.Disconnect_MouseLeave);
            // 
            // Man_lbl4
            // 
            this.Man_lbl4.AutoSize = true;
            this.Man_lbl4.Enabled = false;
            this.Man_lbl4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Man_lbl4.ForeColor = System.Drawing.Color.White;
            this.Man_lbl4.Location = new System.Drawing.Point(43, 14);
            this.Man_lbl4.Name = "Man_lbl4";
            this.Man_lbl4.Size = new System.Drawing.Size(76, 17);
            this.Man_lbl4.TabIndex = 1;
            this.Man_lbl4.Text = "Disconnect";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Enabled = false;
            this.pictureBox11.Image = global::DB_Architect.Properties.Resources.Disconnect;
            this.pictureBox11.Location = new System.Drawing.Point(2, 3);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(35, 35);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 0;
            this.pictureBox11.TabStop = false;
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.Transparent;
            this.Options.Controls.Add(this.Men_lbl3);
            this.Options.Controls.Add(this.pictureBox10);
            this.Options.Location = new System.Drawing.Point(6, 88);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(188, 45);
            this.Options.TabIndex = 12;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            this.Options.MouseEnter += new System.EventHandler(this.Options_MouseEnter);
            this.Options.MouseLeave += new System.EventHandler(this.Options_MouseLeave);
            // 
            // Men_lbl3
            // 
            this.Men_lbl3.AutoSize = true;
            this.Men_lbl3.Enabled = false;
            this.Men_lbl3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Men_lbl3.ForeColor = System.Drawing.Color.White;
            this.Men_lbl3.Location = new System.Drawing.Point(43, 14);
            this.Men_lbl3.Name = "Men_lbl3";
            this.Men_lbl3.Size = new System.Drawing.Size(57, 17);
            this.Men_lbl3.TabIndex = 1;
            this.Men_lbl3.Text = "Options";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Enabled = false;
            this.pictureBox10.Image = global::DB_Architect.Properties.Resources.Options_Gear;
            this.pictureBox10.Location = new System.Drawing.Point(0, 4);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 40);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 0;
            this.pictureBox10.TabStop = false;
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.Transparent;
            this.About.Controls.Add(this.Men_lbl2);
            this.About.Controls.Add(this.pictureBox9);
            this.About.Location = new System.Drawing.Point(6, 135);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(188, 45);
            this.About.TabIndex = 11;
            this.About.Click += new System.EventHandler(this.About_Click);
            this.About.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.About.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Men_lbl2
            // 
            this.Men_lbl2.AutoSize = true;
            this.Men_lbl2.Enabled = false;
            this.Men_lbl2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Men_lbl2.ForeColor = System.Drawing.Color.White;
            this.Men_lbl2.Location = new System.Drawing.Point(43, 14);
            this.Men_lbl2.Name = "Men_lbl2";
            this.Men_lbl2.Size = new System.Drawing.Size(46, 17);
            this.Men_lbl2.TabIndex = 1;
            this.Men_lbl2.Text = "About";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Enabled = false;
            this.pictureBox9.Image = global::DB_Architect.Properties.Resources.AboutIco;
            this.pictureBox9.Location = new System.Drawing.Point(2, 7);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(35, 35);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 0;
            this.pictureBox9.TabStop = false;
            // 
            // AddNew
            // 
            this.AddNew.BackColor = System.Drawing.Color.Transparent;
            this.AddNew.Controls.Add(this.Arrow_lbl);
            this.AddNew.Controls.Add(this.Men_lbl1);
            this.AddNew.Controls.Add(this.pictureBox8);
            this.AddNew.Location = new System.Drawing.Point(6, 40);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(188, 45);
            this.AddNew.TabIndex = 10;
            this.AddNew.MouseEnter += new System.EventHandler(this.AddNew_MouseEnter);
            this.AddNew.MouseLeave += new System.EventHandler(this.AddNew_MouseLeave);
            // 
            // Arrow_lbl
            // 
            this.Arrow_lbl.AutoSize = true;
            this.Arrow_lbl.Enabled = false;
            this.Arrow_lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Arrow_lbl.ForeColor = System.Drawing.Color.White;
            this.Arrow_lbl.Location = new System.Drawing.Point(165, 14);
            this.Arrow_lbl.Name = "Arrow_lbl";
            this.Arrow_lbl.Size = new System.Drawing.Size(17, 17);
            this.Arrow_lbl.TabIndex = 2;
            this.Arrow_lbl.Text = ">";
            // 
            // Men_lbl1
            // 
            this.Men_lbl1.AutoSize = true;
            this.Men_lbl1.Enabled = false;
            this.Men_lbl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Men_lbl1.ForeColor = System.Drawing.Color.White;
            this.Men_lbl1.Location = new System.Drawing.Point(43, 14);
            this.Men_lbl1.Name = "Men_lbl1";
            this.Men_lbl1.Size = new System.Drawing.Size(64, 17);
            this.Men_lbl1.TabIndex = 1;
            this.Men_lbl1.Text = "Add New";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Enabled = false;
            this.pictureBox8.Image = global::DB_Architect.Properties.Resources.AddNew;
            this.pictureBox8.Location = new System.Drawing.Point(7, 9);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(30, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::DB_Architect.Properties.Resources.Untitled_2;
            this.pictureBox4.Location = new System.Drawing.Point(-11, 712);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1367, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::DB_Architect.Properties.Resources.Bar1;
            this.pictureBox2.Location = new System.Drawing.Point(-5, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1361, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // ServerData
            // 
            this.ServerData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerData.BackgroundImage = global::DB_Architect.Properties.Resources.Untitled_2;
            this.ServerData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ServerData.Controls.Add(this.ChangePass);
            this.ServerData.Controls.Add(this.IPA);
            this.ServerData.Controls.Add(this.ServerName);
            this.ServerData.Controls.Add(this.Server);
            this.ServerData.Location = new System.Drawing.Point(-10, 68);
            this.ServerData.Name = "ServerData";
            this.ServerData.Size = new System.Drawing.Size(1360, 87);
            this.ServerData.TabIndex = 11;
            this.ServerData.Visible = false;
            // 
            // ChangePass
            // 
            this.ChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePass.AutoSize = true;
            this.ChangePass.BackColor = System.Drawing.Color.Transparent;
            this.ChangePass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePass.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ChangePass.Location = new System.Drawing.Point(1205, 3);
            this.ChangePass.Name = "ChangePass";
            this.ChangePass.Size = new System.Drawing.Size(129, 20);
            this.ChangePass.TabIndex = 6;
            this.ChangePass.Text = "Change Password";
            this.ChangePass.Click += new System.EventHandler(this.ChangePass_Click);
            this.ChangePass.MouseEnter += new System.EventHandler(this.ChangePass_MouseEnter);
            this.ChangePass.MouseLeave += new System.EventHandler(this.ChangePass_MouseLeave);
            // 
            // IPA
            // 
            this.IPA.AutoSize = true;
            this.IPA.BackColor = System.Drawing.Color.Gray;
            this.IPA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPA.ForeColor = System.Drawing.Color.White;
            this.IPA.Location = new System.Drawing.Point(155, 55);
            this.IPA.Name = "IPA";
            this.IPA.Size = new System.Drawing.Size(64, 13);
            this.IPA.TabIndex = 5;
            this.IPA.Text = "192.168.0.0";
            // 
            // ServerName
            // 
            this.ServerName.AutoSize = true;
            this.ServerName.BackColor = System.Drawing.Color.Gray;
            this.ServerName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerName.ForeColor = System.Drawing.Color.White;
            this.ServerName.Location = new System.Drawing.Point(151, 17);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(133, 30);
            this.ServerName.TabIndex = 4;
            this.ServerName.Text = "ServerName";
            // 
            // Server
            // 
            this.Server.Image = global::DB_Architect.Properties.Resources.Server;
            this.Server.Location = new System.Drawing.Point(85, 14);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(60, 60);
            this.Server.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Server.TabIndex = 3;
            this.Server.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = global::DB_Architect.Properties.Resources.Background;
            this.pictureBox5.Location = new System.Drawing.Point(-1, 68);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1357, 647);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Image = global::DB_Architect.Properties.Resources.AeroEffect26;
            this.pictureBox3.Location = new System.Drawing.Point(91, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1260, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.StatusPic);
            this.Controls.Add(this.AddMenu);
            this.Controls.Add(this.ArchitectLogo);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ServerData);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Architect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).EndInit();
            this.AddMenu.ResumeLayout(false);
            this.QueryBtn.ResumeLayout(false);
            this.QueryBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.TableBtn.ResumeLayout(false);
            this.TableBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DatabaseBtn.ResumeLayout(false);
            this.DatabaseBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchitectLogo)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Disconnect.ResumeLayout(false);
            this.Disconnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.AddNew.ResumeLayout(false);
            this.AddNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ServerData.ResumeLayout(false);
            this.ServerData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Server)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ArchitectLogo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Label Status;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel AddNew;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label Men_lbl1;
        private System.Windows.Forms.Label Arrow_lbl;
        private System.Windows.Forms.Panel About;
        private System.Windows.Forms.Label Men_lbl2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Label Men_lbl3;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Panel Disconnect;
        private System.Windows.Forms.Label Man_lbl4;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Panel AddMenu;
        private System.Windows.Forms.Panel QueryBtn;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel TableBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel DatabaseBtn;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ServerData;
        private System.Windows.Forms.PictureBox Server;
        private System.Windows.Forms.Label ServerName;
        private System.Windows.Forms.Label IPA;
        private System.Windows.Forms.PictureBox StatusPic;
        private System.Windows.Forms.ImageList StatusList;
        private System.Windows.Forms.Label ChangePass;
        private System.Windows.Forms.PictureBox pictureBox3;









    }
}