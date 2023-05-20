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
        public MovieModel GetMovie(int id);
        public bool DeleteMovie(int id);
        public bool UpdateMovie(MovieModel movie);
        public bool RentMovie(int id,int clientId);
        public bool ReturnMovie(MovieModel movie);
        public List<MovieView> GetMovies();
    }
}
