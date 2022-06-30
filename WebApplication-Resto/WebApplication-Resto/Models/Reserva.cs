using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static WebApplication_Resto.Models.Validations;

namespace WebApplication_Resto.Models
{
    [ReservaExists]
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdComensal { get; set; }
        [Required(ErrorMessage ="El campo no puede quedar vacío.")]
        [Display(Name = "Apellido del titular")]
        public string ApellidoTitular { get; set; }

        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [DniExistsDB]
        [Display(Name = "DNI del titular")]
        public int DniTitular { get; set; }

        //[Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [Display(Name = "Cantidad de personas")]
        public int CantComensales { get; set; }

        [ValidDateAtributte]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y hora")]
        public DateTime FechaReserva { get; set; }

        [Display(Name = "Confirmación de la reserva")]
        [EnumDataType(typeof(EstadoReserva))]
        public EstadoReserva EstadoR { get; set; }
    }
}
