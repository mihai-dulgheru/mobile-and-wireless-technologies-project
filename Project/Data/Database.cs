using Project.Utilities;
using SQLite;

namespace Project.Data
{
    internal class Database
    {
        private readonly string filename = Constants.DatabaseName;
        private SQLiteAsyncConnection connection;

        public async Task InitializeAsync()
        {
            if (connection is null)
            {
                string databasePath = Path.Combine(FileSystem.AppDataDirectory, filename);
                SQLiteOpenFlags openFlags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(databasePath, openFlags);
                _ = await connection.CreateTableAsync<User>();
            }
        }

        public async Task<int> AddNewUserAsync(User user)
        {
            int result = await connection.InsertAsync(user);
            return result;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = await connection.Table<User>().ToListAsync();
            return users;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            AsyncTableQuery<User> user = from u in connection.Table<User>()
                                         where u.Username == username
                                         select u;
            return await user.FirstOrDefaultAsync();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            int result = await connection.UpdateAsync(user);
            return result;
        }

        public async Task<int> DeleteUserAsync(int userID)
        {
            int result = await connection.DeleteAsync<User>(userID);
            return result;
        }
    }
}
