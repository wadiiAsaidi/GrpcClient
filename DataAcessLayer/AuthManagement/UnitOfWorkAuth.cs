using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.AuthManagement
{
    public class RepoUser : ReposBase<User>
    {
        public RepoUser(IUnitOfWorkbase _UnitOfWork) : base(_UnitOfWork)
        {

        }
    }

    public class RepoUserRole : ReposBase<UserRole>
    {
        public RepoUserRole(IUnitOfWorkbase _UnitOfWork) : base(_UnitOfWork)
        {

        }
    }

    public class RepoRole : ReposBase<Role>
    {
        public RepoRole(IUnitOfWorkbase _UnitOfWork) : base(_UnitOfWork)
        {

        }
    }



    public class UnitOfWorkAuth : UnitOfWorkbase
    {
        public RepoUser _RepoUser { get; set; }
        public RepoUserRole _RepoUserRole { get; set; }
        public RepoRole _RepoRole { get; set; }

        public UnitOfWorkAuth()
        {
            _RepoUser = new RepoUser(this);
            _RepoUserRole = new RepoUserRole(this);
            _RepoRole = new RepoRole(this);
        }

        public override DbContextBase OnInitialize()
        {
            string connectstring = "";
            return new DbContextBase(connectstring);
        }
    }
}
