using System;
using System.Collections.Generic;

namespace Курсовая_работа2.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public string Availabletime { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Medicalrecord> Medicalrecords { get; set; } = new List<Medicalrecord>();

    public List<DateOnly> GetAvailableDates()
    {
        List<DateOnly> allDatesInMonth = new List<DateOnly>();
        List<DateOnly> randomDates = new List<DateOnly>();
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);

        int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

        // Создаем список всех дат в текущем месяце
        for (int day = 1; day <= daysInMonth; day++)
        {
            allDatesInMonth.Add(new DateOnly(currentDate.Year, currentDate.Month, day));
        }

        // Перемешиваем список всех дат
        Random random = new Random();
        for (int i = allDatesInMonth.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            DateOnly temp = allDatesInMonth[i];
            allDatesInMonth[i] = allDatesInMonth[j];
            allDatesInMonth[j] = temp;
        }

        // Выбираем первые 7 уникальных дат
        foreach (var date in allDatesInMonth)
        {
            if (date > currentDate && randomDates.Count < 7)
            {
                randomDates.Add(date);
            }
        }

        return randomDates;
    }

    //генерация часа/минуты для записи к врачу
    public List<TimeSpan> GenerateDoctorTimeSlots(string workingHours)
    {
        List<TimeSpan> timeSlots = new List<TimeSpan>();

        string[] workingHoursArray = workingHours.Split('-');
        TimeSpan start = TimeSpan.Parse(workingHoursArray[0]);
        TimeSpan end = TimeSpan.Parse(workingHoursArray[1]);
        TimeSpan current = start;

        int interval = 0;

        if (workingHours == "9:00-18:00" || workingHours == "14:00-18:00")
            interval = 15;
        else if (workingHours == "9:00-14:00")
            interval = 20;

        while (current < end)
        {
            timeSlots.Add(current);
            current = current.Add(new TimeSpan(0, interval, 0));
        }

        return timeSlots;
    }
}
