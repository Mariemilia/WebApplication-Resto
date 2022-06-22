using System;
using static WebApplication_Resto.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication_Resto.Models
{
    public class ReservaHecha : Reserva
    {
        [Display(Name = "Fecha y hora de la reserva:")]
        public DateTime FechaR { get; set; }
        [Display(Name = "Cantidad de mesas reservadas: ")]
        public int MesasReservadas { get; set; }

        [DniExistsDB]
        [Display(Name = "DNI del titular de la reserva: ")]
        public int DniTitular { get; set; } }
       // public IEnumerable<SelectListItem> ReservaItems { get; set; }

}
