namespace Restaurant.Application.Exceptions;

public class NotFoundException(string name) : ApplicationException($"{name} Not Found")
{
}