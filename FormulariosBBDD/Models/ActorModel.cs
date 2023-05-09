using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulariosBBDD.Models
{
    public class ActorModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TrabajadorModel Actor { get; set; }
        public int ActorID { get; set; }
        // Relaciones Muchos a Muchos
        public List<CaracterizacionModel> Caracterizaciones { get; set; }
    }
}
