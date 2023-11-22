using System;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;
using System.Linq;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    CityMapRepo cityMapRepo;
    StoreDataRepo storeDataRepo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setCitySelect();
            setDistrictSelect();
            setStoreSelect();
        }
    }
    public void btnSubmit_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        if (Page.IsValid)
        {
            if (doCreate())
            {
                List<ILineMessage> messageList = new List<ILineMessage>();
                messageList.Add(new TextMessage("您好, 已註冊成功"));
                List<Button> buttons = new List<Button>();
                buttons.Add(new Button("uri", "進入系統", "https://liff.line.me/2000626468-ZQE950nX"));
                messageList.Add(new BubbleMessage("您好", "", "您已註冊成功", "註冊成功通知", buttons));
                string jsonMsg = JsonConvert.SerializeObject(LineMessage.createMessage(messageList));
                ClientScript.RegisterStartupScript(typeof(Page), "registerSuccessful", "registerSuccess(" + jsonMsg + ");", true);
                //ClientScript.RegisterStartupScript(typeof(Page), "registerSuccessful", "liff_sendMessages(" + jsonMsg + ");showMsgAndGoto(\"註冊成功\",\"index.aspx\");", true);
                //Response.Redirect("index.aspx");
            }
        }
    }
    public bool doCreate()
    {
        string userId = Session["userId"] as string;
        if (checkIfUserExists(userId))
        {
            //show error message => user is already exists
            ClientScript.RegisterStartupScript(typeof(Page), "alreadyExistsAccount", "showMsg(\"您已擁有會員帳號\");", true);
            return false;
        }

        user_data user = new user_data();
        user.userId = userId;
        user.userName = txtName.Text;
        user.sexType = rdSexType.SelectedValue;
        user.phone = txtPhone.Text;
        user.email = txtEmail.Text;
        user.birth = DateTime.Parse(txtBirth.Text);
        user.roleId = ddlRole.SelectedValue;
        user.cityId = ddlCity.SelectedValue;
        user.districtId = ddlDistrict.SelectedValue;
        user.storeId = ddlStore.SelectedValue;
        user.registerTime = DateTime.Now;
        try
        {
            RepoService.getInstance().user_repo().doCreate(user);
        }
        catch(Exception e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "createFailed", "showMsg(\"新增失敗\");", true);
            Util.Log.LogToFile("create user_data failed", e.Message);
            return false;
        }
            

        return true;
    }
    private bool checkIfUserExists(string userId)
    {
        user_data  user = RepoService.getInstance().user_repo().doQueryOne(u => u.userId == userId);
        if (user == null)
            return false;

        return true;
    }
    private void setCitySelect()
    {
        ddlCity.Items.Clear();
        cityMapRepo = new CityMapRepo();
        Dictionary<string, string> map = cityMapRepo.GetCity();
        foreach(var data in map)
        {
            ddlCity.Items.Add(new ListItem(data.Value,data.Key));
        }
    }
    private void setDistrictSelect()
    {
        ddlDistrict.Items.Clear();
        cityMapRepo = new CityMapRepo();
        Dictionary<string,string> map = cityMapRepo.GetDistrict(ddlCity.SelectedValue);
        foreach(var data in map)
        {
            ddlDistrict.Items.Add(new ListItem(data.Value, data.Key));
        }
    }
    private void setStoreSelect()
    {
        ddlStore.Items.Clear();
        storeDataRepo = new StoreDataRepo();
        Dictionary<string, string> map = storeDataRepo.GetStore(ddlCity.SelectedValue, ddlDistrict.SelectedValue);
        foreach (var data in map)
        {
            ddlStore.Items.Add(new ListItem(data.Value, data.Key));
        }
        //txtAddress.Text = map[ddlStore.SelectedValue];
    }
    public void ddlStore_Change(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        switch (ddl.ID)
        {
            case "ddlCity":
                setDistrictSelect();
                setStoreSelect();
                break;
            case "ddlDistrict":
                setStoreSelect();
                break;
        }
    }
}