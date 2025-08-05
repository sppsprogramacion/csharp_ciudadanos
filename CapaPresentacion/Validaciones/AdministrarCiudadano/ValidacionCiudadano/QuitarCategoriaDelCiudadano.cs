using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class QuitarCategoriaDelCiudadano : AbstractValidator<CiudadanoDatos>
    {

        public QuitarCategoriaDelCiudadano()
        {

            RuleFor(x => x.txtDetalleCategoriaQuitar)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El detalle es obligatorio.")
                .Length(1, 2000).WithMessage("El detalle debe tener entre 1 y 2000 caracteres.");
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
