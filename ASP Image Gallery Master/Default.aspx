<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/imagegallery.ascx" TagPrefix="uc1" TagName="imagegallery" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:imagegallery runat="server" ID="imagegallery" BaseImagePath="gallery/" 
            MaxImageWidth="100" MaxImageHeight="100"  
            />
    </div>
    </form>
</body>
</html>
