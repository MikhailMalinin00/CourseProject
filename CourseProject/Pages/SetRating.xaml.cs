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
    /// Логика взаимодействия для SetRating.xaml
    /// </summary>
    public partial class SetRating : Window
    {
        private Orders _currentOrder = new Orders();
        private static Window thisWindow;
        public SetRating(Orders selecetedOrder)
        {
            InitializeComponent();
            thisWindow = this;
            if (selecetedOrder != null)
                _currentOrder = selecetedOrder;

            DataContext = _currentOrder;
            var currentSchedule = Entities.GetContext().Schedule.Where(x => x.ID == _currentOrder.ScheduleID).FirstOrDefault();
            var currentMovie = Entities.GetContext().Movies.Where(x => x.ID == currentSchedule.MovieID).FirstOrDefault();
        }

        private void SetRating_Click(object sender, RoutedEventArgs e)
        {
            int rate;
            var currentSchedule = Entities.GetContext().Schedule.Where(x => x.ID == _currentOrder.ScheduleID).FirstOrDefault();
            var currentMovie = Entities.GetContext().Movies.Where(x => x.ID == currentSchedule.MovieID).FirstOrDefault();
            int oldRate = Convert.ToInt32(currentMovie.Rating);
            try
            {
                if (!Int32.TryParse(inputRating.Text, out rate))
                    MessageBox.Show("Введите корректное численное значение.", "Ошибка!", MessageBoxButton.OK);
                else if (rate <= 0)
                    MessageBox.Show("Введите положительное значение.", "Ошибка!", MessageBoxButton.OK);
                else if (rate > 10)
                    MessageBox.Show("Введите значение от 1 до 10.", "Ошибка!", MessageBoxButton.OK);
                else if (string.IsNullOrEmpty(inputRating.Text))
                    MessageBox.Show("Пожалуйста, введите значение.", "Ошибка!", MessageBoxButton.OK);
                else
                {
                    int newRate = (oldRate + rate) / 2;
                    currentMovie.Rating = newRate;
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show($"Вы успешно оценили фильм на {rate}!", "Успешно!", MessageBoxButton.OK);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка. Повторите попытку позже", "Ошибка!", MessageBoxButton.OK);
            }
        }
    }
}
