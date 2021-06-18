
namespace SacredAncariaConnectionClient
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.serverList = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.activeServers = new System.Windows.Forms.ListView();
            this.serverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usersCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gameMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.difficulty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.started = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sacServerStatus = new System.Windows.Forms.Label();
            this.hosting = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.forceIP = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.forcedServerIP = new IPAddressControlLib.IPAddressControl();
            this.autodectedIpAddress = new IPAddressControlLib.IPAddressControl();
            this.udpPort = new System.Windows.Forms.TextBox();
            this.broadcastingPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.broadcastInLan = new System.Windows.Forms.CheckBox();
            this.myServerList = new System.Windows.Forms.ListView();
            this.myName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myIPPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myNameUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myPortStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myUsers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myGameMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myDifficulty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myLocked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myStarted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.apply = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sacAboutHeader = new System.Windows.Forms.Label();
            this.motd = new System.Windows.Forms.Label();
            this.readme = new System.Windows.Forms.TextBox();
            this.mainTabs.SuspendLayout();
            this.serverList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.hosting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.about.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabs
            // 
            this.mainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabs.Controls.Add(this.serverList);
            this.mainTabs.Controls.Add(this.hosting);
            this.mainTabs.Controls.Add(this.about);
            this.mainTabs.Enabled = false;
            this.mainTabs.Location = new System.Drawing.Point(12, 12);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(760, 537);
            this.mainTabs.TabIndex = 0;
            // 
            // serverList
            // 
            this.serverList.Controls.Add(this.tableLayoutPanel2);
            this.serverList.Location = new System.Drawing.Point(4, 22);
            this.serverList.Name = "serverList";
            this.serverList.Padding = new System.Windows.Forms.Padding(3);
            this.serverList.Size = new System.Drawing.Size(752, 511);
            this.serverList.TabIndex = 0;
            this.serverList.Text = "Server List";
            this.serverList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.activeServers, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.sacServerStatus, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(740, 499);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // activeServers
            // 
            this.activeServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverName,
            this.usersCount,
            this.gameMode,
            this.difficulty,
            this.locked,
            this.started,
            this.password});
            this.activeServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeServers.HideSelection = false;
            this.activeServers.Location = new System.Drawing.Point(3, 33);
            this.activeServers.Name = "activeServers";
            this.activeServers.Size = new System.Drawing.Size(734, 463);
            this.activeServers.TabIndex = 0;
            this.activeServers.UseCompatibleStateImageBehavior = false;
            this.activeServers.View = System.Windows.Forms.View.Details;
            // 
            // serverName
            // 
            this.serverName.Text = "Name";
            // 
            // usersCount
            // 
            this.usersCount.Text = "Users";
            this.usersCount.Width = 82;
            // 
            // gameMode
            // 
            this.gameMode.Text = "Game Mode";
            this.gameMode.Width = 131;
            // 
            // difficulty
            // 
            this.difficulty.Text = "Difficulty";
            this.difficulty.Width = 104;
            // 
            // locked
            // 
            this.locked.Text = "Locked";
            this.locked.Width = 74;
            // 
            // started
            // 
            this.started.Text = "Started";
            this.started.Width = 76;
            // 
            // password
            // 
            this.password.Text = "Password";
            this.password.Width = 301;
            // 
            // sacServerStatus
            // 
            this.sacServerStatus.AutoSize = true;
            this.sacServerStatus.Location = new System.Drawing.Point(3, 0);
            this.sacServerStatus.Name = "sacServerStatus";
            this.sacServerStatus.Size = new System.Drawing.Size(70, 13);
            this.sacServerStatus.TabIndex = 1;
            this.sacServerStatus.Text = "Connecting...";
            // 
            // hosting
            // 
            this.hosting.Controls.Add(this.tableLayoutPanel1);
            this.hosting.Location = new System.Drawing.Point(4, 22);
            this.hosting.Name = "hosting";
            this.hosting.Padding = new System.Windows.Forms.Padding(3);
            this.hosting.Size = new System.Drawing.Size(752, 511);
            this.hosting.TabIndex = 1;
            this.hosting.Text = "Hosting";
            this.hosting.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.forceIP, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.forcedServerIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.autodectedIpAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.udpPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.broadcastingPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.broadcastInLan, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.myServerList, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.apply, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 499);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Autodected Server IP:";
            // 
            // forceIP
            // 
            this.forceIP.AutoSize = true;
            this.forceIP.Location = new System.Drawing.Point(495, 29);
            this.forceIP.Name = "forceIP";
            this.forceIP.Size = new System.Drawing.Size(66, 17);
            this.forceIP.TabIndex = 2;
            this.forceIP.Text = "Force IP";
            this.forceIP.UseVisualStyleBackColor = true;
            this.forceIP.CheckedChanged += new System.EventHandler(this.forceIP_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Force Server IP:";
            // 
            // forcedServerIP
            // 
            this.forcedServerIP.AllowInternalTab = true;
            this.forcedServerIP.AutoHeight = true;
            this.forcedServerIP.BackColor = System.Drawing.SystemColors.Window;
            this.forcedServerIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.forcedServerIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.forcedServerIP.Location = new System.Drawing.Point(249, 29);
            this.forcedServerIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.forcedServerIP.Name = "forcedServerIP";
            this.forcedServerIP.ReadOnly = false;
            this.forcedServerIP.Size = new System.Drawing.Size(240, 20);
            this.forcedServerIP.TabIndex = 1;
            this.forcedServerIP.Text = "...";
            this.forcedServerIP.Validated += new System.EventHandler(this.forcedServerIP_Validated);
            // 
            // autodectedIpAddress
            // 
            this.autodectedIpAddress.AllowInternalTab = false;
            this.autodectedIpAddress.AutoHeight = true;
            this.autodectedIpAddress.BackColor = System.Drawing.SystemColors.Window;
            this.autodectedIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.autodectedIpAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.autodectedIpAddress.Location = new System.Drawing.Point(249, 3);
            this.autodectedIpAddress.MinimumSize = new System.Drawing.Size(87, 20);
            this.autodectedIpAddress.Name = "autodectedIpAddress";
            this.autodectedIpAddress.ReadOnly = true;
            this.autodectedIpAddress.Size = new System.Drawing.Size(240, 20);
            this.autodectedIpAddress.TabIndex = 25;
            this.autodectedIpAddress.TabStop = false;
            this.autodectedIpAddress.Text = "...";
            // 
            // udpPort
            // 
            this.udpPort.Location = new System.Drawing.Point(249, 55);
            this.udpPort.Name = "udpPort";
            this.udpPort.Size = new System.Drawing.Size(240, 20);
            this.udpPort.TabIndex = 4;
            this.udpPort.Validating += new System.ComponentModel.CancelEventHandler(this.udpPort_Validating);
            this.udpPort.Validated += new System.EventHandler(this.udpPort_Validated);
            // 
            // broadcastingPort
            // 
            this.broadcastingPort.Location = new System.Drawing.Point(249, 81);
            this.broadcastingPort.Name = "broadcastingPort";
            this.broadcastingPort.Size = new System.Drawing.Size(240, 20);
            this.broadcastingPort.TabIndex = 29;
            this.broadcastingPort.Validating += new System.ComponentModel.CancelEventHandler(this.broadcastingPort_Validating);
            this.broadcastingPort.Validated += new System.EventHandler(this.broadcastingPort_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Listening UDP Port";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Broadcasting UDP Port in LAN";
            // 
            // broadcastInLan
            // 
            this.broadcastInLan.AutoSize = true;
            this.broadcastInLan.Location = new System.Drawing.Point(495, 81);
            this.broadcastInLan.Name = "broadcastInLan";
            this.broadcastInLan.Size = new System.Drawing.Size(109, 17);
            this.broadcastInLan.TabIndex = 27;
            this.broadcastInLan.Text = "Broadcast in LAN";
            this.broadcastInLan.UseVisualStyleBackColor = true;
            this.broadcastInLan.CheckedChanged += new System.EventHandler(this.broadcastInLan_CheckedChanged);
            // 
            // myServerList
            // 
            this.myServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.myName,
            this.myIPPort,
            this.myNameUsed,
            this.myPortStatus,
            this.myUsers,
            this.myGameMode,
            this.myDifficulty,
            this.myLocked,
            this.myStarted,
            this.myPassword});
            this.tableLayoutPanel1.SetColumnSpan(this.myServerList, 3);
            this.myServerList.HideSelection = false;
            this.myServerList.Location = new System.Drawing.Point(3, 136);
            this.myServerList.Name = "myServerList";
            this.myServerList.Size = new System.Drawing.Size(734, 360);
            this.myServerList.TabIndex = 30;
            this.myServerList.UseCompatibleStateImageBehavior = false;
            this.myServerList.View = System.Windows.Forms.View.Details;
            // 
            // myName
            // 
            this.myName.Text = "Name";
            this.myName.Width = 76;
            // 
            // myIPPort
            // 
            this.myIPPort.Text = "IP Port";
            this.myIPPort.Width = 64;
            // 
            // myNameUsed
            // 
            this.myNameUsed.Text = "Name already used";
            this.myNameUsed.Width = 106;
            // 
            // myPortStatus
            // 
            this.myPortStatus.Text = "Port Status";
            this.myPortStatus.Width = 97;
            // 
            // myUsers
            // 
            this.myUsers.Text = "Users";
            this.myUsers.Width = 45;
            // 
            // myGameMode
            // 
            this.myGameMode.Text = "Game Mode";
            this.myGameMode.Width = 72;
            // 
            // myDifficulty
            // 
            this.myDifficulty.Text = "Difficulty";
            this.myDifficulty.Width = 55;
            // 
            // myLocked
            // 
            this.myLocked.Text = "Locked";
            this.myLocked.Width = 54;
            // 
            // myStarted
            // 
            this.myStarted.Text = "Started";
            this.myStarted.Width = 49;
            // 
            // myPassword
            // 
            this.myPassword.Text = "Password";
            this.myPassword.Width = 69;
            // 
            // apply
            // 
            this.apply.Enabled = false;
            this.apply.Location = new System.Drawing.Point(249, 107);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 31;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // about
            // 
            this.about.Controls.Add(this.tableLayoutPanel3);
            this.about.Location = new System.Drawing.Point(4, 22);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(752, 511);
            this.about.TabIndex = 2;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.sacAboutHeader, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.motd, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.readme, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(746, 505);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // sacAboutHeader
            // 
            this.sacAboutHeader.AutoSize = true;
            this.sacAboutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sacAboutHeader.Location = new System.Drawing.Point(3, 0);
            this.sacAboutHeader.Name = "sacAboutHeader";
            this.sacAboutHeader.Size = new System.Drawing.Size(740, 50);
            this.sacAboutHeader.TabIndex = 0;
            this.sacAboutHeader.Text = "SAC HEADER";
            this.sacAboutHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // motd
            // 
            this.motd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.motd.AutoSize = true;
            this.motd.Location = new System.Drawing.Point(3, 50);
            this.motd.Name = "motd";
            this.motd.Size = new System.Drawing.Size(740, 50);
            this.motd.TabIndex = 1;
            this.motd.Text = "motd";
            this.motd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // readme
            // 
            this.readme.Location = new System.Drawing.Point(3, 103);
            this.readme.Multiline = true;
            this.readme.Name = "readme";
            this.readme.ReadOnly = true;
            this.readme.Size = new System.Drawing.Size(740, 399);
            this.readme.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Sacred Ancaria Connection Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTabs.ResumeLayout(false);
            this.serverList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.hosting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.about.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.TabPage serverList;
        private System.Windows.Forms.TabPage hosting;
        private System.Windows.Forms.TabPage about;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox forceIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox udpPort;
        private IPAddressControlLib.IPAddressControl forcedServerIP;
        private IPAddressControlLib.IPAddressControl autodectedIpAddress;
        private System.Windows.Forms.CheckBox broadcastInLan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox broadcastingPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView activeServers;
        private System.Windows.Forms.ColumnHeader serverName;
        private System.Windows.Forms.ColumnHeader usersCount;
        private System.Windows.Forms.ColumnHeader gameMode;
        private System.Windows.Forms.ColumnHeader difficulty;
        private System.Windows.Forms.ColumnHeader locked;
        private System.Windows.Forms.ColumnHeader started;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ListView myServerList;
        private System.Windows.Forms.ColumnHeader myName;
        private System.Windows.Forms.ColumnHeader myIPPort;
        private System.Windows.Forms.ColumnHeader myUsers;
        private System.Windows.Forms.ColumnHeader myGameMode;
        private System.Windows.Forms.ColumnHeader myDifficulty;
        private System.Windows.Forms.ColumnHeader myLocked;
        private System.Windows.Forms.ColumnHeader myStarted;
        private System.Windows.Forms.ColumnHeader myPassword;
        private System.Windows.Forms.ColumnHeader myPortStatus;
        private System.Windows.Forms.ColumnHeader myNameUsed;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Label sacServerStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label sacAboutHeader;
        private System.Windows.Forms.Label motd;
        private System.Windows.Forms.TextBox readme;
    }
}

