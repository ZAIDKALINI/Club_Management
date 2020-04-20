using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    interface IGenericBasecs<TEntity> where TEntity : class
    {
        void DeleteElement(TEntity obj);
        IEnumerable<TEntity> GetElements();
        IEnumerable<TEntity> GetElements(Func<TEntity, bool> expression);
        IEnumerable<TEntity> SelectElements(Func<TEntity, TEntity> expression);
        TEntity GetElementByID(int ObjId);
        void InsertElement(TEntity Obj);
        void UpdateElement(TEntity NewObj);



    }
}
