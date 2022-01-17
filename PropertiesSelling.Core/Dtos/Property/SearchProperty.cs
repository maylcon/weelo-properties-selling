using System;

namespace PropertiesSelling.Core.Dtos.Property
{
    public class SearchProperty
    {

        public String Name { get; set; }

        public String Address { get; set; }

        public Decimal? MinPrice { get; set; }
        public Decimal? MaxPrice { get; set; }
    }
}
