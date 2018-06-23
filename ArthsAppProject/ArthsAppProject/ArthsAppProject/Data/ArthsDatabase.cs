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

        readonly SQLiteAsyncConnection database;
        private User admin;
		public ArthsDatabase(string dbPath)
        {
            admin = new User("test@hotmail.fr", "test");

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

            userRepo = new Repository<User>(database);
            painRepo = new Repository<Pain>(database);
            doctorRepo = new Repository<Doctor>(database);
            exerciseRepo = new Repository<Exercise>(database);
            appointmentRepo = new Repository<Appointment>(database);

            userRepo.Insert(admin);
        }

    }
}
