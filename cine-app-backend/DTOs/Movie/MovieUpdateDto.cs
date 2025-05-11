namespace cine_app_backend.Dtos
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public string? PosterUrl { get; set; }
        public string? Synopsis { get; set; }
    }
}
