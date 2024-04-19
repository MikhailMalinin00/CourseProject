using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для OrderTicket.xaml
    /// </summary>
    public partial class OrderTicket : Window
    {
        private Users _currentUser = new Users();
        private Movies _currentMovie = new Movies();
        private Schedule _currentSchedule = new Schedule();
        public OrderTicket(Users selectedUser, Movies selectedMovie, Schedule selectedSchedule)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentUser = selectedUser;

            if (selectedMovie != null)
                _currentMovie = selectedMovie;

            if (selectedSchedule != null)
                _currentSchedule = selectedSchedule;

            DataContext = _currentUser;
            DataContext = _currentMovie;
            DataContext = _currentSchedule;

            var currentMovie = _currentMovie;
            var currentSchedule = _currentSchedule;
            nameMovie.Text = selectedMovie.Title;
            dateTicket.Text = currentSchedule.DateTime.ToString();
            aviableSeats.Text = currentSchedule.AvailableSeat.ToString();
        }

        private void orderSomeTickets_Click(object sender, RoutedEventArgs e)
        {
            string text = selectCountOfSeats.Text;
            int countSeats = 0;
            var currentSchedule = _currentSchedule;
            //var MovieSchedule = Entities.GetContext().Schedule.First(x => x.MovieID == _currentMovie.ID);
            ////MovieSchedule = MovieSchedule.Where(x => x.MovieID == _currentMovie.ID).ToList();
            //int scheduleId = MovieSchedule.ID;
            try
            {
                countSeats = Convert.ToInt32(text);
                if (countSeats > Convert.ToInt32(aviableSeats.Text))
                    MessageBox.Show("Вы не можете заказать больше доступного кол-ва мест.", "Ошибка!", MessageBoxButton.OK);
                else if (countSeats > 10)
                    MessageBox.Show("Вы не можете заказать больше 10 мест.", "Ошибка!", MessageBoxButton.OK);
                else if (countSeats <= 0)
                    MessageBox.Show("Вы не можете заказать меньше 0 мест.", "Ошибка!", MessageBoxButton.OK);
                else
                {
                    try
                    {
                        Entities db = new Entities();
                        Orders orderObject = new Orders()
                        {
                            UserID = _currentUser.ID,
                            ScheduleID = _currentSchedule.ID,
                            NumberOfSeat=countSeats
                        };
                        //SendMail(countSeats);
                        db.Orders.Add(orderObject);
                        db.SaveChanges();
                        _currentSchedule.AvailableSeat -= countSeats;
                        Entities.GetContext().SaveChanges();
                        MessageBox.Show("Вы успешно заказали билет!", "Успешно!", MessageBoxButton.OK);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка при заказе билета. Повторите попытку позже.", "Ошибка!", MessageBoxButton.OK);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректное значение.", "Ошибка!", MessageBoxButton.OK);
            }
        }
        private void SendMail(int count)
        {
            var currentSchedule = Entities.GetContext().Schedule.Where(x => x.MovieID == _currentMovie.ID).FirstOrDefault();

            var countSeats = count;
            var mailFrom = new MailAddress("premium-kino@hotmail.com", "КИНО ПРЕМИУМ");
            var mailTo = new MailAddress(_currentUser.Email, _currentUser.LastName);
            var message = new MailMessage(mailFrom, mailTo);
            string dateTime = Convert.ToString(currentSchedule.DateTime);
            message.Body = $"Здравствуйте, {_currentUser.LastName} {_currentUser.FirstName}! Вы успешно забронировали {countSeats} мест(а) на следующий сеанс:\n" +
                $"{_currentMovie.Title}, {dateTime}." +
                $"\nПриятного просмотра! Пожалуйста, оставьте отзыв о фильме после сеанса.";
            message.Subject = "Бронирование билета: успешно!";

            var client = new SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mailFrom.Address, "xfoAW2oDLzMo");
            client.Send(message);
        }
    }
}
