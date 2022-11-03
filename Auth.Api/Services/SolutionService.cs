using Auth.Api.Models;

namespace Auth.Api.Services;

public class SolutionService
{
    public static int GetAnswer(CreateProblemModel createProblemModel)
    {
        var n = createProblemModel.Number;
        var k = createProblemModel.Digit;
        var count = 0;
        for (int i = 1; i <= n; i++)
        {
            var num = i;
            while (num > 0)
            {
                var digit = num % 10;
                if (digit == k)
                {
                    count++;
                }
                num /= 10;
            }
        }
        return count;
    }
}
