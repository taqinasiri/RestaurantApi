namespace Restaurant.Application.Exceptions;

public class ValidationException(List<ValidationError> errors) : ApplicationException
{
    public List<ValidationError> Errors { get; set; } = errors;
}