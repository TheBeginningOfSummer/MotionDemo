using MotionDemo.Forms;
using Services;

namespace MotionDemo.Services
{
    public class SettingManager
    {
        #region 单例模式
        private static SettingManager _instance;
        private static readonly object _instanceLock = new object();
        public static SettingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                        _instance = new SettingManager();
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 打开控制器信息编辑窗口
        /// </summary>
        public void ControllerSet(MotionManager motionManager)
        {
            ControllerSet axisAdd = new ControllerSet(motionManager);
            axisAdd.Show();
        }
        /// <summary>
        /// 打开一个窗口进行轴参数设置
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="controllerName">控制器名</param>
        public void AxisSet(MotionManager motionManager, string controllerName, string axisName)
        {
            if (string.IsNullOrEmpty(controllerName)) return;
            if (!motionManager.Controllers.ContainsKey(controllerName)) return;
            if (motionManager.Controllers[controllerName].Axes.ContainsKey(axisName))
            {
                AxisSet axisSet = new AxisSet(motionManager.Controllers[controllerName].Axes[axisName]);
                axisSet.Show();
            }
        }
        /// <summary>
        /// 相机参数设置
        /// </summary>
        public void CameraSet()
        {
            CameraSet cameraSet = new CameraSet();
            cameraSet.ShowDialog();
        }

    }
}
