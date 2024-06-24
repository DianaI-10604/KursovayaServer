using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace Курсовая_работа2.Models;

public partial class Appointment : INotifyPropertyChanged
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Doctorid { get; set; }

    public DateOnly Appointmenttime { get; set; }

    public TimeSpan? Appointmenthour { get; set; }

    public string? Appointmentstatus { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();

    public virtual User User { get; set; } = null!;

    //private bool _appointmentCancelButtonVisibility;

    //public bool AppointmentCancelButtonVisibility
    //{
    //    get { return _appointmentCancelButtonVisibility; }
    //    set
    //    {
    //        if (_appointmentCancelButtonVisibility != value)
    //        {
    //            _appointmentCancelButtonVisibility = value;
    //            OnPropertyChanged("AppointmentCancelButtonVisibility");
    //        }
    //    }
    //}

    // Реализация интерфейса INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
