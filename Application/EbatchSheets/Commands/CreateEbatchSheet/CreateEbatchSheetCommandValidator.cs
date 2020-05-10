using Application.Common.Interfaces;
using FluentValidation;

namespace Application.EbatchSheets.Commands
{
    public class CreateEbatchSheetCommandValidator: AbstractValidator<CreateEbatchSheetCommandValidator>
    {
        private readonly IApplicationDbContext _context;

        public CreateEbatchSheetCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            /*RuleFor(v => v.WoDesc)
                .NotEmpty().WithMessage("WoDesc is required.")
                .MaximumLength(200).WithMessage("WoDesc must not exceed 200 characters.");
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");*/
        }

    }
}
