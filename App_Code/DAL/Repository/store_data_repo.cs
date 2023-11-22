using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// store_data_repo 的摘要描述
/// </summary>
public class store_data_repo : SuperRepo
{
    public void doCreate(store_data store)
    {
        using(var db = new LineServiceEntities())
        {
            db.store_data.Add(store);
            db.SaveChanges();
        }
    }
    public void doUpdate(store_data store)
    {
        using (var db = new LineServiceEntities())
        {
            db.SaveChanges();
        }
    }
    public store_data doQueryOne(Expression<Func<store_data,bool>> predicate)
    {
        store_data store;
        using(var db = new LineServiceEntities())
        {
            store = db.store_data.FirstOrDefault(predicate);
        }
        return store;
    }
    public List<store_data> doQueryAll(Expression<Func<store_data, bool>> predicate)
    {
        List<store_data> storeList;
        using (var db = new LineServiceEntities())
        {
            storeList = db.store_data.Where(predicate).ToList();
        }
        return storeList;
    }
}