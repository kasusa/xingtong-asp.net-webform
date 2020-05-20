<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="xiaoqu_make.aspx.cs" Inherits="xingtong_netframe472.Pages.xiaoqu_make" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>录入小区信息</h2><br>
    <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-success alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>信息录入成功!</strong>应该可以在 <a href="xiaoqu_query.aspx">这里</a>查询到了。
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
                    信息录入面板
                </div>
                    <div class="card-body">
                        小区名称: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <hr /> 所在地区: 
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        省 
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        市
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        区
                        <hr /> <asp:Button ID="Button2" class="btn" runat="server" Text="保存" ForeColor="#009933" OnClick="Button2_Click"  /> 
                                <asp:Button ID="Button3" class="btn" runat="server" Text="清空输入" ForeColor="Red" />
                        </table>
                    </div>


                <div class="card-footer">
                    <a class="card-link" data-toggle="collapse" href="#collapseOne">
                        如何使用?
                    </a>
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-footer">
                        <ul>
                            <li>输入小区信息<br>点击保存就可以成功创建小区了</li>
                            <li>如果是直辖市/特别行政区,省和市都填写市的名字</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
