<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="LinksPG.aspx.cs" Inherits="MX2.Manager.Page.LinksPG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="layui-table">
        <thead>
            <tr>
                <th>标题</th>
                <th>链接地址</th>
                <th style="width: 138px; text-align: center;">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptlist">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("LinkStr") %></td>
                        <td>
                            <button class="layui-btn layui-btn-sm layui-btn-normal"><i class="layui-icon">&#xe642;</i>编辑</button>
                            <button class="layui-btn layui-btn-sm layui-btn-danger"><i class="layui-icon">&#xe640;</i>删除</button>
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
            , limit:10 //每页数量
            , limits: [10, 20, 30, 40, 55]
            , curr: location.hash.replace('?page=', '') //获取起始页
            , hash: 'page'
            , layout: ['count', 'prev', 'page', 'next', 'limit','skip']
            , jump: function (obj, first) {
                //obj包含了当前分页的所有参数，比如：
                console.log(obj.curr); //得到当前页，以便向服务端请求对应页的数据。
                console.log(obj.limit); //得到每页显示的条数
                
                //首次不执行
                if (!first) {
                    //do something
                    location.href = "/Manager/Page/LinksPG.aspx?page=" + obj.curr + "&pagesize=" + obj.limit;
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
