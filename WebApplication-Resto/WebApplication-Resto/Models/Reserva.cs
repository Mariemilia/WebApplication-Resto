using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static WebApplication_Resto.Models.Validations;

namespace WebApplication_Resto.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdComensal { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El apellido debe tener como máximo 30 caracteres.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El apellido solo debe contener letras.")]
        [Display(Name = "Apellido del titular")]
        public string ApellidoTitular { get; set; }

        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [Range(90000, 100000000, ErrorMessage = "El documento debe tener al menos 6 caracteres y como máximo 9.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El documento solo debe contener números.")]
        [DniExistsAtributte]
        [Display(Name = "DNI del titular")]
        public int DniTitular { get; set; }

        [Display(Name = "Confirmación de la reserva")]
        [EnumDataType(typeof(EstadoReserva))]
        public EstadoReserva EstadoR { get; set; }

        [Display(Name = "Cantidad de personas")]
        public int CantComensales { get; set; }
        [Display(Name = "Fecha y hora")]
        public DateTime FechaReserva { get; set; }
    }
}
