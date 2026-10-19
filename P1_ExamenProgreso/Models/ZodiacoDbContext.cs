using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace P1_ExamenProgreso.Models
{
    public class ZodiacoDbContext : DbContext
    {
        public ZodiacoDbContext() : base("name=ZodiacoDbContext") { }
        public DbSet<Caballero> caballeros { get; set; }
        public DbSet<Armadura> armaduras { get; set; }
    }
}