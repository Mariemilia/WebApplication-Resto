using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Resto.Models
{
    public enum Horario
    {
        [Display(Name = "20:00")]
        Ocho,
        [Display(Name = "20:30")]
        OchoTreinta,
        [Display(Name = "21:00")]
        Nueve,
        [Display(Name = "21:30")]
        NueveTreinta,
        [Display(Name = "22:00")]
        Diez,
        [Display(Name = "22:30")]
        DiezTreinta,
        [Display(Name = "23:00")]
        Once,
        [Display(Name = "23:30")]
        OnceTreinta,
        [Display(Name = "24:00")]
        Doce,
        [Display(Name = "24:30")]
        DoceTreinta,
        [Display(Name = "1:00")]
        Una
    }
}
