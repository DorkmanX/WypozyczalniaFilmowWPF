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

        private ViewModelBase _currentChildView;
        private string _caption;

        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get { return _caption;} set { _caption = value; OnPropertyChanged(nameof(Caption)); } }

        public MainViewModel() 
        {
            _userRepository = new UserRepo();
            
            ShowMoviesViewCommand = new DelegateCommand(ExecuteShowMoviesViewCommand);
            ShowClientsViewCommand = new DelegateCommand(ExecuteShowClientsViewCommand);

            ExecuteShowMoviesViewCommand(null);
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
