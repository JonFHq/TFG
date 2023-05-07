using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class CaracterizacionModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PersonajeModel Personaje { get; set; }
        public int PersonajeID { get; set; }
        [Required]
        public ActorModel Actor { get; set; }
        public int ActorID { get; set; }
    }
}
