using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            //Title = "Über uns";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://www.desive2.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}