﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System;
using EntitiesLayer.EntityBase;
using System.Reflection.Metadata;
using DataAcessLayer.AuthManagement.Mapping.UserMapping;
using EntitiesLayer.AuthManagement;

namespace DataAcessLayer.DataAccess
{
    public class DbContextBase : DbContext
    {
       
        public DbContextBase(string connectionString) : base(DatabaseProvider.AlterConnectionString(connectionString))
        {
            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            // we can here disable stateManage in EF and we can track manualy the state of entity
        }

        public DbSet<Entity> DbSet<Entity>() 

            where Entity : class
        {
            return base.Set<Entity>();
        }

        //public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        //{
        //    return base.Entry(entity);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Company> Company { get; set; }

        private void CreateModel(ModelBuilder modelBuilder)
        {
            var location = typeof(UserMapping).Assembly.Location;

            foreach (var typeInfo in Assembly.LoadFrom(location).DefinedTypes)
            {
                AddEntityMapping(typeInfo, modelBuilder);
            }
        }

        public void AddEntityMapping(TypeInfo typeInfo, ModelBuilder modelBuilder)
        {
            var isNotGenericTypeAndIsSubclassEntityMapping =
                !typeInfo.ContainsGenericParameters
                && typeInfo.IsSubclassOf(typeof(IEntityTypeMapping));

            if (isNotGenericTypeAndIsSubclassEntityMapping)
            {
                (Activator.CreateInstance(typeInfo)
                    as IEntityTypeMapping
                ).AddEntityTypeMapping(modelBuilder);
            }
        }

        public virtual int SaveChangesInternal()
        {
            return this.SaveChanges();
        }
        public bool IsDisposed => disposedValue;

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DbContextBase()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

       

    }
}
