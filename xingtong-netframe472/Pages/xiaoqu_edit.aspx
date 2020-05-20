<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="xiaoqu_edit.aspx.cs" Inherits="xingtong_netframe472.Pages.xiaoqu_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>小区信息修改</h2><br>
    <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-success alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>修改成功!</strong>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-danger alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button> <asp:Label ID="Label_error" runat="server" Text="Label"></asp:Label>
        </div>
    </asp:Panel>



        <div id="accordion">
            <div class="card">
                <div class="card-header ">
                    输入要修改的小区编号: <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
                    <div class="btn">

                    <asp:Button  ID="Button1" runat="server" Text="查询" ForeColor="#0066CC" OnClick="Button1_Click" /> 
                    </div>
                    <a href="xiaoqu_query.aspx" target="_blank">查询小区编号</a>
                </div>
                <asp:Panel ID="Panel3" runat="server">
                    <div class="card-body">
                        小区名称: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <hr /> 所在地区: 
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> 省 
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> 市
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> 区
                        <hr /> <asp:Button ID="Button2" class="btn" runat="server" Text="保存" ForeColor="#009933" OnClick="Button2_Click" /> 
                                <asp:Button ID="Button3" class="btn" runat="server" Text="取消" ForeColor="Gray" />
                        </table>
                    </div>
                </asp:Panel>


                <div class="card-footer">
                    <a class="card-link" data-toggle="collapse" href="#collapseOne">
                        如何使用?
                    </a>
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-footer">
                        <ul>
                            <li>本功能用于修改录入错误的小区/更名小区的信息</li>
                            <li>首先输入小区编号,点击<kbd>查询</kbd> </li>
                            <li>如果查询成功,会跳出小区的信息,请按照需要修改</li>
                            <li>修改之后,点击保存以存储信息。点击取消以取消修改</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
