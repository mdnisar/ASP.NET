<%@ Page Language="C#" AutoEventWireup="true" CodeFile="noty.aspx.cs" Inherits="del_noty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="js/jquery-latest.min.js" type="text/javascript"></script>

    <script src="js/jquery.noty.packaged.min.js" type="text/javascript"></script>

    <script>
        function notification1(text,type) {
        var n = noty({
            text        : text,
            timeout     : 4000,
            type        : type,
            dismissQueue: true,
            layout      : 'bottomRight',
            theme       : 'defaultTheme',
            maxVisible  : 5
        });
        }
        function notification2(text,type,layout) {
        var n = noty({
            text        : text,
            timeout     : 2000,
            type        : type,
            dismissQueue: true,
            layout      : layout,
            theme       : 'defaultTheme',
            maxVisible  : 1
        });
        }
        function notification3(text,type,layout,timeout) {
        var n = noty({
            text        : text,
            timeout     : timeout,
            type        : type,
            dismissQueue: true,
            layout      : layout,
            theme       : 'defaultTheme',
            maxVisible  : 1
        });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="x" runat="server">
        <ContentTemplate>
            <div>
            <br /><br /><br /><br /><br /><br />
                <input type="button" value="noty" onclick="notification1('notification1','alert');" />
                <asp:Button ID="btn" Text="Noty From Server" runat="server" OnClick="btn_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
