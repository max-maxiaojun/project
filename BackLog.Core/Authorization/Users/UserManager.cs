using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using BackLog.Authorization.Roles;
using System.Linq;

namespace BackLog.Authorization.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            RoleManager roleManager,
            UserStore store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<User>> logger, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings, 
            ISettingManager settingManager)
            : base(
                roleManager, 
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators, 
                keyNormalizer, 
                errors, 
                services, 
                logger, 
                permissionManager, 
                unitOfWorkManager, 
                cacheManager,
                organizationUnitRepository, 
                userOrganizationUnitRepository, 
                organizationUnitSettings, 
                settingManager)
        {
        }
		/// <summary>
		/// 获取Role的用户列表
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public IQueryable<User> GetUserList(int roleId)
		{
			var users = base.Users
			 .Where(p => p.Roles.Any(r => r.RoleId.Equals(roleId)));

			return users;
		}

        public string GetUserNameById(long? userId)
        {
            var user = base.Users.FirstOrDefault(s => s.Id == userId);

            return user == null ? "" : user.Name;
        }
        public IQueryable<User> GetAllUsers(string name)
        {
            var users = base.Users;
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name==name);
            }
            return users;
        }

        public IQueryable<User> GetUsers(int? roldId,string name)
        {
            var users = base.Users;
            if (roldId.HasValue)
            {
                users = users.Where(p => p.Roles.Any(r => r.RoleId.Equals(roldId.Value)));

            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            return users;
        }

        public IQueryable<User> GetUserByName( string name)
        {
            var users = base.Users;

                users = users.Where(p => p.NormalizedUserName.Contains(name));

            return users;
        }




        public string GetClientById(long clientId)
        {
            var client = base.Users.FirstOrDefault(s => s.Id == clientId);

            return client == null ? "" : client.Name;
        }

        public User GetUserPasswdByEmail(string email)
        {
            var user = base.Users.FirstOrDefault(s => s.EmailAddress == email);

            return user;
        }

        
    }

}
