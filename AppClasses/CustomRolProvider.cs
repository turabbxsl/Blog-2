using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blogsayti.Models;

namespace Blogsayti.AppClasses
{
    public class CustomRolProvider : RoleProvider
    {
        Context context = new Context();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                kullanici kl = context.kullanicis.FirstOrDefault(x => x.kullaniciadi == username);
                if (kl != null)
                {
                    return kl.kullanicirols == null ? new string[] { } : kl.kullanicirols.Select(x => x.Roll).Select(x => x.Rolladi).ToArray();
                }
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}