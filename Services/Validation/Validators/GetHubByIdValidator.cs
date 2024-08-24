using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class GetHubByIdValidator : AbstractValidator<GetHubByIdModel>
{
    public GetHubByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}