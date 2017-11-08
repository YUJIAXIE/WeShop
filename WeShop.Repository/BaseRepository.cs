using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;

namespace WeShop.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private WeShopDb _dbContext = DbContextFactory.GetIntance();
        private DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }
        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }
        public void Deletes(IEnumerable<TEntity> tEntity)
        {
            _dbSet.RemoveRange(tEntity);
        }
        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            //更改实体的状态为已修改
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }
        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Count(whereLambda);
        }
        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }
        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }
        public IEnumerable<TEntity> QuetyEntityiesByPage<TType>(int paseSize, int pageIndex, bool isAsc, Func<TEntity, bool> whereLambda, Func<TEntity, TType> orderByLamnda)
        {
            //生成查询语句
            var result = _dbSet.Where(whereLambda);
            //附加排序
            result = isAsc ? result.OrderBy(orderByLamnda) : result.OrderByDescending(orderByLamnda);
            //附加分页
            var offset = (pageIndex - 1) * paseSize;
            result = result.Skip(offset).Take(paseSize);
            return result;
        }
    }
}
