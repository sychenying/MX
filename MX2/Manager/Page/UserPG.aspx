<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="UserPG.aspx.cs" Inherits="MX2.Manager.Page.UserPG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span id="spbt" style="font-size: 24px;">用户管理</span>
    <hr class="layui-bg-green">
    <div class="layui-form layui-form-pane">
        <div class="layui-form-item">
            <label class="layui-form-label">用户名称</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="txtname" CssClass="layui-input" placeholder="请输入用户名" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">用户密码</label>
            <div class="layui-input-block">
                 <asp:TextBox runat="server" ID="txtpwd" CssClass="layui-input" placeholder="请输入用户密码" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">确认密码</label>
            <div class="layui-input-block">
                 <asp:TextBox runat="server" ID="txtpwd2" CssClass="layui-input" placeholder="请输入确认密码" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">用户状态</label>
            <div class="layui-input-block">
                 <asp:TextBox runat="server" ID="txtzt" CssClass="layui-input" placeholder="状态默认1" autocomplete="off" lay-verify="title"></asp:TextBox>
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
            location.href = "UserListPG.aspx";
        }
        function load() {
            if (GetQueryString("type") == "Edit") {
                $("#spbt").html("编辑用户");
            } else {
                $("#spbt").html("新增用户");
            }
        }
        function edOK() {
            layer.open({
                content: '修改成功',
                time: 2000,                
                end: function () {
                    location.href = "UserListPG.aspx";
                }
            }); 
            //layer.msg('修改成功', {
            //    time: 1000,
            //    end: function () {
            //        location.href = "UserListPG.aspx";
            //    }
            //})
        }
        function adOK() {
            layer.open({
                content: '添加成功',
                time: 2000,
                end: function () {
                    location.href = "UserListPG.aspx";
                }
            }); 
        }
    </script>
</asp:Content>