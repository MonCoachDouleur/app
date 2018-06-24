using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace ArthsAppProject
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Appointment { get; set; }
        public DateTime DateAppointment { get; set; }
        public DateTime HourAppointment { get; set; }
        public int user_Id { get; set; }

        public Appointment(DateTime date, DateTime hour, int user_id)
        {
            this.DateAppointment = date;
            this.HourAppointment = hour;
            this.user_Id = user_id;
        }

        public Appointment() { }

        public async Task<List<Appointment>> GetListAsync()
        {
            return await App.Database.appointmentRepo.GetAll();
        }

    }
}