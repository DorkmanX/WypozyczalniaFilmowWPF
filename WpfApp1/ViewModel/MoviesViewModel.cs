﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Repository;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    public class MoviesViewModel : ViewModelBase
    {
        private IMovieInterface _moviesContext;
        private ObservableCollection<MovieView> _movies;
        private MovieView _selectedMovie;
        private MovieModel _movieModel;

        private bool _isViewVisible;

        private int _id;
        private string _title;
        private string _description;
        private string _category;
        private string _director;
        private int _timelapse;
        private int _clientId;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged(nameof(Description)); } }
        public string Category { get { return _category; } set { _category = value; OnPropertyChanged(nameof(Category)); } }
        public string Director { get { return _director; } set { _director = value; OnPropertyChanged(nameof(Director)); } }
        public int TimeLapse { get { return _timelapse; } set { _timelapse = value; OnPropertyChanged(nameof(TimeLapse)); } }
        public int ClientId { get { return _clientId; } set { _clientId = value; OnPropertyChanged(nameof(ClientId)); } }

        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public ICommand AddMovieViewCommand { get; }
        public ICommand EditMovieViewCommand { get; }
        public ICommand EditApplyViewCommand { get; }
        public ICommand RemoveMovieViewCommand { get; }
        public ICommand RentMovieViewCommand { get; set; }
        public ICommand ReturnMovieViewCommand { get; set; }
        public ICommand InfoMovieViewCommand { get; set; }
        public ICommand InsertMovieViewCommand { get; set; }
        public ICommand CloseInfoViewCommand { get; set; }
        public ICommand RentApplyViewCommand { get; set; }


        public MovieView SelectedMovie { get { return _selectedMovie; } set { _selectedMovie = value; OnPropertyChanged(nameof(SelectedMovie)); } }
        public MovieModel SelectedMovieDB { get { return _movieModel; } set { _movieModel = value; OnPropertyChanged(nameof(SelectedMovieDB)); } }
        public ObservableCollection<MovieView> Movies { get { return _movies; } set { _movies = value; OnPropertyChanged(nameof(Movies)); } }

        public MoviesViewModel()
        {
            _movies = new ObservableCollection<MovieView>();
            _moviesContext = new MovieRepo();
            AddMovieViewCommand = new DelegateCommand(ExecuteAddMovie);
            EditMovieViewCommand = new DelegateCommand(ExecuteEditMovie);
            EditApplyViewCommand = new DelegateCommand(ExecuteApplyEditMovie);
            RemoveMovieViewCommand = new DelegateCommand(ExecuteRemoveMovie);
            RentMovieViewCommand = new DelegateCommand(ExecuteRentMovie,CanExecuteRentMovie);
            ReturnMovieViewCommand = new DelegateCommand(ExecuteReturnMovie,CanExecuteReturnMovie);
            InfoMovieViewCommand = new DelegateCommand(ExecuteInfoMovie);
            InsertMovieViewCommand = new DelegateCommand(ExecuteInsertMovie);
            CloseInfoViewCommand = new DelegateCommand(ExecuteCloseInfo);
            RentApplyViewCommand = new DelegateCommand(ExecuteApplyRent);

            _movies.Clear();
            var databaseMovies = _moviesContext.GetMovies();
            databaseMovies.ForEach(movie => _movies.Add(movie));
        }

        private bool CanExecuteReturnMovie(object obj)
        {
            if (SelectedMovie != null)
            {
                if (SelectedMovie.IsRented == "Tak")
                    return true;
                return false;
            }
            return false;
        }

        private bool CanExecuteRentMovie(object obj)
        {
            if(SelectedMovie != null)
            {
                if (SelectedMovie.IsRented == "Tak")
                    return false;
                return true;
            }
            return false;
        }

        private void ExecuteApplyRent(object obj)
        {
            if (SelectedMovieDB.ClientId != null)
            {
                bool isRented = _moviesContext.RentMovie(SelectedMovieDB.Id, (int)SelectedMovieDB.ClientId);
                if(isRented)
                {
                    _movies.Clear();
                    var databaseMovies = _moviesContext.GetMovies();
                    databaseMovies.ForEach(movie => _movies.Add(movie));
                    IsViewVisible = false;
                }
                else 
                {
                    string messageBoxText = "Podany klient nie istnieje";
                    string caption = "Błąd dodawania";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }
        }

        private void ExecuteCloseInfo(object obj)
        {
            IsViewVisible = false;
        }

        private void ExecuteInfoMovie(object obj)
        {
            SelectedMovieDB = _moviesContext.GetMovie(SelectedMovie.Id);
            MovieInfoView newWindow = new MovieInfoView();
            newWindow.DataContext = this;
            newWindow.Show();
        }

        private void ExecuteApplyEditMovie(object obj)
        {
            bool updated = _moviesContext.UpdateMovie(SelectedMovieDB);
            if (updated)
            {
                _movies.Clear();
                var databaseMovies = _moviesContext.GetMovies();
                databaseMovies.ForEach(movie => _movies.Add(movie));
            }
            IsViewVisible = false;
        }

        private void ExecuteInsertMovie(object obj)
        {
            MovieModel newModel = new MovieModel()
            {
                Title = Title,
                Description = Description,
                Category = Category,
                Director = Director,
                TimeLapse = TimeLapse,
                ClientId = ClientId == 0 ? null : ClientId
            };
            newModel.Id =_moviesContext.AddMovie(newModel);
            
            _movies.Clear();
            var databaseMovies = _moviesContext.GetMovies();
            databaseMovies.ForEach(movie => _movies.Add(movie));
            IsViewVisible = false;
        }

        private void ExecuteReturnMovie(object obj)
        {
            _moviesContext.ReturnMovie(SelectedMovie.Id);

            _movies.Clear();
            var databaseMovies = _moviesContext.GetMovies();
            databaseMovies.ForEach(movie => _movies.Add(movie));

            string messageBoxText = "Film został zwrócony";
            string caption = "Zwrot filmu";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        private void ExecuteRentMovie(object obj)
        {
            SelectedMovieDB = _moviesContext.GetMovie(SelectedMovie.Id);
            RentMovieView newWindow = new RentMovieView();
            newWindow.DataContext = this;
            newWindow.Show();
        }

        private void ExecuteRemoveMovie(object obj)
        {
            bool deleted = _moviesContext.DeleteMovie(SelectedMovie.Id);
            if (deleted)
                _movies.Remove(SelectedMovie);
        }

        private void ExecuteEditMovie(object obj)
        {
            SelectedMovieDB = _moviesContext.GetMovie(SelectedMovie.Id);
            EditMovieView newWindow = new EditMovieView();
            newWindow.DataContext = this;
            newWindow.Show();
        }

        private void ExecuteAddMovie(object obj)
        {
            AddMovieView newWindow = new AddMovieView();
            newWindow.DataContext = this;
            newWindow.Show();
        }
    }
}
