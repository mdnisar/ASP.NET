using System.Linq;
using System.Web.UI;
using System.Xml.Linq;

public class noty
{
    public enum allTypes
    {
        alert,
        information,
        error,
        warning,
        notification,
        success
    }
    public enum layout
    {
        topLeft,
        topCenter,
        topRight,
        centerLeft,
        center,
        centerRight,
        bottomLeft,
        bottomCenter,
        bottomRight,
        top,
        bottom
    }
    
    public void notify(System.Web.UI.Page myPage,string message,allTypes types)
    {
        ScriptManager.RegisterClientScriptBlock(myPage, typeof(Page), "notification1", "notification1('" + message + "','" + types + "')", true);
    }
    public void notify(System.Web.UI.Page myPage, string message, allTypes types, layout layout)
    {
        ScriptManager.RegisterClientScriptBlock(myPage, typeof(Page), "notification2", "notification2('" + message + "','" + types + "','" + layout + "')", true);
    }

    public void notify(System.Web.UI.Page myPage, string message, allTypes types, layout layout, string timeout)
    {
        ScriptManager.RegisterClientScriptBlock(myPage, typeof(Page), "notification2", "notification3('" + message + "','" + types + "','" + layout + "','" + timeout + "')", true);
    }
}
