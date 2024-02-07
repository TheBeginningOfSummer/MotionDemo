using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotionDemo.Forms;

namespace Services
{
    public class MotionManager
    {
        #region 单例模式
        private static MotionManager _instance;
        private static readonly object _instanceLock = new object();
        public static MotionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                        _instance = new MotionManager();
                }
                return _instance;
            }
        }
        #endregion

        #region 数据管理
        public Dictionary<string, MotionControl> Controllers = new Dictionary<string, MotionControl>();
        public SQLiteService Sqlite = new SQLiteService("Data.db", "Data");
        #endregion

        #region 信息更新
        public Action<MotionManager> UpdateData;//Controllers更改时调用
        public Action<string[]> UpdateState;
        public bool IsUpdate = false;
        #endregion

        #region 信号
        public AutoResetEvent Input1 = new AutoResetEvent(false);
        #endregion

        #region 默认组件
        public Test TestForm = new Test();
        public BackgroundWorker BGW_Auto = new BackgroundWorker();
        #endregion

        public MotionManager(params MotionControl[] motionControls)
        {
            foreach (MotionControl control in motionControls)
                Controllers.Add(control.Name, control);
            BGW_Auto.DoWork += BGW_Auto_DoWork;
            BGW_Auto.RunWorkerCompleted += BGW_Auto_RunWorkerCompleted;
        }

        public MotionManager()
        {
            LoadConfig();
            BGW_Auto.DoWork += BGW_Auto_DoWork;
            BGW_Auto.RunWorkerCompleted += BGW_Auto_RunWorkerCompleted;
        }

        public void Initialize()
        {

        }

        public void LoadConfig()
        {
            Controllers = JsonManager.ReadJson<Dictionary<string, MotionControl>>("Config", "Motion.json");
            if (Controllers == null)
                Controllers = new Dictionary<string, MotionControl>();
            else
                foreach (var controller in Controllers.Values)
                    controller.ReinitializeAxes();
            UpdateData?.Invoke(this);
        }

        public void SaveConfig()
        {
            JsonManager.SaveJson("Config", "Motion.json", Controllers);
        }

        public bool ModifyInfo(string controllerName, string ip, List<string> axesName, string type)
        {
            if (string.IsNullOrEmpty(controllerName)) return false;
            if (Controllers.ContainsKey(controllerName))
            {
                //如果控制器已经存在，则添加轴
                if (axesName == null) return false;
                Controllers[controllerName].IP = ip;
                foreach (string axisName in axesName)
                    //添加轴
                    Controllers[controllerName].AddAxis(axisName);
                Controllers[controllerName].ReinitializeAxes();
            }
            else
            {
                //如果不存在，则添加轴卡
                if (string.IsNullOrEmpty(ip)) return false;
                if (axesName == null) return false;
                if (string.IsNullOrEmpty(type)) return false;
                
                switch (type)
                {
                    case "Zmotion":
                        Controllers.Add(controllerName, new ZmotionMotionControl(controllerName, ip, axesName.ToArray()));
                        break;
                    case "Trio":
                        Controllers.Add(controllerName, new TrioMotionControl(controllerName, ip, axesName.ToArray()));
                        break;
                    default:
                        break;
                }
            }
            SaveConfig();
            UpdateData?.Invoke(this);
            return true;
        }

        public bool RemoveInfo(string controllerName, string axisName = null)
        {
            if (string.IsNullOrEmpty(controllerName)) return false;
            if (!Controllers.ContainsKey(controllerName)) return false;
            if (string.IsNullOrEmpty(axisName))
            {
                Controllers.Remove(controllerName);
                SaveConfig();
                UpdateData?.Invoke(this);
                return true;
            }
            else
            {
                if (Controllers[controllerName].AxesName.Contains(axisName))
                {
                    Controllers[controllerName].AxesName.Remove(axisName);
                    SaveConfig();
                    UpdateData?.Invoke(this);
                    return true;
                }
                return false;
            }
        }

        #region 连接和更新
        public void UpdateAxesState(string controllerName, int inputCount)
        {
            string[] stateInfo = new string[4];
            while (IsUpdate)
            {
                stateInfo[0] = ""; stateInfo[1] = ""; stateInfo[2] = ""; stateInfo[3] = "";
                Thread.Sleep(100);
                foreach (var axis in GetAxes(controllerName)?.Values)
                {
                    axis.UpdateState();
                    stateInfo[0] += $"轴{axis.Number}{axis.State}{Environment.NewLine}";
                    stateInfo[1] += $"轴{axis.Number}当前位置：{axis.CurrentPosition}{Environment.NewLine}";
                    stateInfo[2] += $"轴{axis.Number}当前速度：{axis.CurrentSpeed}{Environment.NewLine}";
                }
                double[] @in = Controllers[controllerName]?.GetInputs(inputCount);
                for (int i = 0; i < @in.Length; i++)
                {
                    if (i % 3 == 0) stateInfo[3] += Environment.NewLine;
                    stateInfo[3] += $"信号{i}：{@in[i]} ";
                }
                UpdateState?.Invoke(stateInfo);
            }
        }

        public void StartUpdate(string controllerName, int inputCount)
        {
            IsUpdate = false;
            Thread.Sleep(100);
            IsUpdate = true;
            Task.Run(() => UpdateAxesState(controllerName, inputCount));
        }

        public void StopUpdate()
        {
            IsUpdate = false;
        }

        public bool Connect(string controllerName)
        {
            if (Controllers.ContainsKey(controllerName))
            {
                if (Controllers[controllerName].Connect())
                {
                    //轴卡重新初始化
                    Controllers[controllerName].Initialize();
                    //轴重新初始化
                    Controllers[controllerName].ReinitializeAxes();
                    //轴参数重新初始化
                    foreach (var item in Controllers[controllerName].Axes.Values)
                        item.Initialize();
                    MessageBox.Show("连接成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("连接失败");
                }
            }
            return false;
        }

        public void Disconnect(string controllerName)
        {
            if (Controllers.ContainsKey(controllerName))
            {
                Controllers[controllerName].Disconnect();
                IsUpdate = false;
                MessageBox.Show("断开连接");
            }  
        }
        #endregion

        #region 轴操作
        public MotionControl GetController(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return null;
            if (!Controllers.ContainsKey(controllerName)) return null;
            return Controllers[controllerName];
        }
        /// <summary>
        /// 得到指定控制器的所有轴
        /// </summary>
        /// <param name="controllerName">控制器名</param>
        /// <returns>所有轴</returns>
        public Dictionary<string, BaseAxis> GetAxes(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return null;
            if (!Controllers.ContainsKey(controllerName)) return null;
            return Controllers[controllerName].Axes;
        }
        /// <summary>
        /// 得到指定控制器的一个轴
        /// </summary>
        /// <param name="controllerName">控制器名</param>
        /// <param name="axisName">轴名称</param>
        /// <returns>指定轴</returns>
        public BaseAxis GetAxis(string controllerName, string axisName)
        {
            if (string.IsNullOrEmpty(controllerName)) return null;
            if (!Controllers.ContainsKey(controllerName)) return null;
            if (Controllers[controllerName].Axes.ContainsKey(axisName))
                return Controllers[controllerName].Axes[axisName];
            else
                return null;
        }
        /// <summary>
        /// 添加轴
        /// </summary>
        /// <param name="controllerName">控制器名</param>
        /// <param name="axisName">要添加的轴名称</param>
        public void AddAxis(string controllerName, string axisName)
        {
            if (string.IsNullOrEmpty(controllerName)) return;
            if (!Controllers.ContainsKey(controllerName)) return;
            Controllers[controllerName].AddAxis(axisName);
        }
        /// <summary>
        /// 清除所有轴的位置
        /// </summary>
        /// <param name="controllerName">控制器名称</param>
        public void ClearPosition(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return;
            if (!Controllers.ContainsKey(controllerName)) return;
            foreach (var item in GetAxes(controllerName).Values)
                item.DefPos();
        }
        #endregion

        #region 自动轨迹
        public void StartTrack(string controllerName, bool isShowTrack = false)
        {
            if (string.IsNullOrEmpty(controllerName)) return;
            if (!Controllers.ContainsKey(controllerName)) return;
            if (BGW_Auto.IsBusy)
            {
                MessageBox.Show("运行中");
                return;
            }
            else
            {
                if (isShowTrack)
                    TestForm.StartDrawTrackXY(100,
                    GetAxis(controllerName, "Axis1"),
                    GetAxis(controllerName, "Axis2"));
                BGW_Auto.RunWorkerAsync(controllerName);
            }
        }

        private void BGW_Auto_DoWork(object sender, DoWorkEventArgs e)
        {
            Track1(e.Argument.ToString(), 0, 7, 400, 50);
            //Track2(e.Argument.ToString(), 300, 5, 300, 50);
        }

        private void BGW_Auto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TestForm.Stop();
        }

        public void Track1(string name, double startX, int times, double targetPosY1, double intervalX1)
        {
            BaseAxis axis1 = GetAxis(name, "Axis1");
            BaseAxis axis2 = GetAxis(name, "Axis2");
            if (axis1 == null || axis2 == null) return;
            axis1.SingleAbsoluteMove(startX); axis1.Wait();
            if (BGW_Auto.CancellationPending) return;
            //suspend.WaitOne();
            if (times % 2 != 0)
            {
                //int remainder = cutTimes % 2;
                for (int i = 0; i < times / 2; i++)
                {
                    axis2.SingleAbsoluteMove(targetPosY1);
                    axis2.Wait();
                    axis1.SingleRelativeMove(intervalX1);
                    axis1.Wait();
                    if (BGW_Auto.CancellationPending) return;
                    axis2.SingleAbsoluteMove(0);
                    axis2.Wait();
                    axis1.SingleRelativeMove(intervalX1);
                    axis1.Wait();
                    if (BGW_Auto.CancellationPending) return;
                    //suspend.WaitOne();
                }
                axis2.SingleAbsoluteMove(targetPosY1);
                axis2.Wait();
            }
            else
            {
                for (int i = 0; i < times / 2; i++)
                {
                    axis2.SingleAbsoluteMove(targetPosY1);
                    axis2.Wait();
                    axis1.SingleRelativeMove(intervalX1);
                    axis1.Wait();
                    if (BGW_Auto.CancellationPending) return;
                    axis2.SingleAbsoluteMove(0);
                    axis2.Wait();
                    axis1.SingleRelativeMove(intervalX1);
                    axis1.Wait();
                    if (BGW_Auto.CancellationPending) return;
                    //suspend.WaitOne();
                }
            }
        }

        public void Track2(string name, double startX, int times, double targetPosY1, double intervalX1)
        {
            BaseAxis axis1 = GetAxis(name, "Axis1");
            BaseAxis axis2 = GetAxis(name, "Axis2");
            if (axis1 == null || axis2 == null) return;
            axis1.SingleAbsoluteMove(startX);
            axis1.Wait();
            for (int i = 0; i < times; i++)
            {
                Controllers[name].SetOutput(0, 1);
                axis2.SingleAbsoluteMove(targetPosY1);
                axis2.Wait();
                Controllers[name].SetOutput(0, 0);
                axis1.SingleRelativeMove(intervalX1);
                axis1.Wait();
                axis2.SingleAbsoluteMove(0);
                axis2.Wait();
                if (BGW_Auto.CancellationPending) return;
                //suspend.WaitOne();
            }
        }
        #endregion

    }
}
