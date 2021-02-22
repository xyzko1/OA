using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public interface IBaseService<T> where T:class,new()
    {
        #region 查询
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda); //通用条件查询
        IQueryable<T> GetPageGetEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> OrderByLambda, bool IsAsc);//通用分页条件查询
        #endregion
        #region cud
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        bool Delete(int id);

        int DeleteList(List<int> ids);
        #endregion
    }
}
