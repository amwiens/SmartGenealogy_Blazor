﻿using FluentValidation.Internal;

using Microsoft.Extensions.DependencyInjection;

using SmartGenealogy.Application.Common.Helper;

namespace SmartGenealogy.Application.Services.Validation;

public class ValidationService : IValidationService
{
    private readonly IServiceProvider _serviceProvider;

    // in order to keep the service as generic as possible
    // validators are provided by type only when required,
    // an alternative would be creating a IValidationService<TRequest>
    // similar to the ValidationBehavior<TRequest, TResponse>
    // but that would mean injecting a IValidationService for each
    // type of model to validate in a page
    public ValidationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue<TRequest>()
        => async (model, propertyName)
        => await ValidatePropertyAsync((TRequest)model, propertyName);

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue<TRequest>(TRequest _)
        => this.ValidateValue<TRequest>();

    public async Task<IDictionary<string, string[]>> ValidateAsync<TRequest>(TRequest model, CancellationToken cancellationToken)
    {
        var validators = _serviceProvider.GetServices<IValidator<TRequest>>();

        var context = new ValidationContext<TRequest>(model);

        return validators != null
            ? await ValidationHelper.ValidateAsync(validators, context, cancellationToken)
            : new Dictionary<string, string[]>();
    }

    public async Task<IDictionary<string, string[]>> ValidateAsync<TRequest>(TRequest model, Action<ValidationStrategy<TRequest>> options, CancellationToken cancellationToken = default)
    {
        var validators = _serviceProvider.GetServices<IValidator<TRequest>>();

        var context = ValidationContext<TRequest>
            .CreateWithOptions(model, options);

        return validators != null
            ? await ValidationHelper.ValidateAsync(validators, context, cancellationToken)
            : new Dictionary<string, string[]>();
    }

    public async Task<IEnumerable<string>> ValidatePropertyAsync<TRequest>(TRequest model, string propertyName, CancellationToken cancellationToken = default)
    {
        var validationResult = await ValidateAsync(model,
            options =>
            {
                options.IncludeProperties(propertyName);
            }, cancellationToken);

        return validationResult.Where(x => x.Key == propertyName).SelectMany(x => x.Value);
    }
}