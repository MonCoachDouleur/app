using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArthsAppProject.Helper;
using ArthsAppProject.Models;
using SQLite;
namespace ArthsAppProject
{
    public class ExercisePrepro
    {
        [PrimaryKey, AutoIncrement]
        public int Id_exePropr { get; set; }

        public string ImgName { get; set; }
        public string ZonePain { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ExercisePrepro(string zonePain, string typeExe, string description, string imgName)
        {
            this.ZonePain = zonePain;
            this.Type = typeExe;
            this.Description = description;
            this.ImgName = imgName;
        }

        public ExercisePrepro()
        {
        }

    }
}