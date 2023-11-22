using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// city_map_repo 的摘要描述
/// </summary>
public class city_map_repo : SuperRepo
{
    public void doCreate(city_map data)
    {
        using(var db = new LineServiceEntities())
        {
            db.city_map.Add(data);
            db.SaveChanges();
        }
    }
    public void doUpdate(city_map data)
    {
        using (var db = new LineServiceEntities())
        {
            db.SaveChanges();
        }
    }
    public city_map doQueryOne(Expression<Func<city_map,bool>> predicate)
    {
        city_map data;
        using(var db = new LineServiceEntities())
        {
            data = db.city_map.FirstOrDefault(predicate);
        }
        return data;
    }
    public List<city_map> doQueryAll(Expression<Func<city_map, bool>> predicate)
    {
        List<city_map> dataList;
        using (var db = new LineServiceEntities())
        {
            dataList = db.city_map.Where(predicate).ToList();
        }
        return dataList;
    }
}