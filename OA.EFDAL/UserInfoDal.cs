using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OA.EFDAL
  
{
    public partial class UserInfoDal: BaseDal<UserInfo>, IUserInfoDal
    {
        //DataModelContainer db = new DataModelContainer();//上下文
        //crud
        //#region 查询
        ////public UserInfo GetUserInfoById(int id) //根据ID查询
        ////{
        ////    return db.UserInfo.Find(id);
        ////}
        ////public List<UserInfo> GetAllUserInfosById() //查询所有
        ////{
        ////    return db.UserInfo.ToList();
        ////}
        //public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo, bool>> whereLambda) //通用条件查询
        //{
        //    return db.UserInfo.Where(whereLambda).AsQueryable();
        //}
        //public IQueryable<UserInfo> GetPageUsers<T>(int pageSize,int pageIndex,out int total,Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, T>> OrderByLambda,bool IsAsc) //通用分页条件查询
        //{
        //    total = db.UserInfo.Where(whereLambda).Count();
        //    if (IsAsc)
        //    {
        //        var temp = db.UserInfo.Where(whereLambda)
        //            .OrderBy(OrderByLambda)
        //            .Skip(pageSize * (pageIndex - 1))
        //            .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
        //    else
        //    {
        //        var temp = db.UserInfo.Where(whereLambda)
        //           .OrderByDescending(OrderByLambda)
        //           .Skip(pageSize * (pageIndex - 1))
        //           .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
        //}
        //#endregion
        //#region cud
        //public UserInfo Add(UserInfo userInfo)
        //{
        //    db.UserInfo.Add(userInfo);
        //    db.SaveChanges();
        //    return userInfo;
        //}
        //public bool Update(UserInfo userInfo)
        //{
        //    db.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
        //    return db.SaveChanges()>0;
        //}
        //public bool Delete(UserInfo userInfo)
        //{
        //    db.Entry(userInfo).State = System.Data.Entity.EntityState.Deleted;
        //    return db.SaveChanges() > 0;
        //}
        //#endregion

    }
}
