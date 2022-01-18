using PropertiesSelling.Core.Definitions;
using System;

namespace PropertiesSelling.Core.Models
{
    public class PropertyTrace : IEntity
    {
        public Guid IdPropertyTrace { get; set; }

        public Guid IdProperty { get; set; }

        public Property Property { get; set; }

        public DateTime DateSale { get; set; }

        public String Name { get; set; }

        public Decimal Value { get; set; }

        public Decimal Tax { get; set; }
    }
}
