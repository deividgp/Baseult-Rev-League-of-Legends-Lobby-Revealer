using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GetSummonerNames.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetSummonerNames
{
    public partial class Form1 : Form
    {
        private const string Mobalytics = "https://app.mobalytics.gg/lol/profile/";
        private const int WmNclbuttondown = 0xA1;
        private const int HtCaption = 0x2;

        private readonly List<LinkLabel> LinkLabels;
        private List<Player> Players = new List<Player>();
        private Tuple<int, string> Riot;
        private Tuple<int, string> Client;
        private string UggMultisearch;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            LinkLabels = new List<LinkLabel>() { linkLabel1, linkLabel2, linkLabel3, linkLabel4, linkLabel5 };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Hey, there might be an update for my program." +
                "\r\n\r\nIf there is, you can download it from Unknowncheats or my Discord. " +
                "To check out for a possible update and get redirected to UnknownCheats, press Yes." +
                "\r\n\r\n(If you obtained this program from a source other than UnknownCheats or my Discord server, it was not uploaded by me.)",
                "Baseult-Rev Information!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://www.unknowncheats.me/forum/league-of-legends/523020-ranked-12-22-reveal-teammates-lobby.html");
            }

            Text = string.Empty;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Players.Any()) return;

            Process.Start(Players[LinkLabels.IndexOf((LinkLabel)sender)].MobalyticsLink);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Connecting to LCU...";
            GetLcu();
            label1.Text = "Searching for Players...";
            // Found Request in various Logs C:\Riot Games\League of Legends\Logs\LeagueClient
            GetData(MakeRequest("GET", "/chat/v5/participants/champ-select", false));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Opening U.GG...";
            Process.Start(UggMultisearch);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("You might get a Dodge Penalty!\r\nYou also lose LP if you dodge in Ranked.\r\nDo you still want to dodge?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                button2.Enabled = false;
                label1.Text = "Dodging Lobby...";
                GetLcu();
                // Updated Dodge Request
                // Original Credits to "mfro - LeagueClient": https://github.com/mfro/LeagueClient/blob/95c403bd582713c420090dec4f63dae284ff6598/RiotClient/RiotServices.cs#L1092
                // Updated with "KebsCS KBotExt": https://github.com/KebsCS/KBotExt/blob/94d13918558799e7704bd9fa50505362cdc7d47f/KBotExt/GameTab.h#L313
                MakeRequest("POST", "/lol-login/v1/session/invoke?destination=lcdsServiceProxy&method=call&args=[\"\",\"teambuilder-draft\",\"quitV2\",\"\"]", true);
                label1.Text = "Dodged Lobby...";

                Resetlabel();
                BackgroundImage = Resources.off;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string Cmd(string gamename)
        {
            string commandline = "";
            var mngmtClass = new ManagementClass("Win32_Process");
            foreach (ManagementObject o in mngmtClass.GetInstances().Cast<ManagementObject>())
            {
                if (o["Name"].Equals(gamename))
                {
                    commandline = "[" + o["CommandLine"] + "]";
                    break;
                }
            }

            return commandline;
        }

        private string GetString(string text, string from, string to)
        {
            int pFrom = text.IndexOf(from, StringComparison.Ordinal) + from.Length;
            int pTo = text.LastIndexOf(to, StringComparison.Ordinal);

            return text.Substring(pFrom, pTo - pFrom);
        }

        private void GetLcu()
        {
            string commandline = Cmd("LeagueClientUx.exe");
            // Riot port and token
            Riot = Tuple.Create(Convert.ToInt32(GetString(commandline, "--riotclient-app-port=", "\" \"--no-rads")),
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + GetString(commandline, "--riotclient-auth-token=", "\" \"--riotclient"))));
            // Client port and token
            Client = Tuple.Create(Convert.ToInt32(GetString(commandline, "--app-port=", "\" \"--install")),
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + GetString(commandline, "--remoting-auth-token=", "\" \"--respawn-command=LeagueClient.exe"))));
        }

        private void GetData(string req)
        {
            Players.Clear();

            string uggPlayers = string.Empty;
            string region = (string)JObject.Parse(MakeRequest("GET", "/riotclient/get_region_locale", true))["region"];

            JArray array = (JArray)JObject.Parse(req)["participants"];
            Players = array.ToObject<List<Player>>();

            foreach (Player player in Players)
            {
                player.MobalyticsLink = Mobalytics + region + "/" + player.Name + "/overview";
                uggPlayers += player.Name + ", ";
            }

            if (!Players.Any())
            {
                label1.Text = "No Players found...";
                BackgroundImage = Resources.off;
                button2.Enabled = false;
                Resetlabel();
                return;
            }
            
            UggMultisearch = "https://u.gg/multisearch?summoners=" + uggPlayers + "&region=" + region.ToLower() + "1";

            label1.Text = "Found Players in Lobby...";
            BackgroundImage = Resources.on;
            button2.Enabled = true;

            for (int i = 0; i < Players.Count; i++)
            {
                LinkLabels[i].Text = Players[i].Name;
                LinkLabels[i].Enabled = true;
            }
        }

        private string MakeRequest(string type, string url, bool isClient)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate
                {
                    const bool validationResult = true;
                    return validationResult;
                };

                int port;
                string token;

                if(isClient)
                {
                    port = Client.Item1;
                    token = Client.Item2;
                }
                else
                {
                    port = Riot.Item1;
                    token = Riot.Item2;
                }

                var request = (HttpWebRequest)WebRequest.Create("https://127.0.0.1:" + port + url);
                request.PreAuthenticate = true;
                request.ContentType = "application/json";
                request.Method = type;
                request.Headers.Add("Authorization", "Basic " + token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show("Request failed - No Connection...", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void Resetlabel()
        {
            for (int i = 0; i < LinkLabels.Count; i++)
            {
                LinkLabels[i].Text = "PLAYER " + (i+1);
                LinkLabels[i].Enabled = false;
            }
        }

        public class Player
        {
            public string Name { get; set; }
            public string MobalyticsLink { get; set; }
        }
    }
}
