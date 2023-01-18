using Microsoft.AspNetCore.Http;
using Nadafa.SharedKernal.Shared.Enums;
using System.Security.Claims;

namespace Nadafa.SharedKernal.Shared.CurrentUser
{
    public static class CurrentUser
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        #region Logged In User Claims

        public static string BaseUrl => GetBaseUrl();

        public static Guid? Id => string.IsNullOrEmpty(GetClaimValue(ClaimKeys.Id))
            ? null
            : Guid.Parse(GetClaimValue(ClaimKeys.Id)!);

        public static string Name => GetClaimValue(ClaimKeys.Name);
        public static string Email => GetClaimValue(ClaimKeys.Email);
        //public static string ImageUrl => GetClaimValue(ClaimKeys.ImageUrl);
        public static List<Roles> Roles => GetRoles();
        public static string Phones => GetClaimValue(ClaimKeys.PhoneNumber);

        public static string? Token => GetAuthorizationToken();

        #endregion

        #region Helper Methods

        private static Guid? CheckIfVendorIdExist(string vendorId)
        {
            var isValid = string.IsNullOrEmpty(vendorId);

            if (isValid || string.IsNullOrEmpty(vendorId) || Guid.Parse(vendorId) == Guid.Empty)
                return null;

            return Guid.Parse(vendorId);

        }
        private static string GetClaimValue(string key)
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity is null || !user.Identity.IsAuthenticated) return string.Empty;

            var value = user?.Claims?.FirstOrDefault(x => x.Type == key)?.Value;
            return value ?? string.Empty;

            // Dynamic parse from System.Type
            // This should work for all primitive types, and for types that implement IConvertible
            // return (T) Convert.ChangeType(value, typeof(T));
        }


        private static bool? GetBoolOrNull(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return bool.Parse(value);
        }

        private static List<Roles> GetRoles()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity is null || !user.Identity.IsAuthenticated) return Enumerable.Empty<Roles>().ToList();

            var roles = user.Claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => Enum.Parse<Roles>(x.Value))
                .ToList();
            return roles;
        }

        private static string GetBaseUrl()
        {
            // TODO: Find a way to detect the correct schema in the production case in production it return 'http' not 'https'
            var request = _httpContextAccessor?.HttpContext?.Request;
            // return $"{request?.Scheme}://{request?.Host}{request?.PathBase}";
            return $"https://{request?.Host}{request?.PathBase}";
        }

        private static string? GetAuthorizationToken()
        {
            var token = _httpContextAccessor?.HttpContext?.Request.Headers["Authorization"];
            return token;
        }

        #endregion

        internal static void InitializeHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
