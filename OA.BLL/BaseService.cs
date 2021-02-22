using OA.IDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OA.BLL
{/// <summary>
/// 父类要逼迫自己给父类的一个属性赋值
/// 赋值的操作必须在父类的方法调用之前先执行
/// </summary>
/// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T:class,new() 
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession {
            get { return DALFactory.DbSessionFactory.GetCurrentDbSession(); }
        }
        public BaseService()//基类构造函数，早于调用操作方法之前执行子类Dal赋值
        {
            SetCurrentDal();//抽象方法，执行子类的方法
        }
        public abstract void SetCurrentDal();//抽象方法：要求之类必须实现    
        #region 查询
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda) //通用条件查询
        {
            return CurrentDal.GetEntities(whereLambda);
        }
        public IQueryable<T> GetPageGetEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> OrderByLambda, bool IsAsc) //通用分页条件查询
        {
            return CurrentDal.GetPageGetEntities(pageSize, pageIndex,out total, whereLambda, OrderByLambda, IsAsc);
        }
        #endregion
        #region cud
        public T Add(T entity)
        {
             CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges()>0;
        }
        public bool Delete(T entity)
        {
             CurrentDal.Delete(entity);
            return DbSession.SaveChanges()> 0;
        }
        public bool Delete(int id)
        {
             CurrentDal.Delete(id);
            return DbSession.SaveChanges()>0;
        }
        //批量删除
        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Delete(id);
            }
            return DbSession.SaveChanges();
        }
        #endregion
    }
}