using PropertiesSelling.Core.Dtos.Property;
using PropertiesSelling.Core.Dtos.PropertyImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Definitions.Service
{
    public interface IPropertyService
    {
        Task<ReadProperty> CreateProperty(CreateProperty request);

        Task<ReadProperty> UpdateProperty(UpdateProperty request);

        Task<ReadProperty> UpdatePriceProperty(UpdatePriceProperty request);

        Task DeleteProperty(Guid propertyId);

        Task<IList<ReadProperty>> GetAllProperties();

        IList<ReadProperty> GetAllPropertiesByFilters(SearchProperty searchProperty);


    }
}
