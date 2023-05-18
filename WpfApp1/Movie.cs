using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Movie
    {
        public String title { get; set; }
        public String director { get; set; }
        public String description { get; set; }
        public String category { get; set; }
        public int time { get; set; }



        public Movie(string _title, string _director, string _description, string category, int time)
        {
            title = _title;
            director = _director;
            description = _description;
            this.category = category;
            this.time = time;
        }
    }
}
