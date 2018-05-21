using System;
using SQLite;
namespace ArthsAppProject
{
    public class Pain
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pain { get; set; }
        public DateTime Date { get; set; }
        public User user;

    }
}
