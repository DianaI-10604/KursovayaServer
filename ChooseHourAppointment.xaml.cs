using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ChooseHourAppointment.xaml
    /// </summary>
    public partial class ChooseHourAppointment : UserControl, INotifyPropertyChanged
    {
        private string _doctorname;
        private DateOnly _choosenDate;
        private Doctor _selectedDoctor;
        private List<TimeSpan> doctorHourList = new List<TimeSpan>();

        public string ChoosenDoctorName
        {
            get { return _doctorname; }
            set
            {
                _doctorname = value;
                OnPropertyChanged(nameof(ChoosenDoctorName));
            }
        }

        public List<TimeSpan> DoctorHourList
        {
            get { return doctorHourList; }
            set
            {
                doctorHourList = value;
                OnPropertyChanged(nameof(DoctorHourList));
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

        //передали имя доктора и дату записи
        public ChooseHourAppointment(Doctor doctor, DateOnly choosenDate)
        {
            InitializeComponent();
            _selectedDoctor = doctor;
            ChoosenDoctorName = _selectedDoctor.Name;
            ChoosenDate = choosenDate;
            DataContext = this;
            doctorHourList = _selectedDoctor.GenerateDoctorTimeSlots(_selectedDoctor.Availabletime);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChooseHour_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Используйте явное приведение типа
                TimeSpan selectedHour = (TimeSpan)button.DataContext;

                if (selectedHour != null)
                {
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new UserAppointmentFinalPage(_selectedDoctor, _choosenDate, selectedHour);

                    mainWindow.CloseSideMenu();
                }
            }
        }
    }
}
