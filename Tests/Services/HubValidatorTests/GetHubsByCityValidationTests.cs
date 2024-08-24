using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request;
using Services.Validation;
using Xunit;

namespace Tests.Services.HubValidatorTests;

public class GetHubsByCityValidationTests
{
    private readonly HubValidator _validator;
    
    public GetHubsByCityValidationTests()
    {
        _validator = new(
            new Mock<IValidator<CreateHubModel>>().Object,
            new Mock<IValidator<UpdateHubModel>>().Object,
            new Mock<IValidator<DeleteHubModel>>().Object,
            new Mock<IValidator<GetHubByIdModel>>().Object,
            Provider.Get<IValidator<GetHubsByCityModel>>(),
            new Mock<IValidator<GetAllHubsModel>>().Object
            );
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetHubsByCityModel { City = "city" };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_City_Is_Empty()
    {
        // Arrange
        var model = new GetHubsByCityModel { City = "" };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
}