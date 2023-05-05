using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class PeliculaModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        public int PEGI { get; set; }
        [Required]
        public NacionalidadModelo Pais { get; set; }
        public int Nota { get; set; }
        public string Duracion { get; set; }

        // Relaciones Muchos a Muchos
        public List<RepartoModelo> Repartos { get; set; }
        public List<PeliculasPersonajesModelo> PeliculasPersonajes { get; set; }
        public List<GenerosPeliculasModelo> GenerosPeliculas { get; set; }
        public List<DirectoresPeliculasModelo> DirectoresPeliculas { get; set; }
    }
}
