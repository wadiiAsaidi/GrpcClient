using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.AuthManagement.Mapping.UserMapping
{
    public class UserRoleMapping : EntityTypeBase<UserRole>
    {
        public override void OnConfigure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100).IsRequired();
            builder.Property(e => e.UserId).HasMaxLength(100).IsRequired();
            builder.Property(e => e.RoleId).HasMaxLength(100).IsRequired();
        }
    }
}
