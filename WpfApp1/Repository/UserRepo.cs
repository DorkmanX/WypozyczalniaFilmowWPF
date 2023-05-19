using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1.Repository
{
    public class UserRepo : SQLiteContext, IUserInterface
    {
        public bool CheckUser(string login,string password) 
        {

            bool valid = false;
            using(var context = GetConnection()) 
            {
                valid = context.Users.Where(x => x.Login == login && x.Password == password).Any();
            }
            return valid;
        }

        public UserModel GetUserDetails(string login)
        {
            using (var context = GetConnection())
            {
                var user = context.Users.Where(x => x.Login == login).FirstOrDefault();
                return user;
            }
        }
    }
}
