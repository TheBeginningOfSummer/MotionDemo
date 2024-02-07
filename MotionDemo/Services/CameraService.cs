using OpenCvSharp.Extensions;
using Services;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace MotionDemo.Services
{
    public class CameraService
    {
        //记录相机
        readonly OpenCVTool recordCamera = new OpenCVTool();
        //扫码相机
        readonly OpenCVTool scanCamera = new OpenCVTool();
        //是否扫码
        public bool IsScan;
        //扫码图片
        public Action<Image> UpdateScanPic;
        //扫码值
        public Action<string> UpdateScanCode;

        /// <summary>
        /// 保存记录相机的视频
        /// </summary>
        /// <param name="fileName">文件名称.mp4</param>
        /// <param name="folderName">文件夹名称</param>
        /// <returns>路径信息（文件名;文件夹名称;时间）</returns>
        public string RecordVideo(string fileName, string folderName = "Video")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Video");
            string folderPath = Path.Combine(path, folderName);
            if (recordCamera.RecordCamera(folderPath, fileName, 30))
            {
                return $"{fileName};{folderPath};{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                //await _productDatabase.SQLConnection.InsertAsync(new ProductInfo(fileName, filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            return "NoData";
        }
        /// <summary>
        /// 保存记录相机的图片
        /// </summary>
        /// <param name="fileName">文件名称.png</param>
        /// <param name="folderName">文件夹名称</param>
        /// <returns>路径信息（文件名;文件夹名称;时间）</returns>
        public string SaveImage(string fileName, string folderName = "Image")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Image");
            string folderPath = Path.Combine(path, folderName);
            recordCamera.SaveCameraImage(folderPath, fileName);
            return $"{fileName};{folderPath};{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }
        /// <summary>
        /// 从本地文件加载码
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>码值</returns>
        public string LoadCode(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            return ZXingService.Read(bitmap);
        }
        /// <summary>
        /// 从相机加载码值
        /// </summary>
        /// <param name="cameraNumber">相机号</param>
        /// <returns>是否成功加载码值</returns>
        public bool ScanCode(int cameraNumber)
        {
            IsScan = true;
            scanCamera.OpenCamera(cameraNumber);
            while (IsScan)
            {
                Thread.Sleep(500);
                Bitmap bitmap = scanCamera.GetCameraImage().ToBitmap();
                string code = ZXingService.Read(bitmap);
                //PB_Test.Invoke(new Action(() => PB_Test.Image = (Image)bitmap.Clone()));
                UpdateScanPic?.Invoke((Image)bitmap.Clone());
                if (!string.IsNullOrEmpty(code))
                {
                    //LB_Code.Invoke(new Action(() => LB_Code.Text = code));
                    UpdateScanCode?.Invoke(code);
                    scanCamera.CloseCamera();
                    return true;
                }
            }
            scanCamera.CloseCamera();
            return false;
        }

    }
}
