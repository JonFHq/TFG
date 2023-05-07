using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class EspecialistaModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TrabajadorModel Especialista { get; set; }
        public int EspecialistaID { get; set; }
        [Required]
        public EquipoModel Equipo { get; set; }
        public int EquipoID { get; set; }
        public List<ElencoModel> Elencos { get; set; }
    }
}
