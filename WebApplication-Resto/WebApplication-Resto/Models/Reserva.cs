using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication_Resto.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdComensal { get; set; }
        
        [Display(Name = "Titular de la reserva: ")]
        public string ApellidoTitular { get; set; }

        //[Display(Name = "Confirmación de la reserva: ")]
        //[EnumDataType(typeof(EstadoReserva))]
        //public EstadoReserva EstadoR { get; set; }

        [Display(Name = "Cantidad de comensales que asitirán: ")]
        public int CantComensales { get; set; }
        [Display(Name = "Fecha y hora de la reserva: ")]
        public DateTime FechaReserva { get; set; }
    }
}
