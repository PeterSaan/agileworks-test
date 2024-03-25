namespace agileworks_test.Models;

public class Request
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Created_at { get; set; }
    public bool Solved { get; set; }
    public DateTime Solved_when { get; set; }
}