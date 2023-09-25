using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Util
{
    /// <summary>
    /// Util 的摘要描述
    /// </summary>
    public class Common
    {
        public static object get(object value)
        {
            return value ?? DBNull.Value;
        }
        public void ShowMsgAndGoTo(string msg, string location)
        {
            //ClientScript.RegisterStartupScript(typeof(Page), "alreadyExistsAccount", "showMsg(\"您已擁有會員帳號，請由首頁登入\");", true);
            //HttpContext.Current.Response.Redirect("login.aspx");
        }
    }
}
