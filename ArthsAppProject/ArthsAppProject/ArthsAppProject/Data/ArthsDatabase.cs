using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Security.Cryptography;
using System.Linq;

namespace ArthsAppProject
{
    public class ArthsDatabase
    {
		readonly SQLiteAsyncConnection database;
		private User admin;
		public ArthsDatabase(string dbPath)
        {
			admin = new User("test@hotmail.fr", "test");

            database = new SQLiteAsyncConnection(dbPath);
            database.DropTableAsync<User>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.DropTableAsync<Exercise>().Wait();
            database.CreateTableAsync<Exercise>().Wait();
            database.DropTableAsync<Doctor>().Wait();
            database.CreateTableAsync<Doctor>().Wait();
            SaveUserAsync(admin);
        }

       

        public int SaveUserAsync(User user)
        {
            if (user.Id_u != 0)
            {
                return database.UpdateAsync(user).Result;
            }
            else
            {
                return database.InsertAsync(user).Result;
            }
        }

        public int SaveExoAsync(Exercise exercise)
        {
                return database.InsertAsync(exercise).Result;
        }

        public int SaveAsync(Object tableName)
        {
            return database.InsertAsync(tableName).Result;
        }
        public User GetUserAsync(int id)
        {
			return database.Table<User>().Where(i => i.Id_u.Equals(id)).FirstOrDefaultAsync().Result;
        }

		public User GetUserByLogin(String login){

			return database.Table<User>().Where(i => i.Login_u.Equals(login)).FirstOrDefaultAsync().Result;
		}

        public Doctor GetDoctorByUserId(int userId)
        {
            return database.Table<Doctor>().Where(i => i.user_id.Equals(userId)).FirstOrDefaultAsync().Result;
        }

        public List<Exercise> GetListExosAsync(int user_id)
       {
            string test = "SELECT * FROM Exercise";
            return database.QueryAsync<Exercise>(test).Result.ToList();
        }
    }
}
