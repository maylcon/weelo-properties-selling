using Microsoft.EntityFrameworkCore;
using PropertiesSelling.Core.Definitions;
using PropertiesSelling.Core.Definitions.Repository;
using PropertiesSelling.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Infraestructure.Implements.Repository
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private protected readonly DBContext _context;
        private DbSet<TEntity> _entities;


        public Repository(DBContext context)
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }

                return _entities;
            }
        }

        public IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }


        public IQueryable<TEntity> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await Entities.AddAsync(entity);
            _context.SaveChanges();

            return entity;            
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            Entities.Update(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }


        public TEntity GetById(Guid id)
        {
            return Entities.Find(id);
        }


        public async Task<IList<TEntity>> GetAll()
        {
            return await Entities.ToListAsync();
        }
    }
}
