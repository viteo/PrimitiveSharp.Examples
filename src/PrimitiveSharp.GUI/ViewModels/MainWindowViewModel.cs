using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ReactiveUI;

namespace PrimitiveSharp.GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _greeting = "Hello World!";

        public string Greeting
        {
            get { return _greeting; }
            set
            {
                this.RaiseAndSetIfChanged(ref _greeting, value);
            }
        }

        void ChangeGreeting()
        {            
            Greeting = "GoodBye World!";
        }

    }
}
