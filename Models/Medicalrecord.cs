using System;
using System.Collections.Generic;

namespace Курсовая_работа2.Models;

public partial class Medicalrecord
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Doctorid { get; set; }

    public int Appointmentid { get; set; }

    public string? Diagnosis { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
