namespace Project.Utilities
{
    public static class Constants
    {
        public static readonly string APIKey ="";
        public static readonly string DatabaseFilename = "Database.db3";
        public static readonly SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
        public static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public static readonly string RestUrl = "https://moviesdatabase.p.rapidapi.com/{0}";
        public static readonly string BaseUrl = "https://api.spoonacular.com/{0}";
    }
}
