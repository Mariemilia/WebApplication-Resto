using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication_Resto.Models
{
   public class Mesa
    {
        [Display(Name = "N° de mesa: ")]
        [Key]
        public int IdMesa { get; set; }
        [Display(Name = "Cantidad de personas por mesa: ")]
        public int Capacidad { get; set; }
        [Display(Name = "Estado de la mesa: ")]
        [EnumDataType(typeof(EstadoMesa))]
        public EstadoMesa EstadoM { get; set; }
    }
}
