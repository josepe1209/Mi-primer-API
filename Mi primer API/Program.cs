using AutoMapper;
using Mi_primer_API.DAL;
using Mi_primer_API.MoviesMapper;
using Mi_primer_API.Repository;
using Mi_primer_API.Repository.IRepository;
using Mi_primer_API.Services;
using Mi_primer_API.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(x => x.AddProfile<Mappers>());

// Dependency Injection for Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Dependency Injection for Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
