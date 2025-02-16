using EntitiesLayer.EntityBase;
using System;


namespace EntitiesLayer.AuthManagement
{
    public class UserRole: IEntity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
