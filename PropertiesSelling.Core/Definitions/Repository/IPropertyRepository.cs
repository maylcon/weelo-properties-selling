using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Definitions.Repository
{
    public interface IPropertyRepository : IRepository<Property>
    {

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        Task UpdatePrice(Guid IdProperty, decimal price);

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        IPagedList<Property> GetAll(
            string name,
            string address,
            decimal? minPrice,
            decimal? maxPrice
        );

    }
}
