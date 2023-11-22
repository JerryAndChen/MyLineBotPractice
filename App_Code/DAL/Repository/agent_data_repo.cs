using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// agent_data_repo 的摘要描述
/// </summary>
public class agent_data_repo : SuperRepo
{
    public void doCreate(agent_data agent)
    {
        using(var db = new LineServiceEntities())
        {
            db.agent_data.Add(agent);
            db.SaveChanges();
        }
    }
    public void doUpdate(agent_data agent)
    {
        using (var db = new LineServiceEntities())
        {
            db.Entry(agent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
    public agent_data doQueryOne(Expression<Func<agent_data,bool>> predicate)
    {
        agent_data agent;
        using(var db = new LineServiceEntities())
        {
            agent = db.agent_data.FirstOrDefault(predicate);
        }
        return agent;
    }
    public List<agent_data> doQueryAll(Expression<Func<agent_data, bool>> predicate)
    {
        List<agent_data> agentList;
        using (var db = new LineServiceEntities())
        {
            agentList = db.agent_data.Where(predicate).ToList();
        }
        return agentList;
    }
}