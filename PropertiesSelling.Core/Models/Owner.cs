using PropertiesSelling.Core.Definitions;
using System;
using System.Collections.Generic;

namespace PropertiesSelling.Core.Models
{
    public class Owner : IEntity
    {
        public Guid? IdOwner { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public byte[] Photo { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
