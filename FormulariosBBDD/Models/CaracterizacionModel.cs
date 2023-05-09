using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class CaracterizacionModel
    {
        [Key]
        public int ID { get; set; }
        public PersonajeModel Personaje { get; set; }
        public int PersonajeID { get; set; }
        public ActorModel Actor { get; set; }
        public int ActorID { get; set; }
    }
}
