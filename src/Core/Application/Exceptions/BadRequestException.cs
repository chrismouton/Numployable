namespace Numployable.Application.Exceptions;

public abstract class BadRequestException(string message)
    : ApplicationException(message)
{
}