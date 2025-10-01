using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class VincularVisitaMenorValidator : AbstractValidator<CiudadanoDatos>
    {

        public VincularVisitaMenorValidator()
        {
            RuleFor(x => x.txtIdCiudadano)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id de visita.")
                .Must(BeAnInteger).WithMessage("El id de visita debe ser un numero.");
            RuleFor(x => x.txtIdCiudadanoMenor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe seleccionar un menor.")
                .Must(BeAnInteger).WithMessage("El id de menor debe ser un numero.");
            RuleFor(x => x.cmbParentescosMenor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para parentesco.")
                .Length(1, 20).WithMessage("El identificador de parentesco debe tener entre 1 y 20 caracteres.");
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
