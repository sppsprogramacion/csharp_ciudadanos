using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class NovedadNuevaValidator : AbstractValidator<CiudadanoDatos>
    {
        public NovedadNuevaValidator()
        {

            RuleFor(x => x.txtIdCiudadano.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id_ciudadano.")
                .Must(BeAnInteger).WithMessage("El id_ciudadano debe ser un numero entero.");
            RuleFor(x => x.txtNuevaNovedad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El detalle es obligatorio.")
                .Length(1, 2000).WithMessage("El detalle debe tener maximo 2000 caracteres.");

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
