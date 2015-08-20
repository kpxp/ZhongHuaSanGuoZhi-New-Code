namespace MapEditor.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class HintForm : Form
    {
        private IContainer components = null;
        private Label lblHint;

        public HintForm()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHint = new Label();
            base.SuspendLayout();
            this.lblHint.Font = new Font("SimSun", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lblHint.Location = new Point(0x1a, 14);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new Size(0x1a0, 30);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "进行中";
            this.lblHint.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1d1, 60);
            base.Controls.Add(this.lblHint);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "HintForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HintForm";
            base.TopMost = true;
            base.ResumeLayout(false);
        }

        public void SetHint(string hint)
        {
            this.lblHint.Text = hint;
        }
    }
}

