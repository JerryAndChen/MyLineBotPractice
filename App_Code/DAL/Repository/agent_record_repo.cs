using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// agent_record_repo 的摘要描述
/// </summary>
public class agent_record_repo : SuperRepo
{
    public void doCreate(agent_record record)
    {
        using(var db = new LineServiceEntities())
        {
            db.agent_record.Add(record);
            db.SaveChanges();
        }
    }
    public void doUpdate(agent_record record)
    {
        using (var db = new LineServiceEntities())
        {
            db.SaveChanges();
        }
    }
    public agent_record doQueryOne(Expression<Func<agent_record,bool>> predicate)
    {
        agent_record record;
        using(var db = new LineServiceEntities())
        {
            record = db.agent_record.FirstOrDefault(predicate);
        }
        return record;
    }
    public List<agent_record> doQueryAll(Expression<Func<agent_record, bool>> predicate)
    {
        List<agent_record> recordList;
        using (var db = new LineServiceEntities())
        {
            recordList = db.agent_record.Where(predicate).ToList();
        }
        return recordList;
    }
}