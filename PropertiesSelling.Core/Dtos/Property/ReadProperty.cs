using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Dtos.Property
{
    public class ReadProperty
    {
        public Guid IdProperty { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public Decimal? Price { get; set; }

        public String CodeInternal { get; set; }

        public Int32? Year { get; set; }

        public ReadOwner Owner { get; set; }
    }
}
