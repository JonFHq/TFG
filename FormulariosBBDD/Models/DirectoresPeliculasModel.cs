using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class DirectoresPeliculasModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public PeliculaModel Pelicula { get; set; }
        public int PeliculaID { get; set; }
        [Required]
        public DirectorModel Director { get; set; }
        public int DirectorID { get; set; }
    }
}
