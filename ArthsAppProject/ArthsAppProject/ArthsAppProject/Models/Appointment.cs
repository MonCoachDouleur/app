using System;
using SQLite;
namespace ArthsAppProject
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public DateTime dateAppointment { get; set; }
        public User user;

    }
}