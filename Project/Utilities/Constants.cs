﻿namespace Project.Utilities
{
    public static class Constants
    {
        public static string RestUrl = "https://moviesdatabase.p.rapidapi.com/{0}";
        public static string BaseUrl = "https://api.spoonacular.com/{0}";
        public static string DatabaseName = "database.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
    }
}
