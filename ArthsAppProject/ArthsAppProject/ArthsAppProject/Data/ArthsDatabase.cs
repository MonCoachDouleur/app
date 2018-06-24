using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Security.Cryptography;
using System.Linq;
using SQLiteNetExtensionsAsync.Extensions;

namespace ArthsAppProject
{
    public class ArthsDatabase
    {
        public readonly IRepository<User> userRepo;
        public readonly IRepository<Pain> painRepo;
        public readonly IRepository<Doctor> doctorRepo;
        public readonly IRepository<Exercise> exerciseRepo;
        public readonly IRepository<Appointment> appointmentRepo;
        public readonly IRepository<ExercisePrepro> exercisePreproRepo;


        readonly SQLiteAsyncConnection database;
        private User admin;
        public ArthsDatabase(string dbPath)
        {
            admin = new User("test@hotmail.fr", "test", "Durand", "Nicolas", DateTime.Now, PainAreaEnum.Genoux);

            database = new SQLiteAsyncConnection(dbPath);
            database.DropTableAsync<User>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.DropTableAsync<Pain>().Wait();
            database.CreateTableAsync<Pain>().Wait();
            database.DropTableAsync<Exercise>().Wait();
            database.CreateTableAsync<Exercise>().Wait();
            database.DropTableAsync<Doctor>().Wait();
            database.CreateTableAsync<Doctor>().Wait();
            database.DropTableAsync<Appointment>().Wait();
            database.CreateTableAsync<Appointment>().Wait();
            database.DropTableAsync<ExercisePrepro>().Wait();
            database.CreateTableAsync<ExercisePrepro>().Wait();

            userRepo = new Repository<User>(database);
            painRepo = new Repository<Pain>(database);
            doctorRepo = new Repository<Doctor>(database);
            exerciseRepo = new Repository<Exercise>(database);
            appointmentRepo = new Repository<Appointment>(database);
            exercisePreproRepo = new Repository<ExercisePrepro>(database);


            userRepo.Insert(admin);
            AddExoProprAsync();
        }

        public void AddExoProprAsync()
        {
            List<ExercisePrepro> exercices = new List<ExercisePrepro>(){
                new ExercisePrepro(){ZonePain ="Dos",Type="3. Apaiser les tensions dorsales", Description="Pour cet exercice, on s'allonge confortablement à terre, mains face au sol, jambes légèrement fléchies et pieds écartés. Il suffit ensuite de visualiser le chiffre 8, puis de reprendre ce simple mouvement avec le menton en veillant à respirer profondément.", ImgName="Arth.png"},
                new ExercisePrepro(){ZonePain ="Dos",Type="2. Assouplir la colonne vertébrale", Description="Lorsque l'on souffre d'arthrose dorsale, il faut absolument prendre le temps de détendre quotidiennement la colonne vertébrale afin de soulager la douleur. Pour cet exercice, on se tient debout, le ventre rentré, le dos bien droit et les pieds légèrement écartés. Il s'agit de rentrer progressivement la tête vers le buste, puis de dérouler les vertèbres les unes après les autres en inspirant profondément. On expire lorsque l'on se redresse très doucement.", ImgName="Arth.png"},
                new ExercisePrepro(){ZonePain ="Dos",Type="1. Tonifier les muscles dorsaux", Description="Assis confortablement en tailleur, on positionne les mains jointes devant la poitrine et on conserve le dos parfaitement droit. On inspire profondément en allongeant la colonne et en effectuant de légères rotations sur le côté avec l'ensemble du buste. L'alignement tête-poitrine-dos doit être parfait. On expire lentement en reprenant la position initiale.", ImgName="Arth.png"}
            };
            exercisePreproRepo.InsertAll(exercices);
        }

    }
}
