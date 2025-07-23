using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class EditarDDomicilioCiudadanoValidator : AbstractValidator<CiudadanoDatos>
    {
        public EditarDDomicilioCiudadanoValidator()
        {
            RuleFor(x => x.cmbPais)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para pais.")
                .Length(1, 100).WithMessage("El pais debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.cmbProvincia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para provincia.")
                .Length(1, 100).WithMessage("La provincia debe tener entre 1 y 100 caracteres.");
            RuleFor(x => x.cmbDepartamento)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para departamento.")
                .NotEmpty().WithMessage("Debe ingresar un valor para departamento.")
                .Must(BeAnInteger).WithMessage("El departamento debe ser un numero entero.");
            RuleFor(x => x.cmbMunicipio)
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
            RuleFor(x => x.txtDetalleDomicilio)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El motivo edicion del domicilio es obligatorio..")
                .Length(1, 100).WithMessage("El motivo edicion del domicilio debe tener entre 1 y 2000 caracteres.");


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
