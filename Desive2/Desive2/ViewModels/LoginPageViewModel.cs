using Desive2.Models;
using Desive2.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
        private readonly INavigation Navigation;

        public LoginPageViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            PageTitle = "Login";
            IsChecked = false;
           
        }

        #region Properties

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (SetPropertyValue(ref _email, value))
                {
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (SetPropertyValue(ref _password, value))
                {
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (SetPropertyValue(ref _isChecked, value))
                {
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        private bool _isShowCancel;
        public bool IsShowCancel
        {
            get { return _isShowCancel; }
            set { SetPropertyValue(ref _isShowCancel, value); }
        }

        #endregion


        #region Commands

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new Command(LoginAction, CanLoginAction); }
        }

        private ICommand _cancelLoginCommand;
        public ICommand CancelLoginCommand
        {
            get { return _cancelLoginCommand = _cancelLoginCommand ?? new Command(CancelLoginAction); }
        }

        private ICommand _forgotPasswordCommand;
        public ICommand ForgotPasswordCommand
        {
            get { return _forgotPasswordCommand = _forgotPasswordCommand ?? new Command(ForgotPasswordAction); }
        }

        private ICommand _newAccountCommand;
        public ICommand NewAccountCommand
        {
            get { return _newAccountCommand = _newAccountCommand ?? new Command(NewAccountAction); }
        }

        #endregion


        #region Methods

        bool CanLoginAction()
        {
            //Perform your "Can Login?" logic here...

            if ((string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password)))
                return false;
            else if (!IsChecked)
                return false;
            return true;
        }

        async void LoginAction()
        {
            IsBusy = true;
            int id = Database.CheckUser(this.Email, this.Password);
           if (id != -1)
            {
                Preferences.Set("email", this.Email);
                Preferences.Set("idUser", id.ToString());
                Preferences.Set("password", this.Password);

                Preferences.Get("Email", null);
                 
                await  Shell.Current.GoToAsync("//main");

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Anmeldung fehlgeschlagen!", "Bitte überprüfen sie ihre Anmeldedaten!", "OK");
                IsBusy = false;
                this.Email = "";
                this.Password = "";
            }
            //TODO - perform your login action + navigate to the next page
            //Simulate an API call to show busy/progress indicator            

        }

        void CancelLoginAction()
        {
            //TODO - perform cancellation logic

            IsBusy = false;
            IsShowCancel = false;
        }

        void ForgotPasswordAction()
        {
            //TODO - navigate to your forgotten password page
            //Navigation.PushAsync(XXX);
        }

        async void NewAccountAction()
        {
            await Browser.OpenAsync("http://www.desive2.com");
        }

    

        private Command clickCommand;

        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new Command(Click);
                }

                return clickCommand;
            }
        }

        async void Click()
        {
            await Browser.OpenAsync("http://www.desive2.com/index.php/impressum/");
        }
        #endregion
    }
}