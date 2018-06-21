using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ArthsAppProject
{
    public class Pain
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pain { get; set; }
        public DateTime date { get; set; }
        public int painLevel { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public User user { get; set; }

        public Pain() { }

        public Pain(DateTime date, int painLevel)
        {
            this.date = date;
            this.painLevel = painLevel;
        }
    }
}
