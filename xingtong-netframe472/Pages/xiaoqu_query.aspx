<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="xiaoqu_query.aspx.cs" Inherits="xingtong_netframe472.Pages.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>小区信息查询</h2>
    <br>
    <div id="accordion">
        <div class="card">
            <div class="card-header ">
                过滤器
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-6">
                        <table>
                            <tr>
                                <td>编号 :</td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>小区名 :</td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-6">
                        省 ：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <br>
                        市 ：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <br>
                        区 ：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </div>
                </div>


                <asp:Button class="btn" ForeColor="SteelBlue" ID="Button1" runat="server" Text="过滤" OnClick="Button1_Click" />
                <asp:Button class="btn" ID="Button2" ForeColor="#FF5050" runat="server" Text="清空输入" OnClick="Button2_Click" OnClientClick="ButtonConf()" />


            </div>
            <div class="card-footer">
                <a class="card-link" data-toggle="collapse" href="#collapseOne">如何使用?
                </a>
            </div>
            <div id="collapseOne" class="collapse" data-parent="#accordion">
                <div class="card-footer">
                    <ul>
                        <li>如果输入所有的输入框都留空, 将会显示全部小区</li>
                        <li><b>编号</b> 可以精准找到小区</li>
                        <li><b>小区名</b> 可以模糊搜索小区</li>
                        <li><b>省/市/区</b> 来框选地区的范围</li>
                        <li>复制小区编号,使用<a target="_blank" href="https://cli.im/">二维码生成器</a>,生成小区二维码</li>

                    </ul>
                </div>
            </div>
        </div>
        <br>
        <asp:Panel ID="Panel1" runat="server">
            <div class="alert alert-success alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>查询成功!</strong> 找到了<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>个符合条件的小区
            </div>
        </asp:Panel>

        <div class="alert alert-info alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <b>如何生成小区二维码?</b> 复制小区编号,使用<a target="_blank" href="https://cli.im/">二维码生成器</a>生成小区二维码
        </div>
        <asp:Panel ID="Panel2" runat="server">
            <div class="alert alert-danger alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                没有查询到任何符合条件的小区
            </div>
        </asp:Panel>
        <table id="mothertable" class="table table-bordered table-hover " style="margin-bottom: 80px;">

            <thead class="thead-light">
                <tr>
                    <th>编号</th>
                    <th>小区名</th>
                    <th>所在地区</th>

                </tr>
            </thead>
            <tbody id="aa">
                <%= outputtable%>
            </tbody>
        </table>
    </div>
</asp:Content>
