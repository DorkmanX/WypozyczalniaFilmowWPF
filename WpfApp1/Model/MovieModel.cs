using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int TimeLapse { get; set; }
        public string Category { get; set; }
        [Required]
        public bool IsRented { get; set; }
        public int? ClientId { get; set; }
        public virtual ClientModel Client { get; set; }
    }
}
