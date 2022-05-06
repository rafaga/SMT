using SMTx.Services;
using SMTx.Models;
using System.Reactive.Linq;
using ReactiveUI;
using System;

namespace SMTx.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public const string SMT_VERSION = "SMT_109";
        public Interaction<NewVersionViewModel, NewVersionViewModel?>ShowNewVersionDialog { get; }
        public IReactiveCommand ClickCheckUpdates { get; }

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
        }

    }
}
