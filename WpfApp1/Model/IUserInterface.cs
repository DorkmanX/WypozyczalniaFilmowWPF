using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public interface IUserInterface
    {
        public bool CheckUser(string login,string password);
        public UserModel GetUserDetails(string login);
    }
}
