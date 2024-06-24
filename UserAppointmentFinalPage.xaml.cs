using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
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
    /// Логика взаимодействия для UserAppointmentFinalPage.xaml
    /// </summary>
    public partial class UserAppointmentFinalPage : UserControl, INotifyPropertyChanged
    {
        private string _doctorname;
        private DateOnly _choosenDate;
        private Doctor _selectedDoctor;
        private TimeSpan _choosenHour;

        public string ChoosenDoctorName
        {
            get { return _doctorname; }
            set
            {
                _doctorname = value;
                OnPropertyChanged(nameof(ChoosenDoctorName));
            }
        }

        public TimeSpan ChoosenHour
        {
            get { return _choosenHour; }
            set
            {
                _choosenHour = value;
                OnPropertyChanged(nameof(ChoosenHour));
            }
        }


        public DateOnly ChoosenDate
        {
            get { return _choosenDate; }
            set
            {
                _choosenDate = value;
                OnPropertyChanged(nameof(ChoosenDate));
            }
        }

        public UserAppointmentFinalPage(Doctor doctor, DateOnly choosenDate, TimeSpan choosenHour)
        {
            InitializeComponent();
            _selectedDoctor = doctor;
            ChoosenDoctorName = _selectedDoctor.Name;
            ChoosenDate = choosenDate;
            ChoosenHour = choosenHour;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveAppointment_ButtonClick(object sender, RoutedEventArgs e)
        {
            string surname = surnametextbox.Text;
            string name = nametextbox.Text; 
            string patronymic = patronymicnametextbox.Text;
            DateTime? selectedDate = datebirthpicker.SelectedDate;
            string email = emailtextbox.Text;
            string phone = phonetextbox.Text;

            DateOnly datebirth = new DateOnly(2022, 4, 15);
            //берем дату записи
            if (selectedDate.HasValue)
            {
                datebirth = new DateOnly(selectedDate.Value.Year, selectedDate.Value.Month, selectedDate.Value.Day);

                // Теперь вы можете использовать объект dateOnly
            }

            using (var db = new User999Context())
            {
                var user = db.Users.FirstOrDefault(u => u.Phonenumber == phone && u.Usersurname == surname && u.Username == name && u.Userpatronymicname == patronymic && u.Birthdate == datebirth);
                if (user != null)
                {
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new TheMainMenu();

                    Appointment newAppointment = new Appointment()
                    {
                        Userid = user.Id,
                        Doctorid = _selectedDoctor.Id,
                        Appointmenttime = ChoosenDate,
                        Appointmenthour = ChoosenHour
                    };

                    using (var dbContext = new User999Context()) // Используйте ваш DbContext
                    {
                        dbContext.Appointments.Add(newAppointment);
                        dbContext.SaveChanges(); // Сохранение изменений в базе данных
                    }

                    MessageBox.Show("Вы записались к врачу!");
                    
                }
                else
                {
                    MessageBox.Show("Неверные данные для авторизации!");
                }
            }
        }
    }
}
