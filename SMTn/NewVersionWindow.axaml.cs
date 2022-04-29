using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SMTn
{
    public partial class NewVersionWindow : Window
    {
        public NewVersionWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class NewVersionViewModel : INotifyPropertyChanged 
    {
        private string _currentVersion = "";
        private string _newVersion = "";
        private string _releaseNotes = "";

        public string CurrentVersion 
        { 
            get { return this._currentVersion; }
            set { 
                this._currentVersion = value;
                this.OnPropertyChanged("CurrentVersion");
            }
        }

        public string NewVersion
        {
            get { return this._newVersion; }
            set { 
                this._newVersion = value;
                this.OnPropertyChanged("NewVersion");
            }
        }

        public string ReleaseNotes
        {
            get { return this._releaseNotes; }
            set { 
                this._releaseNotes = value;
                this.OnPropertyChanged("ReleaseNotes");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
