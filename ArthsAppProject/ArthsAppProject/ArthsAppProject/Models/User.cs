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
        public string PainArea { get; set; }

        public User(){ }

        public User(string login, string password)
        {
            this.Login_u = login;
            this.Pass_u = Hash.HashSHA512(password);
        }
    }
}