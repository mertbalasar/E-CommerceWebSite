<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="class_OEM_1.AnaSayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ana Sayfa</title>
    <link href="AnaSayfa.css" rel="stylesheet" />
    <script type ="text/javascript">
        function change(lnk,evt)
        {
            if(evt.type == "mouseover")
            {
                lnk.style.color = "lightgray";
             
            }
            else if(evt.type == "mouseout")
            {
                lnk.style.color = "white";
            }
        }
    </script>
    <style type="text/css">
        .auto-style3 {
            width: 179px;
        }
        .auto-style4 {
            width: 212px;
        }
        .auto-style5 {
            float: left;
            height: 1px;
            width: 189px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="baslik">
            <asp:Panel ID="logo" runat="server" CssClass="divlogo"> </asp:Panel>
        </div>
        <table border="0" style="width: 100%">
            <tr>
                <td class="auto-style3" style="padding-right: 10px; padding-left: 60px">
                    <div class="menuler">
                        <button class="menuelements" disabled="disabled" style="cursor:default">KATEGORİLER</button>
                        <asp:Panel ID="kategoriler" runat="server"> </asp:Panel>
                        <button id="sepetclk" class="menuelements" onmouseover="change(this,event);" onmouseout="change(this,event);" runat="server">SEPETİM</button>
                        <button id="bizeulasclk" class="menuelements" onmouseover="change(this,event);" onmouseout="change(this,event);" runat="server">BİZE ULAŞIN</button>
                    </div>
                </td>
                <td class="auto-style4">
                    <div class="menuler">
                        <asp:Label ID="Label1" runat="server" CssClass="filtrea" Text="MARKA" Width="49px"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="filtred" Width="125px">
                        </asp:DropDownList>
                        <asp:Label ID="Label2" runat="server" CssClass="filtrea" Text="FİYAT" Width="49px"></asp:Label>
                        <asp:TextBox ID="Minimum" runat="server" CssClass="filtred" Width="50px" TextMode="Number" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="Maksimum" runat="server" CssClass="filtred" Width="50px" TextMode="Number" Enabled="false"></asp:TextBox>
                        <hr class="auto-style5" style="border-width: 0px; background-color: #000000; border-color: #000000; width: 100%; height: 2px;" />
                        <button class="menuelements" disabled="disabled" style="cursor:default">UYGULA</button>
                    </div>
                </td>
                <td style="padding-right: 60px"> 
                    <asp:Panel ID="divicerik" style="width: 100%; background-color: #CD5C5C; height: 600px; min-width: 600px" runat="server">

                    </asp:Panel>
                </td>
            </tr>
        </table>   
    </form>
</body>
</html>
