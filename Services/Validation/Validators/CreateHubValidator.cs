using FluentValidation;
using Services.Models.Request;

namespace Services.Validation.Validators;

public class CreateHubValidator : AbstractValidator<CreateHubModel>
{
    public CreateHubValidator()
    {
        RuleFor(x => x.Address).NotEmpty();
        
        RuleFor(x => x.City).NotEmpty();
        
        RuleFor(x => x.Latitude)
            .GreaterThanOrEqualTo(-90)
            .LessThanOrEqualTo(90);
        
        RuleFor(x => x.Longitude)
            .GreaterThanOrEqualTo(-180)
            .LessThanOrEqualTo(180);
    }
}