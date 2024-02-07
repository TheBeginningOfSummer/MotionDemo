namespace MotionDemo.Forms
{
    partial class ParameterSet
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
        public void InitializeComponent()
        {
            this.BTN保存 = new System.Windows.Forms.Button();
            this.BTN应用 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN保存
            // 
            this.BTN保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN保存.Location = new System.Drawing.Point(713, 415);
            this.BTN保存.Name = "BTN保存";
            this.BTN保存.Size = new System.Drawing.Size(75, 23);
            this.BTN保存.TabIndex = 0;
            this.BTN保存.Text = "保存";
            this.BTN保存.UseVisualStyleBackColor = true;
            this.BTN保存.Click += new System.EventHandler(this.BTN保存_Click);
            // 
            // BTN应用
            // 
            this.BTN应用.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN应用.Location = new System.Drawing.Point(632, 415);
            this.BTN应用.Name = "BTN应用";
            this.BTN应用.Size = new System.Drawing.Size(75, 23);
            this.BTN应用.TabIndex = 1;
            this.BTN应用.Text = "应用";
            this.BTN应用.UseVisualStyleBackColor = true;
            this.BTN应用.Click += new System.EventHandler(this.BTN应用_Click);
            // 
            // ParameterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN应用);
            this.Controls.Add(this.BTN保存);
            this.Name = "ParameterSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParameterSet";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BTN保存;
        public System.Windows.Forms.Button BTN应用;
    }
}