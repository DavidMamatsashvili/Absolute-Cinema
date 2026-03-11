using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;
using Absolute_Cinema_Backend.Repository.Implementations;
using Absolute_Cinema_Backend.Services.Abstractions;
using Absolute_Cinema_Backend.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//database
builder.Services.AddDbContext<AbsoluteCinemaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//custom services
builder.Services.AddTransient<IGenreRepository,GenreRepository>();
builder.Services.AddTransient<IMovieRepository,MovieRepository>();
builder.Services.AddTransient<IShowtimeRepository, ShowtimeRepository>();
builder.Services.AddTransient<IShowtimeService, ShowtimeService>();

builder.Services.AddTransient<IFilterRepository,FilterRepository>();
builder.Services.AddTransient<IFilterService, FilterService>();

builder.Services.AddScoped<ShowtimeService>();
builder.Services.AddScoped<FilterService>();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<MovieService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
