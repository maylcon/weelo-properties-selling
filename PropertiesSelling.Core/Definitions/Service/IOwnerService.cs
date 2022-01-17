using PropertiesSelling.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Definitions.Service
{
    public interface IOwnerService
    {
        Task<ReadOwner> CreateOwner (CreateOwner request);

        Task<ReadOwner> UpdateOwner(UpdateOwner request);

        Task<IList<ReadOwner>> GetAllOwner();

    }
}
