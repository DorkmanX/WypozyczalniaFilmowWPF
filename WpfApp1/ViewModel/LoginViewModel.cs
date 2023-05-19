using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;

namespace WpfApp1.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _login;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserInterface _userContext;

        public string Login { get => _login; set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RegisterCommand = new DelegateCommand( e => ExecuteRegisterCommand("",""));
            _userContext = new UserRepo();
        }

        private void ExecuteRegisterCommand(string login, string password)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool canExecute = false;
            if(!string.IsNullOrEmpty(Login) && Password != null && Password.Length >= 3)
                canExecute= true;

            return canExecute;
        }

        private void ExecuteLoginCommand(object obj)
        {
            bool valid = _userContext.CheckUser(Login, new System.Net.NetworkCredential(string.Empty, Password).Password);
            if(valid) 
            {
                try
                {
                    string[] roles = {"administrator"};
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity($"{Login}"),roles);
                }
                catch (SecurityException secureException)
                {
                    Console.WriteLine("{0}: Permission to set Principal " +
                        "is denied.", secureException.GetType().Name);
                }
                IsViewVisible = false;
            }
            else 
            {
                string messageBoxText = "Twoj login lub hasło są niepoprawne";
                string caption = "Błąd logowania";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
