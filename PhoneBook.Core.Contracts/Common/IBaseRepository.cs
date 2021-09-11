using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Core.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Get(int Id);
        IQueryable<TEntity> GetAll();
        void Delete(int Id);
        TEntity Add(TEntity entityt);
    }
}
