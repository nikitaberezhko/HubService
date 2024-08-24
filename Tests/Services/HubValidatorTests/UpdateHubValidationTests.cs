using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using NetTopologySuite.Geometries;
using Services.Models.Request;
using Services.Validation;
using Xunit;

namespace Tests.Services.HubValidatorTests;

public class UpdateHubValidationTests
{
    private readonly HubValidator _validator;
    
    public UpdateHubValidationTests()
    {
        _validator = new(
            new Mock<IValidator<CreateHubModel>>().Object,
            Provider.Get<IValidator<UpdateHubModel>>(),
            new Mock<IValidator<DeleteHubModel>>().Object,
            new Mock<IValidator<GetHubByIdModel>>().Object,
            new Mock<IValidator<GetHubsByCityModel>>().Object,
            new Mock<IValidator<GetAllHubsModel>>().Object
            );
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new UpdateHubModel
        {
            Id = Guid.NewGuid(),
            Address = "address",
            City = "city",
            Location = new Point(1,1)
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    } 
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Id_Is_Invalid()
    {
        // Arrange
        var model = new UpdateHubModel
        {
            Id = Guid.Empty,
            Address = "address",
            City = "city",
            Location = new Point(1,1)
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Address_Is_Empty()
    {
        // Arrange
        var model = new UpdateHubModel
        {
            Id = Guid.NewGuid(),
            Address = "",
            City = "city",
            Location = new Point(1,1)
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_City_Is_Empty()
    {
        // Arrange
        var model = new UpdateHubModel
        {
            Id = Guid.NewGuid(),
            Address = "address",
            City = "",
            Location = new Point(1,1)
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Location_Is_Null()
    {
        // Arrange
        var model = new UpdateHubModel
        {
            Id = Guid.NewGuid(),
            Address = "address",
            City = "city",
            Location = null
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(() => _validator.ValidateAsync(model));
    }
}