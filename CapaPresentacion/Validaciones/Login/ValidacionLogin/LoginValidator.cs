﻿using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.Login.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.Login.ValidacionLogin
{
    public class LoginValidator : AbstractValidator<LoginDatos>
    {
        public LoginValidator() {

            RuleFor(x => x.txtUsuario)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para usuario.")
                .Must(BeAnInteger).WithMessage("El usuario debe ser un numero entero.");
            RuleFor(x => x.txtPasword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El password es obligatorio.")
                .Length(1, 16).WithMessage("El password debe tener hasta 16 caracteres");
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
