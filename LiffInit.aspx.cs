﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LiffInit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hfLiffId.Value = System.Configuration.ConfigurationManager.AppSettings["liff_id"];
        hfState.Value = Request["state"];
    }
}