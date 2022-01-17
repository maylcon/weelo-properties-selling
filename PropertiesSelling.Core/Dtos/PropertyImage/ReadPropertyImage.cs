using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Dtos.PropertyImage
{
    public class ReadPropertyImage
    {
        public Guid IdPropertyImage { get; set; }

        public Guid IdProperty { get; set; }

        public Byte[] File { get; set; }

        public Boolean Enable { get; set; }
    }
}
