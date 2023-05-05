using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class DirectoresPeliculasModelo
    {
        [Key]
        public int ID { get; set; }
        public PeliculaModelo Pelicula { get; set; }
        public DirectorModelo Director { get; set; }
    }
}
