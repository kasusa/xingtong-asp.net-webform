<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="personinfo_query.aspx.cs" Inherits="xingtong_netframe472.Pages.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>个人信息查询</h2>
        <br>
        <div id="accordion">
            <div class="card">
                <div class="card-header">
                    过滤器
                </div>
                <div class="card-body">
                    <table>
                        <tr>
                            <td>姓名:</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>身份证:</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                            <td > <asp:Button class="btn" forecolor="SteelBlue" ID="Button1" runat="server" Text="过滤" /></td>
                        </tr>
                    </table>
                        
                </div>
                <div class="card-footer">
                    <a class="card-link" data-toggle="collapse" href="#collapseOne">如何使用过滤功能?
                    </a>
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-footer">
                        <ul>
                            <li>如果不使用过滤功能(输入框留空), 将会显示全部人员(因为数据量大,可能极其耗时)</li>
                            <li>使用过滤身份证过滤的功能, 将会匹配身份证前部号码</li>
                            <li>使用姓名过滤功能, 会模糊匹配姓名</li>
                        </ul>
                    </div>
                </div>
            </div>
            <br>
            <table class="table table-bordered table-hover">

                <thead class="thead-light">
                    <tr>
                        <th>姓名</th>
                        <th>性别</th>
                        <th>身份证</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>John</td>
                        <td>Doe</td>
                        <td>john@example.com</td>
                    </tr>
                    <tr>
                        <td>Mary</td>
                        <td>Moe</td>
                        <td>mary@example.com</td>
                    </tr>
                    <tr>
                        <td>July</td>
                        <td>Dooley</td>
                        <td>july@example.com</td>
                    </tr>
                </tbody>
            </table>

        </div>
    </div>
</asp:Content>
