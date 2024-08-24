using Microsoft.AspNetCore.Authorization;

namespace SkateShop.Infrastructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) : base(policy: permission)
        {
        }
    }
}
