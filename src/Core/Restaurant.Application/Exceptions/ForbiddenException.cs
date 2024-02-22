namespace Restaurant.Application.Exceptions;

public class ForbiddenException(string? message) : ApplicationException(message)
{
}