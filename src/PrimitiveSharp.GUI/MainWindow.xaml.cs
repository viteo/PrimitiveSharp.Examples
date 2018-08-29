using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PrimitiveSharp.GUI
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}