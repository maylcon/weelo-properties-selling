using System;
using System.ComponentModel.DataAnnotations;

namespace PropertiesSelling.Core.Dtos
{
    public class CreateOwner 
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
