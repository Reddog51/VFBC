<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="VFBC.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visit Florida Brightcove Integration Page 2</title>
    <link href="vfbcstyle.css" rel="stylesheet" />
    <script src="lib/jQuery-Ajax-File-Upload-master/jquery-fileupload.js"></script>
</head>
<body>
    <div id="outer">
        <div id="inner">
            <h1>Page 2</h1>
            <form id="form1" runat="server" action="https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/1">
                <div>
                    <input type="submit" name="sb1" id="sb1" value="submit" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
