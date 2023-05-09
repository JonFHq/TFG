using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class RepartoModel
    {
        [Key]
        public int ID { get; set; }
        public PersonajeModel Personaje { get; set; }
        public int PersonajeID { get; set; }
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
    }
}
