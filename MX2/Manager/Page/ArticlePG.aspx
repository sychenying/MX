<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Page/Site1.Master" AutoEventWireup="true" CodeBehind="ArticlePG.aspx.cs" Inherits="MX2.Manager.Page.ArticlePG"  ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <span id="spbt" style="font-size: 24px;">文章管理</span>
    <hr class="layui-bg-green">
    <div class="layui-form">
        <div class="layui-form-item">
            <label class="layui-form-label">文章标题</label>
            <div class="layui-input-block">
                <asp:TextBox runat="server" ID="txtbt" CssClass="layui-input" placeholder="请输入标题" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">栏目</label>
            <div class="layui-input-inline">
                <asp:DropDownList runat="server" ID="ddllm">
                </asp:DropDownList>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">备注</label>
            <div class="layui-input-block">
                <asp:TextBox runat="server" ID="txtbz" CssClass="layui-input" placeholder="请输入地址" autocomplete="off" lay-verify="title"></asp:TextBox>
            </div>
        </div>


        <div class="layui-form-item">
            <label class="layui-form-label">内容</label>
            <div class="layui-input-block">             
                <asp:TextBox runat="server" ID="txtnr" TextMode="MultiLine" ></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">图片</label>
            <div class="layui-input-inline">               

                <div class="layui-upload">
                    <button type="button" class="layui-btn" id="test1"><i class="layui-icon">&#xe67c;</i>上传图片</button>
                    <div class="layui-upload-list">                        
                        <asp:Image runat="server" ID="img1" CssClass="layui-upload-img" />
                        <asp:HiddenField runat="server" ID="hfimg" />
                        <p id="demoText"></p>
                    </div>
                </div>

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
        layui.use('upload', function () {
            var upload = layui.upload;
            var layedit = layui.layedit;

            layedit.set({
                uploadImage: {//编辑器上传图片
                    url: '../Ajax/UploadTool.ashx' //接口url
                  , type: 'post' //默认post
                }
            });
            layedit.build('Content_txtnr'); //建立编辑器

            //普通图片上传
            var uploadInst = upload.render({
                elem: '#test1'
              , url: '../Ajax/UploadTool.ashx?IsThumbnail=1'
              //, before: function (obj) {
              //    //预读本地文件示例，不支持ie8
              //    obj.preview(function (index, file, result) {
              //        $('#demo1').attr('src', result); //图片链接（base64）
              //    });
              //}
              , done: function (res) {
                  //如果上传成功
                  if (res.code == 0) {                      
                      <%--$('#<%=img1.ClientID%>').attr('src', res.data.src);
                      $('#<%=hfimg.ClientID%>').attr('src', res.data.src);--%>
                      document.getElementById('<%=img1.ClientID%>').src = res.data.src;
                      document.getElementById('<%=hfimg.ClientID%>').value = res.data.src;
                  } else {
                      //上传失败
                      return layer.msg('上传失败');
                  }
                  
              }
              , error: function () {
                  //失败状态，并实现重传
                  var demoText = $('#demoText');
                  demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-mini demo-reload">重试</a>');
                  demoText.find('.demo-reload').on('click', function () {
                      uploadInst.upload();
                  });
              }
            });
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
            location.href = "ArticleListPG.aspx";
        }
        function load() {
            if (GetQueryString("type") == "Edit") {
                $("#spbt").html("编辑文章");
            } else {
                $("#spbt").html("新增文章");
            }
        }
        function edOK() {
            layer.open({
                content: '修改成功',
                time: 2000,
                end: function () {
                    location.href = "ArticleListPG.aspx";
                }
            });

        }
        function adOK() {
            layer.open({
                content: '添加成功',
                time: 2000,
                end: function () {
                    location.href = "ArticleListPG.aspx";
                }
            });
        }
    </script>
</asp:Content>
