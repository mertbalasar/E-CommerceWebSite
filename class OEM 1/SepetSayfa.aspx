<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SepetSayfa.aspx.cs" Inherits="class_OEM_1.SepetSayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sepetim</title>
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
        .auto-style5 {
            float: left;
            height: 1px;
            width: 189px;
        }
        .auto-style6 {
            float: left;
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
                <td style="padding-right: 60px"> 
                    <asp:Panel ID="divicerik" style="width: 100%; background-color: #CD5C5C; height: 600px; min-width: 600px" runat="server">
                        <asp:Panel ID="Sepettekiler" style="width: 100%; background-color: #CD5C5C; height: 150px;" runat="server" ScrollBars="Auto">
                            <asp:Panel style="width: 33%; height: 25px; background-color: #CD5C5C; float:left" runat="server">
                                <asp:Label Text="ÜRÜN ADI" style="font-family:Calibri; font-size:18px; font-weight:bold;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 33%; height: 25px; background-color: #CD5C5C; float:left" runat="server">
                                <asp:Label Text="ÜRÜN ADEDİ" style="font-family:Calibri; font-size:18px; font-weight:bold;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 33%; height: 25px; background-color: #CD5C5C; float:left" runat="server">
                                <asp:Label Text="İŞLEM" style="font-family:Calibri; font-size:18px; font-weight:bold;" runat="server"></asp:Label>
                            </asp:Panel>
                        </asp:Panel>
                        <hr class="auto-style5" style="border-width: 0px; background-color: #000000; border-color: #000000; width: 100%; height: 2px;" />
                        <asp:Panel style="width: 100%; background-color: #CD5C5C; height: 30px;" runat="server">
                            <asp:Label ID="TotalPrice" Text="Toplam Fiyat: " style="font-family:Calibri; font-size:18px; font-weight:bold;" runat="server"></asp:Label>
                        </asp:Panel>
                        <asp:Panel style="width: 100%; background-color: #CD5C5C; height: 100px; margin-top:20px" runat="server">
                            <asp:Label Text="Teslimat Adresi: " style="font-family:Calibri; font-size:16px; float:left; margin-left:10px" runat="server"></asp:Label>
                            <asp:TextBox ID="TeslimAdresi" TextMode="MultiLine" style="font-family:Calibri; font-size:16px; float:left; margin-left:10px; width:70%; height:80px;" runat="server"></asp:TextBox>
                        </asp:Panel>  
                        <hr class="auto-style5" style="border-width: 0px; background-color: #000000; border-color: #000000; width: 100%; height: 2px;" />
                        <asp:Panel ScrollBars="Auto" style="width: 100%; background-color: #CD5C5C; height: 200px; margin-top:20px" runat="server">
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                <asp:Label Text="Kredi Kartı Numarası " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">

                                <asp:TextBox ID="KartNo" runat="server" Width="90%"></asp:TextBox>

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                <asp:Label Text="Kredi Kartı Sahibinin Adı " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">

                                <asp:TextBox ID="KartSahip" runat="server" Width="90%"></asp:TextBox>

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                <asp:Label Text="Kredi Kartı Son Kullanma Tarihi " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                               
                                <asp:DropDownList ID="SKAy" runat="server" Width="45%">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="SKYıl" runat="server" Width="45%">
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                    <asp:ListItem>2024</asp:ListItem>
                                    <asp:ListItem>2025</asp:ListItem>
                                    <asp:ListItem>2026</asp:ListItem>
                                </asp:DropDownList>
                               
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                 <asp:Label Text="Kredi Kartı CVV Numarası " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">

                                <asp:TextBox ID="KartCVV" runat="server" Width="90%"></asp:TextBox>

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                  <asp:Label Text="Taksit Miktarı " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">

                                <asp:DropDownList ID="Taksit" runat="server" Width="90%">
                                    <asp:ListItem>Tek Çekim</asp:ListItem>
                                    <asp:ListItem>3 Ay (%0 Vade Farkı)</asp:ListItem>
                                    <asp:ListItem>6 Ay (%0 Vade Farkı)</asp:ListItem>
                                    <asp:ListItem>9 Ay (%0 Vade Farkı)</asp:ListItem>
                                    <asp:ListItem>12 Ay (%6 Vade Farkı)</asp:ListItem>
                                    <asp:ListItem>24 Ay (%9 Vade Farkı)</asp:ListItem>
                                    <asp:ListItem>36 Ay (%15 Vade Farkı)</asp:ListItem>
                                </asp:DropDownList>

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">
                                 <asp:Label Text="Mail Adresiniz " style="font-family:Calibri; font-size:16px; margin:10px;" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 25px; float:left;" runat="server">

                                <asp:TextBox ID="Mail" runat="server" TextMode="Email" Width="90%"></asp:TextBox>

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 40px; float:left;" runat="server">

                            </asp:Panel>
                            <asp:Panel style="width: 45%; background-color: #CD5C5C; height: 40px; float:left;" runat="server">
                                  <asp:Button ID="OdemeYap" Text="SATIN AL" style="cursor:pointer; font-family:Calibri; font-size:18px; color:#FFFFFF; background-image:url('arkaplan.jpg'); width:90%; height:100%; font-weight:bold;" runat="server" />
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
        </table>  
    </form>
</body>
</html>
