using System;
using SQLite;
namespace ArthsAppProject
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public DateTime DateAppointment { get; set; }
        public User user;

    }
}