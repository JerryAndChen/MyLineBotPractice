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
        var userId = Session["userId"] as string;
        if (userId == null)
        {
            Response.Redirect("xx.html");
        }

        if (!checkIfUserExists(userId))
        {
            Response.Redirect("register.aspx");
        }
        
    }
    private bool checkIfUserExists(string userId)
    {
        UserDataRepo userDataRepo = new UserDataRepo();
        UserData userData = userDataRepo.GetUserDataById(userId);
        if (userData == null)
            return false;

        return true;
    }
}