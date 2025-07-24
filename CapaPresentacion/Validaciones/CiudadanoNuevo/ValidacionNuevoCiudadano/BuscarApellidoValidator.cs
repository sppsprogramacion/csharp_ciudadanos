using CapaPresentacion.Validaciones.Login.Datos;
using CapaPresentacion.Validaciones.NuevoCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaPresentacion.Validaciones.NuevoCiudadano.ValidacionNuevoCiudadano
{
    public class BuscarApellidoValidator : AbstractValidator<CiudadanoNuevoDatos>
    {
        public BuscarApellidoValidator()
        {
            
            RuleFor(x => x.txtBuscarApellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Length(1, 16).WithMessage("El apelldio debe tener hasta 16 caracteres");
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
