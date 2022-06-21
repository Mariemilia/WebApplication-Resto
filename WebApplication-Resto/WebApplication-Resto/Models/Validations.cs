using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Resto.Models
{
    public class Validations
    {
        public class DniExistsAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new RestoDatabaseContext())
                {
                    int Dni = (int)value;
                    if (context.Comensales.Any(e => e.Dni == Dni)) //probar usando any
                    {
                        return new ValidationResult("El usuario ya está registrado en el sistema.");
                    }
                }
                return ValidationResult.Success;
            }
        }

        public class DniExistsDB : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new RestoDatabaseContext())
                {
                    
                    int Dni = (int)value;
                    Boolean documentoExists = context.Comensales.Any(e => e.Dni == Dni);
                    if (documentoExists) //probar usando any
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("El paciente no está registrado en sistema. Deberá registrarse.");
                    }
                }
                
            }
        }

        public class ReservaExistsAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new RestoDatabaseContext())
                {
                    int IdReserva = (int)value;
                    if (context.RegistroReservas.Any(e => e.IdReserva == IdReserva)) 
                    {
                        return new ValidationResult("La reserva ya está registrada en el sistema.");
                    }
                }
                return ValidationResult.Success;
            }
        }

    }
}
