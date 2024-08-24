using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request;
using Services.Validation;
using Xunit;

namespace Tests.Services.HubValidatorTests;

public class GetAllHubsValidationTests
{
    private readonly HubValidator _validator;
    
    public GetAllHubsValidationTests()
    {
        _validator = new(
            new Mock<IValidator<CreateHubModel>>().Object,
            new Mock<IValidator<UpdateHubModel>>().Object,
            new Mock<IValidator<DeleteHubModel>>().Object,
            new Mock<IValidator<GetHubByIdModel>>().Object,
            new Mock<IValidator<GetHubsByCityModel>>().Object,
            Provider.Get<IValidator<GetAllHubsModel>>()
            );
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetAllHubsModel
        {
            Page = 1,
            PageSize = 10
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Page_Less_Than_1()
    {
        // Arrange
        var model = new GetAllHubsModel
        {
            Page = 0,
            PageSize = 10
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PageSize_Less_Than_1()
    {
        // Arrange
        var model = new GetAllHubsModel
        {
            Page = 1,
            PageSize = 0
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PageSize_Greater_Than_50()
    {
        // Arrange
        var model = new GetAllHubsModel
        {
            Page = 1,
            PageSize = 51
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    } 
}