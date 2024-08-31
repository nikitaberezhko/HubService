using Exceptions.Contracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Models.Request;

namespace Services.Validation;

public class HubValidator(
    IValidator<CreateHubModel> createHubModelValidator,
    IValidator<UpdateHubModel> updateHubModelValidator,
    IValidator<DeleteHubModel> deleteHubModelValidator,
    IValidator<GetHubByIdModel> getHubByIdModelValidator,
    IValidator<GetHubsByCityModel> getHubsByCityModelValidator,
    IValidator<GetAllHubsModel> getAllHubsModelValidator)
{
    public async Task<bool> ValidateAsync(CreateHubModel model)
    {
        var validationResult = await createHubModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(UpdateHubModel model)
    {
        var validationResult = await updateHubModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(DeleteHubModel model)
    {
        var validationResult = await deleteHubModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(GetHubByIdModel model)
    {
        var validationResult = await getHubByIdModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(GetHubsByCityModel model)
    {
        var validationResult = await getHubsByCityModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(GetAllHubsModel model)
    {
        var validationResult = await getAllHubsModelValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithErrorValidationMessage();
        
        return true;
    }

    private void ThrowWithErrorValidationMessage() =>
        throw new ServiceException
        {
            Title = "Model invalid",
            Message = "Model validation failed",
            StatusCode = StatusCodes.Status400BadRequest
        };
}