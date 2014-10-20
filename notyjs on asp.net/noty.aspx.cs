using System;
using System.Linq;
using System.Xml.Linq;

public partial class del_noty : System.Web.UI.Page
{
    noty nty = new noty();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        //nty.notify(this, "this is an kkkasdf message", noty.allTypes.success);
        nty.notify(this, "this is an kkkasdf message", noty.allTypes.success,noty.layout.top);
    }

}
