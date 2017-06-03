<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AspProjectApplication._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Label1" runat="server" Text="Label">Натискайки този бутон вие ще заредите всички XML файлове в Базата от данни</asp:Label>
    <asp:Button ID="submit_Button" runat="server" 
        Text="Въвеждане на XML документите в  БД" onclick="submit_Button_Click" 
        />
    <hr />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" 
        Text="Резултат от зареждането на XML документите:"></asp:Label>
    <br />
    <asp:TextBox ID="submissionResult_TextBox" runat="server" Height="373px" 
        ReadOnly="True" TextMode="MultiLine" Width="732px"></asp:TextBox>
    <br />
    <br />
    <br />

    &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" 
        Text="Натискайки този бутон Вие ще бъдете препратени към попълване на Уеб форма"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="fillXML" runat="server" 
    Text="Попълване на XML документ" onclick="fillXML_Click" Height="22px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <hr />
    <br /><br />

    <asp:TextBox ID="errorsLog_TextBox" runat="server" Height="379px" 
        ReadOnly="True" TextMode="MultiLine" Width="664px" Visible="False"></asp:TextBox>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

    </asp:Content>
