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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
            comboBoxFilterSelect.ItemsSource = Entities.GetContext().Genres.ToList();
            var currentFilm=Entities.GetContext().Movies.ToList();
            tableView.ItemsSource = currentFilm;
            comboBoxFilterSelect.SelectedIndex = 0;
        }
        //private void Update()
        //{
        //    var currentMovie = Entities.GetContext().Movies.ToList();
        //    currentMovie = currentMovie.Where(x => x.Title.ToLower().Contains(searchBox.Text.ToLower())).ToList();
        //    tableView.ItemsSource = currentMovie;
        //    if (comboBoxFilterSelect.SelectedIndex != 0)
        //        tableView.ItemsSource = currentMovie.Where(x => x.Genres.Genre.ToLower().Contains(comboBoxFilterSelect.Text.ToLower())).ToList();
        //}
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var AddFilm = new AddFilm();
            AddFilm.Show();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Update();
            var currentMovie = Entities.GetContext().Movies.ToList();
            currentMovie = currentMovie.Where(x => x.Title.ToLower().Contains(searchBox.Text.ToLower())).ToList();
            tableView.ItemsSource = currentMovie;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var moviesForRemoving = tableView.SelectedItems.Cast<Movies>().ToList();
            if (moviesForRemoving.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, фильм, который хотите удалить", "Внимание");
                return;
            }
            if(MessageBox.Show($"Вы точно хотите удалить записи в количестве {moviesForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Movies.RemoveRange(moviesForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    tableView.ItemsSource = Entities.GetContext().Movies.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            tableView.ItemsSource = Entities.GetContext().Movies.ToList();
            searchBox.Text = "";
            comboBoxFilterSelect.SelectedIndex = -1;
        }

        private void comboBoxFilterSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update();
            var currentMovie = Entities.GetContext().Movies.ToList();
            if (comboBoxFilterSelect.SelectedIndex != 0)
                tableView.ItemsSource = currentMovie.Where(x => x.Genres.Genre.ToLower().Contains(comboBoxFilterSelect.Text.ToLower())).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x=>x.Reload());
                tableView.ItemsSource=Entities.GetContext().Movies.ToList();
            }
        }

        private void AddSchedule_Button(object sender, RoutedEventArgs e)
        {
            var AddSchedule = new AddSchedule((sender as Button).DataContext as Movies);
            AddSchedule.Show();
        }
    }
}
