using System;
using SQLite;
namespace ArthsAppProject
{
    public class Doctor
    {
        [PrimaryKey, AutoIncrement]
        public int Id_doc { get; set; }
        public string Name_doc { get; set; }
        public string DocAdress { get; set; }
        public string DocSpeciality { get; set; }
        public string DocEmail { get; set; }
        public string DocPhone { get; set; }
        public User user;

    }
}