using FilmSitesi.Models;
using Microsoft.EntityFrameworkCore;
using FilmSitesi.Models;

namespace FilmSitesi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
