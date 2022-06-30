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
                        return new ValidationResult("El usuario no está registrado en sistema. Deberá registrarse.");
                    }
                }

            }
        }
        public class ReservaExists : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                using (var context = new RestoDatabaseContext())
                {
                    Reserva r = (Reserva)value;
                    string Apellido = r.ApellidoTitular;
                    int Dni = r.DniTitular;
                    int CantCom = r.CantComensales;
                    DateTime DiaHora = r.FechaReserva;
                    EstadoReserva EstRes = r.EstadoR;

                    if (context.Reservas.Any(e => e.ApellidoTitular == Apellido && e.DniTitular == Dni &&
                     e.CantComensales == CantCom && e.FechaReserva == DiaHora && e.EstadoR == EstRes))
                    {
                     
                        return new ValidationResult("La reserva ya está registrada en el sistema.");
                    }
                }
                return ValidationResult.Success;
            }
        }
        public class ValidDateAtributte : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime fechaIngresada = (DateTime)value;
                DateTime date = DateTime.Now;
                if (fechaIngresada < date)
                {
                    return new ValidationResult("La fecha no puede ser menor al día actual.");
                }
                return ValidationResult.Success;
            }
        }

    }
}
