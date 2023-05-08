using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class NacionalidadModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        [ValidateNever]
        public List<TrabajadorModel> Trabajadores { get; set; }
        [ValidateNever]
        public List<PeliculaModel> Peliculas { get; set; }

    }
}
