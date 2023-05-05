using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formularios_BBDD.Models
{
    public class ActorModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TrabajadorModelo Actor { get; set; }
        // Relaciones Muchos a Muchos
        public List<RepartoModelo> Repartos { get; set; }
        public List<CaracterizacionModelo> Caracterizaciones { get; set; }
    }
}
