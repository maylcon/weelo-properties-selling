using Microsoft.EntityFrameworkCore;
using PropertiesSelling.Core.Definitions;
using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesSelling.Core.Models;

namespace PropertiesSelling.Infraestructure.Implements.Repository
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(DBContext context) : base(context)
        {
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        public async Task UpdatePrice(Guid idProperty, decimal price)
        {
            var entityUpdated = this.Entities.Single(x => x.IdProperty == idProperty);
            entityUpdated.Price = price;
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        public IPagedList<Property> GetAll(
            string owner,
            string address,
            decimal? minPrice,
            decimal? maxPrice
        )
        {
            var query = this.TableNoTracking;

            if (!string.IsNullOrEmpty(owner))
            {
                query = query.Include(x => x.Owner).Where(x => x.Owner.Name.ToLower().Contains(owner.Trim().ToLower()));
            }
            else
            {
                query = query.Include(x => x.Owner);
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(address.Trim().ToLower()));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(x => x.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= maxPrice.Value);
            }

            query = query.OrderByDescending(x => x.IdProperty);

            return new PagedList<Property>(query, 0, 10); ;
        }

    }
}