using AutoMapper;
using PropertiesSelling.Core.Dtos.Property;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Mappers
{
    public class PropertyMapper : Profile
    {
        public PropertyMapper()
        {
            CreateMap<CreateProperty, Property>();
            CreateMap<Property, ReadProperty>();
            CreateMap<UpdateProperty, Property>();
            CreateMap<UpdatePriceProperty, Property>();
        }
    }
}
