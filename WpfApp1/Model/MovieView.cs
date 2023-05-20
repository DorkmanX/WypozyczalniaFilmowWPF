using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class MovieView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string IsRented { get; set; }
        public int? ClientId { get; set; }
    }
}
