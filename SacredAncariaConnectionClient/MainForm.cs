using SacredAncariaConnectionClient.Controller;
using SacredAncariaConnectionClient.Models;
using SacredAncariaConnectionClient.Network;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SacredAncariaConnectionClient
{
    public partial class MainForm : Form
    {
        private readonly Client _client;

        internal Context Context { get; }

        internal MainForm()
        {
            InitializeComponent();
            Context = new Context();
            _client = new Client(Context);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var firstTime = _client.ReadConfiguration();
            if (firstTime)
            {
                MessageBox.Show("Welcome to Sacred Ancaria Connection Client. Enjoy your Sacred Online!\n" +
                                              "If you plan to host a game, please be sure to read the help!");
            }
            if (Context.ServerPort == Context.ClientPort)
            {
                MessageBox.Show("You should not use the same port for server listening and client broadcasting. Please change them. Quitting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Environment.Exit(0);
            }
            _client.Init();
            forcedServerIP.Text = Utils.ConvertIP(Context.ForceIPAddress);
            forceIP.Checked = Context.ForceIP;
            udpPort.Text = Context.ServerPort.ToString();
            broadcastingPort.Text = Context.ClientPort.ToString();
            broadcastInLan.Checked = Context.BroadcastInLan;
            apply.Enabled = false;
            Context.ServerPosted += OnServerPosted;
            Context.ServerReceived += OnServerReceived;
            sacAboutHeader.Text = $"SACRED ANCARIA CONNECTION - VERSION {Program.Version}";
            readme.Text = ReadReadme();
        }

        private string ReadReadme()
        {
            if (!File.Exists("readme.txt"))
            {
                return "Missing readme.txt";
            }

            using (var readme = new StreamReader("readme.txt"))
            {
                return readme.ReadToEnd();
            }
        }

        private void udpPort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(((TextBox)sender).Text, out _))
            {
                e.Cancel = true;
            }
        }

        private void udpPort_Validated(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _client.Close();
        }

        private void forcedServerIP_Validated(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void forceIP_CheckedChanged(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void broadcastInLan_CheckedChanged(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void broadcastingPort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(((TextBox)sender).Text, out _))
            {
                e.Cancel = true;
            }
        }

        private void broadcastingPort_Validated(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void OnServerReceived(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(OnServerReceived), sender, e);
                return;
            }
            UpdateServerList();
            autodectedIpAddress.IPAddress = new IPAddress(Context.MyIp);
            var status = GetSACServerStatus();
            sacServerStatus.Text = status.message;
            sacServerStatus.ForeColor = status.status ? System.Drawing.Color.Black : System.Drawing.Color.DarkRed;
            motd.Text = Context.Motd;
            mainTabs.Enabled = Context.Connected;
        }

        private (string message, bool status) GetSACServerStatus()
        {
            if (Context.ToUpdate)
            {
                return (Context.UpdateMessage, false);
            }

            if (!Context.Connected)
            {
                return ("Not connected or Sacred Ancaria Connection Server is down", false);
            }

            return ("Connected to Sacred Ancaria Connection server", true);
        }

        private void UpdateServerList()
        {
            activeServers.Items.Clear();
            List<Server> serversCopy;
            lock (Context.Servers)
            {
                serversCopy = Context.Servers.ToList();
            }
            foreach (var server in serversCopy)
            {
                string[] serverItem = new string[8];

                serverItem[0] = server.Name;
                serverItem[1] = server.GetUsers();
                serverItem[2] = server.GetGamemode();
                serverItem[3] = server.GetDifficulty();
                serverItem[4] = server.Locked ? "X" : "";
                serverItem[5] = server.Started ? "X" : "";
                serverItem[6] = server.Pass ? "X" : "";
                activeServers.Items.Add(new ListViewItem(serverItem));
            }
        }

        private void OnServerPosted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(OnServerPosted), sender, e);
                return;
            }
            UpdateMyServersList();
        }

        private void UpdateMyServersList()
        {
            myServerList.Items.Clear();
            List<(MyServerStatus serverStatus, Server server)> myServerCopy;
            myServerCopy = Context.MyServers.Values.ToList();
            foreach (var (serverStatus, server) in myServerCopy)
            {
                string[] serverItem = new string[11];

                var nameAlreadyUsed = "";
                var portStatus = "";
                var notInList = false;

                if (serverStatus != null)
                {
                    nameAlreadyUsed = serverStatus.NameAlreadyUsed ? "X" : "";
                    portStatus = serverStatus.GetPortStatus();
                    if (serverStatus.PortState != PortState.Reachable || serverStatus.NameAlreadyUsed)
                    {
                        notInList = true;
                    }
                }

                serverItem[0] = server.Name;
                serverItem[1] = server.GetIPPort();
                serverItem[2] = nameAlreadyUsed;
                serverItem[3] = portStatus;
                serverItem[4] = server.GetUsers();
                serverItem[5] = server.GetGamemode();
                serverItem[6] = server.GetDifficulty();
                serverItem[7] = server.Locked ? "X" : "";
                serverItem[8] = server.Started ? "X" : "";
                serverItem[9] = server.Pass ? "X" : "";
                var element = new ListViewItem(serverItem);
                if (notInList)
                {
                    element.ForeColor = System.Drawing.Color.DarkRed;
                }

                myServerList.Items.Add(element);
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            apply.Enabled = false;
            var serverPortGUI = int.Parse(udpPort.Text);
            var clientPortGUI = int.Parse(broadcastingPort.Text);
            if (serverPortGUI != Context.ServerPort || clientPortGUI != Context.ClientPort)
            {
                MessageBox.Show("To use this new settings, please restart this software", "Sacred Ancaria Connection");
            }
            Context.ServerPort = serverPortGUI;
            Context.ClientPort = clientPortGUI;
            _client.SetForceIP(forceIP.Checked);
            _client.SetBroadcastInLAN(broadcastInLan.Checked);
            _client.SetForcedIP(forcedServerIP.GetAddressBytes());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Context.ServerPosted -= OnServerPosted;
            Context.ServerReceived -= OnServerReceived;
        }
    }
}
