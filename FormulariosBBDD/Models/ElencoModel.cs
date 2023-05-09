using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class ElencoModel
    {
        [Key]
        public int ID { get; set; }
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
        public EspecialistaModel Especialista { get; set; }
        public int EspecialistaID { get; set; }
    }
}
