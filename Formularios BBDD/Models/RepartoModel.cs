using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formularios_BBDD.Models
{
    public class RepartoModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
        [Required]
        public ActorModel Actor { get; set; }
        public int ActorID { get; set; }
    }
}
