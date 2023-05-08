﻿using System.ComponentModel.DataAnnotations;

namespace FormulariosBBDD.Models
{
    public class GeneroModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(25)]
        public string Genero { get; set; }
        public List<GenerosPeliculasModel> GenerosPeliculas { get; set; }
    }
}
