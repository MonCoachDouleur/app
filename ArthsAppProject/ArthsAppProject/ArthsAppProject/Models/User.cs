using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Pain> painList { get; set; }

        public User(){ }

        public User(string login, string password)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
            this.painList = new List<Pain>();
        }

        public User(string login, string password, string lastname, string firstname, DateTime birthDate, PainAreaEnum painAreaEnum)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
            this.Lastname_u = lastname;
            this.Firstname_u = firstname;
            this.BirthDate_u = birthDate;
            this.painList = new List<Pain>();
            PainArea = painAreaEnum;
        }
    }
}