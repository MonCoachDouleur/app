using System;
using SQLite;
namespace ArthsAppProject
{
    public class Pain
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pain { get; set; }
        public DateTime date { get; set; }
        public int painLevel { get; set; }

        public Pain() { }

        public Pain(DateTime date, int painLevel)
        {
            this.date = date;
            this.painLevel = painLevel;
        }
    }
}
