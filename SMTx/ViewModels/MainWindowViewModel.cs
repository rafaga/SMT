using SMTx.Services;
using SMTx.Models;
using System.Threading.Tasks;
using System.Reactive.Linq;
using ReactiveUI;

namespace SMTx.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        //private GithubAPI _github;
        //private GithubRelease _release;
        public const string SMT_VERSION = "SMT_110";
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
                }
                var result = await ShowNewVersionDialog.Handle(updater);
                return result;
            });
        }


        private async Task AsyncCheckUpdates()
        {


        }

    }
}
