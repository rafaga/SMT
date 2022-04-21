using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SMT
{
    public partial class App : Window
    {
        public App()
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
