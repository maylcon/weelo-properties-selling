using AutoMapper;
using PropertiesSelling.Core.Dtos;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Mappers
{
    public class OwnerMapper : Profile
    {
        public OwnerMapper()
        {
            CreateMap<CreateOwner, Owner>();
            CreateMap<Owner, ReadOwner>();
            CreateMap<UpdateOwner, Owner>();
        }
    }
}
