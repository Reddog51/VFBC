<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wasdefault.aspx.cs" Inherits="VFBC._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visit Florida Brightcove Integration Sample</title>
    <link href="vfbcstyle.css" rel="stylesheet" />
</head>
<body>
    <div id="outer">
        <div id="inner">
            <h1>Visit Florida Portal - Brightcove Integration Sample .Net</h1>
            <p>
                File upload is working<br />
                need to call end point with file name<br />
                need to add byte [] to json<br />
                need to create web request and send to end point<br />
                Create call to end point and test without complications
            </p>
            <form id="form1" runat="server" method="post">
                <p>All values are being pulled from config file</p>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblBrightCoveClientId" Text="Brightcove Client Id: " runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblClientIdVal" runat="server" Text="Client Id Value" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblBrightCoveSecretClientId" Text="Brightcove Secret Client Id: " runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblClientSecIdVal" runat="server" Text="Client Secret Id Value" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblIngestProfile" Text="Ingest Profile: " runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblIngestPVal" runat="server" Text="Ingest Profile Value" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblIngestProfileName" Text="Ingest Profile Name: " runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblIngestPName" runat="server" Text="Ingest Profile Name Value" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblBrightcoveLoginId" Text="Brightcove Login Id:" runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblBCLogId" runat="server" Text="Brightcove Login Id Value" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Label ID="lblBrightcoveLoginPW" Text="Brightcove Login PW:" runat="server" />
                    </div>
                    <div class="fLeft25">
                        <asp:Label ID="lblBCPW" runat="server" Text="" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">&nbsp;</div>
                <div class="row">
                    <div class="fLeft15">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload to Portal" OnClick="btnUpload2Portal_Click" />
                    </div>
                    <div class="fLeft25">
                        <asp:FileUpload ID="fu" runat="server" />
                    </div>
                    <div class="clear" />
                </div>
                <div class="row">
                    <br />
                    <asp:Label ID="RetVal" runat="server" Text="FileSuccessfully uploaded" Visible="false" />
                </div>
                <div class="row">
                    <asp:Button ID="WorkPost" runat="server" Text="Work On Post" OnClick="btnWorkOnPost_Click" />
                </div>
                <br />
                <div class="row pad">
                    <div class="fLeft15">
                        <asp:Label ID="Label1" runat="server" Text="Mime Type" CssClass="lbl25" /></div>
                    <div class="fLeftLarge">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="tb1" /></div>
                    <div class="clear" />
                </div>
                <div class="row pad">
                    <div class="fLeft15">
                        <asp:Label ID="Label3" runat="server" Text="Submitted URL" CssClass="lbl25" /></div>
                    <div class="fLeftLarge">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="tb1" /></div>
                    <div class="clear" />
                </div>
                <div class="row pad">
                    <div class="fLeft15">
                        <asp:Label ID="lbl1" runat="server" Text="Submitted JSON" CssClass="lbl25" /></div>
                    <div class="fLeftLarge">
                        <asp:TextBox ID="tb2" runat="server" CssClass="tb1" /></div>
                    <div class="clear" />
                </div>
                <div class="row pad">
                    <div class="fLeft15">
                        <asp:Label ID="Label2" runat="server" Text="Server Reply Received" CssClass="lbl25" /></div>
                    <div class="fLeftLarge">
                        <asp:TextBox ID="tb1" runat="server" CssClass="tb1" /></div>
                    <div class="clear" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
<!-- https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/1 
    <input type="submit" value="Create" id="btnSubmit"/>
    $('#btnSubmit').click();
    -->
