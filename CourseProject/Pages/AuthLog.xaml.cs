using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AuthLog.xaml
    /// </summary>
    public partial class AuthLog : Page
    {
        public AuthLog()
        {
            InitializeComponent();
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(loginTextBox.Text) || string.IsNullOrEmpty(passwordText.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            string _password=GetHash(passwordText.Password);
            using (var db = new Entities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == loginTextBox.Text && u.Password == _password);
                if (user == null) { MessageBox.Show("Пользователь с такими данными не найден!"); return; }
                if(user.Role==1)
                {
                    var newWindow = new UserWindow(user);
                    newWindow.Show();
                    MainWindow.closeWindow();
                }
                else
                {
                    var newWindow = new AdminWindow(user);
                    newWindow.Show();
                    MainWindow.closeWindow();
                }
            }
        }

        private void register_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate((new Uri("/Pages/Registration.xaml", UriKind.Relative)));
    }
}
