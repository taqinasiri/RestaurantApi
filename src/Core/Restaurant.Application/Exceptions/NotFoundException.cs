namespace Restaurant.Application.Exceptions;

public class NotFoundException(string name,object key) : ApplicationException($"{name} ({key}) Not Found")
{
}