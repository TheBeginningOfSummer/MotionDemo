namespace MotionDemo.Forms
{
    partial class ControllerSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB控制器名称 = new System.Windows.Forms.Label();
            this.TB轴名称 = new System.Windows.Forms.TextBox();
            this.LB轴名称 = new System.Windows.Forms.Label();
            this.CB控制器 = new System.Windows.Forms.ComboBox();
            this.LB信息 = new System.Windows.Forms.Label();
            this.CB类型 = new System.Windows.Forms.ComboBox();
            this.LB类型 = new System.Windows.Forms.Label();
            this.BTN修改 = new System.Windows.Forms.Button();
            this.GB信息修改 = new System.Windows.Forms.GroupBox();
            this.BTN删除 = new System.Windows.Forms.Button();
            this.TBIP = new System.Windows.Forms.TextBox();
            this.LBIP = new System.Windows.Forms.Label();
            this.GB信息修改.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB控制器名称
            // 
            this.LB控制器名称.AutoSize = true;
            this.LB控制器名称.Location = new System.Drawing.Point(47, 32);
            this.LB控制器名称.Name = "LB控制器名称";
            this.LB控制器名称.Size = new System.Drawing.Size(65, 12);
            this.LB控制器名称.TabIndex = 0;
            this.LB控制器名称.Text = "控制器名称";
            // 
            // TB轴名称
            // 
            this.TB轴名称.Location = new System.Drawing.Point(118, 108);
            this.TB轴名称.Name = "TB轴名称";
            this.TB轴名称.Size = new System.Drawing.Size(100, 21);
            this.TB轴名称.TabIndex = 2;
            // 
            // LB轴名称
            // 
            this.LB轴名称.AutoSize = true;
            this.LB轴名称.Location = new System.Drawing.Point(47, 111);
            this.LB轴名称.Name = "LB轴名称";
            this.LB轴名称.Size = new System.Drawing.Size(41, 12);
            this.LB轴名称.TabIndex = 3;
            this.LB轴名称.Text = "轴名称";
            // 
            // CB控制器
            // 
            this.CB控制器.FormattingEnabled = true;
            this.CB控制器.Location = new System.Drawing.Point(118, 29);
            this.CB控制器.Name = "CB控制器";
            this.CB控制器.Size = new System.Drawing.Size(100, 20);
            this.CB控制器.TabIndex = 4;
            this.CB控制器.SelectedIndexChanged += new System.EventHandler(this.CB控制器_SelectedIndexChanged);
            // 
            // LB信息
            // 
            this.LB信息.AutoSize = true;
            this.LB信息.Location = new System.Drawing.Point(434, 103);
            this.LB信息.Name = "LB信息";
            this.LB信息.Size = new System.Drawing.Size(29, 12);
            this.LB信息.TabIndex = 5;
            this.LB信息.Text = "信息";
            // 
            // CB类型
            // 
            this.CB类型.FormattingEnabled = true;
            this.CB类型.Items.AddRange(new object[] {
            "Zmotion",
            "Trio"});
            this.CB类型.Location = new System.Drawing.Point(118, 146);
            this.CB类型.Name = "CB类型";
            this.CB类型.Size = new System.Drawing.Size(100, 20);
            this.CB类型.TabIndex = 6;
            // 
            // LB类型
            // 
            this.LB类型.AutoSize = true;
            this.LB类型.Location = new System.Drawing.Point(47, 149);
            this.LB类型.Name = "LB类型";
            this.LB类型.Size = new System.Drawing.Size(29, 12);
            this.LB类型.TabIndex = 7;
            this.LB类型.Text = "类型";
            // 
            // BTN修改
            // 
            this.BTN修改.Location = new System.Drawing.Point(37, 184);
            this.BTN修改.Name = "BTN修改";
            this.BTN修改.Size = new System.Drawing.Size(75, 23);
            this.BTN修改.TabIndex = 8;
            this.BTN修改.Text = "修改";
            this.BTN修改.UseVisualStyleBackColor = true;
            this.BTN修改.Click += new System.EventHandler(this.BTN修改_Click);
            // 
            // GB信息修改
            // 
            this.GB信息修改.Controls.Add(this.LBIP);
            this.GB信息修改.Controls.Add(this.TBIP);
            this.GB信息修改.Controls.Add(this.BTN删除);
            this.GB信息修改.Controls.Add(this.LB控制器名称);
            this.GB信息修改.Controls.Add(this.BTN修改);
            this.GB信息修改.Controls.Add(this.TB轴名称);
            this.GB信息修改.Controls.Add(this.LB类型);
            this.GB信息修改.Controls.Add(this.LB轴名称);
            this.GB信息修改.Controls.Add(this.CB类型);
            this.GB信息修改.Controls.Add(this.CB控制器);
            this.GB信息修改.Location = new System.Drawing.Point(87, 103);
            this.GB信息修改.Name = "GB信息修改";
            this.GB信息修改.Size = new System.Drawing.Size(278, 235);
            this.GB信息修改.TabIndex = 9;
            this.GB信息修改.TabStop = false;
            this.GB信息修改.Text = "信息修改";
            // 
            // BTN删除
            // 
            this.BTN删除.Location = new System.Drawing.Point(143, 184);
            this.BTN删除.Name = "BTN删除";
            this.BTN删除.Size = new System.Drawing.Size(75, 23);
            this.BTN删除.TabIndex = 10;
            this.BTN删除.Text = "删除";
            this.BTN删除.UseVisualStyleBackColor = true;
            this.BTN删除.Click += new System.EventHandler(this.BTN删除_Click);
            // 
            // TBIP
            // 
            this.TBIP.Location = new System.Drawing.Point(118, 65);
            this.TBIP.Name = "TBIP";
            this.TBIP.Size = new System.Drawing.Size(100, 21);
            this.TBIP.TabIndex = 10;
            // 
            // LBIP
            // 
            this.LBIP.AutoSize = true;
            this.LBIP.Location = new System.Drawing.Point(47, 68);
            this.LBIP.Name = "LBIP";
            this.LBIP.Size = new System.Drawing.Size(41, 12);
            this.LBIP.TabIndex = 10;
            this.LBIP.Text = "IP地址";
            // 
            // ControllerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GB信息修改);
            this.Controls.Add(this.LB信息);
            this.Name = "ControllerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制器信息";
            this.GB信息修改.ResumeLayout(false);
            this.GB信息修改.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB控制器名称;
        private System.Windows.Forms.TextBox TB轴名称;
        private System.Windows.Forms.Label LB轴名称;
        private System.Windows.Forms.ComboBox CB控制器;
        private System.Windows.Forms.Label LB信息;
        private System.Windows.Forms.ComboBox CB类型;
        private System.Windows.Forms.Label LB类型;
        private System.Windows.Forms.Button BTN修改;
        private System.Windows.Forms.GroupBox GB信息修改;
        private System.Windows.Forms.Button BTN删除;
        private System.Windows.Forms.TextBox TBIP;
        private System.Windows.Forms.Label LBIP;
    }
}