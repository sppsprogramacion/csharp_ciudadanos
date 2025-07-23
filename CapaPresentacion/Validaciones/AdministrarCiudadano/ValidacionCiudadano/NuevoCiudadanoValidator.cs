using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class NuevoCiudadanoValidator : AbstractValidator<CiudadanoDatos>
    {
        public NuevoCiudadanoValidator()
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
            RuleFor(x => x.cmbPais)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para pais.")
                .Length(1, 100).WithMessage("El pais debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.cmbProvincia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para provincia.")
                .Length(1, 100).WithMessage("La provincia debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.cmbDepartamento.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para departamento.")
                .Must(BeAnInteger).WithMessage("El departamento debe ser un numero entero.");
            RuleFor(x => x.cmbMunicipio.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para municipio.")
                .Must(BeAnInteger).WithMessage("El municipio debe ser un numero entero.");
            RuleFor(x => x.txtCiudad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La ciudad es obligatoria.")
                .Length(1, 100).WithMessage("La ciudad debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtBarrio)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El barrio es obligatorio.")
                .Length(1, 100).WithMessage("El barrio debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtDireccion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La direccion es obligatoria.")
                .Length(1, 100).WithMessage("La direccion debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtNumeroDominio)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para el dominio.")
                .Must(BeAnInteger).WithMessage("El dominio debe ser un numero entero.");

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
