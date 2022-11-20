using ActividadSanciones_ASPNET.DAL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.Utilities
{
    public class conductorValidation: AbstractValidator<conductorDTO>
    {
        public conductorValidation() {
            RuleFor(c=> c.identificacion).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .WithMessage("El número de identificación es obligatorio!")
               .MinimumLength(8)
               .WithMessage("El campo {PropertyName} tiene {TotalLength} caracteres. " +
               "Debe tener una longitud mínima de {MinLength} caracteres.");

            RuleFor(c => c.nombre).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(c => c.apellidos).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(c => c.direccion).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(c => c.telefono).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(c => c.email).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es obligatorio!")
                .EmailAddress()
                .WithMessage("Ingrese un correo valido en el campo {PropertyName}!");
            RuleFor(c => c.fecha_nacimiento).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es obligatorio!")
                .Must(mayorEdad)
                .WithMessage("Tiene que ser mayor de edad!");
            RuleFor(c => c.activo).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(c => c.matriculaId).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
        }

        private bool mayorEdad(DateTime fecha_nacimiento)
        {
            return DateTime.Now.AddYears(-18) >= fecha_nacimiento;
        }

    }
}
