using PropertiesSelling.Core.Definitions;
using System;

namespace PropertiesSelling.Core.Models
{
    public class PropertyImage : IEntity
    {
        public Guid IdPropertyImage { get; set; }

        public Guid IdProperty { get; set; }

        public virtual Property Property { get; set; }

        public Byte[] File { get; set; }

        public Boolean Enable { get; set; }
    }
}
