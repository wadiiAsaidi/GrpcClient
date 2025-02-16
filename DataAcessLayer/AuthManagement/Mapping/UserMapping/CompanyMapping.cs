using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.AuthManagement.Mapping.UserMapping
{
    internal class CompanyMapping : EntityTypeBase<Company>
    {
        public override void OnConfigure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        }
    }
}
