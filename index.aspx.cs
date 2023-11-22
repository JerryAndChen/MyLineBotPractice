using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        user_data user = Master.user;
        if(user != null)
        {
            spWelcome.InnerText = "您好，" + user.userName;
        }
    }
    
}