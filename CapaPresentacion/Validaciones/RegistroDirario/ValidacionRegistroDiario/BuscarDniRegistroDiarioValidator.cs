using CapaPresentacion.Validaciones.Login.Datos;
using CapaPresentacion.Validaciones.RegistroDirario.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CapaPresentacion.Validaciones.RegistroDirario.ValidacionRegistroDiario
{
    public class BuscarDniRegistroDiarioValidator : AbstractValidator<RegistroDiarioDatos>
    {
        public BuscarDniRegistroDiarioValidator()
        {
            RuleFor(x => x.txtBuscarDocumento)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para dni.")
                .Must(BeAnInteger).WithMessage("El dni debe ser un numero entero.");
        }

        private bool BeAnInteger(string numero)
        {
            int numerox;
            try
            {
                numerox = int.Parse(numero);
            }
            catch
            {
                return false;
            }

            return numerox % 1 == 0;
        }
    }
}
