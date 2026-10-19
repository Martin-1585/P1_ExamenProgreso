using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_ExamenProgreso.Models
{
    public class Armadura
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombreArmadura { get; set; }
        [Required]
        public string tipo { get; set; }
        [Range(1,200)]
        public int resistencia { get; set; }
        [Required]
        public int caballeroId { get; set; }
        public virtual Caballero caballero { get; set; }
    }
}