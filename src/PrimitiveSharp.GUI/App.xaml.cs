using Avalonia;
using Avalonia.Markup.Xaml;

namespace PrimitiveSharp.GUI
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}