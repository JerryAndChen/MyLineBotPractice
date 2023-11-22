using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cfgSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addOption(ref ddlStartH, 0, 23, true);
            addOption(ref ddlStartT, 0, 59, true);
            addOption(ref ddlEndH, 0, 23, true);
            addOption(ref ddlEndT, 0, 59, true);
            addOption(ref ddlPStartH, 0, 23, true);
            addOption(ref ddlPStartT, 0, 59, true);
            addOption(ref ddlPEndH, 0, 23, true);
            addOption(ref ddlPEndT, 0, 59, true);
            txtStartD.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtEndD.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    protected void rdType_Changed(object sender, EventArgs e)
    {
        Response.Write("this");
    }
    public void addOption(ref DropDownList ddlType, int initVal, int limitVal, bool addZero)
    {
        ddlType.Items.Clear();
        while (initVal <= limitVal)
        {
            ddlType.Items.Add(new ListItem(formatOption(initVal, addZero)));
            initVal++;
        }
    }
    public string formatOption(int val, bool addZero)
    {
        string fVal = val.ToString();
        if (addZero)
        {
            if (fVal.Length == 1)
                return "0" + fVal;
        }
        return fVal;
    }
}