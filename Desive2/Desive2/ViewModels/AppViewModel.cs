using Desive2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private bool isAdmin;

        public bool IsAdmin { get => isAdmin; set => SetProperty(ref isAdmin, value); }
        public AppViewModel()
        {
            MessagingCenter.Subscribe<LoginPage>(this, "admin", (sender) =>
            {
                IsAdmin = true;
            });

            MessagingCenter.Subscribe<LoginPage>(this, "user", (sender) =>
            {
                IsAdmin = false;
            });

        }
    }
}
