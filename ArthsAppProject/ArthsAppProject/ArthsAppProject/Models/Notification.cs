using System;
using SQLite;
namespace ArthsAppProject
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public User user;

    }
}
