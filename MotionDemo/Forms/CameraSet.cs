using Services;
using System;

namespace MotionDemo.Forms
{
    public class CameraSet : ParameterSet
    {
        public CameraSet()
        {
            //参数源
            Config = new KeyValueManager("CameraConfig.json", "Config\\Setting");
            //标题
            Text = $"相机参数设置";
            //控件初始化
            InitializeControl();
        }

        public override void BTN应用_Click(object sender, EventArgs e)
        {
            base.BTN应用_Click(sender, e);
        }
    }
}
