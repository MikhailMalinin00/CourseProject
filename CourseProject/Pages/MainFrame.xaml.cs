using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        private Users _currentUser = new Users();
        public MainFrame(Users currentUser)
        {
            InitializeComponent();
            filterGenre.ItemsSource=Entities.GetContext().Genres.ToList();
            var currentMovie=Entities.GetContext().Movies.ToList();
            mainFilmsListView.ItemsSource = currentMovie;
            filterGenre.SelectedIndex = 0;

            if (currentUser != null)
                _currentUser = currentUser;
            DataContext = _currentUser;
        }
        //private void Update()
        //{
        //    var currentMovie = Entities.GetContext().Movies.ToList();
        //    currentMovie = currentMovie.Where(x => x.Title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
        //    if (filterGenre.SelectedIndex != 0)
        //        mainFilmsListView.ItemsSource = currentMovie.Where(x => x.Genres.Genre.ToLower().Contains(filterGenre.Text.ToLower())).ToList();
        //    currentMovie = currentMovie.Where(x => x.GenreID.Equals(filterGenre.SelectedItem as Genres)).ToList();
        //    if (filterGenre.SelectedIndex == 0) mainFilmsListView.ItemsSource = currentMovie.Where(x => x.Genres.Genre == "Комедия");
        //    mainFilmsListView.ItemsSource = currentMovie;
        //}

        private void filterGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update();
            var currentMovie = Entities.GetContext().Movies.ToList();
            if (filterGenre.SelectedIndex > 0)
                mainFilmsListView.ItemsSource = currentMovie.Where(x => x.Genres.Genre.ToLower().Contains(filterGenre.Text.ToLower())).ToList();
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Update();
            var currentMovie = Entities.GetContext().Movies.ToList();
            currentMovie = currentMovie.Where(x => x.Title.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            mainFilmsListView.ItemsSource = currentMovie;
        }

        private void buyTicket_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new AboutFilm(_currentUser, (sender as Button).DataContext as Movies));

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            var currentMovie = Entities.GetContext().Movies.ToList();
            mainFilmsListView.ItemsSource = currentMovie;
            searchTextBox.Text = "";
            filterGenre.SelectedIndex = -1;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"..\..\Resources\help.chm");
        }
    }
}
