<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="LinksListPG.aspx.cs" Inherits="MX2.Manager.Page.LinksListPG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span style="font-size: 24px;">友情链接</span>
    <div style="float: right;">
        <a href="javascript:abc();" class="layui-btn"><i class="layui-icon">&#xe608;</i>添加</a>
    </div>
    <hr class="layui-bg-green">

    <table class="layui-table">
        <thead>
            <tr>
                <th>标题</th>
                <th>链接地址</th>
                <th style="width: 150px; text-align: center;">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptlist">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("LinkStr") %></td>
                        <td>
                            <a href="javascript:" class="layui-btn layui-btn-sm "><i class="layui-icon">&#xe642;</i>编辑</a>
                            <a href="javascript:"  class="layui-btn layui-btn-sm layui-btn-primary"><i class="layui-icon">&#xe640;</i>删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:HiddenField runat="server" ID="hfcount" />
    <div id="page"></div>
    <script type="text/javascript">
        var laypage = layui.laypage;
        laypage.render({
            elem: 'page'
            , count: $("#<%=hfcount.ClientID%>").val() //数据总数，从服务端得到
            , limit: GetQueryString("pagesize") == null ? '10' : GetQueryString("pagesize") //每页数量
            , limits: [10, 15, 20, 30, 50]
            , curr: GetQueryString("page") //获取起始页
            , layout: ['prev', 'page', 'next', 'limit', 'count', 'skip']
            , jump: function (obj, first) {
                //obj包含了当前分页的所有参数，比如：
                console.log(obj.curr); //得到当前页，以便向服务端请求对应页的数据。
                console.log(obj.limit); //得到每页显示的条数

                //首次不执行
                if (!first) {
                    //do something
                    location.href = "/Manager/Page/LinksListPG.aspx?page=" + obj.curr + "&pagesize=" + obj.limit;
                }
            }
        });
        $(document).ready(function () {

        });
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        function abc() {
            layer.open({
                title: '在线调试'
                , content: '可以填写任意的layer代码'
            }); 
        }
    </script>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>--%>
