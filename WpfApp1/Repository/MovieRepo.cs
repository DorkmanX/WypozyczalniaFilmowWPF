using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public class MovieRepo : DatabaseContext, IMovieInterface
    {
        public int AddMovie(MovieModel movie)
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Movies.Add(movie);
                dbContext.SaveChanges();
                return movie.Id;
            }
        }

        public bool DeleteMovie(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public bool RentMovie(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public bool ReturnMovie(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(MovieModel movie)
        {
            throw new NotImplementedException();
        }
        public List<MovieView> GetMovies() 
        {
            List<MovieModel> movies;
            List<MovieView> moviesView = new List<MovieView>();
            using(var dbContext = GetConnection()) 
            {
                movies = dbContext.Movies.ToList();
            }
            foreach(var movie in movies) 
            {
                moviesView.Add(Utils.CastToMovieView<MovieModel, MovieView>(movie));
            }
            return moviesView;
        }
    }
}
