using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class UpdateHubValidator : AbstractValidator<UpdateHubModel>
{
    public UpdateHubValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Address).NotEmpty();
        
        RuleFor(x => x.City).NotEmpty();

        RuleFor(x => x.Location).NotEmpty();
    }
}