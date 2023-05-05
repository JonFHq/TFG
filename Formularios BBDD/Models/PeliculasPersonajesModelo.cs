using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class PeliculasPersonajesModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PersonajeModelo Personaje { get; set; }
        [Required]
        public PeliculaModelo Pelicula { get; set; }
    }
}
