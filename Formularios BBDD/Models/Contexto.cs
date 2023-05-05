using Microsoft.EntityFrameworkCore;

namespace Formularios_BBDD.Models
{
    public class Contexto : DbContext
    {
        
        public Contexto(DbContextOptions<Contexto> options): base(options) 
        {
            
        }
        public DbSet<ActorModelo> Actores { get; set; }
        public DbSet<DirectorModelo> Directores { get; set; }
        public DbSet<GeneroModelo> Generos { get; set; }
        public DbSet<NacionalidadModelo> Nacionalidades { get; set; }
        public DbSet<PeliculaModelo> Peliculas { get; set; }
        public DbSet<PersonajeModelo> Personajes { get; set; }
        public DbSet<TrabajadorModelo> Trabajadores { get; set; }
        public DbSet<RepartoModelo> Repartos { get; set; }
        public DbSet<GenerosPeliculasModelo> GenerosPeliculas { get; set; }
        public DbSet<DirectoresPeliculasModelo> DirectoresPeliculas { get; set; }
        public DbSet<PeliculasPersonajesModelo> PeliculasPersonajes { get; set; }
        public DbSet<CaracterizacionModelo> Caracterizaciones { get; set; }
    }
}
