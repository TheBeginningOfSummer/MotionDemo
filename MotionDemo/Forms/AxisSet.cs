using Services;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MotionDemo.Forms
{
    public class AxisSet : ParameterSet
    {
        readonly BaseAxis axis;

        public AxisSet(BaseAxis currentAxis)
        {
            //参数源
            axis = currentAxis;
            //标题
            Text = $"{axis.Name}轴参数设置";
            //控件初始化
            InitializeControl();
        }

        public override void InitializeControl()
        {
            int x = 30;
            int y = 30;
            AddLabel(new Point(x, y), $"轴信息：{axis.ControllerName} {axis.Name} {axis.Number}");
            y += 30;
            PropertyInfo[] properties = axis.GetType().GetProperties();
            int j = 0;
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(bool)) continue;
                if (properties[i].Name == "TargetPosition" || properties[i].Name == "CurrentPosition" || properties[i].Name == "CurrentSpeed") continue;
                AddSetBox(new Point(x, y), Translate(properties[i].Name), properties[i].GetValue(axis).ToString());
                y += 30; j++;
                if (j == 11)
                {
                    x = 200;
                    y = 60;
                }
            }
        }

        public override void BTN应用_Click(object sender, EventArgs e)
        {
            try
            {
                axis.Initialize();
                MessageBox.Show("应用更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void BTN保存_Click(object sender, EventArgs e)
        {
            try
            {
                PropertyInfo[] properties = axis.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType == typeof(bool)) continue;
                    if (property.Name == "TargetPosition" || property.Name == "CurrentPosition" || property.Name == "CurrentSpeed") continue;
                    axis.SaveAxisConfig(property.Name, double.Parse(ControlList[Translate(property.Name)].Text));
                }
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
