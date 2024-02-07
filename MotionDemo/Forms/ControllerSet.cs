using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MotionDemo.Forms
{
    public partial class ControllerSet : Form
    {
        readonly MotionManager motion;

        public ControllerSet(MotionManager motionManager)
        {
            InitializeComponent();
            motion = motionManager;
            UpdateComboBox(motion);
            motion.UpdateData += UpdateComboBox;
            motion.UpdateData += UpdateControllerInfo;
        }

        private void UpdateComboBox(MotionManager motion)
        {
            CB控制器.Items.Clear();
            foreach (var controller in motion.Controllers.Values)
                CB控制器.Items.Add(controller.Name);
        }

        private void UpdateControllerInfo(MotionManager motion)
        {
            if (CB控制器.Text != null)
            {
                if (!motion.Controllers.ContainsKey(CB控制器.Text)) return;
                string axes = $"{Environment.NewLine}轴列表：{Environment.NewLine}";
                for (int i = 0; i < motion.Controllers[CB控制器.Text].AxesName.Count; i++)
                {
                    axes += $"        {motion.Controllers[CB控制器.Text].AxesName[i]}  [{i}]{Environment.NewLine}";
                }
                LB信息.Text = $"控制器：{CB控制器.Text}{Environment.NewLine}" +
                    $"{Environment.NewLine}IP地址：{motion.Controllers[CB控制器.Text].IP}{Environment.NewLine}" +
                    $"{axes}{Environment.NewLine}类型：{motion.Controllers[CB控制器.Text].GetType().ToString().Split('.').LastOrDefault()}";
            }
        }

        private void CB控制器_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControllerInfo(motion);
        }

        private void BTN修改_Click(object sender, EventArgs e)
        {
            List<string> axes = TB轴名称.Text.Split(';').ToList();
            if (motion.ModifyInfo(CB控制器.Text, TBIP.Text, axes, CB类型.Text))
                MessageBox.Show("已修改");
        }

        private void BTN删除_Click(object sender, EventArgs e)
        {
            if (motion.RemoveInfo(CB控制器.Text, TB轴名称.Text))
                MessageBox.Show("已删除");
        }
    }
}
