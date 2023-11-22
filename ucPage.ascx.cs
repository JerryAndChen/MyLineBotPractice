using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucPage : System.Web.UI.UserControl
{
    public event EventHandler lbPage_Clicked;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public PagedDataSource BindPageInfo(List<agent_data> list)
    {
        PagedDataSource pgData = new PagedDataSource();
        pgData.DataSource = list;
        pgData.AllowPaging = true;
        pgData.PageSize = 5;
        pgData.CurrentPageIndex = Request["index"]!=null ? Util.Common.parseInt(Request["index"]) : 0;
        if (pgData.PageCount > 1)
        {
            rptPage.Visible = true;
            //1
            //ArrayList arrList = new ArrayList();
            //for (int i = 0; i < pgData.PageCount; i++)
            //{
            //    arrList.Add((i + 1).ToString());
            //}
            //rptPage.DataSource = arrList;
            //rptPage.DataBind();
            //2
            Panel plContainer = new Panel();
            plContainer.Attributes.Add("align", "center");
            rptPage.Controls.Add(plContainer);
            for (int i = 0; i < pgData.PageCount; i++)
            {
                if (i == pgData.CurrentPageIndex)
                {
                    Label label = new Label();
                    label.CssClass = "pgLabel";
                    label.Style.Add("color", "red");
                    label.Text = (i + 1).ToString();
                    plContainer.Controls.Add(label);
                }
                else
                {
                    HyperLink link = new HyperLink();
                    link.CssClass = "pgLink";
                    link.NavigateUrl = Request.Path + "?index=" + i;
                    link.Text = (i + 1).ToString();
                    plContainer.Controls.Add(link);
                }
                
            }

        }
        else
        {
            rptPage.Visible = false;
        }
        return pgData;
    }
    public PagedDataSource BindPageInfo(DataTable dt)
    {
        PagedDataSource pgData = new PagedDataSource();
        pgData.DataSource = dt.DefaultView;
        pgData.AllowPaging = true;
        pgData.PageSize = 5;
        pgData.CurrentPageIndex = Request["index"] != null ? Util.Common.parseInt(Request["index"]) : 0;
        if (pgData.PageCount > 1)
        {
            rptPage.Visible = true;
            //1
            //ArrayList arrList = new ArrayList();
            //for (int i = 0; i < pgData.PageCount; i++)
            //{
            //    arrList.Add((i + 1).ToString());
            //}
            //rptPage.DataSource = arrList;
            //rptPage.DataBind();
            //2
            Panel plContainer = new Panel();
            plContainer.Attributes.Add("align", "center");
            rptPage.Controls.Add(plContainer);
            for (int i = 0; i < pgData.PageCount; i++)
            {
                if (i == pgData.CurrentPageIndex)
                {
                    Label label = new Label();
                    label.CssClass = "pgLabel";
                    label.Style.Add("color", "red");
                    label.Text = (i + 1).ToString();
                    plContainer.Controls.Add(label);
                }
                else
                {
                    HyperLink link = new HyperLink();
                    link.CssClass = "pgLink";
                    link.NavigateUrl = Request.Path + "?index=" + i;
                    link.Text = (i + 1).ToString();
                    plContainer.Controls.Add(link);
                }

            }

        }
        else
        {
            rptPage.Visible = false;
        }
        return pgData;
    }
    public void lbPage_Click(object sender, EventArgs e)
    {
        //lbPage_Clicked(sender, e);
    }
}