using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Auth 的摘要描述
/// </summary>
public class Auth
{
    private static Auth auth;
    public Auth()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public static Auth getInstance()
    {
        if (auth == null)
        {
            auth = new Auth();
        }
        return auth;
    }
    public HttpSessionState getSession()
    {
        return HttpContext.Current.Session;
    }
    public UserData getCurrentUser_Old()
    {
        UserData user = (UserData)getSession()[WebConstants.Session_Current_User];
        return user;
    }
    public user_data getCurrentUser()
    {
        user_data user = (user_data)getSession()[WebConstants.Session_Current_User];
        return user;
    }
}