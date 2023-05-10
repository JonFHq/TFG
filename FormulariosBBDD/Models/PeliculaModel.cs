using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class PeliculaModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        public int PEGI { get; set; }
        [Required]
        public DateTime Estreno { get; set; }
        [Required]
        public TimeSpan Duracion { get; set; }
        public NacionalidadModel Pais { get; set; }
        public int PaisID { get; set; }
        public float Nota { get; set; }
        [DataType(DataType.Text)]
        public string Sinopsis { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Cartel { get; set; }
        [DataType(DataType.Url)]
        public string Trailer { get; set; }

        // Relaciones Muchos a Muchos
        public List<RepartoModel> PeliculasPersonajes { get; set; }
        public List<GenerosPeliculasModel> GenerosPeliculas { get; set; }
        public List<ElencoModel> Elencos { get; set; }
    }
}
