using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using SMTx.ViewModels;
using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;

namespace SMTx.Views
{
    internal partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {

        private NativeMenu nMenu;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.ShowNewVersionDialog.RegisterHandler(asyncShowNewVersionDialog)));


            OperatingSystemType oOS = AvaloniaLocator.Current.GetService<IRuntimePlatform>().GetRuntimeInfo().OperatingSystem;
            if (oOS == OperatingSystemType.OSX || oOS == OperatingSystemType.Linux)
            {
                //this.FindControl<Menu>("SystemMenu").IsVisible = false;
                nMenu = NativeMenu.GetMenu(this);
                NativeMenu.SetMenu(App.Current,nMenu);
            }
            
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
