using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class PersonajeModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        public List<PeliculasPersonajesModel> PeliculasPersonajes { get; set; }
        public List<CaracterizacionModel> Caracterizaciones { get; set; }
    }
}
