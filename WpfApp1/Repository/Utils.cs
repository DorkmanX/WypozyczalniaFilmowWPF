using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public static class Utils
    {
        public static D CastToMovieInfo<T,D>(T obj) where T : class where D : class
        {
            if(obj is MovieModel movie) 
            {
                MovieInfo movieInfo = new MovieInfo()
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Director = movie.Director,
                    TimeLapse = movie.TimeLapse
                };
                return movieInfo as D;
            }
            return new MovieInfo() as D;
        }

        public static D CastToMovieView<T,D> (T obj) where T : class where D : class
        {
            if (obj is MovieModel movie)
            {
                MovieView movieView = new MovieView()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Category = movie.Category,
                    IsRented = movie.IsRented == true ? "Tak" : "Nie",
                    ClientId = movie.ClientId
                };
                return movieView as D;
            }
            return new MovieView() as D;
        }
    }
}
