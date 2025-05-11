using cine_app_backend.Dtos;
using cine_app_backend.DTOs.Movie;
using cine_app_backend.Models;
using cine_app_backend.Repositories;

namespace cine_app_backend.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task CreateAsync(MovieCreateDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Genre = dto.Genre,
                DurationMinutes = dto.DurationMinutes,
                PosterUrl = dto.PosterUrl,
                Synopsis = dto.Synopsis
            };

            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(MovieUpdateDto dto)
        {
            var movie = new Movie
            {
                Id = dto.Id,
                Title = dto.Title,
                Genre = dto.Genre,
                DurationMinutes = dto.DurationMinutes,
                PosterUrl = dto.PosterUrl,
                Synopsis = dto.Synopsis
            };

            await _movieRepository.UpdateAsync(movie);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
    }
}
