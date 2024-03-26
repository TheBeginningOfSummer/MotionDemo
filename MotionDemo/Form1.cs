using MotionDemo.Services;
using OpenCvSharp;
using Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace MotionDemo
{
    public partial class Form1 : Form
    {
        //控制管理
        readonly MotionManager motion = MotionManager.Instance;
        //设置管理
        readonly SettingManager setting = SettingManager.Instance;
        //相机
        readonly CameraService cm = new CameraService();

        public Form1()
        {
            InitializeComponent();
            InitializeCheckBox(10, 10, PN信号控制, 9);

            motion.UpdateState += UpdateState;
            motion.UpdateData += UpdateControllerInfo;
            motion.UpdateData += UpdateAxesInfo;
            UpdateControllerInfo(motion);
        }

        #region 方法
        public static void OnThread(Control control, Action method)
        {
            if (control.IsHandleCreated)
                control.Invoke(method);
            else
                method();
        }
        //卡状态读取
        private void UpdateState(string[] info)
        {
            OnThread(LB轴状态, new Action(() => LB轴状态.Text = info[0]));
            OnThread(LB轴位置, new Action(() => LB轴位置.Text = info[1]));
            OnThread(LB轴速度, new Action(() => LB轴速度.Text = info[2]));
            OnThread(LB输入信号, new Action(() => LB输入信号.Text = info[3]));
        }
        //更新控制卡下拉列表
        private void UpdateControllerInfo(MotionManager motion)
        {
            CB控制卡.Items.Clear();
            foreach (var item in motion.Controllers.Values)
            {
                CB控制卡.Items.Add(item.Name);
            }
        }
        //更新轴下拉列表
        private void UpdateAxesInfo(MotionManager motion)
        {
            if (string.IsNullOrEmpty(CB控制卡.Text)) return;
            CB轴.Items.Clear();
            foreach (var item in motion.Controllers[CB控制卡.Text].AxesName)
            {
                CB轴.Items.Add(item);
            }
        }
        //控制卡选择变更时更新轴下拉列表
        private void CB控制卡_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAxesInfo(motion);
        }

        private void InitializeCheckBox(int x, int y, Control control, int count)
        {
            int xTemp = x;
            for (int i = 0; i < count; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    y += 20;
                    x = xTemp;
                }

                CheckBox checkBox = new CheckBox()
                {
                    Name = i.ToString(),
                    Location = new System.Drawing.Point(x, y),
                    Text = $"输入{i}",
                    AutoSize = true,
                    Tag = i.ToString()
                };
                checkBox.CheckedChanged += CHB信号更改_CheckedChanged;
                control.Controls.Add(checkBox);
                x += 60;
            }
        }
        #endregion

        #region 按钮事件
        private void BTN连接_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CB控制卡.Text)) return;
            if (motion.Connect(CB控制卡.Text))
            {
                motion.StartUpdate(CB控制卡.Text, 9);
            }
        }

        private void BTN断开_Click(object sender, EventArgs e)
        {
            motion.Disconnect(CB控制卡.Text);
        }

        private void BTN轴设置_Click(object sender, EventArgs e)
        {
            setting.AxisSet(motion, CB控制卡.Text, CB轴.Text);
        }

        private void BTN编辑信息_Click(object sender, EventArgs e)
        {
            setting.ControllerSet(motion);
        }

        private void BTN测试窗口_Click(object sender, EventArgs e)
        {
            motion.TestForm.Show();
        }

        private void BTN绝对位置移动_Click(object sender, EventArgs e)
        {
            if (CB轴.Text == "") return;
            if (double.TryParse(TB目标位置.Text, out double position))
                motion.GetAxis(CB控制卡.Text, CB轴.Text)?.SingleAbsoluteMove(position);
            else
                motion.GetAxis(CB控制卡.Text, CB轴.Text)?.SingleAbsoluteMove(0);
        }

        private void BTN相对位置移动_Click(object sender, EventArgs e)
        {
            if (CB轴.Text == "") return;
            if (double.TryParse(TB目标位置.Text, out double position))
                motion.GetAxis(CB控制卡.Text, CB轴.Text)?.SingleRelativeMove(position);
            else
                motion.GetAxis(CB控制卡.Text, CB轴.Text)?.SingleRelativeMove(0);
        }

        private void BTN负向运动_Click(object sender, EventArgs e)
        {
            motion.GetAxis(CB控制卡.Text, CB轴.Text)?.Reverse();
            //trio1.Trio.Execute("MOVEABS(1000)");
        }

        private void BTN正向运动_Click(object sender, EventArgs e)
        {
            motion.GetAxis(CB控制卡.Text, CB轴.Text)?.Forward();
        }

        private void BTN原点_Click(object sender, EventArgs e)
        {
            motion.GetAxis(CB控制卡.Text, CB轴.Text)?.Datum(3);
        }

        private void BTN停止_Click(object sender, EventArgs e)
        {
            motion.Controllers[CB控制卡.Text]?.Scram();
        }

        private void BTN位置清零_Click(object sender, EventArgs e)
        {
            motion.ClearPosition(CB控制卡.Text);
        }

        private void BTN测试_Click(object sender, EventArgs e)
        {
            motion.StartTrack(CB控制卡.Text, true);
        }

        private void CHB信号更改_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                motion.GetController(CB控制卡.Text)?.SetInput(int.Parse(checkBox.Tag.ToString()), 1);
            }
            else
            {
                motion.GetController(CB控制卡.Text)?.SetInput(int.Parse(checkBox.Tag.ToString()), 0);
            }
        }

        #endregion

        private void TSM打开二维码_Click(object sender, EventArgs e)
        {
            OFD识别图片码.Filter = "png图片|*.png|jpg图片|*.jpg";
            if (OFD识别图片码.ShowDialog() == DialogResult.OK)
            {
                string codeText = cm.LoadCode(OFD识别图片码.FileName);
                LB码值.Text = codeText;
            }
        }

        private void TSM存为二维码_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Code.Text))
            {
                MessageBox.Show("填入要生成码的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            var config = new KeyValueManager("CameraConfig.json", "Config\\Setting");
            if (button.Name == "TSM存为二维码")
            {
                ZXingService.GetQrCode(TB_Code.Text,
                    Directory.GetCurrentDirectory() + "//QrCode", $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png",
                    int.Parse(config.Load("二维码宽")), int.Parse(config.Load("二维码高")), int.Parse(config.Load("二维码边距")));
                MessageBox.Show("保存为二维码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (button.Name == "TSM存为条形码")
            {
                if (int.TryParse(TB_Code.Text, out _))
                {
                    ZXingService.GetBarCode(TB_Code.Text,
                        Directory.GetCurrentDirectory() + "//QrCode", $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png",
                        int.Parse(config.Load("条形码宽")), int.Parse(config.Load("条形码高")), int.Parse(config.Load("条形码边距")));
                    MessageBox.Show("保存为条形码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("生成条形码请输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TSM设置_Click(object sender, EventArgs e)
        {
            setting.CameraSet();
        }

        private void BTN模板匹配测试_Click(object sender, EventArgs e)
        {
            //Mat img = Cv2.ImRead("C:\\Users\\1\\Desktop\\test\\测试图片\\test1.0.png");
            //Mat temp = Cv2.ImRead("C:\\Users\\1\\Desktop\\test\\测试图片\\test1.2.png");
            //Mat result = Match.MatchingMethod(img, temp);
            //Cv2.ImShow("match", result);
            Match.Matching();
        }
    }
}
