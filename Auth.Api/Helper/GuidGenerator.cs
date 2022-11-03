namespace Auth.Api.Helper;

public class GuidGenerator
{
    public static string GenerateNewGuidString => Guid.NewGuid().ToString("N")[..20];
}
