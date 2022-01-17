using PropertiesSelling.Core.Dtos.PropertyImage;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Definitions.Service
{
    public interface IPropertyImageService
    {
        Task<ReadPropertyImage> InsertImageAsync(CreatePropertyImage request);
    }
}
