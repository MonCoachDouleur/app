using System;
using SQLite;

namespace ArthsAppProject
{
    public class User
    {
		[PrimaryKey, AutoIncrement]
        public int Id_u { get; set; }
        public string Name_u { get; set; }
        public string Surname_u { get; set; }
        public string Login_u { get; set; }
        public string Pass_u { get; set; }
        public PainAreaEnum PainArea { get; set; }

        public DateTime BirthDate_u { get; set; }

        public User(){ }

        public User(string login, string password, DateTime BirthDate)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
            this.BirthDate_u = BirthDate;
        }

        public User(string login, string password, DateTime BirthDate, PainAreaEnum painAreaEnum)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
            this.PainArea = painAreaEnum;
            this.BirthDate_u = BirthDate;
        }
    }
}