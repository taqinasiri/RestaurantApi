namespace Restaurant.Application.Configs.MediatR;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest,TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context)));

        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError
            {
                PropertyName = validationFailure.PropertyName,
                ErrorMessage = validationFailure.ErrorMessage
            }).ToList();

        if(errors.Any())
        {
            throw new Exceptions.ValidationException(errors);
        }

        var response = await next();

        return response;
    }
}