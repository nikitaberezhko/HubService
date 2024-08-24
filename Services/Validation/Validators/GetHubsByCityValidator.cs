using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class GetHubsByCityValidator : AbstractValidator<GetHubsByCityModel>
{
    public GetHubsByCityValidator()
    {
        RuleFor(x => x.City).NotEmpty();
    }
}