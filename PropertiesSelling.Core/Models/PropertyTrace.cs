using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Models
{
    public class PropertyTrace
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
