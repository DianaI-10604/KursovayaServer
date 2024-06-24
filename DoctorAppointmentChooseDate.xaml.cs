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
using Курсовая_работа2.Models;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для DoctorAppointmentChooseDate.xaml
    /// </summary>
    /// 
    public partial class DoctorAppointmentChooseDate : UserControl, INotifyPropertyChanged
    {
        private string _choosenDoctorname;
        private Doctor _selectedDoctor;
        private List<DateOnly> doctorDateList = new List<DateOnly>();

        public List<DateOnly> DoctorDateList
        {
            get { return doctorDateList; }
            set
            {
                doctorDateList = value;
                OnPropertyChanged(nameof(DoctorDateList));
            }
        }

        public string ChoosenDoctorName
        {
            get { return _choosenDoctorname; }
            set
            {
                _choosenDoctorname = value;
                OnPropertyChanged(nameof(ChoosenDoctorName));
            }
        }

        public DoctorAppointmentChooseDate(Doctor doctor)
        {
            InitializeComponent();
            _selectedDoctor = doctor;
            DataContext = this;
            ChoosenDoctorName = _selectedDoctor.Name;
            doctorDateList = _selectedDoctor.GetAvailableDates(); //присвоили список дат
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        private void ChooseDate_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Используйте явное приведение типа
                DateOnly selectedDate = (DateOnly)button.DataContext;

                if (selectedDate != null)
                {
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new ChooseHourAppointment(_selectedDoctor, selectedDate);

                    mainWindow.CloseSideMenu();
                }
            }
        }
    }
}
