using System;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Pelicula> Pelicula { get; set; }
    public DbSet<Serie> Serie { get; set; }
    public DbSet<Genero> Genero { get; set; }
    public DbSet<Favoritos> Favoritos { get; set; }
    public DbSet<Visualizacion> Visualizacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}