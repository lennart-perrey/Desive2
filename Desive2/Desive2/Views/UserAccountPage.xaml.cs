using Desive2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desive2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAccountPage : ContentPage
    {
        public UserAccountPage()
        {
            InitializeComponent();
            BindingContext = new UserAccountViewModel();
        }
    }
}