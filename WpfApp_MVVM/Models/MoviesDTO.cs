using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MVVM.Models
{
    public class MoviesDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged("genre"); }
        }
        private string timing;
        public string Timing
        {
            get { return timing; }
            set { timing = value; OnPropertyChanged("timing"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("name"); }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged("country"); }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged("year"); }
        }
        private string director;
        public string Director
        {
            get { return director; }
            set { director = value; OnPropertyChanged("director"); }
        }
        private string release_date;
        public string Release_date
        {
            get { return release_date; }
            set { release_date = value; OnPropertyChanged("release_date"); }
        }
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("price"); }
        }
    }
}
