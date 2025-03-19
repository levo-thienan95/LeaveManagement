namespace LeaveManagement.Application.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string name, int key) : base($"The {name} with key {key} could not be found.")
    {
        
    }
}