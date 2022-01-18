using AutoMapper;
using PropertiesSelling.Core.Dtos.PropertyImage;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Mappers
{
    public class PropertyImageMapper : Profile
    {
        public PropertyImageMapper()
        {
            CreateMap<CreatePropertyImage, PropertyImage>();
            CreateMap<PropertyImage, ReadPropertyImage>();
        }
    }
}
