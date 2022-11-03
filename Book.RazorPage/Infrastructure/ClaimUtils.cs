using System.Security.Claims;

namespace Book.RazorPage.Infrastructure;

public static class ClaimUtils
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return new Guid(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}