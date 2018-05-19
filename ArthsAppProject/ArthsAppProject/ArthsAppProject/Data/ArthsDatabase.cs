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
			admin.Password = "test";

			database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<User>().Wait();
			database.CreateTableAsync<Notification>().Wait();
           
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
