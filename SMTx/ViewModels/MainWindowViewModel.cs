using SMTx.Services;
using SMTx.Models;
using System.Reactive.Linq;
using ReactiveUI;
using EVEData;
using System;

namespace SMTx.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public const string SMT_VERSION = "SMT_108";
        public Interaction<NewVersionViewModel, NewVersionViewModel?>ShowNewVersionDialog { get; }
        public IReactiveCommand ClickCheckUpdates { get; }
        private EVEData.EveManager _data;

        private string _serverVersion;
        private int _serverPlayers;
        private DateTime? _serverTime;

        public string ServerVersion { 
            get => _serverVersion; 
            set => this.RaiseAndSetIfChanged(ref _serverVersion, value);
        }

        public int ServerPlayers
        {
            get => _serverPlayers;
            set => this.RaiseAndSetIfChanged(ref _serverPlayers, value);
        }

        public DateTime? ServerTime
        {
            get => _serverTime;
            set => this.RaiseAndSetIfChanged(ref _serverTime, value);
        }

        public MainWindowViewModel()
        {                          
            ShowNewVersionDialog = new Interaction<NewVersionViewModel, NewVersionViewModel?>();
            ClickCheckUpdates = ReactiveCommand.CreateFromTask(async() => {
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
            InitEVEManager();
        }

        private void InitEVEManager()
        {
            _data = new EveManager(SMT_VERSION);
            ServerPlayers = _data.ServerInfo.NumPlayers;
            ServerTime = _data.ServerInfo.ServerTime;
            ServerVersion = _data.ServerInfo.ServerVersion;
        }

    }
}
