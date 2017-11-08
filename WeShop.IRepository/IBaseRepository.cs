using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeShop.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        void Insert(TEntity tEntity);
        void Delete(TEntity tEntity);
        void Deletes(IEnumerable<TEntity> tEntity);
        void Update(TEntity tEntity);
        bool SaveChanges();
        int QueryCount(Func<TEntity, bool> whereLambda);
        TEntity QueryEntity(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> QuetyEntityiesByPage<TType>(int paseSize, int pageIndex, bool isAsc, Func<TEntity, bool> whereLambda, Func<TEntity, TType> orderByLamnda);
    }
}
