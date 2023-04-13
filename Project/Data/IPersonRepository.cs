using Project.Models;

namespace Project.Data
{
    public interface IPersonRepository
    {
        string StatusMessage { get; set; }

        Task AddNewPersonAsync(string name);
        Task<List<Person>> GetAllPeopleAsync();
    }
}