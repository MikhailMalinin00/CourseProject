using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddSchedule.xaml
    /// </summary>
    public partial class AddSchedule : Window
    {
        private Movies _currentMovie=new Movies();
        public AddSchedule(Movies currentMovie)
        {
            InitializeComponent();
            _currentMovie = currentMovie;
            DataContext = _currentMovie;
        }

        private void addSchedule_Click(object sender, RoutedEventArgs e)
        {
            int seatsInt;
            var date = dateInput.Text;
            var time = timeInput.Text;
            Int32.TryParse(seatsInput.Text, out seatsInt);
            if (string.IsNullOrEmpty(date))
                MessageBox.Show("Введите дату!", "Ошибка", MessageBoxButton.OK);
            else if (string.IsNullOrEmpty(time))
                MessageBox.Show("Введите время!", "Ошибка", MessageBoxButton.OK);
            else if (string.IsNullOrEmpty(seatsInput.Text))
                MessageBox.Show("Введите кол-во мест!", "Ошибка", MessageBoxButton.OK);
            else
            {
                try
                {
                    var dateTest = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Неккоректно введена дата.", "Ошибка!", MessageBoxButton.OK);
                }
                try
                {
                    var timeTest = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Неккоректно введено время.", "Ошибка!", MessageBoxButton.OK);
                }

                if (seatsInt > 50)
                    MessageBox.Show("Слишком много мест.", "Ошибка", MessageBoxButton.OK);
                else if (seatsInt < 10)
                    MessageBox.Show("Слишком мало мест.", "Ошибка", MessageBoxButton.OK);
                else if (!Int32.TryParse(seatsInput.Text, out seatsInt))
                    MessageBox.Show("Введите корректное значение доступных мест.", "Ошибка", MessageBoxButton.OK);
                else
                {
                    try
                    {
                        var s = string.Concat(date, " ", time);
                        DateTime dt = DateTime.ParseExact(s, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                        Entities db = new Entities();
                        Schedule scheduleObject = new Schedule
                        {
                            MovieID = _currentMovie.ID,
                            AvailableSeat = seatsInt,
                            DateTime= dt,
                        };
                        db.Schedule.Add(scheduleObject);
                        db.SaveChanges();
                        MessageBox.Show("Расписание успешно добавлено!", "Успешно!", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void escButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
                   
