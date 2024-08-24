using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class GetAllHubsValidator : AbstractValidator<GetAllHubsModel>
{
    public GetAllHubsValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(50);
    }
}