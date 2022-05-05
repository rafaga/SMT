using SMTx.Services;
using SMTx.Models;
using ReactiveUI;
using System.Reactive;

namespace SMTx.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private GithubAPI _github;
        private GithubRelease _release;
        public const string SMT_VERSION = "SMT_110";

        public NewVersionViewModel updater { get; private set; }



        public MainWindowViewModel()
        {
            _github = new GithubAPI();
            _release = new GithubRelease();

            CheckForUpdates = ReactiveCommand.Create(checkupdates);
        }

        private Action checkupdates(Unit a)
        {
            updater = new NewVersionViewModel(SMT_VERSION);
            _release = _github.GetLastSMTVersion();
            if (_release != null)
            {
                updater.CurrentVersion = SMT_VERSION;
                updater.NewVersion = _release.tag_name;
                updater.ReleaseNotes = _release.body;
            }
            return (a);
;        }

        public ReactiveCommand CheckForUpdates<Unit, Unit> { get; }


    }
}
