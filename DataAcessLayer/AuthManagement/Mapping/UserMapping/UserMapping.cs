using DataAcessLayer.DataAccess;
using EntitiesLayer.AuthManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAcessLayer.AuthManagement.Mapping.UserMapping
{
    public class UserMapping : EntityTypeBase<User>
    {
        public override void OnConfigure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Username).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.IsActive).HasMaxLength(100).IsRequired();
        }
    }
}
