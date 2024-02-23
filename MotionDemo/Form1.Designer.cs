namespace MotionDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TC_Main = new System.Windows.Forms.TabControl();
            this.TP首页 = new System.Windows.Forms.TabPage();
            this.TP轴测试 = new System.Windows.Forms.TabPage();
            this.GB特殊信号控制 = new System.Windows.Forms.GroupBox();
            this.PN信号控制 = new System.Windows.Forms.Panel();
            this.GB信号 = new System.Windows.Forms.GroupBox();
            this.PN信号 = new System.Windows.Forms.Panel();
            this.LB输入信号 = new System.Windows.Forms.Label();
            this.GB轴设置 = new System.Windows.Forms.GroupBox();
            this.BTN编辑信息 = new System.Windows.Forms.Button();
            this.LB轴选择 = new System.Windows.Forms.Label();
            this.LB轴卡选择 = new System.Windows.Forms.Label();
            this.CB控制卡 = new System.Windows.Forms.ComboBox();
            this.CB轴 = new System.Windows.Forms.ComboBox();
            this.BTN轴设置 = new System.Windows.Forms.Button();
            this.BTN测试窗口 = new System.Windows.Forms.Button();
            this.BTN连接 = new System.Windows.Forms.Button();
            this.BTN断开 = new System.Windows.Forms.Button();
            this.GB轴信息 = new System.Windows.Forms.GroupBox();
            this.PN轴信息 = new System.Windows.Forms.Panel();
            this.LB轴状态 = new System.Windows.Forms.Label();
            this.LB轴速度 = new System.Windows.Forms.Label();
            this.LB轴位置 = new System.Windows.Forms.Label();
            this.GB轴控制 = new System.Windows.Forms.GroupBox();
            this.BTN相对位置移动 = new System.Windows.Forms.Button();
            this.BTN绝对位置移动 = new System.Windows.Forms.Button();
            this.BTN测试 = new System.Windows.Forms.Button();
            this.BTN位置清零 = new System.Windows.Forms.Button();
            this.BTN原点 = new System.Windows.Forms.Button();
            this.BTN停止 = new System.Windows.Forms.Button();
            this.TB目标位置 = new System.Windows.Forms.TextBox();
            this.BTN负向运动 = new System.Windows.Forms.Button();
            this.BTN正向运动 = new System.Windows.Forms.Button();
            this.LB目标位置 = new System.Windows.Forms.Label();
            this.TP数据 = new System.Windows.Forms.TabPage();
            this.TP扫码测试 = new System.Windows.Forms.TabPage();
            this.TB_Code = new System.Windows.Forms.TextBox();
            this.LB码值 = new System.Windows.Forms.Label();
            this.MS_Camera = new System.Windows.Forms.MenuStrip();
            this.TSM文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM打开二维码 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM存为二维码 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM存为条形码 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM相机 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM开始录制 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM停止录制 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM开始扫码 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM停止扫码 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM拍摄 = new System.Windows.Forms.ToolStripMenuItem();
            this.TP模板匹配 = new System.Windows.Forms.TabPage();
            this.OFD识别图片码 = new System.Windows.Forms.OpenFileDialog();
            this.BTN模板匹配测试 = new System.Windows.Forms.Button();
            this.TC_Main.SuspendLayout();
            this.TP轴测试.SuspendLayout();
            this.GB特殊信号控制.SuspendLayout();
            this.GB信号.SuspendLayout();
            this.PN信号.SuspendLayout();
            this.GB轴设置.SuspendLayout();
            this.GB轴信息.SuspendLayout();
            this.PN轴信息.SuspendLayout();
            this.GB轴控制.SuspendLayout();
            this.TP扫码测试.SuspendLayout();
            this.MS_Camera.SuspendLayout();
            this.TP模板匹配.SuspendLayout();
            this.SuspendLayout();
            // 
            // TC_Main
            // 
            this.TC_Main.Controls.Add(this.TP首页);
            this.TC_Main.Controls.Add(this.TP轴测试);
            this.TC_Main.Controls.Add(this.TP数据);
            this.TC_Main.Controls.Add(this.TP扫码测试);
            this.TC_Main.Controls.Add(this.TP模板匹配);
            this.TC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Main.Location = new System.Drawing.Point(0, 0);
            this.TC_Main.Name = "TC_Main";
            this.TC_Main.SelectedIndex = 0;
            this.TC_Main.Size = new System.Drawing.Size(800, 450);
            this.TC_Main.TabIndex = 0;
            // 
            // TP首页
            // 
            this.TP首页.Location = new System.Drawing.Point(4, 22);
            this.TP首页.Name = "TP首页";
            this.TP首页.Padding = new System.Windows.Forms.Padding(3);
            this.TP首页.Size = new System.Drawing.Size(792, 424);
            this.TP首页.TabIndex = 0;
            this.TP首页.Text = "首页";
            this.TP首页.UseVisualStyleBackColor = true;
            // 
            // TP轴测试
            // 
            this.TP轴测试.Controls.Add(this.GB特殊信号控制);
            this.TP轴测试.Controls.Add(this.GB信号);
            this.TP轴测试.Controls.Add(this.GB轴设置);
            this.TP轴测试.Controls.Add(this.GB轴信息);
            this.TP轴测试.Controls.Add(this.GB轴控制);
            this.TP轴测试.Location = new System.Drawing.Point(4, 22);
            this.TP轴测试.Name = "TP轴测试";
            this.TP轴测试.Padding = new System.Windows.Forms.Padding(3);
            this.TP轴测试.Size = new System.Drawing.Size(792, 424);
            this.TP轴测试.TabIndex = 1;
            this.TP轴测试.Text = "轴测试";
            this.TP轴测试.UseVisualStyleBackColor = true;
            // 
            // GB特殊信号控制
            // 
            this.GB特殊信号控制.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB特殊信号控制.Controls.Add(this.PN信号控制);
            this.GB特殊信号控制.Location = new System.Drawing.Point(398, 211);
            this.GB特殊信号控制.Name = "GB特殊信号控制";
            this.GB特殊信号控制.Size = new System.Drawing.Size(386, 207);
            this.GB特殊信号控制.TabIndex = 22;
            this.GB特殊信号控制.TabStop = false;
            this.GB特殊信号控制.Text = "信号控制";
            // 
            // PN信号控制
            // 
            this.PN信号控制.AutoScroll = true;
            this.PN信号控制.AutoSize = true;
            this.PN信号控制.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN信号控制.Location = new System.Drawing.Point(3, 17);
            this.PN信号控制.Name = "PN信号控制";
            this.PN信号控制.Size = new System.Drawing.Size(380, 187);
            this.PN信号控制.TabIndex = 7;
            // 
            // GB信号
            // 
            this.GB信号.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB信号.Controls.Add(this.PN信号);
            this.GB信号.Location = new System.Drawing.Point(8, 211);
            this.GB信号.Name = "GB信号";
            this.GB信号.Size = new System.Drawing.Size(384, 207);
            this.GB信号.TabIndex = 21;
            this.GB信号.TabStop = false;
            this.GB信号.Text = "信号";
            // 
            // PN信号
            // 
            this.PN信号.Controls.Add(this.LB输入信号);
            this.PN信号.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN信号.Location = new System.Drawing.Point(3, 17);
            this.PN信号.Name = "PN信号";
            this.PN信号.Size = new System.Drawing.Size(378, 187);
            this.PN信号.TabIndex = 1;
            // 
            // LB输入信号
            // 
            this.LB输入信号.AutoSize = true;
            this.LB输入信号.Location = new System.Drawing.Point(10, 17);
            this.LB输入信号.Name = "LB输入信号";
            this.LB输入信号.Size = new System.Drawing.Size(53, 12);
            this.LB输入信号.TabIndex = 0;
            this.LB输入信号.Text = "输入信号";
            // 
            // GB轴设置
            // 
            this.GB轴设置.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB轴设置.Controls.Add(this.BTN编辑信息);
            this.GB轴设置.Controls.Add(this.LB轴选择);
            this.GB轴设置.Controls.Add(this.LB轴卡选择);
            this.GB轴设置.Controls.Add(this.CB控制卡);
            this.GB轴设置.Controls.Add(this.CB轴);
            this.GB轴设置.Controls.Add(this.BTN轴设置);
            this.GB轴设置.Controls.Add(this.BTN测试窗口);
            this.GB轴设置.Controls.Add(this.BTN连接);
            this.GB轴设置.Controls.Add(this.BTN断开);
            this.GB轴设置.Location = new System.Drawing.Point(398, 6);
            this.GB轴设置.Name = "GB轴设置";
            this.GB轴设置.Size = new System.Drawing.Size(191, 199);
            this.GB轴设置.TabIndex = 20;
            this.GB轴设置.TabStop = false;
            this.GB轴设置.Text = "轴设置";
            // 
            // BTN编辑信息
            // 
            this.BTN编辑信息.Location = new System.Drawing.Point(96, 106);
            this.BTN编辑信息.Name = "BTN编辑信息";
            this.BTN编辑信息.Size = new System.Drawing.Size(75, 23);
            this.BTN编辑信息.TabIndex = 23;
            this.BTN编辑信息.Text = "编辑信息";
            this.BTN编辑信息.UseVisualStyleBackColor = true;
            this.BTN编辑信息.Click += new System.EventHandler(this.BTN编辑信息_Click);
            // 
            // LB轴选择
            // 
            this.LB轴选择.AutoSize = true;
            this.LB轴选择.Location = new System.Drawing.Point(13, 49);
            this.LB轴选择.Name = "LB轴选择";
            this.LB轴选择.Size = new System.Drawing.Size(41, 12);
            this.LB轴选择.TabIndex = 21;
            this.LB轴选择.Text = "轴选择";
            // 
            // LB轴卡选择
            // 
            this.LB轴卡选择.AutoSize = true;
            this.LB轴卡选择.Location = new System.Drawing.Point(13, 23);
            this.LB轴卡选择.Name = "LB轴卡选择";
            this.LB轴卡选择.Size = new System.Drawing.Size(53, 12);
            this.LB轴卡选择.TabIndex = 21;
            this.LB轴卡选择.Text = "轴卡选择";
            // 
            // CB控制卡
            // 
            this.CB控制卡.FormattingEnabled = true;
            this.CB控制卡.Items.AddRange(new object[] {
            "Zmotion1",
            "Trio1"});
            this.CB控制卡.Location = new System.Drawing.Point(72, 20);
            this.CB控制卡.Name = "CB控制卡";
            this.CB控制卡.Size = new System.Drawing.Size(100, 20);
            this.CB控制卡.TabIndex = 20;
            this.CB控制卡.SelectedIndexChanged += new System.EventHandler(this.CB控制卡_SelectedIndexChanged);
            // 
            // CB轴
            // 
            this.CB轴.FormattingEnabled = true;
            this.CB轴.Items.AddRange(new object[] {
            "Axis1",
            "Axis2"});
            this.CB轴.Location = new System.Drawing.Point(72, 46);
            this.CB轴.Name = "CB轴";
            this.CB轴.Size = new System.Drawing.Size(100, 20);
            this.CB轴.TabIndex = 7;
            // 
            // BTN轴设置
            // 
            this.BTN轴设置.Location = new System.Drawing.Point(15, 106);
            this.BTN轴设置.Name = "BTN轴设置";
            this.BTN轴设置.Size = new System.Drawing.Size(75, 23);
            this.BTN轴设置.TabIndex = 1;
            this.BTN轴设置.Text = "轴设置";
            this.BTN轴设置.UseVisualStyleBackColor = true;
            this.BTN轴设置.Click += new System.EventHandler(this.BTN轴设置_Click);
            // 
            // BTN测试窗口
            // 
            this.BTN测试窗口.Location = new System.Drawing.Point(15, 135);
            this.BTN测试窗口.Name = "BTN测试窗口";
            this.BTN测试窗口.Size = new System.Drawing.Size(75, 23);
            this.BTN测试窗口.TabIndex = 14;
            this.BTN测试窗口.Text = "测试窗口";
            this.BTN测试窗口.UseVisualStyleBackColor = true;
            this.BTN测试窗口.Click += new System.EventHandler(this.BTN测试窗口_Click);
            // 
            // BTN连接
            // 
            this.BTN连接.Location = new System.Drawing.Point(15, 77);
            this.BTN连接.Name = "BTN连接";
            this.BTN连接.Size = new System.Drawing.Size(75, 23);
            this.BTN连接.TabIndex = 9;
            this.BTN连接.Text = "连接";
            this.BTN连接.UseVisualStyleBackColor = true;
            this.BTN连接.Click += new System.EventHandler(this.BTN连接_Click);
            // 
            // BTN断开
            // 
            this.BTN断开.Location = new System.Drawing.Point(97, 77);
            this.BTN断开.Name = "BTN断开";
            this.BTN断开.Size = new System.Drawing.Size(75, 23);
            this.BTN断开.TabIndex = 10;
            this.BTN断开.Text = "断开";
            this.BTN断开.UseVisualStyleBackColor = true;
            this.BTN断开.Click += new System.EventHandler(this.BTN断开_Click);
            // 
            // GB轴信息
            // 
            this.GB轴信息.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB轴信息.Controls.Add(this.PN轴信息);
            this.GB轴信息.Location = new System.Drawing.Point(8, 6);
            this.GB轴信息.Name = "GB轴信息";
            this.GB轴信息.Size = new System.Drawing.Size(384, 199);
            this.GB轴信息.TabIndex = 19;
            this.GB轴信息.TabStop = false;
            this.GB轴信息.Text = "轴信息";
            // 
            // PN轴信息
            // 
            this.PN轴信息.AutoScroll = true;
            this.PN轴信息.AutoSize = true;
            this.PN轴信息.Controls.Add(this.LB轴状态);
            this.PN轴信息.Controls.Add(this.LB轴速度);
            this.PN轴信息.Controls.Add(this.LB轴位置);
            this.PN轴信息.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN轴信息.Location = new System.Drawing.Point(3, 17);
            this.PN轴信息.Name = "PN轴信息";
            this.PN轴信息.Size = new System.Drawing.Size(378, 179);
            this.PN轴信息.TabIndex = 12;
            // 
            // LB轴状态
            // 
            this.LB轴状态.AutoSize = true;
            this.LB轴状态.Location = new System.Drawing.Point(273, 11);
            this.LB轴状态.Name = "LB轴状态";
            this.LB轴状态.Size = new System.Drawing.Size(41, 12);
            this.LB轴状态.TabIndex = 11;
            this.LB轴状态.Text = "轴状态";
            // 
            // LB轴速度
            // 
            this.LB轴速度.AutoSize = true;
            this.LB轴速度.Location = new System.Drawing.Point(142, 11);
            this.LB轴速度.Name = "LB轴速度";
            this.LB轴速度.Size = new System.Drawing.Size(41, 12);
            this.LB轴速度.TabIndex = 4;
            this.LB轴速度.Text = "轴速度";
            // 
            // LB轴位置
            // 
            this.LB轴位置.AutoSize = true;
            this.LB轴位置.Location = new System.Drawing.Point(3, 11);
            this.LB轴位置.Name = "LB轴位置";
            this.LB轴位置.Size = new System.Drawing.Size(41, 12);
            this.LB轴位置.TabIndex = 2;
            this.LB轴位置.Text = "轴位置";
            // 
            // GB轴控制
            // 
            this.GB轴控制.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB轴控制.Controls.Add(this.BTN相对位置移动);
            this.GB轴控制.Controls.Add(this.BTN绝对位置移动);
            this.GB轴控制.Controls.Add(this.BTN测试);
            this.GB轴控制.Controls.Add(this.BTN位置清零);
            this.GB轴控制.Controls.Add(this.BTN原点);
            this.GB轴控制.Controls.Add(this.BTN停止);
            this.GB轴控制.Controls.Add(this.TB目标位置);
            this.GB轴控制.Controls.Add(this.BTN负向运动);
            this.GB轴控制.Controls.Add(this.BTN正向运动);
            this.GB轴控制.Controls.Add(this.LB目标位置);
            this.GB轴控制.Location = new System.Drawing.Point(595, 6);
            this.GB轴控制.Name = "GB轴控制";
            this.GB轴控制.Size = new System.Drawing.Size(189, 199);
            this.GB轴控制.TabIndex = 18;
            this.GB轴控制.TabStop = false;
            this.GB轴控制.Text = "轴控制";
            // 
            // BTN相对位置移动
            // 
            this.BTN相对位置移动.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTN相对位置移动.Location = new System.Drawing.Point(99, 49);
            this.BTN相对位置移动.Name = "BTN相对位置移动";
            this.BTN相对位置移动.Size = new System.Drawing.Size(75, 23);
            this.BTN相对位置移动.TabIndex = 16;
            this.BTN相对位置移动.Text = "相对位置移动";
            this.BTN相对位置移动.UseVisualStyleBackColor = true;
            this.BTN相对位置移动.Click += new System.EventHandler(this.BTN相对位置移动_Click);
            // 
            // BTN绝对位置移动
            // 
            this.BTN绝对位置移动.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTN绝对位置移动.Location = new System.Drawing.Point(18, 49);
            this.BTN绝对位置移动.Name = "BTN绝对位置移动";
            this.BTN绝对位置移动.Size = new System.Drawing.Size(75, 23);
            this.BTN绝对位置移动.TabIndex = 15;
            this.BTN绝对位置移动.Text = "绝对位置移动";
            this.BTN绝对位置移动.UseVisualStyleBackColor = true;
            this.BTN绝对位置移动.Click += new System.EventHandler(this.BTN绝对位置移动_Click);
            // 
            // BTN测试
            // 
            this.BTN测试.Location = new System.Drawing.Point(99, 135);
            this.BTN测试.Name = "BTN测试";
            this.BTN测试.Size = new System.Drawing.Size(75, 23);
            this.BTN测试.TabIndex = 18;
            this.BTN测试.Text = "自动测试";
            this.BTN测试.UseVisualStyleBackColor = true;
            this.BTN测试.Click += new System.EventHandler(this.BTN测试_Click);
            // 
            // BTN位置清零
            // 
            this.BTN位置清零.Location = new System.Drawing.Point(18, 135);
            this.BTN位置清零.Name = "BTN位置清零";
            this.BTN位置清零.Size = new System.Drawing.Size(75, 23);
            this.BTN位置清零.TabIndex = 19;
            this.BTN位置清零.Text = "位置清零";
            this.BTN位置清零.UseVisualStyleBackColor = true;
            this.BTN位置清零.Click += new System.EventHandler(this.BTN位置清零_Click);
            // 
            // BTN原点
            // 
            this.BTN原点.Location = new System.Drawing.Point(18, 106);
            this.BTN原点.Name = "BTN原点";
            this.BTN原点.Size = new System.Drawing.Size(75, 23);
            this.BTN原点.TabIndex = 12;
            this.BTN原点.Text = "原点";
            this.BTN原点.UseVisualStyleBackColor = true;
            this.BTN原点.Click += new System.EventHandler(this.BTN原点_Click);
            // 
            // BTN停止
            // 
            this.BTN停止.Location = new System.Drawing.Point(99, 106);
            this.BTN停止.Name = "BTN停止";
            this.BTN停止.Size = new System.Drawing.Size(75, 23);
            this.BTN停止.TabIndex = 6;
            this.BTN停止.Text = "停止";
            this.BTN停止.UseVisualStyleBackColor = true;
            this.BTN停止.Click += new System.EventHandler(this.BTN停止_Click);
            // 
            // TB目标位置
            // 
            this.TB目标位置.Location = new System.Drawing.Point(74, 19);
            this.TB目标位置.Name = "TB目标位置";
            this.TB目标位置.Size = new System.Drawing.Size(100, 21);
            this.TB目标位置.TabIndex = 13;
            // 
            // BTN负向运动
            // 
            this.BTN负向运动.Location = new System.Drawing.Point(18, 77);
            this.BTN负向运动.Name = "BTN负向运动";
            this.BTN负向运动.Size = new System.Drawing.Size(75, 23);
            this.BTN负向运动.TabIndex = 0;
            this.BTN负向运动.Text = "←";
            this.BTN负向运动.UseVisualStyleBackColor = true;
            this.BTN负向运动.Click += new System.EventHandler(this.BTN负向运动_Click);
            // 
            // BTN正向运动
            // 
            this.BTN正向运动.Location = new System.Drawing.Point(99, 77);
            this.BTN正向运动.Name = "BTN正向运动";
            this.BTN正向运动.Size = new System.Drawing.Size(75, 23);
            this.BTN正向运动.TabIndex = 8;
            this.BTN正向运动.Text = "→";
            this.BTN正向运动.UseVisualStyleBackColor = true;
            this.BTN正向运动.Click += new System.EventHandler(this.BTN正向运动_Click);
            // 
            // LB目标位置
            // 
            this.LB目标位置.AutoSize = true;
            this.LB目标位置.Location = new System.Drawing.Point(16, 22);
            this.LB目标位置.Name = "LB目标位置";
            this.LB目标位置.Size = new System.Drawing.Size(53, 12);
            this.LB目标位置.TabIndex = 14;
            this.LB目标位置.Text = "目标位置";
            // 
            // TP数据
            // 
            this.TP数据.Location = new System.Drawing.Point(4, 22);
            this.TP数据.Name = "TP数据";
            this.TP数据.Size = new System.Drawing.Size(792, 424);
            this.TP数据.TabIndex = 2;
            this.TP数据.Text = "数据";
            this.TP数据.UseVisualStyleBackColor = true;
            // 
            // TP扫码测试
            // 
            this.TP扫码测试.Controls.Add(this.TB_Code);
            this.TP扫码测试.Controls.Add(this.LB码值);
            this.TP扫码测试.Controls.Add(this.MS_Camera);
            this.TP扫码测试.Location = new System.Drawing.Point(4, 22);
            this.TP扫码测试.Name = "TP扫码测试";
            this.TP扫码测试.Padding = new System.Windows.Forms.Padding(3);
            this.TP扫码测试.Size = new System.Drawing.Size(792, 424);
            this.TP扫码测试.TabIndex = 3;
            this.TP扫码测试.Text = "扫码测试";
            this.TP扫码测试.UseVisualStyleBackColor = true;
            // 
            // TB_Code
            // 
            this.TB_Code.Location = new System.Drawing.Point(13, 68);
            this.TB_Code.Name = "TB_Code";
            this.TB_Code.Size = new System.Drawing.Size(734, 21);
            this.TB_Code.TabIndex = 2;
            // 
            // LB码值
            // 
            this.LB码值.AutoSize = true;
            this.LB码值.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB码值.Location = new System.Drawing.Point(8, 38);
            this.LB码值.Name = "LB码值";
            this.LB码值.Size = new System.Drawing.Size(66, 27);
            this.LB码值.TabIndex = 1;
            this.LB码值.Text = "码值";
            // 
            // MS_Camera
            // 
            this.MS_Camera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM文件,
            this.TSM相机});
            this.MS_Camera.Location = new System.Drawing.Point(3, 3);
            this.MS_Camera.Name = "MS_Camera";
            this.MS_Camera.Size = new System.Drawing.Size(786, 25);
            this.MS_Camera.TabIndex = 0;
            this.MS_Camera.Text = "menuStrip";
            // 
            // TSM文件
            // 
            this.TSM文件.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM打开二维码,
            this.TSM存为二维码,
            this.TSM存为条形码,
            this.TSM设置});
            this.TSM文件.Name = "TSM文件";
            this.TSM文件.Size = new System.Drawing.Size(44, 21);
            this.TSM文件.Text = "文件";
            // 
            // TSM打开二维码
            // 
            this.TSM打开二维码.Name = "TSM打开二维码";
            this.TSM打开二维码.Size = new System.Drawing.Size(136, 22);
            this.TSM打开二维码.Text = "打开二维码";
            this.TSM打开二维码.Click += new System.EventHandler(this.TSM打开二维码_Click);
            // 
            // TSM存为二维码
            // 
            this.TSM存为二维码.Name = "TSM存为二维码";
            this.TSM存为二维码.Size = new System.Drawing.Size(136, 22);
            this.TSM存为二维码.Text = "存为二维码";
            this.TSM存为二维码.Click += new System.EventHandler(this.TSM存为二维码_Click);
            // 
            // TSM存为条形码
            // 
            this.TSM存为条形码.Name = "TSM存为条形码";
            this.TSM存为条形码.Size = new System.Drawing.Size(136, 22);
            this.TSM存为条形码.Text = "存为条形码";
            // 
            // TSM设置
            // 
            this.TSM设置.Name = "TSM设置";
            this.TSM设置.Size = new System.Drawing.Size(136, 22);
            this.TSM设置.Text = "设置";
            this.TSM设置.Click += new System.EventHandler(this.TSM设置_Click);
            // 
            // TSM相机
            // 
            this.TSM相机.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM开始录制,
            this.TSM停止录制,
            this.TSM开始扫码,
            this.TSM停止扫码,
            this.TSM拍摄});
            this.TSM相机.Name = "TSM相机";
            this.TSM相机.Size = new System.Drawing.Size(44, 21);
            this.TSM相机.Text = "相机";
            // 
            // TSM开始录制
            // 
            this.TSM开始录制.Name = "TSM开始录制";
            this.TSM开始录制.Size = new System.Drawing.Size(124, 22);
            this.TSM开始录制.Text = "开始录制";
            // 
            // TSM停止录制
            // 
            this.TSM停止录制.Name = "TSM停止录制";
            this.TSM停止录制.Size = new System.Drawing.Size(124, 22);
            this.TSM停止录制.Text = "停止录制";
            // 
            // TSM开始扫码
            // 
            this.TSM开始扫码.Name = "TSM开始扫码";
            this.TSM开始扫码.Size = new System.Drawing.Size(124, 22);
            this.TSM开始扫码.Text = "开始扫码";
            // 
            // TSM停止扫码
            // 
            this.TSM停止扫码.Name = "TSM停止扫码";
            this.TSM停止扫码.Size = new System.Drawing.Size(124, 22);
            this.TSM停止扫码.Text = "停止扫码";
            // 
            // TSM拍摄
            // 
            this.TSM拍摄.Name = "TSM拍摄";
            this.TSM拍摄.Size = new System.Drawing.Size(124, 22);
            this.TSM拍摄.Text = "拍摄";
            // 
            // TP模板匹配
            // 
            this.TP模板匹配.Controls.Add(this.BTN模板匹配测试);
            this.TP模板匹配.Location = new System.Drawing.Point(4, 22);
            this.TP模板匹配.Name = "TP模板匹配";
            this.TP模板匹配.Size = new System.Drawing.Size(792, 424);
            this.TP模板匹配.TabIndex = 4;
            this.TP模板匹配.Text = "模板匹配测试";
            this.TP模板匹配.UseVisualStyleBackColor = true;
            // 
            // OFD识别图片码
            // 
            this.OFD识别图片码.FileName = "openFileDialog";
            // 
            // BTN模板匹配测试
            // 
            this.BTN模板匹配测试.Location = new System.Drawing.Point(380, 170);
            this.BTN模板匹配测试.Name = "BTN模板匹配测试";
            this.BTN模板匹配测试.Size = new System.Drawing.Size(75, 23);
            this.BTN模板匹配测试.TabIndex = 0;
            this.BTN模板匹配测试.Text = "测试";
            this.BTN模板匹配测试.UseVisualStyleBackColor = true;
            this.BTN模板匹配测试.Click += new System.EventHandler(this.BTN模板匹配测试_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TC_Main);
            this.MainMenuStrip = this.MS_Camera;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotionDemo";
            this.TC_Main.ResumeLayout(false);
            this.TP轴测试.ResumeLayout(false);
            this.GB特殊信号控制.ResumeLayout(false);
            this.GB特殊信号控制.PerformLayout();
            this.GB信号.ResumeLayout(false);
            this.PN信号.ResumeLayout(false);
            this.PN信号.PerformLayout();
            this.GB轴设置.ResumeLayout(false);
            this.GB轴设置.PerformLayout();
            this.GB轴信息.ResumeLayout(false);
            this.GB轴信息.PerformLayout();
            this.PN轴信息.ResumeLayout(false);
            this.PN轴信息.PerformLayout();
            this.GB轴控制.ResumeLayout(false);
            this.GB轴控制.PerformLayout();
            this.TP扫码测试.ResumeLayout(false);
            this.TP扫码测试.PerformLayout();
            this.MS_Camera.ResumeLayout(false);
            this.MS_Camera.PerformLayout();
            this.TP模板匹配.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TC_Main;
        private System.Windows.Forms.TabPage TP首页;
        private System.Windows.Forms.TabPage TP轴测试;
        private System.Windows.Forms.GroupBox GB轴控制;
        private System.Windows.Forms.Button BTN相对位置移动;
        private System.Windows.Forms.Button BTN绝对位置移动;
        private System.Windows.Forms.Label LB目标位置;
        private System.Windows.Forms.TextBox TB目标位置;
        private System.Windows.Forms.Button BTN原点;
        private System.Windows.Forms.Button BTN负向运动;
        private System.Windows.Forms.Button BTN停止;
        private System.Windows.Forms.Button BTN正向运动;
        private System.Windows.Forms.GroupBox GB轴信息;
        private System.Windows.Forms.Label LB轴状态;
        private System.Windows.Forms.Label LB轴位置;
        private System.Windows.Forms.Label LB轴速度;
        private System.Windows.Forms.GroupBox GB轴设置;
        private System.Windows.Forms.Button BTN测试;
        private System.Windows.Forms.Button BTN位置清零;
        private System.Windows.Forms.ComboBox CB控制卡;
        private System.Windows.Forms.ComboBox CB轴;
        private System.Windows.Forms.Button BTN轴设置;
        private System.Windows.Forms.Button BTN测试窗口;
        private System.Windows.Forms.Button BTN连接;
        private System.Windows.Forms.Button BTN断开;
        private System.Windows.Forms.Label LB轴选择;
        private System.Windows.Forms.Label LB轴卡选择;
        private System.Windows.Forms.GroupBox GB信号;
        private System.Windows.Forms.Label LB输入信号;
        private System.Windows.Forms.GroupBox GB特殊信号控制;
        private System.Windows.Forms.Button BTN编辑信息;
        private System.Windows.Forms.Panel PN信号控制;
        private System.Windows.Forms.Panel PN轴信息;
        private System.Windows.Forms.Panel PN信号;
        private System.Windows.Forms.TabPage TP数据;
        private System.Windows.Forms.TabPage TP扫码测试;
        private System.Windows.Forms.MenuStrip MS_Camera;
        private System.Windows.Forms.ToolStripMenuItem TSM文件;
        private System.Windows.Forms.ToolStripMenuItem TSM打开二维码;
        private System.Windows.Forms.ToolStripMenuItem TSM存为二维码;
        private System.Windows.Forms.ToolStripMenuItem TSM存为条形码;
        private System.Windows.Forms.ToolStripMenuItem TSM相机;
        private System.Windows.Forms.ToolStripMenuItem TSM开始录制;
        private System.Windows.Forms.ToolStripMenuItem TSM停止录制;
        private System.Windows.Forms.ToolStripMenuItem TSM开始扫码;
        private System.Windows.Forms.ToolStripMenuItem TSM停止扫码;
        private System.Windows.Forms.ToolStripMenuItem TSM拍摄;
        private System.Windows.Forms.Label LB码值;
        private System.Windows.Forms.OpenFileDialog OFD识别图片码;
        private System.Windows.Forms.TextBox TB_Code;
        private System.Windows.Forms.ToolStripMenuItem TSM设置;
        private System.Windows.Forms.TabPage TP模板匹配;
        private System.Windows.Forms.Button BTN模板匹配测试;
    }
}

