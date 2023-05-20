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

        public MovieModel GetMovie(int id) 
        {
            using (var dbContext = GetConnection())
            {
                var movie = dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
                return movie;
            }
        }
        public bool DeleteMovie(int id)
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Movies.Remove(new MovieModel() { Id = id });
                dbContext.SaveChanges();
            }
            return true;
        }

        public bool RentMovie(int id, int clientId)
        {
            using (var dbContext = GetConnection())
            {
                var movie = dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
                if (movie.IsRented == false)
                {
                    movie.IsRented = true;
                    movie.ClientId = clientId;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public bool ReturnMovie(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(MovieModel movie)
        {
            using (var dbContext = GetConnection())
            {
                dbContext.Movies.Update(movie);
                dbContext.SaveChanges();
            }
            return true;
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
