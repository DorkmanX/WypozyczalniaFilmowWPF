using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public class ClientRepo : DatabaseContext, IClientInterface
    {
        public List<ClientModel> GetAllClients()
        {
            using(var dbContext = GetConnection())
            {
                var clientsList = dbContext.Clients.ToList();
                return clientsList;
            }
        }
    }
}
