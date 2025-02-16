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
            int count = CurrentDbContext.SaveChangesInternal();

            return count;
        }

        DbContextBase CurrentDbContext => OnInitialize();
        public DbContextBase GetDbContextWriter()
        {
            return CurrentDbContext;
        }

        public DbContextBase GetDbContexReader()
        {
            return OnInitialize();
        }

        public abstract DbContextBase OnInitialize();

    }
}
