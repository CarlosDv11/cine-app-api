using cine_app_backend.Models;

namespace cine_app_backend.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<Movie>> SearchAsync(string? genre, string? title);
    }
}
