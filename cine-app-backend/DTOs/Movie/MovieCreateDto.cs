namespace cine_app_backend.DTOs.Movie
{
    public class MovieCreateDto
    {
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public string? PosterUrl { get; set; }
        public string? Synopsis { get; set; }
    }
}
