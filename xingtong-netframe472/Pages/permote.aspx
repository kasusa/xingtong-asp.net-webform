<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="permote.aspx.cs" Inherits="xingtong_netframe472.Pages.permote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>提升人员权限</h2><br>
    <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-success alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>操作成功!</strong><asp:Label ID="Label_success" runat="server" Text="Label"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-danger alert-dismissible">
            <button type="button" class="close" data-dismiss="alert">&times;</button> 
                    <asp:Label ID="Label_error" runat="server" Text="Label"></asp:Label>
        </div>
    </asp:Panel>

        <div id="accordion">
            <div class="card">
                <div class="card-header ">
                    要操作的身份证号:&nbsp; <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
                    <div class="btn">

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="身份证不合法" ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>

                    <asp:Button  ID="Button1" runat="server" Text="查询" ForeColor="#0066CC" OnClick="Button1_Click"  /> 
                    </div>
                    <a href="personinfo_query.aspx" target="_blank">搜索人员身份证号</a>
                </div>
                <asp:Panel ID="Panel3" runat="server">
                    <div class="card-body">
                        姓名: <asp:Label ID="Label_name" runat="server" Text="Label"></asp:Label><br />
                        是否为管理员:<asp:Label ID="Label_isworker" runat="server" Text="Label"></asp:Label>
                      
                        <hr /> <asp:Button ID="Button2"  runat="server" Text="提升为管理" OnClick="Button2_Click"  /> 
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
                            <li>本功能用于提升/降低人员权限。</li>
                            <li>输入身份证号，查询人员当前的权限（如果你不确定需要人员的身份证号码，可以<a href="personinfo_query.aspx" target="_blank">搜索人员身份证号</a>）</kbd> </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
