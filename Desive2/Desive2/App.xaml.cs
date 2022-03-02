using Desive2.Services;
using Desive2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desive2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
