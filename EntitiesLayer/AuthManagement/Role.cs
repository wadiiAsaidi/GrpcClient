﻿using EntitiesLayer.EntityBase;
using System;


namespace EntitiesLayer.AuthManagement
{
    public class Role: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
