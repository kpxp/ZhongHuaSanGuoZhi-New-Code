namespace WorldOfTheThreeKingdoms
{
    partial class jiazaitishichuangkou
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.jiazaijindu = new System.Windows.Forms.ProgressBar();
            this.tishi1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jiazaijindu
            // 
            this.jiazaijindu.Location = new System.Drawing.Point(58, 26);
            this.jiazaijindu.Name = "jiazaijindu";
            this.jiazaijindu.Size = new System.Drawing.Size(177, 18);
            this.jiazaijindu.TabIndex = 0;
            // 
            // tishi1
            // 
            this.tishi1.Location = new System.Drawing.Point(-3, 47);
            this.tishi1.Name = "tishi1";
            this.tishi1.Size = new System.Drawing.Size(298, 38);
            this.tishi1.TabIndex = 1;
            this.tishi1.Text = new TiShiText().getRandomText();
            this.tishi1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jiazaitishichuangkou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 82);
            this.ControlBox = false;
            this.Controls.Add(this.tishi1);
            this.Controls.Add(this.jiazaijindu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "jiazaitishichuangkou";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加载中，请稍候……";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar jiazaijindu;
        internal System.Windows.Forms.Label tishi1;


    }
}