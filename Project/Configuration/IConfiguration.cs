namespace Project.Configuration
{
    public interface IConfiguration
    {
        string GetValue(string key);
    }
}