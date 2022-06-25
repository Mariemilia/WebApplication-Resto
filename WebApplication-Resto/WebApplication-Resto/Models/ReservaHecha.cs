using System;
using static WebApplication_Resto.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Resto.Models
{
    public class ReservaHecha : Reserva
    {
       // public int IdComensal { get; set; }
        [DniExistsDB]
        //[Display(Name = "DNI del titular de la reserva: ")]
        //public int DniTitular { get; set; }

        //[Display(Name = "Confirmación de la reserva: ")]
        [EnumDataType(typeof(EstadoReserva))]
        public EstadoReserva EstadoReserva { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ComensalItems { get; set; }
        
    }
}
