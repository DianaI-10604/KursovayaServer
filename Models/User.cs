﻿using System;
using System.Collections.Generic;

namespace Курсовая_работа2.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Usersurname { get; set; } = null!;

    public string Userpatronymicname { get; set; } = null!;

    public string Snils { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();
}
