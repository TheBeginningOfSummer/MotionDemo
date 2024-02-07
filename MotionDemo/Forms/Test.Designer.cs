namespace MotionDemo.Forms
{
    partial class Test
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
            this.BTN清除 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN清除
            // 
            this.BTN清除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN清除.Location = new System.Drawing.Point(795, 482);
            this.BTN清除.Name = "BTN清除";
            this.BTN清除.Size = new System.Drawing.Size(75, 23);
            this.BTN清除.TabIndex = 0;
            this.BTN清除.Text = "清除";
            this.BTN清除.UseVisualStyleBackColor = true;
            this.BTN清除.Click += new System.EventHandler(this.BTN清除_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 517);
            this.Controls.Add(this.BTN清除);
            this.Name = "Test";
            this.Text = "Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Test_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN清除;
    }
}