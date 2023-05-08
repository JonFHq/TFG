using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class EquipoModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Equipo { get; set; }
        [ValidateNever]
        public List<EspecialistaModel> Especialistas { get; set; }
    }
}
