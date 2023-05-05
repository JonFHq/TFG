using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formularios_BBDD.Models
{
    public class RepartoModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PeliculaModelo Pelicula { get; set; }
        [Required]
        public ActorModelo Actor { get; set; }
    }
}
