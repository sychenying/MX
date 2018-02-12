using MX2.Manager.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MX2.Manager.Ajax
{
    /// <summary>
    /// UploadTool 的摘要说明
    /// </summary>
    public class UploadTool : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UpLoadFile(context);
        }
        #region 上传文件处理===================================
        private void UpLoadFile(HttpContext context)
        {
            string _delfile = FTRequest.GetString("DelFilePath");
            HttpPostedFile _upfile = context.Request.Files["file"];
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (FTRequest.GetQueryString("IsWater") == "1")
                _iswater = true;
            if (FTRequest.GetQueryString("IsThumbnail") == "1")
                _isthumbnail = true;
            if (_upfile == null)
            {
                context.Response.Write("{\"code\": -1, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            
            string msg = fileSaveAs(_upfile, _isthumbnail, _iswater);
            //删除已存在的旧文件
            if (!string.IsNullOrEmpty(_delfile))
            {
                SysConstant.DeleteUpFile(_delfile);
            }
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }
        #endregion
        /// <summary>
        /// 裁剪图片并保存
        /// </summary>
        public bool cropSaveAs(string fileName, string newFileName, int maxWidth, int maxHeight, int cropWidth, int cropHeight, int X, int Y)
        {
            string fileExt = SysConstant.GetFileExt(fileName); //文件扩展名，不含“.”
            if (!IsImage(fileExt))
            {
                return false;
            }
            string newFileDir = SysConstant.GetMapPath(newFileName.Substring(0, newFileName.LastIndexOf(@"/") + 1));
            //检查是否有该路径，没有则创建
            if (!Directory.Exists(newFileDir))
            {
                Directory.CreateDirectory(newFileDir);
            }
            try
            {
                string fileFullPath = SysConstant.GetMapPath(fileName);
                string toFileFullPath = SysConstant.GetMapPath(newFileName);
                return Thumbnail.MakeThumbnailImage(fileFullPath, toFileFullPath, 180, 180, cropWidth, cropHeight, X, Y);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="isThumbnail">是否生成缩略图</param>
        /// <param name="isWater">是否打水印</param>
        /// <returns>上传后文件信息</returns>
        public string fileSaveAs(HttpPostedFile postedFile, bool isThumbnail, bool isWater)
        {
            try
            {
                string fileExt = SysConstant.GetFileExt(postedFile.FileName); //文件扩展名，不含“.”
                int fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
                string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原文件名
                string newFileName = SysConstant.GetRamCode() + "." + fileExt; //随机生成新的文件名
                string newThumbnailFileName = "thumb_" + newFileName; //随机生成缩略图文件名
                string upLoadPath = GetUpLoadPath(); //上传目录相对路径
                string fullUpLoadPath = SysConstant.GetMapPath(upLoadPath); //上传目录的物理路径
                string newFilePath = upLoadPath + newFileName; //上传后的路径
                string newThumbnailPath = upLoadPath + newThumbnailFileName; //上传后的缩略图路径

                //检查文件扩展名是否合法
                if (!CheckFileExt(fileExt))
                {
                    return "{\"code\": -1, \"msg\": \"不允许上传" + fileExt + "类型的文件！\"}";
                }
                //检查文件大小是否合法
                if (!CheckFileSize(fileExt, fileSize))
                {
                    return "{\"code\": -1, \"msg\": \"文件超过限制的大小啦！\"}";
                }
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }

                //保存文件
                postedFile.SaveAs(fullUpLoadPath + newFileName);
                //如果是图片，检查图片是否超出最大尺寸，是则裁剪
                if (IsImage(fileExt))
                {
                    Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newFileName,
                        800, 800);
                }
                //如果是图片，检查是否需要生成缩略图，是则生成
                if (IsImage(fileExt) && isThumbnail)
                {
                    Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newThumbnailFileName,
                        800, 800, "Cut");
                }
                int watermarktype = 1;
                ////如果是图片，检查是否需要打水印
                //if (IsWaterMark(fileExt) && isWater)
                //{
                //    switch (watermarktype)
                //    {
                //        case 1:
                //            SysConstant.AddImageSignText(newFilePath, newFilePath, "水印文字", 9, 80, "Tahoma", 12);
                //            break;
                //        case 2:
                //            SysConstant.AddImageSignPic(newFilePath, newFilePath, "watermark.png", 9, 80, 5);
                //            break;
                //    }
                //}
                //处理完毕，返回JOSN格式的文件信息
                //return "{\"status\": 1, \"msg\": \"上传文件成功！\", \"name\": \""
                //    + fileName + "\", \"path\": \"" + newFilePath + "\", \"thumb\": \""
                //    + newThumbnailPath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}";
                return "{\"code\": 0, \"msg\": \"上传文件成功！\", \"data\": {\"src\":\""+ newFilePath + "\",\"title\":\""+ fileName + "\",\"thumb\":\""+ newThumbnailPath + "\",\"size\":\"" + fileSize + "\",\"thumb\":\"" + newThumbnailPath + "\",\"ext\":\"" + fileExt + "\"}}";
                
            }
            catch
            {
                return "{\"code\": -1, \"msg\": \"上传过程中发生意外错误！\"}";
            }
        }
        #region 私有方法

        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath()
        {
            string path = "/upload/"; //站点目录+上传目录
            path += DateTime.Now.ToString("yyyyMMdd");
            return path + "/";
        }

        /// <summary>
        /// 是否需要打水印
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        private bool IsWaterMark(string _fileExt)
        {
            //判断是否开启水印

            //判断是否可以打水印的图片类型
            ArrayList al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        private bool IsImage(string _fileExt)
        {
            ArrayList al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            //检查危险文件
            string[] excExt = { "asp", "aspx", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = "gif,jpg,png,bmp,rar,zip,doc,xls,txt".Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <param name="_fileSize">文件大小(B)</param>
        private bool CheckFileSize(string _fileExt, int _fileSize)
        {
            //判断是否为图片文件
            if (IsImage(_fileExt))
            {
                if (_fileSize > 10240 * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (_fileSize > 51200 * 1024)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}