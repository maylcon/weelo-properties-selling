using AutoMapper;
using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Core.Implements.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
            this._mapper = mapper;
        }


        public async Task<ReadOwner> CreateOwner(CreateOwner createOwner)
        {
            Owner entity = _mapper.Map<CreateOwner, Owner>(createOwner);
            var result = await this.ownerRepository.InsertAsync(entity);

            return _mapper.Map<Owner, ReadOwner>(result);
        }

        /// <summary>
        /// Updates the specified owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>the task</returns>
        public async Task<ReadOwner> UpdateOwner(UpdateOwner updateOwner)
        {
            Owner ownerEntity = this.ownerRepository.TableNoTracking.Where(x => x.IdOwner == updateOwner.IdOwner).FirstOrDefault();

            if (ownerEntity == null)
            {
                throw new KeyNotFoundException();
            }

            ownerEntity.Name = string.IsNullOrEmpty(updateOwner.Name) ? ownerEntity.Name : updateOwner.Name.Trim();
            ownerEntity.Address = string.IsNullOrEmpty(updateOwner.Address) ? ownerEntity.Address : updateOwner.Address.Trim();
            ownerEntity.Photo = updateOwner.Photo == null ? ownerEntity.Photo : updateOwner.Photo;
            ownerEntity.Birthday = !updateOwner.Birthday.HasValue ? ownerEntity.Birthday : updateOwner.Birthday.Value;
            Owner ownerUpdate = await this.ownerRepository.UpdateAsync(ownerEntity);

            return _mapper.Map<Owner, ReadOwner>(ownerUpdate);

        }



        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns>the list ownners</returns>
        public async Task<IList<ReadOwner>> GetAllOwner()
        {
            IList<Owner> owners = await ownerRepository.GetAll();
            return _mapper.Map<IList<Owner>, IList<ReadOwner>>(owners);
        }

    }
}