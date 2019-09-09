using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebasMvc.Models
{
    public class Persona
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del empleado")]
        [Required]
        [MinLength(10, ErrorMessage = "Minimo 10 caracteres")]
        [MaxLength(20, ErrorMessage = "maximo 20 caracteres")]
        public string Nombre { get; set; }

        public Profesion Profesion { get; set; }

    }
}