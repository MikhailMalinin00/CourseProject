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

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutFilm.xaml
    /// </summary>
    public partial class AboutFilm : Page
    {
        private Users _currentUser = new Users();
        private Movies _currentMovie = new Movies();
        public AboutFilm(Users selectedUser, Movies selectedMovie)
        {
            InitializeComponent();

            if (selectedUser != null)
                _currentUser = selectedUser;

            if (selectedMovie != null)
                _currentMovie = selectedMovie;

            DataContext = _currentUser;
            DataContext = _currentMovie;

            var currentSchedule = Entities.GetContext().Schedule.Where(x => x.MovieID == _currentMovie.ID).ToList();

            ScheduleTableView.ItemsSource = currentSchedule;
        }

        private void SelectSchedule_Button(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderTicket(_currentUser, _currentMovie, (sender as Button).DataContext as Schedule);
            orderWindow.Show();
        }

        private void NuttonGoBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void Schedule_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                var currentSchedule = Entities.GetContext().Schedule.Where(x => x.MovieID == _currentMovie.ID).ToList();
                ScheduleTableView.ItemsSource = currentSchedule;
            }
        }
    }
}
