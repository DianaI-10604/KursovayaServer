using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Курсовая_работа2.Context;
using Курсовая_работа2.Models;

namespace Курсовая_работа2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private User _authenticatedUser;
        private Visibility _infoVisibility = Visibility.Collapsed;

        public Visibility InfoVisibility
        {
            get { return _infoVisibility; }
            set
            {
                if (_infoVisibility != value)
                {
                    _infoVisibility = value;
                    OnPropertyChanged(nameof(InfoVisibility));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //Показываем окно "ServicesWithoutAuthorization" при запуске
            ShowServicesWithoutAuthorization();
        }

        public void SetAuthenticatedUser(User user)
        {
            _authenticatedUser = user;
        }

        private void ShowServicesWithoutAuthorization()
        {
            var servicesWithoutAuthorization = new ServicesWithoutAuthorization();
            ContentControlPage.Content = servicesWithoutAuthorization;
            servicesWithoutAuthorization.Authorization.UserAuthenticated += Authorization_UserAuthenticated;
        }

        private void Authorization_UserAuthenticated(object sender, UserAuthenticatedEventArgs e)
        {
            _authenticatedUser = e.AuthenticatedUser;
            NavigateToMainMenu();
        }

        private void NavigateToMainMenu()
        {
            Dispatcher.Invoke(() =>
            {
                TheMainMenu mainMenu = new TheMainMenu();
                ContentControlPage.Content = mainMenu;
            });
        }

        private void OpenSideMenu()
        {
            DoubleAnimation animation = new DoubleAnimation(200, TimeSpan.FromSeconds(0.2));
            SideMenu.BeginAnimation(Grid.WidthProperty, animation);
            InfoVisibility = Visibility.Visible;
        }

        private void CloseSideMenu()
        {
            DoubleAnimation animation = new DoubleAnimation(40, TimeSpan.FromSeconds(0.2));
            SideMenu.BeginAnimation(Grid.WidthProperty, animation);
            InfoVisibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenSideMenu();
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            if (SideMenu.ActualWidth > 40)
                CloseSideMenu();
            else
                OpenSideMenu();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void MedicalRecords_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (_authenticatedUser != null)
            {
                MedicalRecords records = new MedicalRecords(_authenticatedUser);
                ContentControlPage.Content = records;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
        }


        private void DoctorAppointment(object sender, RoutedEventArgs e)
        {
            if (_authenticatedUser != null)
            {
                DoctorAppointment appointment = new DoctorAppointment();
                ContentControlPage.Content = appointment;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
        }

        private void MyAppointments(object sender, RoutedEventArgs e)
        {
            if (_authenticatedUser != null)
            {
                UserAppointmentsList appointmentsList = new UserAppointmentsList(_authenticatedUser);
                ContentControlPage.Content = appointmentsList;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ExitUser_ButtonClick(object sender, RoutedEventArgs e)
        {
            _authenticatedUser = null; // Сброс авторизованного пользователя
            var authorization = new Authorization();
            //authorization.UserAuthenticated += Authorization_UserAuthenticated;
            ContentControlPage.Content = authorization;
        }

        private void MyProfile_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (_authenticatedUser != null)
            {
                MyProfile myProfile = new MyProfile(_authenticatedUser);
                ContentControlPage.Content = myProfile;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            if (_authenticatedUser != null)
            {
                TheMainMenu mainMenu = new TheMainMenu();
                ContentControlPage.Content = mainMenu;
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован.");
            }
        }

        //Перемещение окна с помощью мыши
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ServiceWithoutAuth(object sender, RoutedEventArgs e)
        {
            var servicesWithoutAuthorization = new ServicesWithoutAuthorization();
            ContentControlPage.Content = servicesWithoutAuthorization;
        }
    }
}