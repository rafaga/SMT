using ReactiveUI;

namespace SMTx.ViewModels
{
    internal class NewVersionViewModel : ViewModelBase
    {

        private string _currentVersion;
        private string _newVersion;
        private string _releaseNotes;

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
        
        public IReactiveCommand ClickDownload { get; private set; }

        public NewVersionViewModel(string SMTVersion)
        {
            CurrentVersion = SMTVersion;
            ClickDownload = ReactiveCommand.Create(() => { });
        }
    }
}
