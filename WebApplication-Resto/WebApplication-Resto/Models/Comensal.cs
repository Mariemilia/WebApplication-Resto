using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static WebApplication_Resto.Models.Validations;

namespace WebApplication_Resto.Models
{
    public class Comensal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El nombre debe tener como máximo 30 caracteres.")]
        [RegularExpression("^[a-zA-Z\u00F1\u00D1]+$", ErrorMessage = "El nombre solo debe contener letras.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El apellido debe tener como máximo 30 caracteres.")]
        [RegularExpression("^[a-zA-Z\u00F1\u00D1]+$", ErrorMessage = "El apellido solo debe contener letras.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [Range(90000, 100000000, ErrorMessage = "El documento debe tener al menos 6 caracteres y como máximo 9.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El documento solo debe contener números.")]
        [DniExistsAtributte]
        [Display(Name = "DNI")]
        public int Dni { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Teléfono de contacto inválido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo debe contener números.")]
        [Display(Name = "Telefono de contacto")]
        public int NroCelular { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo no puede quedar vacío.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El E-mail no es válido.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

    }
}
