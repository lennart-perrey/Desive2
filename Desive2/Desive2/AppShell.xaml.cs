using Desive2;
using Desive2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Desive2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // Routing.RegisterRoute("registration", typeof(RegistrationModal));
           
            Routing.RegisterRoute(nameof(UserAccountPage), typeof(UserAccountPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

    }
}
