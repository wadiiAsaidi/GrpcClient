using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer.EntityBase
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
