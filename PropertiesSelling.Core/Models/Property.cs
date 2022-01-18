using PropertiesSelling.Core.Definitions;
using System;
using System.Collections.Generic;

namespace PropertiesSelling.Core.Models
{
    public class Property : IEntity
    {
        public Guid IdProperty { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public Decimal? Price { get; set; }

        public String CodeInternal { get; set; }

        public Int32? Year { get; set; }

        public Guid IdOwner { get; set; }

        public virtual Owner Owner { get; set; }

        public ICollection<PropertyImage> Images { get; set; }
        public ICollection<PropertyTrace> Traces { get; set; }
    }
}
