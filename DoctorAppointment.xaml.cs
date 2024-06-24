using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для DoctorAppointment.xaml
    /// </summary>
    public partial class DoctorAppointment : UserControl
    {
        private User _user;
        public ObservableCollection<Doctor> DoctorsList { get; set; }
        public DoctorAppointment()
        {
            InitializeComponent();
        }

        public DoctorAppointment(User user) //добавляем отображение врачей
        {
            InitializeComponent();
            _user = user;

            using (var context = new User999Context())
            {
                var doctorslist = context.Doctors.ToList(); // Получаем всех врачей из базы данных

                DoctorsList = new ObservableCollection<Doctor>(doctorslist);
            }

            DataContext = this;
        }

        private void ChooseDoctorAndTime_ButtonClick(object sender, RoutedEventArgs e)
        {
            Doctor selectedDoctor = (sender as FrameworkElement)?.DataContext as Doctor;

            if (selectedDoctor != null)
            {
                // Здесь можно обратиться к базе данных, используя, например, Entity Framework
                // и получить дополнительную информацию о выбранном враче (selectedDoctor)

                // Пример обращения к базе данных и получения информации о враче
                using (User999Context context = new User999Context())
                {
                    Doctor doctorFromDb = context.Doctors.FirstOrDefault(d => d.Id == selectedDoctor.Id);

                    if (doctorFromDb != null)
                    {
                        MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                        mainWindow.ContentControlPage.Content = new DoctorAppointmentChooseDate(doctorFromDb);

                        mainWindow.CloseSideMenu();
                    }
                }
            }
        }
    }
}
