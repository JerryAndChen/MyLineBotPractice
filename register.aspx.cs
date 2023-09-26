using System;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if Session["userId"] not exist, go to xx.html
        if (Session["userId"] == null)
        {
            Response.Redirect("xx.html");
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
                messageList.Add(new TextMessage("您好, 已註冊會員成功"));
                List<Button> buttons = new List<Button>();
                buttons.Add(new Button("uri", "進入會員中心", "https://liff.line.me/2000626468-ZQE950nX"));
                messageList.Add(new BubbleMessage("您好", "", "您已註冊會員成功", "訊息通知", buttons));
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

        UserDataRepo userDataRepo = new UserDataRepo();
        UserData userData = new UserData();
        userData.UserId = userId;
        userData.UserName = txtName.Text;
        userData.SexType = rdSexType.SelectedValue;
        userData.Phone = txtPhone.Text;
        userData.Email = txtEmail.Text;
        userData.Birth = DateTime.Parse(txtBirth.Text).ToString("yyyy-MM-dd");
        userData.RegisterTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        return userDataRepo.CreateUserData(userData);
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