using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Domain.Entities;

namespace LegoStore.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
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

        public override string[] GetRolesForUser(string customername)
        {
            string[] roles = new string[] { };
            using (LegoStoreContext db = new LegoStoreContext())
            {
                // Получаем пользователя
                Customer customer = db.Customers.FirstOrDefault(u => u.Email == customername);
                if (customer != null)
                {
                    // получаем роль
                    Role customerRole = db.Roles.Find(customer.RoleId);
                    if(customerRole != null)
                        roles = new string[] { customer.Role.Name };
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string customername, string roleName)
        {
            bool outputResult = false;
            using (LegoStoreContext db = new LegoStoreContext())
            {
                // Получаем пользователя
                Customer customer = db.Customers.FirstOrDefault(u => u.Email == customername);
                if (customer != null)
                {
                    Role customerRole = db.Roles.Find(customer.RoleId);
                    if (customerRole != null && customerRole.Name == roleName)
                        outputResult = true;
                } 
            }
            return outputResult;
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