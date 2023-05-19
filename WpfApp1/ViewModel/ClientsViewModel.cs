using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.View;

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
        private bool _isViewVisible;

        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(nameof(Surname)); } }
        public string Adress { get { return _adress; } set { _adress = value; OnPropertyChanged(nameof(Adress)); } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }

        public ICommand AddClientViewCommand { get; }
        public ICommand RemoveClientViewCommand { get; }
        public ICommand EditClientViewCommand { get; }
        public ICommand InsertClient { get; set; }
        public ICommand UpdateClient { get; set; }

        public ClientModel SelectedClient { get { return _selectedClient; } set { _selectedClient = value; OnPropertyChanged(nameof(SelectedClient)); } }
        public ObservableCollection<ClientModel> Clients { get { return _clients; } set { _clients = value; OnPropertyChanged(nameof(Clients)); } }
        public ClientsViewModel()
        {
            _clientContext = new ClientRepo();
            _clients = new ObservableCollection<ClientModel>();

            AddClientViewCommand = new DelegateCommand(ExecuteAddClient);
            RemoveClientViewCommand = new DelegateCommand(ExecuteRemoveClient);
            EditClientViewCommand = new DelegateCommand(ExecuteEditClient);
            InsertClient = new DelegateCommand(ExecuteInsertClient, CanExecuteInsertClient);
            UpdateClient = new DelegateCommand(ExecuteUpdateClient, CanExecuteUpdateClient);

            _clients.Clear();
            var databaseClients = _clientContext.GetAllClients();
            databaseClients.ForEach(client => _clients.Add(client));
        }

        private bool CanExecuteUpdateClient(object obj)
        {
            if (string.IsNullOrEmpty(SelectedClient?.Name ?? string.Empty) || string.IsNullOrEmpty(SelectedClient?.Surname ?? string.Empty))
                return false;
            return true;
        }

        private void ExecuteUpdateClient(object obj)
        {
            bool updated = _clientContext.UpdateClient(SelectedClient);
            if(updated) 
            {
                foreach(var client in _clients) 
                {
                    if(client.Id == SelectedClient.Id)
                    {
                        client.Name = SelectedClient.Name;
                        client.Surname = Surname;
                        client.Adress = Adress;
                        client.Surname = Surname;
                    }
                }
            }
            IsViewVisible= false;
        }

        private void ExecuteEditClient(object obj)
        {
            EditView newWindow = new EditView();
            newWindow.DataContext = this;
            newWindow.Show();
        }

        private void ExecuteRemoveClient(object obj)
        {
            _clientContext.DeleteClient(SelectedClient);
            _clients.Remove(SelectedClient);
        }

        private void ExecuteAddClient(object obj)
        {
            AddClientView newWindow = new AddClientView();
            newWindow.DataContext = this;
            newWindow.Show();
        }
        private bool CanExecuteInsertClient(object obj)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname))
                return false;
            return true;
        }

        private void ExecuteInsertClient(object obj)
        {
            ClientModel newClient = new ClientModel()
            {
                Name = Name,
                Surname = Surname,
                PhoneNumber= PhoneNumber,
                Adress=Adress,
            };
            newClient.Id = _clientContext.AddClient(newClient);
            _clients.Add(newClient);
            IsViewVisible = false;
        }
    }
}
