using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class GenerosPeliculasModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public GeneroModel Genero { get; set; }
        public int GeneroID { get; set; }
        [Required]
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
    }
}
