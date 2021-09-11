using PhoneBook.Core.Contracts.Common;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.Common
{

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly PhoneBookContext _dbContext;

        public BaseRepository(PhoneBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entityt)
        {
            _dbContext.Set<TEntity>().Add(entityt);
            _dbContext.SaveChanges();
            return entityt;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                Id = id
            };
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }        
    }
}

