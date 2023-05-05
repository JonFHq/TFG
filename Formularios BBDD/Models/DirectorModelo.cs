using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formularios_BBDD.Models
{
    public class DirectorModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TrabajadorModelo Director { get; set; }
        public List<DirectoresPeliculasModelo> DirectoresPeliculas { get; set; }
    }
}
