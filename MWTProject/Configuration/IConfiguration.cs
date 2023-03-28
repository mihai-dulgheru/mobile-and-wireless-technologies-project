namespace MWTProject.Configuration
{
    public interface IConfiguration
    {
        string GetValue(string key);
    }
}