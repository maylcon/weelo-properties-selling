using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Dtos.Property
{
    public class CreateProperty
    {
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }

        [Required]
        [MaxLength(100)]
        public String Address { get; set; }

        public Decimal? Price { get; set; }

        [MaxLength(10)]
        public String CodeInternal { get; set; }

        public Int32? Year { get; set; }

        [Required]
        public Guid IdOwner { get; set; }
    }
}
