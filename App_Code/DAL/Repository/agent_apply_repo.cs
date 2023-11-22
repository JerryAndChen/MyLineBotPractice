using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// agent_apply_repo 的摘要描述
/// </summary>
public class agent_apply_repo : SuperRepo
{
    public void doCreate(agent_apply agent)
    {
        using(var db = new LineServiceEntities())
        {
            db.agent_apply.Add(agent);
            db.SaveChanges();
        }
    }
    public void doUpdate(agent_apply agent)
    {
        using (var db = new LineServiceEntities())
        {
            db.Entry(agent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
    public agent_apply doQueryOne(Expression<Func<agent_apply,bool>> predicate)
    {
        agent_apply agent;
        using(var db = new LineServiceEntities())
        {
            agent = db.agent_apply.FirstOrDefault(predicate);
        }
        return agent;
    }
    public List<agent_apply> doQueryAll(Expression<Func<agent_apply, bool>> predicate)
    {
        List<agent_apply> agentList;
        using (var db = new LineServiceEntities())
        {
            agentList = db.agent_apply.Where(predicate).ToList();
        }
        return agentList;
    }
}