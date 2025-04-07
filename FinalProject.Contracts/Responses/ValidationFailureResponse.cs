namespace FinalProject.Contracts.Responses;

public class ValidationFailureResponse
{
    public required IEnumerable<ValidationResposne> Errors{ get; set; }
}

public class ValidationResposne 
{
    public required string PropertyName{ get; set; }
    public required string ErrorMessage { get; set; }
}
