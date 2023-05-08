using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulariosBBDD.Models
{
    public class DirectorModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TrabajadorModel Director { get; set; }
        public int DirectorID { get; set; }
        public List<DirectoresPeliculasModel> DirectoresPeliculas { get; set; }
    }
}
