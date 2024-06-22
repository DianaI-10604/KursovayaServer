using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Курсовая_работа2.Context;
using Курсовая_работа2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для MedicalRecords.xaml
    /// </summary>
    public partial class MedicalRecords : UserControl
    {
        public ObservableCollection<Medicalrecord> MedicalRecordsCollection { get; set; }
        private User _user;

        public MedicalRecords(User user)
        {
            InitializeComponent();
            _user = user;

            using (var context = new User999Context())
            {
                var medicalRecordsList = context.Medicalrecords
                    .Include(m => m.Appointment)
                    .Include(m => m.Doctor)
                    .Where(m => m.Userid == _user.Id) // Фильтр по Userid текущего пользователя
                    .ToList();

                MedicalRecordsCollection = new ObservableCollection<Medicalrecord>(medicalRecordsList);
            }

            DataContext = this;

        }
    }
}
