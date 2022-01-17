using AutoMapper;
using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos.Property;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Implements.Services
{
    public class PropertyService : IPropertyService
    {

        private readonly IPropertyRepository propertyRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper _mapper;


        public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.propertyRepository = propertyRepository;
            this.ownerRepository = ownerRepository;
            this._mapper = mapper;
        }

        public async Task<ReadProperty> CreateProperty(CreateProperty createProperty)
        {
            Property entity = _mapper.Map<CreateProperty, Property>(createProperty);
            Property property = await this.propertyRepository.InsertAsync(entity);
            return _mapper.Map<Property, ReadProperty>(property);
        }

        public async Task<ReadProperty> UpdateProperty(UpdateProperty updateProperty)
        {
            var propertyEntity = this.propertyRepository.TableNoTracking.Where(x => x.IdProperty == updateProperty.IdProperty).FirstOrDefault();
            if (propertyEntity == null)
            {
                throw new KeyNotFoundException();
            }

            propertyEntity.Name = string.IsNullOrEmpty(updateProperty.Name) ? propertyEntity.Name : updateProperty.Name.Trim();
            propertyEntity.Address = string.IsNullOrEmpty(updateProperty.Address) ? propertyEntity.Address : updateProperty.Address.Trim();
            propertyEntity.Price = !updateProperty.Price.HasValue ? propertyEntity.Price : updateProperty.Price;
            propertyEntity.CodeInternal = string.IsNullOrEmpty(updateProperty.CodeInternal) ? propertyEntity.CodeInternal : updateProperty.CodeInternal.Trim();
            propertyEntity.Year = !updateProperty.Year.HasValue ? propertyEntity.Year : updateProperty.Year.Value;
            propertyEntity.IdOwner = !updateProperty.IdOwner.HasValue ? propertyEntity.IdOwner : updateProperty.IdOwner.Value;

            Property propertyUpdate = await this.propertyRepository.UpdateAsync(propertyEntity);
            return _mapper.Map<Property, ReadProperty>(propertyUpdate);

        }

        public async Task<ReadProperty> UpdatePriceProperty(UpdatePriceProperty request)
        {
            await this.propertyRepository.UpdatePrice(request.IdProperty, request.Price);
            var result = this.propertyRepository.Table.FirstOrDefault(x => x.IdProperty == request.IdProperty);
            return _mapper.Map<Property, ReadProperty>(result);
        }


        public Task DeleteProperty(Guid propertyId)
        {
            throw new NotImplementedException();
        }


        public async Task<IList<ReadProperty>> GetAllProperties()
        {
            IList<Property> properties = await propertyRepository.GetAll();

            return _mapper.Map<IList<Property>, IList<ReadProperty>>(properties);
        }

        public IList<ReadProperty> GetAllPropertiesByFilters (SearchProperty searchProperty)
        {
            var properties = this.propertyRepository.GetAll(
                name: searchProperty.Name,
                address: searchProperty.Address,
                minPrice: searchProperty.MinPrice,
                maxPrice: searchProperty.MaxPrice).ToList(); ;

            return _mapper.Map<IList<Property>, IList<ReadProperty>>(properties);
        }

    }
}
