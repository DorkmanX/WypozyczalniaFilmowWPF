using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;

namespace WpfApp1.ViewModel
{
    public class MoviesViewModel : ViewModelBase
    {
        private IMovieInterface _moviesContext;
        private ObservableCollection<MovieView> _movies;
        private MovieModel _selectedMovie;
        private bool _isViewVisible;

        private string _title;
        private string _description;

        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public ICommand AddMovieViewCommand { get; }
        public ICommand EditMovieViewCommand { get; }
        public ICommand RemoveMovieViewCommand { get; }
        public ICommand RentMovieViewCommand { get; set; }
        public ICommand ReturnMovieViewCommand { get; set; }
        public ICommand InfoMovieViewCommand { get; set; }
        public MovieModel SelectedMovie { get { return _selectedMovie; } set { _selectedMovie = value; OnPropertyChanged(nameof(SelectedMovie)); } }
        public ObservableCollection<MovieView> Movies { get { return _movies; } set { _movies = value; OnPropertyChanged(nameof(Movies)); } }

        public MoviesViewModel()
        {
            _movies = new ObservableCollection<MovieView>();
            _moviesContext = new MovieRepo();
            AddMovieViewCommand = new DelegateCommand(ExecuteAddMovie);
            EditMovieViewCommand = new DelegateCommand(ExecuteEditMovie);
            RemoveMovieViewCommand = new DelegateCommand(ExecuteRemoveMovie);
            RentMovieViewCommand = new DelegateCommand(ExecuteRentMovie);
            ReturnMovieViewCommand = new DelegateCommand(ExecuteReturnMovie);

            _movies.Clear();
            var databaseMovies = _moviesContext.GetMovies();
            databaseMovies.ForEach(movie => _movies.Add(movie));
        }

        private void ExecuteReturnMovie(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRentMovie(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRemoveMovie(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteEditMovie(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteAddMovie(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
