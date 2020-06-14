
using Entities.Paginate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IGenericBase<TEntity> where TEntity : class
    {
        void DeleteElement(TEntity obj);
        IEnumerable<TEntity> GetElements();
        IEnumerable<TEntity> GetElements(Func<TEntity, bool> expression);
        PagedResult<TEntity> GetElements(int pageNumber, int pageSize);
        IEnumerable<TEntity> SelectElements(Func<TEntity, TEntity> expression);
        TEntity GetElementByID(Guid ObjId);
        void InsertElement(TEntity Obj);
        void UpdateElement(TEntity NewObj);
        IEnumerable<TEntity> GetWithItems(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetWithItems(params Expression<Func<TEntity, object>>[] includes);
    }
}
