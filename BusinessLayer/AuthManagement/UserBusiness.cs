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

            Data._RepoUser.Add(request);
            Data.commit();

            return "";
        }
    }
}
