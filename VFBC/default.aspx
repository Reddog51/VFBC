<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="VFBC._default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visit Florida Brightcove Integration Demo</title>
    <link href="vfbcstyle.css" rel="stylesheet" />
</head>
<body>
    <div id="outer">
        <div id="inner">
            <form id="form1" runat="server">
                <div class="row">
                    <h1 class="title">Visit Florida Brightcove Integration Demo</h1>
                </div>
                    <div class="row">
                        <h2>Upload New Video</h2>
                        <asp:Label ID="lbl1" runat="server" Text="Please select video for upload" CssClass="LargeLabel" />
                        <hr />
                        <br />
                    </div>
                    <div class="row">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="LargeLabel" />
                        <hr />
                        <br />
                    </div>
                    <div class="row">
                        <div class="fLeft25">
                            <asp:Label ID="lblTitle" Text="Video Title: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="tbTitle" runat="server" CssClass="TextBoxCaption LargeLabel" /><br />
                            <asp:Label ID="uploadErrorTitle" runat="server" Visible="false" CssClass="red" />
                        </div>

                        <div class="fLeft25">
                            <asp:Label ID="lblCaption" Text="Video Caption: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="tbCaption" runat="server" CssClass="TextBoxCaption LargeLabel" /><br />
                            <asp:Label ID="uploadErrorCaption" runat="server" Visible="false" CssClass="red" />
                        </div>
                        <div class="clear" />

                        <br />
                    </div>
                    <div class="row">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload to Visit Florida Brightcove" OnClick="btnUpload2Portal_Click" CssClass="upLoadBtn" />
                        <br />
                        <br />
                        <asp:Label ID="RetVal" runat="server" Text="FileSuccessfully uploaded" Visible="false" CssClass="LargeLabel" />
                    </div>
                <div class="row">
                    <hr />
                </div>
                <asp:Panel ID="pnl2" runat="server" Visible="true">
                    <div class="row"><!--  -->
                        <h2>Edit Existing Video Title and Caption</h2>
                        <br />
                        </div>
                        <div class="row">
                            <div class="fLeft33">
                                <asp:Label ID="Label5" Text="Enter Media Key: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="MediaKeyUpdate" runat="server" CssClass="TextBoxCaption LargeLabel"/><br />
                            </div>
                            <div class="fLeft33">
                                <asp:Label ID="Label1" Text="New Title: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="tbTitleUpdate" runat="server" CssClass="TextBoxCaption LargeLabel" /><br />
                                <asp:Label ID="titleUpdateError" runat="server" Visible="false" CssClass="red" />
                            </div>

                            <div class="fLeft33">
                                <asp:Label ID="Label3" Text="New Caption: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="tbCaptionUpdate" runat="server" CssClass="TextBoxCaption LargeLabel" /><br />
                                <asp:Label ID="titleUpdateCaptionError" runat="server" Visible="false" CssClass="red" />
                            </div>
                            <div class="clear" />

                            <br />
                        </div>
                        <div class="row">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update Title and Caption" OnClick="btnUpDate2Portal_Click" CssClass="upLoadBtn" />
                            <br />
                            <br />
                            <asp:Label ID="RetValUpdate" runat="server" Text="FileSuccessfully updated" Visible="false" CssClass="LargeLabel" />
                        </div>
                </asp:Panel>
                <div class="row">
                    <hr />
                </div>
                <asp:Panel ID="pnl3" runat="server" Visible="true">
                    <div class="row">
                        <h2>Delete Video</h2>
                        <br />
                    </div>
                    <div class="row">
                        <div class="fLeft33">
                            <asp:Label ID="Label8" Text="Enter Media Key: " runat="server" CssClass="LargeLabel" /><asp:TextBox ID="MediaKeyDelete" runat="server" CssClass="TextBoxCaption LargeLabel" text=""/><br />
                        </div>
                        <div class="clear" />
                        <br />
                    </div>
                    <div class="row">
                        <asp:Button ID="Button1" runat="server" Text="Delete Selected File" OnClick="btnDelete2Portal_Click" CssClass="upLoadBtn" />
                        <br />
                        <asp:Label ID="RetValDelete" runat="server" Text="FileSuccessfully deleted" Visible="false" CssClass="LargeLabel" />
                    </div>

                </asp:Panel>
            </form>
        </div>
    </div>
</body>
</html>
<!--
    MODOPTEST0014000001hVJ1GAAW01102017120348125.mov
5278776744001
PR-MODOPTEST0014000001hVJ1GAAW01102017120348125.mov
01/11/2017 3:59 PM
01/11/2017 3:59 PM
00:00
MODOPTEST01112017155907585.mp4
5278780374001
PR-MODOPTEST01112017155907585.mp4
01/11/2017 3:59 PM
01/11/2017 3:59 PM
01:29
0014000001hVJ1GAAW01102017120348125.mp4
0014000001hVJ1GAAW01102017120348125.mp4
5276883967001
PR-0014000001hVJ1GAAW01102017120348125.mp4
01/10/2017 9:06 AM
01/10/2017 9:10 AM
00:06
Adobe_Sample_6Sec
Adobe_Sample_6Sec
4897773021001
05/17/2016 9:16 AM
01/10/2017 8:17 AM
02:11
Vintage Clothing in Ybor City
Vintage Clothing in Ybor City
2849617225001
qwwgtdvkyjwktjyt
11/18/2013 9:39 PM
01/10/2017 8:16 AM
02:30
Shell Point Sailing (Tim Wheeler)
Shell Point Sailing (Tim Wheeler)
4013678796001
     -->