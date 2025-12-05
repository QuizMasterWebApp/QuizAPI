namespace Quiz;

public static class HttpContextExtensions
{
    public static string? GetGuestSessionId(this HttpContext context)
    {
        if (context.Items.TryGetValue("GuestSessionId", out var value))
            return value?.ToString();

        return null;
    }

    public static int? GetUserId(this HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var idClaim = context.User.Claims.FirstOrDefault(c => c.Type == "user_id");
            if (int.TryParse(idClaim?.Value, out int userId))
                return userId;
        }

        return null;
    }
}
