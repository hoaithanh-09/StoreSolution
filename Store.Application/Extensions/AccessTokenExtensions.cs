using System;
using System.Linq;
using System.Security.Claims;
using Store.Data.Constants;

namespace Store.Application.Extensions
{
    public static class AccessTokenExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            if (user.HasClaim(c => c.Type.Equals(AuthConstants.ID)))
            {
                try
                {
                    var claim = user.Claims.FirstOrDefault(c => c.Type.Equals(AuthConstants.ID)).Value;
                    return Int32.Parse(claim);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public static string? GetRole(this ClaimsPrincipal user)
        {
            if (user.HasClaim(c => c.Type.Equals(AuthConstants.ROLE)))
            {
                try
                {
                    var claim = user.Claims.FirstOrDefault(c => c.Type.Equals(AuthConstants.ROLE)).Value;
                    return claim;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }
    }
}