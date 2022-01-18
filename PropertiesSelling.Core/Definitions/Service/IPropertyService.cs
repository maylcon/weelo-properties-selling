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

        Task UpdateProperty(UpdateProperty request);

        Task UpdatePriceProperty(UpdatePriceProperty request);

        Task<IList<ReadProperty>> GetAllProperties();

        IList<ReadProperty> GetAllPropertiesByFilters(SearchProperty searchProperty);


    }
}
