using System;
using System.ComponentModel.DataAnnotations;

namespace PropertiesSelling.Core.Dtos
{
    public class UpdateOwner
    {
        [Required]
        public Guid IdOwner { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public Byte[] Photo { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
