using System;
using SQLite;
namespace ArthsAppProject
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id_exe { get; set; }
        public string Name_exe { get; set; }
        public string Duration { get; set; }
        public User user;

    }
}