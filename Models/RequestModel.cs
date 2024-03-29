namespace agileworks_test.Models;

public class Request
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Solved { get; set; }
    public DateTime ToBeSolvedBy { get; set; }
    public DateTime SolvedWhen { get; set; }
}