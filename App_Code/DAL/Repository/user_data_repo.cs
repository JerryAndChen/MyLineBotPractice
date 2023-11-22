using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// user_data_repo 的摘要描述
/// </summary>
public class user_data_repo : SuperRepo
{
    public void doCreate(user_data user)
    {
        using(var db = new LineServiceEntities())
        {
            db.user_data.Add(user);
            db.SaveChanges();
        }
    }
    public void doUpdate(user_data user)
    {
        using (var db = new LineServiceEntities())
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
    public user_data doQueryOne(Expression<Func<user_data,bool>> predicate)
    {
        user_data user;
        using(var db = new LineServiceEntities())
        {
            user = db.user_data.FirstOrDefault(predicate);
        }
        return user;
    }
    public List<user_data> doQueryAll(Expression<Func<user_data, bool>> predicate)
    {
        List<user_data> userList;
        using (var db = new LineServiceEntities())
        {
            userList = db.user_data.Where(predicate).ToList();
        }
        return userList;
    }
}