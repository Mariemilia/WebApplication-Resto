using System.ComponentModel.DataAnnotations;

namespace WebApplication_Resto.Models
{
    public class ReservaHecha : Reserva
    {
        [Display(Name = "Fecha de la reserva:")]
        public string FechaR { get; set; }

        [Display(Name = "Cantidad de mesas reservadas: ")]
        public int MesasReservadas { get; set; }
        
        [Display(Name = "DNI del titular de la reserva: ")]
        public int DniTitular { get; set; }
    }
}
