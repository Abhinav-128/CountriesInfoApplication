<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountriesForm.aspx.cs" Inherits="CountryInfo.Countries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Weather Report App and Countries Information">
            <asp:Label ID="Label1" runat="server" BackColor="#660066" BorderStyle="Solid" ForeColor="White" Text="Cities and Countries Information App" Width="382px"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:DropDownList ID="Continents" runat="server" Height="16px" OnSelectedIndexChanged="Continents_SelectedIndexChanged" Width="297px" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <br />
        </div>
        <asp:DropDownList ID="Countries1" runat="server" Height="16px" OnSelectedIndexChanged="Countries_SelectedIndexChanged" Width="297px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="MoreInfo" runat="server" OnClick="MoreInfo_Click" Text="More Information" Width="237px" />
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="SearchCity" runat="server" AutoPostBack="True" OnTextChanged="SearchCity_TextChanged" style="width: 168px"></asp:TextBox>
        </p>
        <p>
            <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="297px" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Run" runat="server" OnClick="Run_Click" Text="Show" Width="138px" />
        <style>
    .city-info-box {
        position: absolute;   /* 🔥 free positioning */
        top: 400px;           /* adjust as needed */
        left: 500px;
        text-align: center;
    }
</style>

<div class="city-info-box">
    <asp:Label 
        ID="lblCityInfo" 
        runat="server" 
        Text="City Info"
        Font-Bold="true" />

    <br /><br />

    <asp:DetailsView 
        ID="CityInfo" 
        runat="server"
        AutoGenerateRows="true" OnPageIndexChanging="CityInfo_PageIndexChanging">
    </asp:DetailsView>
</div>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Country Information" Font-Bold="True"></asp:Label>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="125px">
        </asp:DetailsView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
