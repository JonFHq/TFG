using FormulariosBBDD.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FormulariosBBDD.Models
{
    public class TrabajadorModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [ValidateNever]
        public NacionalidadModel Nacionalidad { get; set; }
        [Required]
        public int NacionalidadID { get; set; }
        [NotMapped]
        public bool Actor { get; set; }
        [NotMapped]
        public bool Especialista { get; set; }
        [NotMapped]
        [ValidateNever]
        public List<int> Equipos { get; set; }
    }
}
