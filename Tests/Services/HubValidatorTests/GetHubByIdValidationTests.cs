using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request;
using Services.Validation;
using Xunit;

namespace Tests.Services.HubValidatorTests;

public class GetHubByIdValidationTests
{
    private readonly HubValidator _validator;
    
    public GetHubByIdValidationTests()
    {
        _validator = new(
            new Mock<IValidator<CreateHubModel>>().Object,
            new Mock<IValidator<UpdateHubModel>>().Object,
            new Mock<IValidator<DeleteHubModel>>().Object,
            Provider.Get<IValidator<GetHubByIdModel>>(),
            new Mock<IValidator<GetHubsByCityModel>>().Object,
            new Mock<IValidator<GetAllHubsModel>>().Object
            );
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetHubByIdModel { Id = Guid.NewGuid() };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Id_Is_Invalid()
    {
        // Arrange
        var model = new GetHubByIdModel { Id = Guid.Empty };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
}