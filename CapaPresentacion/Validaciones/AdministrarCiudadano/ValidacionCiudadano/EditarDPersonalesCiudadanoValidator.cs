using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class EditarDPersonalesCiudadanoValidator : AbstractValidator<CiudadanoDatos>
    {
        public EditarDPersonalesCiudadanoValidator()
        {
            RuleFor(x => x.txtDni)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para dni.")
                .Must(BeAnInteger).WithMessage("El dni debe ser un numero entero.");
            RuleFor(x => x.txtApellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Length(1, 100).WithMessage("El apellido debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtNombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(1, 100).WithMessage("El nombre debe tener maximo 100 caracteres.");
            RuleFor(x => x.cmbSexo.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para sexo.")
                .Must(BeAnInteger).WithMessage("El sexo debe ser un numero entero.");
            RuleFor(x => x.dtpickFechaNacimiento.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria");
            //.Must(BeAValidDate).WithMessage("La fecha de inicio no es valida.");
            RuleFor(x => x.txtTelefono)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El telefono es obligatorio.")
                .Length(1, 100).WithMessage("El telefono debe tener maximo 100 caracteres.");
            RuleFor(x => x.cmbEstadoCivil.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para estado civil.")
                .Must(BeAnInteger).WithMessage("El estado civil debe ser un numero entero.");
            RuleFor(x => x.cmbNacionalidad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para nacionalidad.")
                .Length(1, 100).WithMessage("La nacionalidad debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.txtDetalleMotivo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El motivo edicion es obligatorio..")
                .Length(1, 2000).WithMessage("El motivo edicion debe tener entre 1 y 2000 caracteres.");
            
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
