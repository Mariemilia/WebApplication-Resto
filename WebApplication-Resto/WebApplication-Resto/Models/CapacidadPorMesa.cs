using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Resto.Models
{
    public enum CapacidadPorMesa
    {
        [Display(Name = "2")]
        Dos,
        [Display(Name = "4")]
        Cuatro,
    }
}
