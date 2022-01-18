using AutoMapper;
using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos.PropertyImage;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Implements.Services
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IRepository<PropertyImage> _propertyImageRepository;
        private readonly IMapper _mapper;

        public PropertyImageService(IRepository<PropertyImage> propertyImageRepository, IMapper mapper)
        {
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
        }
        public async Task<ReadPropertyImage> InsertImageAsync(CreatePropertyImage createPropertyImage)
        {
            PropertyImage entity =  _mapper.Map<CreatePropertyImage, PropertyImage>(createPropertyImage);

            var propertyEntity = _propertyImageRepository.TableNoTracking.Where(x => x.IdProperty == createPropertyImage.IdProperty);
            if (propertyEntity == null)
            {
                throw new KeyNotFoundException();
            }

            PropertyImage result = await _propertyImageRepository.InsertAsync(entity);

            return _mapper.Map<PropertyImage, ReadPropertyImage>(result);
        }
    }
}
