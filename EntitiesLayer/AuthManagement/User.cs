using EntitiesLayer.EntityBase;
using System;


namespace EntitiesLayer.AuthManagement
{
    public  class User: IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        //public Guid OrganizationId { get; set; }
        //public Organization Organization { get; set; }
        //public Guid LocationId { get; set; }
        //public Location Location { get; set; }
        //public Guid LanguageId { get; set; }
        //public Language Language { get; set; }
    }
}
