using Project.Models;
using SQLite;

namespace Project
{
    public class PersonRepository
    {
        private readonly string _dbPath;
        private SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        private async Task InitAsync()
        {
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteAsyncConnection(_dbPath);

            _ = await conn.CreateTableAsync<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewPersonAsync(string name)
        {
            try
            {
                await InitAsync();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Valid name required");
                }

                int result = await conn.InsertAsync(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            try
            {
                await InitAsync();
                return await conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
