using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public interface IMovieInterface
    {
        public int AddMovie(MovieModel movie);
        public bool DeleteMovie(MovieModel movie);
        public bool UpdateMovie(MovieModel movie);
        public bool RentMovie(MovieModel movie);
        public bool ReturnMovie(MovieModel movie);
        public List<MovieView> GetMovies();
    }
}
