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
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }


        public async Task<ReadOwner> CreateOwner(CreateOwner createOwner)
        {
            var entity = _mapper.Map<CreateOwner, Owner>(createOwner);
            var result = await this._ownerRepository.InsertAsync(entity);

            return _mapper.Map<Owner, ReadOwner>(result);
        }

        public async Task<ReadOwner> UpdateOwner(UpdateOwner updateOwner)
        {
            Owner ownerEntity = this._ownerRepository.TableNoTracking.Where(x => x.IdOwner == updateOwner.IdOwner).FirstOrDefault();

            if (ownerEntity == null)
            {
                throw new KeyNotFoundException();
            }

            ownerEntity.Name = string.IsNullOrEmpty(updateOwner.Name) ? ownerEntity.Name : updateOwner.Name.Trim();
            ownerEntity.Address = string.IsNullOrEmpty(updateOwner.Address) ? ownerEntity.Address : updateOwner.Address.Trim();
            ownerEntity.Photo = updateOwner.Photo == null ? ownerEntity.Photo : updateOwner.Photo;
            ownerEntity.Birthday = !updateOwner.Birthday.HasValue ? ownerEntity.Birthday : updateOwner.Birthday.Value;
            Owner ownerUpdate = await this._ownerRepository.UpdateAsync(ownerEntity);

            return _mapper.Map<Owner, ReadOwner>(ownerUpdate);

        }

        public async Task<IList<ReadOwner>> GetAllOwner()
        {
            IList<Owner> owners = await _ownerRepository.GetAll();
            return _mapper.Map<IList<Owner>, IList<ReadOwner>>(owners);
        }

    }
}