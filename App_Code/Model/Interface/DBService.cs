using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DBService 的摘要描述
/// </summary>
public class DBService
{
    private static DBService instance;
    public DBService()
    {
        lineServiceEntities = new LineServiceEntities();
    }
    public static DBService getInstance()
    {
        if(instance == null)
        {
            instance = new DBService();
        }
        return instance;
    }

    private LineServiceEntities lineServiceEntities;
    public LineServiceEntities GetLineServiceEntities()
    {
        return lineServiceEntities;
    }
}