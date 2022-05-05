using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using SMTx.ViewModels;
using ReactiveUI;

namespace SMTx.Views
{
    internal partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {

        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.ShowNewVersionDialog.RegisterHandler(asyncShowNewVersionDialog)));
        }

        private async Task asyncShowNewVersionDialog(InteractionContext<NewVersionViewModel, NewVersionViewModel?> interaction) 
        {
            var wdwNewVersion = new NewVersionWindow();
            wdwNewVersion.DataContext = interaction.Input;

            var result = await wdwNewVersion.ShowDialog<NewVersionViewModel>(this);
            interaction.SetOutput(result);
        }

    }
}
