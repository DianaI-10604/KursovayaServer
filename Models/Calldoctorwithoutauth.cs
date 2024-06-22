using System;
using System.Collections.Generic;

namespace Курсовая_работа2.Models;

public partial class Calldoctorwithoutauth
{
    public string Username { get; set; } = null!;

    public string Usersurname { get; set; } = null!;

    public string Userpatronymicname { get; set; } = null!;

    public string Userphone { get; set; } = null!;

    public string Useremail { get; set; } = null!;

    public DateOnly Datebirth { get; set; }

    public string Gender { get; set; } = null!;

    public string Snils { get; set; } = null!;

    public string Useraddress { get; set; } = null!;

    public string Callreason { get; set; } = null!;

    public DateOnly Apponmentdate { get; set; }
}
