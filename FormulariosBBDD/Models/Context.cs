using Microsoft.EntityFrameworkCore;

namespace FormulariosBBDD.Models
{
    public class Context : DbContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ElencoModel>()
            .HasOne(e => e.Pelicula)
            .WithMany(p => p.Elencos)
            .HasForeignKey(e => e.PeliculaID)
            .OnDelete(DeleteBehavior.Restrict);

        }

        public void updateAll()
        {
            // Relaciones de Paises
            foreach (NacionalidadModel pais in Nacionalidades)
            {
                List<TrabajadorModel> trabajadores = new List<TrabajadorModel>();
                foreach (TrabajadorModel trabajador in Trabajadores)
                {
                    if (trabajador.NacionalidadID == pais.ID)
                    {
                        trabajadores.Add(trabajador);
                        trabajador.Nacionalidad = pais;
                    }
                }
                pais.Trabajadores = trabajadores;

                List<PeliculaModel> peliculas = new List<PeliculaModel>();
                foreach (PeliculaModel pelicula in Peliculas)
                {
                    if (pelicula.PaisID == pais.ID)
                    {
                        peliculas.Add(pelicula);
                        pelicula.Pais = pais;
                    }
                }
                pais.Peliculas = peliculas;
            }

            // Relaciones de Trabajadores
            foreach (TrabajadorModel trabajador in Trabajadores)
            {
                foreach (ActorModel actor in Actores)
                {
                    if (actor.ActorID == trabajador.ID)
                    {
                        trabajador.Actor = true;
                        actor.Actor = trabajador;
                        actor.ActorID = trabajador.ID;
                        break;
                    }
                }

                trabajador.Equipos = new List<int>();
                foreach (EspecialistaModel especialista in Especialistas)
                {
                    if (especialista.EspecialistaID == trabajador.ID)
                    {
                        trabajador.Especialista = true;
                        especialista.Especialista = trabajador;
                        especialista.EspecialistaID = trabajador.ID;
                        trabajador.Equipos.Add(especialista.EquipoID);
                    }
                }
            }

            // Relaciones de Equipos
            foreach (EquipoModel equipo in Equipos)
            {
                List<EspecialistaModel> especialistas = new List<EspecialistaModel>();
                foreach (EspecialistaModel especialista in Especialistas)
                {
                    if (especialista.EquipoID == equipo.ID)
                    {
                        especialistas.Add(especialista);
                        especialista.Equipo = equipo;
                    }
                }
                equipo.Especialistas = especialistas;
            }

            // Relaciones de Generos
            foreach (GeneroModel genero in Generos)
            {
                List<GenerosPeliculasModel> generosPeliculas = new List<GenerosPeliculasModel>();
                foreach (GenerosPeliculasModel generoPelicula in GenerosPeliculas)
                {
                    if (generoPelicula.GeneroID == genero.ID)
                    {
                        generosPeliculas.Add(generoPelicula);
                        generoPelicula.Genero = genero;
                    }
                }
                genero.GenerosPeliculas = generosPeliculas;
            }

            // Relaciones de Actores
            foreach (ActorModel actor in Actores)
            {
                List<CaracterizacionModel> caracterizaciones = new List<CaracterizacionModel>();
                foreach (CaracterizacionModel caracterizacion in Caracterizaciones)
                {
                    if (caracterizacion.ActorID == actor.ID)
                    {
                        caracterizaciones.Add(caracterizacion);
                        caracterizacion.Actor = actor;
                    }
                }
                actor.Caracterizaciones = caracterizaciones;
            }

            // Relaciones de Personajes
            foreach (PersonajeModel personaje in Personajes)
            {
                List<RepartoModel> repartos = new List<RepartoModel>();
                foreach (RepartoModel reparto in Repartos)
                {
                    if (reparto.PersonajeID == personaje.ID)
                    {
                        repartos.Add(reparto);
                        reparto.Personaje = personaje;
                    }
                }
                personaje.PeliculasPersonajes = repartos;
            }

            // Relaciones de Peliculas
            foreach (PeliculaModel pelicula in Peliculas)
            {
                List<GenerosPeliculasModel> generosPeliculas = new List<GenerosPeliculasModel>();
                foreach (GenerosPeliculasModel generoPelicula in GenerosPeliculas)
                {
                    if (generoPelicula.PeliculaID == pelicula.ID)
                    {
                        generosPeliculas.Add(generoPelicula);
                        generoPelicula.Pelicula = pelicula;
                    }
                }
                pelicula.GenerosPeliculas = generosPeliculas;

                List<RepartoModel> repartos = new List<RepartoModel>();
                foreach (RepartoModel reparto in Repartos)
                {
                    if (reparto.PeliculaID == pelicula.ID)
                    {
                        repartos.Add(reparto);
                        reparto.Pelicula = pelicula;
                    }
                }
                pelicula.PeliculasPersonajes = repartos;
            }

        }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<NacionalidadModel> Nacionalidades { get; set; }
        public DbSet<TrabajadorModel> Trabajadores { get; set; }
        public DbSet<ActorModel> Actores { get; set; }
        public DbSet<EquipoModel> Equipos { get; set; }
        public DbSet<EspecialistaModel> Especialistas { get; set; }
        public DbSet<GeneroModel> Generos { get; set; }
        public DbSet<PeliculaModel> Peliculas { get; set; }
        public DbSet<PersonajeModel> Personajes { get; set; }
        public DbSet<GenerosPeliculasModel> GenerosPeliculas { get; set; }
        public DbSet<RepartoModel> Repartos { get; set; }
        public DbSet<CaracterizacionModel> Caracterizaciones { get; set; }
        public DbSet<ElencoModel> Elencos { get; set; }
    }
}
