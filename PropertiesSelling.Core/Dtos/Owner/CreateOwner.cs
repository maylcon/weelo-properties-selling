using System;
using System.ComponentModel.DataAnnotations;

namespace PropertiesSelling.Core.Dtos
{
    public class CreateOwner
    {
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }

        [Required]
        [MaxLength(100)]
        public String Address { get; set; }

        public Byte[] Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
