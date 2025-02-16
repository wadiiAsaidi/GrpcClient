using EntitiesLayer.EntityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataAcessLayer.DataAccess
{
    public interface IEntityTypeMapping
    {
        void AddEntityTypeMapping(ModelBuilder builder);
    }
    //public interface IEntityTypeConfiguration<TEntity> where TEntity : class
    //{
    //    //
    //    // Summary:
    //    //     Configures the entity of type TEntity.
    //    //
    //    // Parameters:
    //    //   builder:
    //    //     The builder to be used to configure the entity type.
    //    void Configure(EntityTypeBuilder<TEntity> builder);
    //}

    public interface IEntityTypeMapping<TEntity>: IEntityTypeConfiguration<TEntity>
        where TEntity: class
    {

    }


    public abstract class EntityTypeBase<TEntity> : IEntityTypeMapping<TEntity> where TEntity : class
    {

        public void AddEntityTypeMapping(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PreConfigure(builder);
            OnConfigure(builder);
        }

        //public virtual ModelBuilder ApplyConfiguration<TEntity>([JetBrains.Annotations.NotNull] IEntityTypeConfiguration<TEntity> configuration) where TEntity : class
        //{
        //    Microsoft.EntityFrameworkCore.Utilities.Check.NotNull(configuration, "configuration");
        //    configuration.Configure(Entity<TEntity>());
        //    return this;
        //}
        public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
        public  void PreConfigure(EntityTypeBuilder<TEntity> builder)
        {

        }
    }
}
