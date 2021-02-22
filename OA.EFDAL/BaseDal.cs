using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{/// <summary>
/// 封装所有Dal公共的crud
/// </summary>
   public class BaseDal<T> where T:class,new()//含构造函数的引用类型泛型
    {
        //DataModelContainer db = new DataModelContainer();//需保证上下文实例唯一
        //依赖抽象编程，减少代码改动
        public DbContext db {
            get {return DbContextFactory.GetCurrentDbContext(); }
        }
        #region 查询
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda) //通用条件查询
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public IQueryable<T> GetPageGetEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> OrderByLambda, bool IsAsc) //通用分页条件查询
        {
            total = db.Set<T>().Where(whereLambda).Count();
            if (IsAsc)
            {
                var temp = db.Set<T>().Where(whereLambda)
                    .OrderBy(OrderByLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = db.Set<T>().Where(whereLambda)
                   .OrderByDescending(OrderByLambda)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize).AsQueryable();
                return temp;
            }
        }
        #endregion
        #region cud
        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var entity = db.Set<T>().Find(id);
            db.Set<T>().Remove(entity);
            return true;
        }
        #endregion
    }
}
