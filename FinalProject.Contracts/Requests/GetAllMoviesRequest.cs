namespace FinalProject.Contracts.Requests;

//public class GetAllMoviesRequest
//{
//    public string? Title{ get; set; }
//    public int? YearOfRelease{ get; set; }
//}

public record GetAllMoviesRequest(string? Title, int? YearOfRelease);
