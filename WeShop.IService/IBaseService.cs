using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShop.IService
{
    public interface IBaseService<TEntity>where TEntity:class,new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        bool Add(TEntity tEntity);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        bool Remove(TEntity tEntity);
        /// <summary>
        /// 多个移除
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        bool Removes(IEnumerable<TEntity> tEntity);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        bool Modify(TEntity tEntity);
        /// <summary>
        /// 查询个数
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int GetCount(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        TEntity GetEntity(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 查询多个
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="paseSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLamnda"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntityiesByPage<TType>(int paseSize, int pageIndex, bool isAsc, Func<TEntity, bool> whereLambda, Func<TEntity, TType> orderByLamnda);
    }
}
