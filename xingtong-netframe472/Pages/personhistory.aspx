<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="personhistory.aspx.cs" Inherits="xingtong_netframe472.Pages.personhistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <h2>个人历史查询</h2>
        <br>
        <div id="accordion">
            <div class="card">
                <div class="card-header ">
                    过滤器

                </div>
                <div class="card-body form-group">
                    身份证号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="* " ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="* 身份证不合法" ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
                    <asp:Button CssClass ="btn" ID="Button1" runat="server" Text="查询" ForeColor="#0033CC" OnClick="Button1_Click" />


                    <asp:Button ID="Button2" runat="server" class="btn" ForeColor="#FF5050" OnClick="Button2_Click" OnClientClick="ButtonConf()" Text="清空输入" />


                </div>
                <div class="card-footer">
                    <a class="card-link" data-toggle="collapse" href="#collapseOne">如何使用?
                    </a>
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-footer">
                        <ul>
                            <li>请使用完整的身份证号查询出行记录</li>
                            <li>可以<a href="personinfo_query.aspx">个人信息查询</a> 在中查询</li>
                            <li>如果要查询具体日期的出行记录,可以按下<kbd>ctrl</kbd>+<kbd>F</kbd>使用浏览器搜索功能<br>
                                输入类似<kbd>2020-04-04</kbd>这样的日期格式进行具体定位</li>
                        </ul>
                    </div>
                </div>
            </div>
            <br>
            <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-success alert-dismissible">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>查询成功!</strong> 获取了
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>条记录
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-danger alert-dismissible">
                    <button type="button" class="close" data-dismiss="alert">&times;</button> 没有任何相关记录
                </div>
            </asp:Panel>
            <table id="mothertable" class="table table-bordered table-hover" style="margin-bottom: 80px;">
                <thead class="thead-light">
                    <tr>
                        <th>地区</th>
                        <th>小区</th>
                        <th>出入方向</th>
                        <th>时间</th>
                    </tr>
                </thead>
                <tbody id="aa">
                    <%= outputtable%>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
