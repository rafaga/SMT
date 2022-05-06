using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SMTx.ViewModels;

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
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        
    }
}
