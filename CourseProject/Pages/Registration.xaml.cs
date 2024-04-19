using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
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
        private bool isValidMail(string mail)
        {
            var regex = new Regex(@"^(\w+\@\w+\.\w+)$");
            try
            {
                MailAddress m = new MailAddress(mail);
                if (!regex.IsMatch(mail))
                    return false;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate((new Uri("/Pages/AuthLog.xaml", UriKind.Relative)));

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginText.Text.Length > 0)
            {
                using (var db = new Entities())
                {
                    var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == loginText.Text);
                    if(user!=null) { MessageBox.Show("Пользователь с такими данными уже существует!"); return; }
                }
                    if (passwordText.Password.Length > 0)
                {
                    if (passwordText.Password.Length > 6)
                    {
                        bool en = true;
                        bool number = false;
                        var regex = new Regex(@"^((\+7))\d{10}$");

                        for (int i = 0; i < passwordText.Password.Length; i++)
                        {
                            if (passwordText.Password[i] >= 'А' && passwordText.Password[i] <= 'Я') en = false;
                            if (passwordText.Password[i] >= '0' && passwordText.Password[i] <= '9') number = true;
                        }
                        if (!en) MessageBox.Show("Доступна только английская раскладка");
                        else if (!number) MessageBox.Show("Введите хотя бы одну цифру");
                        else if (!regex.IsMatch(phoneText.Text))
                            MessageBox.Show("Введите корректный номер телефона в формате +7XXXXXXXXXX.", "Ошибка!", MessageBoxButton.OK);
                        else if (!isValidMail(emailText.Text))
                            MessageBox.Show("Введите корректный e-mail.", "Ошибка!", MessageBoxButton.OK);

                        if (en && number && regex.IsMatch(phoneText.Text) && isValidMail(emailText.Text))
                        {
                           Entities db=new Entities();
                            Users userObject = new Users
                            {
                                FirstName = nameText.Text,
                                LastName = surnameText.Text,
                                Login = loginText.Text,
                                Password = GetHash(passwordText.Password),
                                Role = 1,
                                Email = emailText.Text,
                                Phone = phoneText.Text,
                            };
                            db.Users.Add(userObject);
                            db.SaveChanges();
                            MessageBox.Show("Вы успешно зарегистрировались!", "Успешно!", MessageBoxButton.OK);
                            NavigationService.Navigate((new Uri("/Pages/AuthLog.xaml", UriKind.Relative)));
                        }
                    }
                    else MessageBox.Show("Данный пароль слишком короткий, минимум 6 символов");


                }
                else MessageBox.Show("Укажите пароль!");
            }
            else MessageBox.Show("Укажите лоигн!");
        }
    }
}
