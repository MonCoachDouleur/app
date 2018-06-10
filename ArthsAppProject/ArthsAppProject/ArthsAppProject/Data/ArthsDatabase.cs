using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Security.Cryptography;

namespace ArthsAppProject
{
    public class ArthsDatabase
    {
		readonly SQLiteAsyncConnection database;
		private User admin;
		public ArthsDatabase(string dbPath)
        {
			admin = new User();
			admin.Login_u = "test@hotmail.fr";
            admin.Pass_u = Hash.HashSHA512("test");

            database = new SQLiteAsyncConnection(dbPath);
            database.DropTableAsync<User>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.DropTableAsync<Exercise>().Wait();
            database.CreateTableAsync<Exercise>().Wait();
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
        public User GetUserAsync(int id)
        {
			return database.Table<User>().Where(i => i.Id_u.Equals(id)).FirstOrDefaultAsync().Result;
        }

		public User GetUserByLogin(String login){

			return database.Table<User>().Where(i => i.Login_u.Equals(login)).FirstOrDefaultAsync().Result;
		}


    }
}
