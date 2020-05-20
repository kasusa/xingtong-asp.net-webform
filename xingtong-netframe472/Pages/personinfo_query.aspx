<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="personinfo_query.aspx.cs" Inherits="xingtong_netframe472.Pages.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>个人信息查询</h2>
        <br>
        <div id="accordion">
            <div class="card">
                <div class="card-header ">
                    过滤器 | <asp:CheckBox  ID="CheckBox1" runat="server" Text="判断工作人员"  ForeColor="#666666" />
                </div>
                <div class="card-body form-group">
                    <table>
                        <tr>
                            <td>姓名:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>身份证:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Button class="btn" ForeColor="SteelBlue" ID="Button1" runat="server" Text="过滤" OnClick="Button1_Click" />
                                <asp:Button class="btn" ID="Button2" ForeColor="#FF5050" runat="server" Text="清空输入" OnClick="Button2_Click" OnClientClick="ButtonConf()" />
                               
                            </td>
                        </tr>

                    </table>
                     

                </div>
                <div class="card-footer">
                    <a class="card-link" data-toggle="collapse" href="#collapseOne">如何使用?
                    </a>
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-footer">
                        <ul>
                            <li>如果输入框留空, 将会显示全部结果</li>
                            <li>使用过滤身份证过滤的功能, 将会匹配身份证前部号码</li>
                            <li>使用姓名过滤功能, 会模糊匹配姓名</li>
                            <li>使用判断工作人员功能, 具体信息中会显示是否为工作人员 (可能比较耗时)<br>
                                如果不勾选，所有都会人的显示为 False</li>
                        </ul>
                    </div>
                </div>
            </div>
            <br>
            <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-success alert-dismissible">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>查询成功!</strong> 获取了<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>条记录
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-danger alert-dismissible">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    没有任何相关记录
                </div>
            </asp:Panel>
            <style>
                #mothertable > tbody > tr:nth-child(odd):hover {
                    background-color: rgba(0, 0, 0, 0.05);
                }
            </style>
            <table id="mothertable" class="table table-bordered " style="margin-bottom: 80px;">

                <thead class="thead-light">
                    <tr>
                        <th>姓名</th>
                        <th>性别</th>
                        <th>身份证</th>
                    </tr>
                </thead>
                <tbody id="aa">
                    <%= outputtable%>
                </tbody>
            </table>

        </div>
    </div>
</asp:Content>
