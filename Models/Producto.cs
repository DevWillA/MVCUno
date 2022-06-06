using System;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Producto
    {
        public int id { get; set; }

        [Required (ErrorMessage ="El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required (ErrorMessage ="La descripción es requerida")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Precio COP")]
        public Decimal Precio { get; set; }
        public bool Activo { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime FechaDeAlta { get; set; }
    }
}