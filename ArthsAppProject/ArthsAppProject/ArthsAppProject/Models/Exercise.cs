using System;
using ArthsAppProject.Models;
using SQLite;
namespace ArthsAppProject
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id_exe { get; set; }
        public TypeExosEnum Name_exe { get; set; }
        public string Duration { get; set; }
  //      public int Id_user;

        public Exercise() { }

        public Exercise(TypeExosEnum typeExe, string duration)
        {
            this.Name_exe = typeExe;
            this.Duration = duration;
  //          this.Id_user = id_user;
        }



    }
}