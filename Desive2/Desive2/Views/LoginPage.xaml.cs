using Desive2.Models;
using Desive2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Desive2.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            if (Preferences.Get("idUser", null) == null)
            {
                BindingContext = new LoginPageViewModel(Navigation);

            }
            else
            {
                GoToMain();
            }

       

        }
        public async void GoToMain()
        {
            await Shell.Current.GoToAsync("//main");
        }

    }


}
