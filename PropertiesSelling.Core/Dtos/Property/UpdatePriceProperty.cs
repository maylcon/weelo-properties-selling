using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Dtos.Property
{
    public class UpdatePriceProperty
    {
        [Required]
        public Guid IdProperty { get; set; }

        [Required]
        public Decimal Price { get; set; }

    }
}
