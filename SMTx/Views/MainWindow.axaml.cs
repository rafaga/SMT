using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using SMTx.ViewModels;
using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia;
using Avalonia.Controls;

namespace SMTx.Views
{
    internal partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.ShowNewVersionDialog.RegisterHandler(asyncShowNewVersionDialog)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
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
