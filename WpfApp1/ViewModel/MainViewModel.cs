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
        }

        private DelegateCommand showHomeViewCommand;
        public ICommand ShowHomeViewCommand => showHomeViewCommand ??= new DelegateCommand(ShowHomeView);

        private void ShowHomeView(object commandParameter)
        {
        }

        private DelegateCommand showCustomerViewCommand;
        public ICommand ShowCustomerViewCommand => showCustomerViewCommand ??= new DelegateCommand(ShowCustomerView);

        private void ShowCustomerView(object commandParameter)
        {
        }
    }
}
