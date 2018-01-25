<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="LinksListPG.aspx.cs" Inherits="MX2.Manager.Page.LinksListPG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span style="font-size: 24px;">友情链接</span>
    <div style="float: right;">
        <a href="javascript:Add();" class="layui-btn"><i class="layui-icon">&#xe608;</i>新增</a>
    </div>
    <hr class="layui-bg-green">

    <table class="layui-table">
        <thead>
            <tr>
                <th>ID</th>
                <th>标题</th>
                <th>链接地址</th>
                <th style="width: 150px; text-align: center;">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptlist">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("LinkStr") %></td>
                        <td>
                            <a href="javascript:Edit(<%# Eval("Id") %>);" class="layui-btn layui-btn-sm "><i class="layui-icon">&#xe642;</i>编辑</a>
                            <a href="javascript:Delete(<%# Eval("Id") %>);" class="layui-btn layui-btn-sm layui-btn-primary"><i class="layui-icon">&#xe640;</i>删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:HiddenField runat="server" ID="hfcount" />
    <div id="page"></div>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
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

        function Add() {
            location.href = "LinksPG.aspx?type=Add";
        }
        function Edit(ID) {
            location.href = "LinksPG.aspx?type=Edit&ID=" + ID;
        }
        function Delete(ID) {
            layer.confirm('是否删除？', {
                btn: ['确定', '取消'] //按钮
            }, function () {
                $.ajax({
                    type: 'post',
                    url: '../Ajax/AjaxTool.ashx',
                    dataType: "text",
                    data: {
                        action: "DeleteLinksById",
                        LinksId: ID
                    },
                    success: function (data) {
                        if (data == "OK") {
                            //layer.msg("删除成功");
                            location.href = location.href;
                        } else {
                            layer.alert("删除失败");
                        }
                    },
                    error: function () {
                        layer.alert("出错了！请稍候再试！");
                    }
                });
            }, function () {
                
            });
        }
    </script>
</asp:Content>

