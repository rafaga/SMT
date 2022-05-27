using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SMTx.ViewModels;
using Avalonia.Platform;

namespace SMTx.Views
{
    internal partial class NewVersionWindow : ReactiveWindow<NewVersionViewModel>
    {
        public NewVersionWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            OperatingSystemType oOS = AvaloniaLocator.Current.GetService<IRuntimePlatform>().GetRuntimeInfo().OperatingSystem;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        
    }
}
