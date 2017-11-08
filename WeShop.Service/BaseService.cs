using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;
using WeShop.IService;

namespace WeShop.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Remove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Removes(IEnumerable<TEntity> tEntity)
        {
            _baseRepository.Deletes(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Modify(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.SaveChanges();
        }
        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryCount(whereLambda);
        }
        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntity(whereLambda);
        }
        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }

        public IEnumerable<TEntity> GetEntityiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Func<TEntity, bool> whereLambda, Func<TEntity, TType> orderByLambda)
        {
            return _baseRepository.QuetyEntityiesByPage(pageSize, pageIndex, isAsc, whereLambda, orderByLambda);
        }
    }
}
