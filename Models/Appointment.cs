using System;
using System.Collections.Generic;

namespace Курсовая_работа2.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Doctorid { get; set; }

    public DateOnly Appointmenttime { get; set; }

    public TimeOnly? Appointmenthour { get; set; }

    public string? Appointmentstatus { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();

    public virtual User User { get; set; } = null!;
}
