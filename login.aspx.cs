using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void btnLogin_Click(object sender, EventArgs e) 
    {
        //Response.Write("btnLogin is Clicked");
    }
    public void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}