﻿namespace Project.Utilities
{
    public static class Constants
    {
        public static string DatabaseFilename = "Database.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public static string RestUrl = "https://moviesdatabase.p.rapidapi.com/{0}";
        public static string BaseUrl = "https://api.spoonacular.com/{0}";
    }
}
