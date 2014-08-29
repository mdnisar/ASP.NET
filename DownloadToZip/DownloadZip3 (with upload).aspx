<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DownloadZip3 (with upload).aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Download Multiple Files as zip files archive in Asp.net using c#,vb.net</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload ID="fileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload Files" onclick="btnUpload_Click" />    
    <br />
    <asp:Label ID="lbltxt" runat="server" Font-Bold="true" ForeColor="Red" />
    </div>
    <asp:GridView ID="gvDetails" CellPadding="5" runat="server" AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:CheckBox ID="chkSelect" runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Text" HeaderText="FileName" />
    </Columns>
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
    <asp:Button ID="btnDownload" Text="Download Selected Files" runat="server" onclick="btnDownload_Click" />
    </form>
</body>
</html>