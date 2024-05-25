using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_MVVM.Commands;
using WpfApp_MVVM.Models;

namespace WpfApp_MVVM.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        MoviesServices ObjMoviesService;
        public MoviesViewModel()
        {
            ObjMoviesService = new MoviesServices();
            LoadData();
            CurrentMovies = new MoviesDTO();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        private ObservableCollection<MoviesDTO> moviesList;
        public ObservableCollection<MoviesDTO> MoviesList
        {
            get { return moviesList; }
            set { moviesList = value; OnPropertyChanged("MoviesList"); }
        }

        private void LoadData()
        {
            MoviesList = new ObservableCollection<MoviesDTO>(ObjMoviesService.GetAll());
        }


        private MoviesDTO currentMovies;

        public MoviesDTO CurrentMovies
        {
            get { return currentMovies; }
            set { currentMovies = value; OnPropertyChanged("CurrentMovies"); }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }

        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjMoviesService.Add(CurrentMovies);
                LoadData();
                if (IsSaved)
                    Message = "Фильм сохранен";
                else Message = "Операция прервана!";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }


        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        /**/
        public void Search()
        {
            try
            {
                var ObjMovies = ObjMoviesService.Search(CurrentMovies.Id);
                if (ObjMovies != null)
                {
                    CurrentMovies.Genre = ObjMovies.Genre;
                    currentMovies.Timing = ObjMovies.Timing;
                    currentMovies.Name = ObjMovies.Name;

                    currentMovies.Country = ObjMovies.Country;
                    currentMovies.Year = ObjMovies.Year;
                    currentMovies.Director = ObjMovies.Director;
                    currentMovies.Release_date = ObjMovies.Release_date;

                    currentMovies.Price = ObjMovies.Price;


                }
                else
                {
                    Message = "Фильм не найден";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }

        }
        public void Update()
        {
            try
            {
                var IsUpdate = ObjMoviesService.Update(CurrentMovies);
                if (IsUpdate)
                {
                    Message = "Фильм обновлен";
                    LoadData();
                }
                else
                {
                    Message = "Неудачно!";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }

        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjMoviesService.Delete(CurrentMovies.Id);
                if (IsDeleted)
                {
                    Message = "Фильм удален!";
                    LoadData();
                }
                else
                {
                    Message = "неудачно!";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
    }
}