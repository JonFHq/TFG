using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class GenerosPeliculasModelo
    {
        [Key]
        public int ID { get; set; }
        public GeneroModelo Genero { get; set; }
        public PeliculaModelo Pelicula { get; set; }
    }
}
