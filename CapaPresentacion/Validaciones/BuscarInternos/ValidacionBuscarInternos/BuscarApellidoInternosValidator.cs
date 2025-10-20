using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.BuscarInternos.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.BuscarInternos.ValidacionBuscarInternos
{
    public class BuscarApellidoInternosValidator : AbstractValidator<BuscarInternosDatos>
    {
        public BuscarApellidoInternosValidator()
        {
                         
            RuleFor(x => x.txtBuscarApellidoInternos)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio..")
                .Length(1, 100).WithMessage("El apellido debe tener entre 1 y 100 caracteres.");
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
