using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для UserAppointmentsList.xaml
    /// </summary>
    public partial class UserAppointmentsList : UserControl
    {
        public ObservableCollection<Appointment> UserAppointmentsCollection { get; set; }
        private User _user;

        public UserAppointmentsList(User user)
        {
            InitializeComponent();
            _user = user;

            using (var context = new User999Context())
            {
                var appointmentList = context.Appointments
                    .Include(m => m.Doctor)
                    .Where(m => m.Userid == _user.Id) // Исправлено на UserId
                    .ToList();

                UserAppointmentsCollection = new ObservableCollection<Appointment>(appointmentList);
            }

            DataContext = this; // Установка контекста данных на текущий UserControl
        }
    }
}
