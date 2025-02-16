using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.AuthManagement.Mapping.UserMapping
{
    public class RoleMapping : EntityTypeBase<Role>
    {
        public override void OnConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(100).IsRequired();
        }
    }
}
