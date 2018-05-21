using System;
using SQLite;
using System.Collections.Generic;

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
        //public List<Notification> listNotifications { get; set; }

    }
}