// Al Roben Adriane Goh - 300910584

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Success : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        Page.Theme = Application["CurrentTheme"].ToString();
    }

    // Al Roben Adriane Goh - 300910584

    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];
        txtMessage.InnerText = type == "add" ? "Recipe successfully added!" : "Recipe successfully deleted!";
    }
}

// Al Roben Adriane Goh - 300910584