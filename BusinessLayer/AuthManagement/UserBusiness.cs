using DataAcessLayer.AuthManagement;
using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AuthManagement
{
    public class UserBusiness
    {
        UnitOfWorkAuth Data {  get; set; }
        public UserBusiness()
        {
            Data = new UnitOfWorkAuth();
        }   

        public string SignIn(User request)
        {
            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Company",
            };

            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Code = 252
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName= "FirstName",
                Username= "Username",
                LastName= "LastName",
                Email= "Email",
                Password="123456789",
                IsActive=true,
                CompanyId = company.Id,
                Company = company
            };

            // DDD
            var userRole = new UserRole
            {
                UserId= user.Id,
                Id = Guid.NewGuid(),
                RoleId= role.Id,
                User= user,
                Role= role,
            };

            //Data._RepoUser.Add(user);
            Data._RepoUserRole.Add(userRole);
            Data.commit();

            return "";
        }
    }
}
