using ActividadSanciones_ASPNET.DAL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.Utilities
{
    public class matriculaValidation : AbstractValidator<matriculaDTO>
    {

        public matriculaValidation() {

            RuleFor(m => m.numero).Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage("El número de matricula es obligatorio!")
            .Length(6,6)
            .WithMessage("El campo {PropertyName} tiene {TotalLength} caracteres. " +
            "Debe tener una longitud de {MinLength} caracteres.");

        }

    }
}
