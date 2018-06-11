using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public int Id_user;

        public Exercise() { }

        public Exercise(TypeExosEnum typeExe, string duration, int id_user)
        {
            this.Name_exe = typeExe;
            this.Duration = duration;
            this.Id_user = id_user;
        }

        public List<Exercise> GetListAsync()
        {

            var login = App.Current.Properties["login"] as string;
            User user = App.Database.GetUserByLogin(login);
            List<Exercise> lisExos = new List<Exercise>();
            return App.Database.GetListExosAsync(user.Id_u);
        }



    }
}