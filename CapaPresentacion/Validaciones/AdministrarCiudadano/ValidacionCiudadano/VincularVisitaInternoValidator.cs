﻿using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano
{
    public class VincularVisitaInternoValidator : AbstractValidator<CiudadanoDatos>
    {

        public VincularVisitaInternoValidator()
        {
            RuleFor(x => x.txtIdVisita)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id de visita.")
                .Must(BeAnInteger).WithMessage("El id de visita debe ser un numero.");
            RuleFor(x => x.txtIdInterno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id de interno.")
                .Must(BeAnInteger).WithMessage("El id de interno debe ser un numero.");
            RuleFor(x => x.cmbParentesco.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para parentesco.")
                .Must(BeAnInteger).WithMessage("El id de parentesco debe ser un numero.");
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
