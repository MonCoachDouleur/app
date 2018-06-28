using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArthsAppProject.Helper;
using ArthsAppProject.Models;
using SQLite;
namespace ArthsAppProject
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id_exe { get; set; }
        public string Name_exe { get; set; }
        public string Duration { get; set; }

        public DateTime DayExo { get; set; }

        public int Id_user { get; set; }

        public Exercise() { }

        public Exercise(string typeExe,DateTime dayExo, string duration, int id_user)
        {
            this.Name_exe = typeExe;
            this.DayExo = dayExo;
            this.Duration = duration;
            this.Id_user = id_user;
        }

        public async Task<List<Exercise>> GetListAsync()
        {
            return await App.Database.exerciseRepo.GetAll();
        }



    }
}