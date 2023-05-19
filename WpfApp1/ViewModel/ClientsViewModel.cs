using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;

namespace WpfApp1.ViewModel
{
    public class ClientsViewModel : ViewModelBase
    {
        private IClientInterface _clientContext;
        private ObservableCollection<ClientModel> _clients;
        private ClientModel _selectedClient;

        private int _id;
        private string _name;
        private string _surname;
        private string _adress;
        private string _phoneNumber;
        public ICommand AddClientViewCommand { get; }
        public ICommand RemoveClientViewCommand { get; }
        public ICommand EditClientViewCommand { get; }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(nameof(Surname)); } }
        public string Adress { get { return _adress; } set { _adress = value; OnPropertyChanged(nameof(Adress)); } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public ClientModel SelectedClient { get { return _selectedClient; } set { _selectedClient = value; OnPropertyChanged(nameof(SelectedClient)); } }
        public ObservableCollection<ClientModel> Clients { get { return _clients; } set { _clients = value; OnPropertyChanged(nameof(Clients)); } }
        public ClientsViewModel()
        {
            _clientContext = new ClientRepo();
            _clients = new ObservableCollection<ClientModel>();

            AddClientViewCommand = new DelegateCommand(ExecuteAddClient);
            RemoveClientViewCommand = new DelegateCommand(ExecuteRemoveClient);
            EditClientViewCommand = new DelegateCommand(ExecuteEditClient);
            //_clients.Clear();
        }

        private void ExecuteEditClient(object obj)
        {
            ClientModel clientEditer = SelectedClient;
            Console.Write(clientEditer.Name);
        }

        private void ExecuteRemoveClient(object obj)
        {
            _clients.Remove(SelectedClient);
        }

        private void ExecuteAddClient(object obj)
        {
            ClientModel newClient = new ClientModel()
            {
                Id = 1,
                Name = "MARIUSZ",
                Surname = "Lewandowski",
                Adress = "Dziwna 69",
                PhoneNumber = "12345",
            };
            ClientModel newlient = new ClientModel()
            {
                Id = 2,
                Name = "MAasdasdSZ",
                Surname = "Leasdasdndowski",
                Adress = "Dziwasdas69",
                PhoneNumber = "asd345",
            };
            _clients.Add(newlient);
            _clients.Add(newClient);
        }
    }
}
