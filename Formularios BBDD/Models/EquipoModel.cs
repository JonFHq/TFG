using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class EquipoModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Equipo { get; set; }
        public List<EspecialistaModel> Especialistas { get; set; }
    }
}
