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
using Курсовая_работа2.Context;
using Курсовая_работа2.Models;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        public static bool isAuthorized;
        public event EventHandler<UserAuthenticatedEventArgs> UserAuthenticated;

        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = phone.Text;
            string passwordUser = password.Password; // используйте .Password для пароля

            // Поиск пользователя в базе данных
            using (var db = new User999Context())
            {
                var user = db.Users.FirstOrDefault(u => u.Phonenumber == phoneNumber && u.Userpassword == passwordUser);
                if (user != null)
                {
                    isAuthorized = true;
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new TheMainMenu();

                    // Вызываем событие, чтобы сообщить MainWindow об авторизации пользователя
                    OnUserAuthenticated(new UserAuthenticatedEventArgs(user));
                }
                else
                {
                    MessageBox.Show("Неверные данные для авторизации!");
                }
            }
        }

        protected virtual void OnUserAuthenticated(UserAuthenticatedEventArgs e)
        {
            UserAuthenticated?.Invoke(this, e);
        }
    }

    public class UserAuthenticatedEventArgs : EventArgs
    {
        public User AuthenticatedUser { get; }

        public UserAuthenticatedEventArgs(User user)
        {
            AuthenticatedUser = user;
        }
    }
}
