using ReactiveUI;
using System.Threading.Tasks;
using System.Reactive;

namespace SMTx.ViewModels
{
    internal class NewVersionViewModel : ViewModelBase
    {

        private string _currentVersion;
        private string _newVersion;
        private string _releaseNotes;
        private bool _isNewVersionAvailable;
        private IReactiveCommand clickDownload { get; }

        public bool IsNewVersionAvailable
        {
            get => _isNewVersionAvailable;
            set => this.RaiseAndSetIfChanged(ref _isNewVersionAvailable, value);
        }

        public string CurrentVersion
        { 
            get => _currentVersion;
            set => this.RaiseAndSetIfChanged(ref _currentVersion, value); 
        }

        public string NewVersion
        {
            get => _newVersion;
            set => this.RaiseAndSetIfChanged(ref _newVersion, value);
        }

        public string ReleaseNotes
        {
            get => _releaseNotes;
            set => this.RaiseAndSetIfChanged(ref _releaseNotes, value);
        }
       
        public NewVersionViewModel(string SMTVersion)
        {
            CurrentVersion = SMTVersion;
            clickDownload = ReactiveCommand.Create(() => { 
                
            });
        }

    }
}
