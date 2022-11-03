namespace Auth.Api.Entities;

public class ProblemEntity
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Digit { get; set; }
    public int Answer { get; set; }
    public int UserEntityId { get; set; }
}
