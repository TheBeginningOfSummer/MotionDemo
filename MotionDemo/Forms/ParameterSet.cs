using Services;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MotionDemo.Forms
{
    public partial class ParameterSet : Form
    {
        public readonly Dictionary<string, Control> ControlList = new Dictionary<string, Control>();
        public KeyValueManager Config;

        public ParameterSet()
        {
            InitializeComponent();
        }

        public void AddLabel(Point point, string name)
        {
            Label label = new Label
            {
                Name = $"LB{name}",
                Location = point,
                Text = name,
                AutoSize = true
            };
            Controls.Add(label);
        }

        public void AddSetBox(Point point, string name, string value, int width = 50, int offset = 80)
        {
            Label label = new Label
            {
                Name = $"LB{name}",
                Location = point,
                Text = name,
                AutoSize = true
            };
            TextBox textBox = new TextBox
            {
                Name = $"TB{name}",
                Location = new Point(point.X + offset, point.Y - 5),
                Text = value,
                Size = new Size(width, 24)
            };
            Controls.Add(label);
            Controls.Add(textBox);
            ControlList.Add(name, textBox);
        }

        public virtual string Translate(string message)
        {
            switch (message)
            {
                case "Type": return "轴类型";
                case "Units": return "脉冲当量";
                case "Sramp": return "S曲线";
                case "Speed": return "速度";
                case "Creep": return "爬行速度";
                case "JogSpeed": return "Jog速度";
                case "Accele": return "加速度";
                case "Decele": return "减速度";
                case "FastDecele": return "快速减速度";
                case "FsLimit": return "正软限位";
                case "RsLimit": return "负软限位";
                case "DatumIn": return "原点信号";
                case "ForwardIn": return "正限位信号";
                case "ReverseIn": return "负限位信号";
                case "ForwardJogIn": return "Jog正向信号";
                case "ReverseJogIn": return "Jog负向信号";
                case "FastJogIn": return "快速Jog信号";
            }
            return default;
        }

        public virtual void InitializeControl()
        {
            if (Config == null) return;
            if (!Config.KeyValueList.ContainsKey("Title")) Config.Change("Title", "");
            if (!Config.KeyValueList.ContainsKey("Row")) Config.Change("Row", "12");
            if (!Config.KeyValueList.ContainsKey("X")) Config.Change("X", "30");
            if (!Config.KeyValueList.ContainsKey("Y")) Config.Change("Y", "30");
            if (!Config.KeyValueList.ContainsKey("XInterval")) Config.Change("XInterval", "200");
            if (!Config.KeyValueList.ContainsKey("YInterval")) Config.Change("YInterval", "30");
            if (!int.TryParse(Config.Load("Row"), out int result)) return;
            if (!int.TryParse(Config.Load("X"), out int xInitial)) return;
            if (!int.TryParse(Config.Load("Y"), out int yInitial)) return;
            if (!int.TryParse(Config.Load("XInterval"), out int xInterval)) return;
            if (!int.TryParse(Config.Load("YInterval"), out int yInterval)) return;

            int x = xInitial;
            int y = yInitial;

            AddLabel(new Point(x, y), Config.Load("Title"));
            y += yInterval;

            int j = 0;
            foreach (var config in Config.KeyValueList)
            {
                if (config.Key == "Title" || config.Key == "Row") continue;
                if (config.Key == "X" || config.Key == "Y") continue;
                if (config.Key == "XInterval" || config.Key == "YInterval") continue;
                AddSetBox(new Point(x, y), config.Key, config.Value);
                y += yInterval; j++;
                if (j % result == 0)
                {
                    x += xInterval;
                    y = yInitial + yInterval;
                }
            }
        }

        public virtual void BTN应用_Click(object sender, System.EventArgs e)
        {

        }

        public virtual void BTN保存_Click(object sender, System.EventArgs e)
        {
            foreach (var tb in ControlList)
            {
                Config.Change(tb.Key, tb.Value.Text);
            }
            MessageBox.Show("保存完成。", "提示");
        }
    }
}
