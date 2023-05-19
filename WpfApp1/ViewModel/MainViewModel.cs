using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.ViewModel;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UserRepo _userRepository;
        private UserModel _userModel;

        private ViewModelBase _currentChildView;
        private string _caption;

        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get { return _caption;} set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public UserModel UserModel { get { return _userModel; } set { _userModel = value; OnPropertyChanged(nameof(UserModel)); } }

        public MainViewModel() 
        {
            _userRepository = new UserRepo();
            string login = Thread.CurrentPrincipal?.Identity?.Name ?? "Empty";
            if (login != null)
            {
                _userModel = _userRepository.GetUserDetails(login);
                _userModel.Password = string.Empty;
            }
            ShowMoviesViewCommand = new DelegateCommand(ExecuteShowMoviesViewCommand);
            ShowClientsViewCommand = new DelegateCommand(ExecuteShowClientsViewCommand);

            ExecuteShowClientsViewCommand(null);
        }

        private void ExecuteShowClientsViewCommand(object obj)
        {
            CurrentChildView = new ClientsViewModel();
            Caption = "Lista klientów";
        }

        private void ExecuteShowMoviesViewCommand(object obj)
        {
            CurrentChildView = new MoviesViewModel();
            Caption = "Lista filmów";
        }

        public ICommand ShowMoviesViewCommand { get; }
        public ICommand ShowClientsViewCommand { get;}
    }
}
