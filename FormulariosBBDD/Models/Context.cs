using Microsoft.EntityFrameworkCore;

namespace FormulariosBBDD.Models
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public Context(DbContextOptions<Context> options): base(options) { }

        public DbSet<NacionalidadModel> Nacionalidades { get; set; }
        public DbSet<TrabajadorModel> Trabajadores { get; set; }
        public DbSet<ActorModel> Actores { get; set; }
        public DbSet<DirectorModel> Directores { get; set; }
        public DbSet<EquipoModel> Equipos { get; set; }
        public DbSet<EspecialistaModel> Especialistas { get; set; }
        public DbSet<GeneroModel> Generos { get; set; }
        public DbSet<PeliculaModel> Peliculas { get; set; }
        public DbSet<PersonajeModel> Personajes { get; set; }
        public DbSet<RepartoModel> Repartos { get; set; }
        public DbSet<GenerosPeliculasModel> GenerosPeliculas { get; set; }
        public DbSet<DirectoresPeliculasModel> DirectoresPeliculas { get; set; }
        public DbSet<PeliculasPersonajesModel> PeliculasPersonajes { get; set; }
        public DbSet<CaracterizacionModel> Caracterizaciones { get; set; }
        public DbSet<ElencoModel> Elencos { get; set; }
    }
}
