using MWTProject.Data;

namespace MWTProject.Services
{
    public interface IRestService
    {
        List<Movie> Movies { get; }

        Task<List<Movie>> RefreshDataAsync();
    }
}