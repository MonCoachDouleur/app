using System;
using SQLite;

namespace ArthsAppProject
{
    public class User
    {
		[PrimaryKey, AutoIncrement]
        public int Id_u { get; set; }
        public string Firstname_u { get; set; }
        public string Lastname_u { get; set; }
        public string Login_u { get; set; }
        public string Pass_u { get; set; }
        public PainAreaEnum PainArea { get; set; }
        public DateTime BirthDate_u { get; set; }

        public User(){ }

        public User(string login, string password)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
        }

        public User(string login, string password, string lastname, string firstname, DateTime birthDate, PainAreaEnum painAreaEnum)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
            this.Lastname_u = lastname;
            this.Firstname_u = firstname;
            this.BirthDate_u = birthDate;
            PainArea = painAreaEnum;
        }
    }
}