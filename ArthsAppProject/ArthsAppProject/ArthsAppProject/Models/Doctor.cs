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
        public int user_id { get; set; }

        public Doctor(string name, string adresse, string speciality, string email, String phone, int userId)
        {
            this.Name_doc = name;
            this.DocAdress = adresse;
            this.DocSpeciality = speciality;
            this.DocEmail = email;
            this.DocPhone = phone;
            this.user_id = userId;
        }

        public Doctor() { }
    }
}