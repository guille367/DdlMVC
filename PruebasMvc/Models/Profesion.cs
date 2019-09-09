using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebasMvc.Models
{
    public class Profesion
    {
        public int Id { get; set; }
        //[MinLength(1)]
        public IList<Trabajo> Trabajos { get; set; }
        public IList<int> TrabajosId { get; set; }

        public Profesion()
        {
            this.Id = 1;
            this.Trabajos = new List<Trabajo>();
        }
    }
}