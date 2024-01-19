namespace Restaurant.Application.Exceptions;

public class BadRequestException(List<string> errors) : ApplicationException()
{
    public List<string> Errors { get; set; } = errors;
}