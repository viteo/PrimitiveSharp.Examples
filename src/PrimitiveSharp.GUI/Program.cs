using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using PrimitiveSharp.GUI.ViewModels;
using PrimitiveSharp.GUI.Views;

namespace PrimitiveSharp.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
