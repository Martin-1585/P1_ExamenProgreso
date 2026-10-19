using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_ExamenProgreso.Models
{
    public class Caballero
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string constelacion { get; set; }
        [Range(1,1000)]
        public int nivelPoder { get; set; }
        [Required]
        public string elemento { get; set; }
    }
}