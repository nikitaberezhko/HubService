using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class DeleteHubValidator : AbstractValidator<DeleteHubModel>
{
    public DeleteHubValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}