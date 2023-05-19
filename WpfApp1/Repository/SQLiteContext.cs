using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public class SQLiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\user\\Downloads\\WpfApp1\\WpfApp1\\WpfApp1\\bin\\Debug\\net6.0-windows\\DataFile.db");
        }

        protected SQLiteContext GetConnection()
        {
            return this;
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ClientModel> Clients { get; set; }


    }
}
