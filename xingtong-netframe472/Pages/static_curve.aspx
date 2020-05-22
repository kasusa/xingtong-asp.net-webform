<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="static_curve.aspx.cs" Inherits="xingtong_netframe472.Pages.static_curve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js@2.9.3/dist/Chart.min.js"></script>
    <style>
        .none-style td {
            padding-top: 0 !important;
            padding-bottom: 0 !important;
        }
    </style>
    <h2>出入情况统计(按照时间)</h2>
    <br>
    <div id="accordion">
        <div class="card">
            <div class="card-header ">
                过滤器<a class="card-link" data-toggle="collapse" href="#filter"> 展开过滤器</a>
            </div>
                            <div id="filter" class="collapse" data-parent="#accordion">
            <div class="card-body">
                <table class="table table-borderless">
                    <tr>
                        <td>小区编号:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>

                            <a target="_blank" href="xiaoqu_query.aspx">查询小区编号</a>
                        </td>
                    </tr>
                    <tr>
                        <td>时间:</td>
                        <td>
                            <div class="none-style">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="10">最近10天</asp:ListItem>
                                    <asp:ListItem Value="30">最近30天</asp:ListItem>
                                    <asp:ListItem Value="100">最近100个天</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>显示方式:</td>
                        <td>
                            <div class="none-style">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="bar">柱状图</asp:ListItem>
                                    <asp:ListItem Value="line">曲线图</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </td>

                    </tr>
                </table>

                <asp:Button class="btn" ForeColor="SteelBlue" ID="Button_filter" runat="server" Text="查询" OnClick="Button_filter_Click" />

            </div>
                </div>

            <div class="card-footer">
                <a class="card-link" data-toggle="collapse" href="#collapseOne">如何使用过滤功能?
                </a>
            </div>
            <div id="collapseOne" class="collapse" data-parent="#accordion">
                <div class="card-footer">
                    <ul>
                        <li>默认显示最近10天的全部出入统计数据</li>
                        <li>可以使用部分输入框以达到最佳过滤效果</li>
                        <ul>
                            <li>仅仅输入小区名字来看某个指定小区的统计数据</li>

                            <li><del>仅仅输入省份来查看某个省的统计数据</del></li>
                        </ul>
                        <li>选择合适的显示方式<b>曲线/柱状图</b> </li>
                        <li>选择合适的时间范围</li>
                    </ul>
                </div>
            </div>
        </div>

        <br>
        <asp:Panel ID="Panel1" runat="server">
            <div class="alert alert-success alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>查询成功!</strong>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <div class="alert alert-danger alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>错误!</strong>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
        </asp:Panel>

        <div class="container">
            <canvas id="myChart"></canvas>
        </div>
        <script>
            let myChart = document.getElementById('myChart').getContext('2d');

            // Global Options
            Chart.defaults.global.defaultFontFamily = 'Lato';
            Chart.defaults.global.defaultFontSize = 18;
            Chart.defaults.global.defaultFontColor = '#777';

            let massPopChart = new Chart(myChart, {
                type: '<%= chartstyle%>', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
                data: {
                    labels: [<%= ListToString(bottomTextlist) %>],
                    datasets: [{
                        label: '总出入次数',
                        data: [<%= ListToString(datalist)%>                            ],
                        //backgroundColor:'green',
                        backgroundColor:
                            ' rgba(0, 185, 255, 0.27)'
                        ,
                        borderWidth: 1,
                        borderColor: '#777',
                        hoverBorderWidth: 3,
                        hoverBorderColor: '#000',
                        hoverBackgroundColor: ' rgba(0, 185, 255, 0.5)'
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: '<%= charttitle%>',
                        fontSize: 25
                    },
                    legend: { //是否显示侧边图例
                        display: false,
                        position: 'right',
                        labels: {
                            fontColor: '#000'
                        }
                    },
                    layout: {
                        padding: {
                            left: 50,
                            right: 0,
                            bottom: 0,
                            top: 0
                        }
                    },
                    tooltips: {
                        enabled: true
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        </script>
</asp:Content>
