using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Models
{
    public class Owner
    {
        public Guid IdOwner { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public Byte[] Photo { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
