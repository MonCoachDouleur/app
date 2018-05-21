using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ArthsAppProject
{
    public class ArthsDatabase
    {
		readonly SQLiteAsyncConnection database;
		private User admin;
        
		public ArthsDatabase(string dbPath)
        {
            admin = new User();
            admin.Login = "test";
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            SaveUserAsync(admin);
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<User> GetUserAsync(int id)
        {
			return database.Table<User>().Where(i => i.ID.Equals(id)).FirstOrDefaultAsync();
        }

		public Task<User> GetUserByLogin(String login){

			return database.Table<User>().Where(i => i.Login.Equals(login)).FirstOrDefaultAsync();
		}


    }
}
