
<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Xingtong_NETFRAME.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<div class="container  text-center loginform">
<center>
    <title>--登录</title>

<style>
    .sidebar {
        hidden:true;
        opacity: 0 ;
        filter:alpha(opacity=0);
    }
    .form-signin {
        width: 100%;
        max-width: 330px;
        padding: 15px;
        margin: auto;
    }
    .form-signin .checkbox {
        font-weight: 400;
    }
    .form-signin .form-control {
        position: relative;
        box-sizing: border-box;
        height: auto;
        padding: 10px;
        font-size: 16px;
    }
    .form-signin .form-control:focus {
        z-index: 2;
    }
    .loginform{
       max-width:500px;
    }
    .btn{
        max-width:300px;
    }
</style>  
    <form class="form-signin">
        &nbsp;<h1 class="h3 mb-3 font-weight-normal">登录</h1>

        <asp:TextBox class="form-control"  ID="TextBox1" runat="server" placeholder="大陆身份证号码"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="^必须填写" ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="^身份证号码格式错误" ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
        <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="密码" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="^必须填写" ControlToValidate="TextBox2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="checkbox mb-3">
            <asp:CheckBox ID="CheckBox1" runat="server" Text=""  title="(勾选后在这个浏览器上近期无需多次登录)"></asp:CheckBox>
            记住我
        </div>
        <div class="alert alert-info alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>注册?</strong> 如果你没有注册过，请先使用
            <a href="#" class="alert-link">移动端</a>
            注册，本系统仅供工作人员使用，普通用户不拥有登录权限。
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <div class="alert alert-danger alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </asp:Panel>
        <asp:Button class="btn btn-lg btn-primary btn-block"  ID="Button1" runat="server" Text="登录" OnClick="Button1_Click"></asp:Button>
    </form>
</center>
</div>


</asp:Content>
