using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private TreeMenuRepo treeMenuRepo;
    public user_data user;

    protected void Page_Init(object sender, EventArgs e)
    {
        user = Auth.getInstance().getCurrentUser();
        if (user == null)
        {
            Response.Redirect("~/LiffInit.aspx");
        }
        BuildTreeMenu("root", plSidebar, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
            
    }
    protected void BuildTreeMenu(string parentId, PlaceHolder pl, bool display)
    {
        treeMenuRepo = new TreeMenuRepo();
        List<TreeMenu> menuList = treeMenuRepo.GetTreeMenuNode(user.roleId, parentId);
        if (menuList.Count > 0)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("class", parentId);
            ul.Attributes.CssStyle.Add("display", display ? "" : "none");
            for (int i = 0; i < menuList.Count; i++)
            {
                TreeMenu treeMenu = menuList[i];
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "Mst_menu_node");
                li.Attributes.Add("id", treeMenu.Menu_id);
                li.Attributes.Add("data-parent", treeMenu.Parent);
                HyperLink a = new HyperLink();
                a.Text = treeMenu.Name;
                if (treeMenu.Url == null) {
                    PlaceHolder newpl = new PlaceHolder();
                    li.Controls.Add(newpl);
                    li.Attributes.Add("class", "Mst_menu_parent_node");
                    BuildTreeMenu(treeMenu.Menu_id, newpl, false);
                }
                else
                    a.NavigateUrl = treeMenu.Url;
                a.Attributes.CssStyle.Add("color", "inherit");
                a.Attributes.CssStyle.Add("text-decoration", "none");
                li.Controls.AddAt(0,a);
                ul.Controls.Add(li);
            }
            pl.Controls.Add(ul);
        }
    }
}
