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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private Users _currentUser;
        public UserWindow(Users currentUser)
        {
            InitializeComponent();
            if (currentUser != null)
                _currentUser = currentUser;
            DataContext = _currentUser;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)  // Реализация подтверждения закрытия программы
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
                e.Cancel = true;
            base.OnClosing(e);
        }

        private void afisha_Click(object sender, RoutedEventArgs e) => frameMain.NavigationService.Navigate(new MainFrame(_currentUser));

        private void aboutUs_Click(object sender, RoutedEventArgs e) => frameMain.NavigationService.Navigate(new Uri("/Pages/AboutUs.xaml", UriKind.Relative));

        private void cabinet_Click(object sender, RoutedEventArgs e) => frameMain.NavigationService.Navigate(new PersonalAccount((sender as Button).DataContext as Users));
    }
}
