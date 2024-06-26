﻿using System;
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
using System.ComponentModel;
using System.Globalization;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для UserAppointmentsList.xaml
    /// </summary>
    public partial class UserAppointmentsList : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<Appointment> AllAppointmentsCollection { get; set; }
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

                AllAppointmentsCollection = new ObservableCollection<Appointment>(appointmentList);
                UserAppointmentsCollection = new ObservableCollection<Appointment>(appointmentList);
            }

            DataContext = this; // Установка контекста данных на текущий UserControl
        }

        private void AllAppointments_ButtonClick(object sender, RoutedEventArgs e)
        {
            UserAppointmentsCollection.Clear();

            foreach (var appointment in AllAppointmentsCollection)
            {
                UserAppointmentsCollection.Add(appointment);
            }
        }

        private void UpcomingAppointments_ButtonClick(object sender, RoutedEventArgs e)
        {
            var filteredAppointments = AllAppointmentsCollection.Where(a => a.Appointmentstatus == "Предстоящие").ToList();
            UserAppointmentsCollection.Clear();

            foreach (var appointment in filteredAppointments)
            {
                UserAppointmentsCollection.Add(appointment);
            }
        }

        private void CompletedAppointments_ButtonClick(object sender, RoutedEventArgs e)
        {
            var filteredAppointments = AllAppointmentsCollection.Where(a => a.Appointmentstatus == "Завершен").ToList();
            UserAppointmentsCollection.Clear();

            foreach (var appointment in filteredAppointments)
            {
                UserAppointmentsCollection.Add(appointment);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //отмена записи
        private void CancelAppointment_ButtonClick(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент из коллекции UserAppointmentsCollection
            Appointment selectedAppointment = (sender as Button).DataContext as Appointment;

            // Удаляем выбранный элемент из базы данных
            MessageBoxResult result = MessageBox.Show("Вы уверены? Отменить это дейстие будет нельзя", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Удаляем выбранный элемент из базы данных
                using (var context = new User999Context())
                {
                    context.Appointments.Remove(selectedAppointment);
                    context.SaveChanges();
                }

                // Удаляем выбранный элемент из коллекции AllAppointmentsCollection и UserAppointmentsCollection
                AllAppointmentsCollection.Remove(selectedAppointment);
                UserAppointmentsCollection.Remove(selectedAppointment);
            }
        }
    }

    public class StatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value as string;
            if (status == "Предстоящие")
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
