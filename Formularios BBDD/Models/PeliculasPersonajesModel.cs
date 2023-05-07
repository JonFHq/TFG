using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class PeliculasPersonajesModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PersonajeModel Personaje { get; set; }
        public int PersonajeID { get; set; }
        [Required]
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
    }
}
