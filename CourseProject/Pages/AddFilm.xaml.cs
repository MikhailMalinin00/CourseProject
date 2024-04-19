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
using System.Windows.Shapes;

namespace CourseProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        public AddFilm()
        {
            InitializeComponent();
            DataContext = _currentMovie;
            CmbGenre.ItemsSource = Entities.GetContext().Genres.ToList();
        }
        private Movies _currentMovie=new Movies();
        private void addFilmButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentMovie.Title)) errors.AppendLine("Укажите название фильма!");
            if (string.IsNullOrWhiteSpace(_currentMovie.Director)) errors.AppendLine("Укажите режиссера фильма!");
            if (_currentMovie.Director == null) errors.AppendLine("Выберите жанр фильма!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentMovie.Duration))) errors.AppendLine("Укажите длительность фильма!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentMovie.Rating))) errors.AppendLine("Укажите рейтинг фильма!");
            //if (string.IsNullOrWhiteSpace(_currentMovie.Photo)) errors.AppendLine("Вставьте ссылку на фото!");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentMovie.ID == 0)
            {
                if (_currentMovie.Photo == null)
                    _currentMovie.Photo = null;
                Entities.GetContext().Movies.Add(_currentMovie);
            }
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Close();

            }
            catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            filmName.Text = "";
            filmDirector.Text = "";
            CmbGenre.Text = "";
            duration.Text = "";
            rating.Text = "";
            photoLink.Text = "";
            filmDescription.Text = "";
        }

    }
}
