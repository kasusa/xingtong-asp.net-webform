<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Xingtong_NETFRAME.Pages.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Panel ID="Panel1" runat="server">

            <h1 class="display-4">如需使用任何功能,<br>
                请先点击右上角的登录</h1>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <h1 class="display-4">
                行通管理系统欢迎您的使用!<br>
                ←请选择左侧的功能以继续<br>
               <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#669900"></asp:Label></h1>
        </asp:Panel>
        <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
    </div>

</asp:Content>
