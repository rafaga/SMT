using SMTx.Services;
using SMTx.Models;
using System.Reactive.Linq;
using ReactiveUI;
using EVEData;
using System;
using System.Threading;

namespace SMTx.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public const string SMT_VERSION = "SMT_108";
        public Interaction<NewVersionViewModel, NewVersionViewModel?> ShowNewVersionDialog { get; }
        public IReactiveCommand ClickCheckUpdates { get; }
        //private EVEData.EveManager _data;

        private string? _serverVersion;
        private int _serverPlayers;
        private string? _serverTime;

        // Timers - These timers are used to update data into the Application
        private Timer? tStatus;
        private Timer? tClock;

        public string ServerVersion
        {
            get => _serverVersion;
            set => this.RaiseAndSetIfChanged(ref _serverVersion, value);
        }

        public int ServerPlayers
        {
            get => _serverPlayers;
            set => this.RaiseAndSetIfChanged(ref _serverPlayers, value);
        }

        public string? ServerTime
        {
            get => _serverTime;
            set => this.RaiseAndSetIfChanged(ref _serverTime, value);
        }

        public MainWindowViewModel()
        {
            ShowNewVersionDialog = new Interaction<NewVersionViewModel, NewVersionViewModel?>();
            ClickCheckUpdates = ReactiveCommand.CreateFromTask(async () =>
            {
                var _github = new GithubAPI();
                var _release = new GithubRelease();
                var updater = new NewVersionViewModel(SMT_VERSION);
                _release = _github.GetLastSMTVersion();
                if (_release != null)
                {
                    updater.CurrentVersion = SMT_VERSION;
                    updater.NewVersion = _release.tag_name;
                    updater.ReleaseNotes = _release.body;
                    updater.ReleaseUrl = _release.zipball_url;
                    if (int.Parse(updater.CurrentVersion.Split("_")[1]) < int.Parse(updater.NewVersion.Split("_")[1]))
                    {
                        updater.IsNewVersionAvailable = true;
                    }
                }
                var result = await ShowNewVersionDialog.Handle(updater);
                return result;
            });
            InitDataSync();
        }

        /// <summary>
        /// This methond will create multiple timers to keep updated the intel feed
        /// </summary>
        private void InitDataSync()
        {
            // We will update the ESI Status each halfhour
            tStatus = new Timer(new TimerCallback(StatusCallback));
            tStatus.Change(12, 1800000);

            // We are updating the EVETime each 54 seconds
            tClock = new Timer(new TimerCallback(ClockCallback));
            tClock.Change(35, 54000);
        }

        /// <summary>
        /// This is the callback used  to update the playercount and server version
        /// </summary>
        /// <param name="state">The timer object</param>
        private async void StatusCallback(object state)
        {
            int cont;
            EVEData.ESIData.Status status;
            status = await ESIReader.Instance.getStatus();
            for (cont = 0; cont < 2 && status.players == 0; cont++)
            {
                status = await ESIReader.Instance.getStatus();
            }
            this.ServerPlayers = status.players;
            this.ServerVersion = status.server_version;
        }

        /// <summary>
        /// This is the callback used to update the EVE Time clock
        /// </summary>
        /// <param name="state">The timer object</param>
        private async void ClockCallback(object state)
        {
            this.ServerTime = DateTime.UtcNow.ToShortTimeString();
        }


    }
}