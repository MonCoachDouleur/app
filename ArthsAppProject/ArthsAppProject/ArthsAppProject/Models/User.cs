using System;
using SQLite;
using System.Collections.Generic;

namespace ArthsAppProject
{
    public class User
    {
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
		public List<Notification> listNotifications { get; set; }
    }
}