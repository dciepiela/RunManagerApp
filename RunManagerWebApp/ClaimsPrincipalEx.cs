using System.Security.Claims;

namespace RunManagerWebApp
{
    public static class ClaimsPrincipalEx
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
