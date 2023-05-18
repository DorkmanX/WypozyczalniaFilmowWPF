using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Client
    {
        public String name;
        public String surname;
        public String email;
        public String address;
        public List<Movie> wypozyczone;


        public Client(string name, string surname, string email, string address)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.address = address;

            wypozyczone = new List<Movie>();
        }

        public Client() { }

        public void Wypozycz(Movie movie)
        {
            wypozyczone.Add(movie);
        }

        public void Zwroc(Movie movie)
        {
            if (wypozyczone.Contains(movie))
            {
                wypozyczone.Remove(movie);
            }
            else
            {
                
            }
        }
    }
}
