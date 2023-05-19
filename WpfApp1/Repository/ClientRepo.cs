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
        public int AddClient(ClientModel client) 
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Clients.Add(client);
                dbContext.SaveChanges();
                return client.Id;
            }
        }
        public bool UpdateClient(ClientModel client) 
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Clients.Update(client);
                dbContext.SaveChanges();
            }
            return true;
        }
        public bool DeleteClient(ClientModel client) 
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Clients.Remove(client);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
    
}
