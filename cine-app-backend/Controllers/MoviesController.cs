using cine_app_backend.Dtos;
using cine_app_backend.DTOs.Movie;
using cine_app_backend.Models;
using Microsoft.AspNetCore.Mvc;
using cine_app_backend.Services;

namespace cine_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Movie data is required");
            }

            try
            {
                await _movieService.CreateAsync(dto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the movie.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MovieUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Movie data is required");
            }

            try
            {
                await _movieService.UpdateAsync(dto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the movie.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            try
            {
                var movies = await _movieService.GetAllAsync();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the movies.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            try
            {
                var movie = await _movieService.GetByIdAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the movie.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _movieService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the movie.");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Movie>>> Search([FromQuery] string? genre, [FromQuery] string? title)
        {
            try
            {
                var movies = await _movieService.SearchAsync(genre, title);
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while searching for movies.");
            }
        }
    }
}
