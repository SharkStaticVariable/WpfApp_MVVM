using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_MVVM.Models;
using WpfApp_MVVM.ViewModels;

namespace WpfApp_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientsViewModel ViewModel;
        MoviesViewModel ViewModelM;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ClientsViewModel();
            ViewModelM = new MoviesViewModel();

            this.DataContext = ViewModel;
        }
    }
}
