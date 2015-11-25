using SteamKit2;
using SteamKit2.Unified.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace configdownloader
{
    public partial class main : Form
    {
        bool isRunning = true;

        bool isReady = false;

        bool requestOnGoing = false;

        uint appidCurrent = 0;

        uint pageCurrent = 1;
        uint totalPages = 0;

        /// <summary>
        /// Items to requests per query, 100 is maximum allowed by Steam
        /// </summary>
        uint itemsPerPage = 100;

        List<Game> Games = new List<Game>();

        BindingList<ConfigItem> items = new BindingList<ConfigItem>();

        #region "Steam Connection"
        Thread steamThread;

        SteamClient steamClient;
        CallbackManager manager;
        SteamUser steamUser;

        void steam_connection()
        {
            steamClient = new SteamClient();

            manager = new CallbackManager(steamClient);

            steamUser = steamClient.GetHandler<SteamUser>();

            manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
            manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);
            manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnect);
            manager.Subscribe<SteamUnifiedMessages.ServiceMethodResponse>(OnServiceMethod);

            steamClient.Connect();

            while (isRunning)
            {
                manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
        }

        void OnConnected(SteamClient.ConnectedCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                MessageBox.Show("Failed to connect to steam");
                Application.Exit();    
            }

            steamUser.LogOnAnonymous();
        }

        void OnDisconnect(SteamClient.DisconnectedCallback callback)
        {
            if (!callback.UserInitiated)
                steamClient.Connect();
            else
                isRunning = false;
        }

        void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                MessageBox.Show("Failed to connect to steam");
                Application.Exit();
            }

            isReady = true;

            Invoke(new MethodInvoker(delegate
            {
                currentStatus.Text = string.Format("Connected to Steam!");
            }));
        }

        void OnServiceMethod(SteamUnifiedMessages.ServiceMethodResponse callback)
        {
            if (callback.RpcName == "QueryFiles")
                HandleQueryFiles(callback.GetDeserializedResponse<CPublishedFile_QueryFiles_Response>(), callback.JobID);
        }

        void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
        }
        #endregion

        void startNewRequest()
        {
            if (!isReady)
            {
                MessageBox.Show("Waiting for connection!");
                return;
            }

            if (requestOnGoing)
            {
                MessageBox.Show("Waiting for results");
                return;
            }

            if (uint.TryParse(inputAppID.Text.Trim(), out appidCurrent))
            {

            }
            else
            {
                var game = Games.Where(x => x.Name == inputAppID.Text).FirstOrDefault();

                if (game != null)
                    appidCurrent = game.AppID;
                else
                {
                    MessageBox.Show("Invalid AppID");
                    return;
                }
            }

            pageCurrent = 1;
            totalPages = 0;

            requestOnGoing = true;

            items.Clear();

            sendRequest();
        }

        /// <summary>
        /// Sends request for controller configs
        /// </summary>
        void sendRequest()
        {
            var service = steamClient.GetHandler<SteamUnifiedMessages>().CreateService<IPublishedFile>();

            var query = new CPublishedFile_QueryFiles_Request
            {
                return_vote_data = true,
                return_children = true,
                return_for_sale_data = true,
                return_kv_tags = true,
                return_metadata = true,
                return_tags = true,
                return_previews = true,
                appid = appidCurrent,
                page = pageCurrent,
                numperpage = itemsPerPage,
                query_type = 11,
                filetype = (uint)EWorkshopFileType.GameManagedItem,
            };

            service.SendMessage(x => x.QueryFiles(query));

            Invoke(new MethodInvoker(delegate
            {
                if (totalPages > 0)
                    currentStatus.Text = string.Format("Requesting page {0} of {1}", pageCurrent, totalPages);
                else
                    currentStatus.Text = string.Format("Requesting page {0}", pageCurrent, totalPages);
            }));
        }

        void HandleQueryFiles(CPublishedFile_QueryFiles_Response response, JobID jobid)
        {
            foreach (var item in response.publishedfiledetails)
            {
                var info = new ConfigItem
                {
                    App = item.app_name,
                    Name = item.title,
                    FileName = item.filename.Split('/').Last(),
                    URL = item.file_url,
                    RatesUp = item.vote_data != null ? item.vote_data.votes_up : 0,
                    RatesDown = item.vote_data != null ? item.vote_data.votes_down : 0,
                    Details = item
                };

                Invoke(new MethodInvoker(delegate
                {
                    items.Add(info);
                }));
            }

            totalPages = (uint) Math.Ceiling(response.total / (double)itemsPerPage);

            if (totalPages > pageCurrent)
            {
                pageCurrent++;

                sendRequest();
            }
            else
            {
                requestOnGoing = false;

                Invoke(new MethodInvoker(delegate
                {
                    currentStatus.Text = string.Format("Complete!");
                }));
            }
        }

        public main()
        {
            InitializeComponent();

            steamThread = new Thread(steam_connection);
            steamThread.Start();

            if (File.Exists("games.txt"))
            {
                foreach (var line in File.ReadAllLines("games.txt"))
                {
                    var parts = line.Split(new char[] { '\t' }, 2);

                    Games.Add(new Game
                    {
                        AppID = uint.Parse(parts[0]),
                        Name = parts[1]
                    });
                }
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            configItemBindingSource.DataSource = items;

            var source = new AutoCompleteStringCollection();
            source.AddRange(Games.Select(x => x.Name).ToArray());

            inputAppID.AutoCompleteCustomSource = source;
            inputAppID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            inputAppID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void get_Click(object sender, EventArgs e)
        {
            startNewRequest();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                ConfigItem item = datagridConfigs.Rows[e.RowIndex].DataBoundItem as ConfigItem;

                if (item != null)
                {
                    saveFileDialog1.FileName = item.FileName;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (var wc = new WebClient())
                        {
                            wc.DownloadFile(new Uri(item.URL), saveFileDialog1.FileName);
                            MessageBox.Show("Download Done!");
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            steamClient.Disconnect();
        }

        private void inputAppID_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputAppID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startNewRequest();
            }
        }
    }
}
