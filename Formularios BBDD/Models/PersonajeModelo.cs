using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class PersonajeModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<PeliculasPersonajesModelo> PeliculasPersonajes { get; set; }
        public List<CaracterizacionModelo> Caracterizaciones { get; set; }
    }
}
