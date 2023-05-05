using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class CaracterizacionModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PersonajeModelo Personaje { get; set; }
        [Required]
        public ActorModelo Actor { get; set; }
    }
}
