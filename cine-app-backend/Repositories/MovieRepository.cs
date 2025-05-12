using Dapper;
using cine_app_backend.Models;
using cine_app_backend.Data;

namespace cine_app_backend.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public MovieRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Movie movie)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                INSERT INTO Movies (Title, Genre, DurationMinutes, PosterUrl, Synopsis)
                VALUES (@Title, @Genre, @DurationMinutes, @PosterUrl, @Synopsis);
            ";

            await connection.ExecuteAsync(sql, movie);
        }

        public async Task UpdateAsync(Movie movie)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                UPDATE Movies
                SET Title = @Title,
                    Genre = @Genre,
                    DurationMinutes = @DurationMinutes,
                    PosterUrl = @PosterUrl,
                    Synopsis = @Synopsis
                WHERE Id = @Id;
            ";

            await connection.ExecuteAsync(sql, movie);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = "SELECT * FROM Movies;";

            return await connection.QueryAsync<Movie>(sql);
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = "SELECT * FROM Movies WHERE Id = @Id;";

            return await connection.QueryFirstOrDefaultAsync<Movie>(sql, new { Id = id });
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = "DELETE FROM Movies WHERE Id = @Id;";

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Movie>> SearchAsync(string? genre, string? title)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM Movies WHERE 1 = 1";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(genre))
            {
                sql += " AND Genre LIKE @Genre";
                parameters.Add("Genre", $"%{genre}%");
            }

            if (!string.IsNullOrEmpty(title))
            {
                sql += " AND Title LIKE @Title";
                parameters.Add("Title", $"%{title}%");
            }

            var result = await connection.QueryAsync<Movie>(sql, parameters);
            return result;
        }
    }
}
