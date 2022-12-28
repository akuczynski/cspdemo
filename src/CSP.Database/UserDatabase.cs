using CSP.Database;
using CSP.ModuleContracts;
using CSP.ModuleContracts.Database;
using CSP.Users.Contract;
using SQLite;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace TodoSQLite.Data;

public class UserDatabase 
{
    SQLiteAsyncConnection Database;

	//public const SQLite.SQLiteOpenFlags Flags =
	//// open the database in read/write mode
	//SQLite.SQLiteOpenFlags.ReadWrite |
	//// create the database if it doesn't exist
	//SQLite.SQLiteOpenFlags.Create |
	//// enable multi-threaded database access
	//SQLite.SQLiteOpenFlags.SharedCache;

	public UserDatabase()
    { 

	}
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(DbSettings.DatabasePath);
		var result = await Database.CreateTableAsync<User>();
    }

    public async Task<List<User>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<User>().ToListAsync();
    }

    public async Task<User> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(User item)
    {
        await Init();
        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(User item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}