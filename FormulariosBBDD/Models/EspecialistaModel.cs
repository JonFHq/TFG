using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class EspecialistaModel
    {
        [Key]
        public int ID { get; set; }
        public TrabajadorModel Especialista { get; set; }
        public int EspecialistaID { get; set; }
        public EquipoModel Equipo { get; set; }
        public int EquipoID { get; set; }
        public List<ElencoModel> Elencos { get; set; }
    }
}
