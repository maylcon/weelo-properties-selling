using System;
using System.ComponentModel.DataAnnotations;

namespace PropertiesSelling.Core.Dtos.PropertyImage
{
    public class CreatePropertyImage
    {
        [Required]
        public Guid IdProperty { get; set; }

        public Byte[] File { get; set; }

        public Boolean? Enable { get; set; }
    }
}
