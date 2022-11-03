using System.ComponentModel.DataAnnotations;

namespace Auth.Api.Models;

public class CreateProblemModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Number { get; set; }

    [Range(0, 9, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Digit { get; set; }
}
