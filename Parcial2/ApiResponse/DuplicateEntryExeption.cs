namespace Parcial2.ApiResponse;

public class DuplicateEntryExeption : Exception
{
    public DuplicateEntryExeption(string message) : base(message)
    {
        
    }
}