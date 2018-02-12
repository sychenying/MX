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
               <asp:DropDownList runat="server" ID="ddlflm">
               </asp:DropDownList>
            </div>
        </div>
        
        <div class="layui-form-item">
            <label class="layui-form-label">栏目类型</label>
            <div class="layui-input-inline">
                 <asp:DropDownList runat="server" ID="ddltype">                  
                   <asp:ListItem Value="新闻" Selected="True">新闻</asp:ListItem>
                   <asp:ListItem Value="产品">产品</asp:ListItem>
               </asp:DropDownList>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">栏目顺序</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="txtorders" CssClass="layui-input" placeholder="请输入地址" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
                 <asp:Button runat="server" ID="btnsave" Text="确认提交" CssClass="layui-btn" OnClick="btnsave_Click" />
                <a class="layui-btn layui-btn-primary" href="javascript:fanhui();">返回</a>
            </div>
        </div>
    </div>
   
    <script type="text/javascript">
        layui.use('form', function () {
            var form = layui.form; //只有执行了这一步，部分表单元素才会自动修饰成功
            //但是，如果你的HTML是动态生成的，自动渲染就会失效
            //因此你需要在相应的地方，执行下述方法来手动渲染，跟这类似的还有 element.init();
            form.render();
        });
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        load();
        $(document).ready(function () {

        });
        function fanhui() {
            location.href = "ColumnListPG.aspx";
        }
        function load() {
            if (GetQueryString("type") == "Edit") {
                $("#spbt").html("编辑栏目");
            } else {
                $("#spbt").html("新增栏目");
            }
        }
        function edOK() {
            layer.open({
                content: '修改成功',
                time: 2000,
                end: function () {
                    location.href = "ColumnListPG.aspx";
                }
            });
            
        }
        function adOK() {
            layer.open({
                content: '添加成功',
                time: 2000,
                end: function () {
                    location.href = "ColumnListPG.aspx";
                }
            });
        }
    </script>
</asp:Content>
