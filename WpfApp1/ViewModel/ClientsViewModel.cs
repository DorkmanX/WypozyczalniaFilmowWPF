using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Repository;

namespace WpfApp1.ViewModel
{
    public class ClientsViewModel : ViewModelBase
    {
        private IClientInterface _clientContext;
        private ObservableCollection<ClientModel> _clients;
        
        private int _id;
        private string _name;
        private string _surname;
        private string _adress;
        private string _phoneNumber;

        public int Id { get {return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(nameof(Surname)); } }
        public string Adress { get { return _adress; } set { _adress = value; OnPropertyChanged(nameof(Adress)); } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }

        public ObservableCollection<ClientModel> Clients { get { return _clients; } set { _clients = value; OnPropertyChanged(nameof(Clients)); } }
        public ClientsViewModel()
        {
            _clientContext = new ClientRepo();
        }
    }
}
