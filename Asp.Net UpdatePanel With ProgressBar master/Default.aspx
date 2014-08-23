<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="del_updatepanel_withprogressbar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Opaque
        {
            opacity: 0.6;
            filter: alpha(opacity=50);
            -moz-opacity: 0.6;
            position: absolute;
            height: 2000px;
            width: 2000px;
            background-color: #000000;
            z-index: 20;
            overflow:hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div id="Layer1" class="Opaque">
                        </div>
                        <img id="UpdateProgressImage" alt="Loading..." src="images/ajax-loader-(opt).gif"
                            style="left: 50%; top: 50%; position: absolute; z-index: 20;" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
          
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
            <asp:Button ID="btn" Text="calculate 2+2" runat="server" onclick="btn_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
