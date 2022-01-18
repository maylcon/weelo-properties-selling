using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Core.Models;
using PropertiesSelling.Infraestructure.Context;

namespace PropertiesSelling.Infraestructure.Implements.Repository
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DBContext context) : base(context)
        {
        }

    }
}
