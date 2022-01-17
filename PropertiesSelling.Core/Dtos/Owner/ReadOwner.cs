using System;

namespace PropertiesSelling.Core.Dtos
{
    public class ReadOwner
    {
        public Guid IdOwner { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public Byte[] Photo { get; set; }

        public DateTime Birthday { get; set; }
    }
}
