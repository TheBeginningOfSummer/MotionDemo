using Services;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionDemo.Forms
{
    public partial class Test : Form
    {
        readonly Graphics graphics;
        bool isDraw = true;

        public Test()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        #region 图形绘制
        private void DrawHLine(Graphics graphics, Pen pen, int x1, int x2, int y, int step = 100)
        {
            graphics.DrawLine(pen, x1, y, x2, y);
            var brush = new SolidBrush(Color.Green);
            int length = x2 - x1;
            if (length > 0)
            {
                for (int i = 0; i < length / step; i++)
                {
                    graphics.DrawLine(pen, step * i, y, step * i, y + 5);
                    graphics.DrawString((step * i).ToString(), new Font("宋体", 10), brush, new PointF(step * i, 5));
                }
            }
            else
            {

            }
        }

        private void DrawVLine(Graphics graphics, Pen pen, int y1, int y2, int x, int step = 100)
        {
            graphics.DrawLine(pen, x, y1, x, y2);
            var brush = new SolidBrush(Color.Green);
            int length = y2 - y1;
            if (length > 0)
            {
                for (int i = 0; i < length / step; i++)
                {
                    if (i == 0) continue;
                    graphics.DrawLine(pen, x, step * i, x + 5, step * i);
                    graphics.DrawString((step * i).ToString(), new Font("宋体", 10), brush, new PointF(5, step * i));
                }
            }
            else
            {

            }
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
        }

        private void Test_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Green, 2);
            DrawHLine(graphics, pen, 0, 1000, 0, 100);
            DrawVLine(graphics, pen, 0, 1000, 0, 100);
        }

        public void StartDrawTrackXY(double offset, BaseAxis axis1, BaseAxis axis2)
        {
            if (axis1 == null || axis2 == null) return;
            isDraw = true;
            Pen pen = new Pen(Color.LightBlue, 2);
            var brush1 = new SolidBrush(Color.Red);
            var brush2 = new SolidBrush(BackColor);
            double x2 = offset;
            double y2 = offset;
            Task.Run(() =>
            {
                while (isDraw)
                {
                    double x1 = x2;
                    double y1 = y2;
                    graphics.FillEllipse(brush2, (float)x1 + 1, (float)y1, 4, 4);
                    Thread.Sleep(10);
                    x2 = axis1.CurrentPosition + offset;
                    y2 = axis2.CurrentPosition + offset;
                    graphics.FillEllipse(brush1, (float)x2 + 1, (float)y2, 4, 4);
                    graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            });
        }

        public void Stop()
        {
            isDraw = false;
        }
        #endregion

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void BTN清除_Click(object sender, EventArgs e)
        {
            Clear();
            Pen pen = new Pen(Color.Green, 2);
            DrawHLine(graphics, pen, 0, 1000, 0, 100);
            DrawVLine(graphics, pen, 0, 1000, 0, 100);
        }
    }
}
