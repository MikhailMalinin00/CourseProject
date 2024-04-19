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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Page
    {
        public PersonalAccount(Users _currentUser)
        {
            InitializeComponent();
            if(_currentUser.Role != 0)
            {
                adminListView.Visibility = Visibility.Hidden;
                var UserOrder = Entities.GetContext().Orders.ToList();
                UserOrder = UserOrder.Where(x => x.UserID == _currentUser.ID).ToList();
                listViewOrders.ItemsSource = UserOrder;
            }
            else
            {
                listViewOrders.Visibility = Visibility.Hidden;
                var AdminOrder = Entities.GetContext().Orders.ToList();
                adminListView.ItemsSource = AdminOrder;
            }

            var currentUser = _currentUser;
            name.Text = currentUser.FirstName;
            surname.Text = currentUser.LastName;
            login.Text = currentUser.Login;
            email.Text = currentUser.Email;
            phone.Text= currentUser.Phone;
        }

        private void ratingButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = (sender as Button)?.DataContext as Orders;
            var orderMovie = Entities.GetContext().Schedule.Where(x => x.ID == selectedOrder.ScheduleID).First();
            if (orderMovie.DateTime > DateTime.Now)
                MessageBox.Show("Вы можете оценить только просмотренные фильмы!");
            else
            {
                var newWindow = new SetRating((sender as Button)?.DataContext as Orders);
                newWindow.Show();
            }
        }
    }
}
