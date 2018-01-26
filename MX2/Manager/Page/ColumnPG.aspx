<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="ColumnPG.aspx.cs" Inherits="MX2.Manager.Page.ColumnPG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span id="spbt" style="font-size: 24px;">栏目</span>
    <hr class="layui-bg-green">
    <div class="layui-form layui-form-pane">
        <div class="layui-form-item">
            <label class="layui-form-label">栏目标题</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="txtbt" CssClass="layui-input" placeholder="请输入标题" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">父级栏目</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="TextBox2" CssClass="layui-input" placeholder="请输入标题" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">栏目类型</label>
            <div class="layui-input-inline">
                 <asp:TextBox runat="server" ID="txtdz" CssClass="layui-input" placeholder="请输入地址" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">栏目顺序</label>
            <div class="layui-input-inline">
                 <asp:TextBox runat="server" ID="TextBox1" CssClass="layui-input" placeholder="请输入地址" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
                <asp:Button runat="server" ID="btnsave" Text="确认提交" CssClass="layui-btn"  />
                <a class="layui-btn layui-btn-primary" href="javascript:fanhui();" >返回</a>
            </div>
        </div>
    </div>
</asp:Content>
