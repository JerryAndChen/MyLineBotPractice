using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// SuperRepo 的摘要描述
/// </summary>
public abstract class SuperRepo
{
    public List<object> sqlquery(string sql)
    {
        List<object> list;
        using (var db = new LineServiceEntities())
        {
            list = db.Database.SqlQuery<object>(sql).ToList();
        }
        return list;
    }
    //public IQueryable linqQuery(Expression<Func<agent_apply, bool>> predicate)
    //{
    //    IQueryable query;
    //    using (var db = new LineServiceEntities())
    //    {
    //        query = db.
    //    }
    //    return list;
    //}
}