using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.DataAccess
{

    public class DbContextReader
    {

    }

    public class DbContextWriter
    {

    }

    public interface IUnitOfWorkbase
    {
        int commit();
        //DbContextBase GetDbContextReader();
        DbContextBase GetDbContextWriter();
    }

    public abstract class UnitOfWorkbase : IUnitOfWorkbase
    {
        public int commit()
        {
            int count = OnInitialize().SaveChangesInternal();

            return count;
        }

        public DbContextBase GetDbContextWriter()
        {
            return OnInitialize();
        }

        public abstract DbContextBase OnInitialize();

    }
}
