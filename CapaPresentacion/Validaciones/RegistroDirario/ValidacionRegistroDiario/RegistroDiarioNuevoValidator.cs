using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.RegistroDirario.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.RegistroDirario.ValidacionRegistroDiario
{
    public class RegistroDiarioNuevoValidator : AbstractValidator<RegistroDiarioDatos>
    {
        public RegistroDiarioNuevoValidator()
        {
            RuleFor(x => x.txtIdCiudadanoIngreso)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe seleccionar el ciudadano.")
                .Must(BeAnInteger).WithMessage("Debe seleccionar el ciudadano.");
            RuleFor(x => x.cmbTipoAtencion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id.")
                .Must(BeAnInteger).WithMessage("El tipo de atencion debe ser un numero entero.");
            RuleFor(x => x.cmbTipoAcceso)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id.")
                .Must(BeAnInteger).WithMessage("El tipo de acceso debe ser un numero entero.");
            RuleFor(x => x.txtBuscarInternos)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("El nombre de interno debe tener maximo 200 caracteres.");
            

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
