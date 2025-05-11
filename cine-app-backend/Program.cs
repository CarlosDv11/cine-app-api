using cine_app_backend.Data;
using cine_app_backend.Repositories;
using cine_app_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registro de dependências
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<MovieService>();

// OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
