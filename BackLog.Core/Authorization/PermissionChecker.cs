using Abp.Authorization;
using BackLog.Authorization.Roles;
using BackLog.Authorization.Users;

namespace BackLog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
