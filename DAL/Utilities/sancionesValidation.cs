using ActividadSanciones_ASPNET.DAL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.Utilities
{
    public class sancionesValidation : AbstractValidator<sancionesDTO>
    {
        public sancionesValidation(){
            RuleFor(s => s.conductorId).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio!");
            RuleFor(s => s.sancion).NotEmpty().WithMessage("El campo {PropertyName} debe tener una descripción!");
            RuleFor(s => s.valor).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es obligatorio!")
                .GreaterThan(50000)
                .WithMessage("El valor del campo {PropertyName} debe ser mayor a 50000!");
        }
    }
}
