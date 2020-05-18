<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="xingtong_netframe472.Pages.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn {
            max-width: 300px;
        }
    </style>
    <h1 class="h3 mb-3 font-weight-normal">登出</h1>
        您确定要登出吗？如果您登出，在下次登入之前将会不能进行任何系统操作。
    <br />
    <br />

     <asp:Button class="btn btn-lg btn-danger btn-block"  ID="Button1" runat="server" Text="登出" OnClick="Button1_Click" ></asp:Button>
     <asp:Button class="btn btn-lg btn-secondary btn-block"  ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  ></asp:Button>

</asp:Content>
