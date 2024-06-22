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

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для ServicesWithoutAuthorization.xaml
    /// </summary>
    public partial class ServicesWithoutAuthorization : UserControl
    {
        public Authorization Authorization { get; private set; }

        public ServicesWithoutAuthorization()
        {
            InitializeComponent();
            Authorization = new Authorization();
            //Authorization.UserAuthenticated += Authorization_UserAuthenticated;
        }

        private void SignIn_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null && mainWindow.ContentControlPage.Content != Authorization)
            {
                mainWindow.ContentControlPage.Content = Authorization;
            }
        }

        private void Authorization_UserAuthenticated(object sender /*UserAuthenticatedEventArgs e*/)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                //mainWindow.SetAuthenticatedUser(e.AuthenticatedUser);
                TheMainMenu mainMenu = new TheMainMenu();
                mainWindow.ContentControlPage.Content = mainMenu;
            }
        }

        private void Registration_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ContentControlPage.Content = new RegistrationUser();
            }
        }
    }
}
