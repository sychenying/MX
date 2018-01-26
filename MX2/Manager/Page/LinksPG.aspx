<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="LinksPG.aspx.cs" Inherits="MX2.Manager.Page.LinksPG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span id="spbt" style="font-size: 24px;">友情链接</span>
    <hr class="layui-bg-green">
    <div class="layui-form layui-form-pane">
        <div class="layui-form-item">
            <label class="layui-form-label">链接标题</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="txtbt" CssClass="layui-input" placeholder="请输入标题" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">链接地址</label>
            <div class="layui-input-block">
                 <asp:TextBox runat="server" ID="txtdz" CssClass="layui-input" placeholder="请输入地址" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
                <asp:Button runat="server" ID="btnsave" Text="确认提交" CssClass="layui-btn" OnClick="btnsave_Click" />
                <a class="layui-btn layui-btn-primary" href="javascript:fanhui();" >返回</a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        load(); 
        $(document).ready(function () {
            
        });
        function fanhui() {
            location.href = "LinksListPG.aspx";
        }
        function load() {
            if (GetQueryString("type") == "Add") {
                $("#spbt").html("新增链接");
            } else {
                $("#spbt").html("编辑链接");
            }
        }
        function edOK() {
            layer.open({
                content: '修改成功',
                time: 2000,                
                end: function () {
                    location.href = "LinksListPG.aspx";
                }
            }); 
            //layer.msg('修改成功', {
            //    time: 1000,
            //    end: function () {
            //        location.href = "LinksListPG.aspx";
            //    }
            //})
        }
        function adOK() {
            layer.open({
                content: '添加成功',
                time: 2000,
                end: function () {
                    location.href = "LinksListPG.aspx";
                }
            }); 
        }
    </script>
</asp:Content>
