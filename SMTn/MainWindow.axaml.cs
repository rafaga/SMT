using Avalonia.Controls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System;

namespace SMTn
{
    public partial class MainWindow : Window
    {
        public const string SMT_VERSION = "SMT_110";
        public MainWindow()
        {
            InitializeComponent();
            Title = "SMT (Powered by Plastic Support : " + SMT_VERSION + ")";
            CheckGitHubVersion();
        }


        #region NewVersion

        private async Task CheckGitHubVersion()
        {
            HttpClient client = new HttpClient();
            client.Timeout = new System.TimeSpan(0,0,30);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SMT", "1.xx"));
            client.BaseAddress = new Uri("https://api.github.com");
            HttpResponseMessage response = await client.GetAsync("/repos/slazanger/smt/releases/latest");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                GithubRelease releaseInfo = JsonSerializer.Deserialize<GithubRelease>(responseBody);

                if (releaseInfo != null)
                {
                    if (releaseInfo.tag_name != SMT_VERSION)
                    {
                        NewVersionWindow nw = new NewVersionWindow()
                        {
                            DataContext = new NewVersionViewModel()
                        };
                        /*nw.DataContext.CurrentVersion = SMT_VERSION;
                        nw.DataContext.NewVersion = releaseInfo.tag_name;
                        nw.DataContext.ReleaseNotes = releaseInfo.body;*/
                        nw.ShowDialog(this);
                        
                        /*Application.Current.Dispatcher.Invoke((Action)(() =>
                        {
                            NewVersionWindow nw = new NewVersionWindow();
                            nw.ReleaseInfo = releaseInfo.body;
                            nw.CurrentVersion = SMT_VERSION;
                            nw.NewVersion = releaseInfo.tag_name;
                            nw.ReleaseURL = releaseInfo.html_url.ToString();
                            nw.Owner = this;
                            nw.ShowDialog();
                        }), DispatcherPriority.ApplicationIdle);*/
                    }
                }
            }  
        }


        #endregion NewVersion
    }
}
