namespace MapEditor.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCutMap : Form
    {
        public int BottomRightX;
        public int BottomRightY;
        private Button btnBuildMap;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbBRX;
        private TextBox tbBRY;
        private TextBox tbTLX;
        private TextBox tbTLY;
        public int TopLeftX;
        public int TopLeftY;

        public frmCutMap()
        {
            this.InitializeComponent();
        }

        private void btnBuildMap_Click(object sender, EventArgs e)
        {
            try
            {
                this.TopLeftX = int.Parse(this.tbTLX.Text);
                this.TopLeftY = int.Parse(this.tbTLY.Text);
                this.BottomRightX = int.Parse(this.tbBRX.Text);
                this.BottomRightY = int.Parse(this.tbBRY.Text);
                base.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("请输入地图大小之内的自然数", "请注意");
            }
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
            this.label1 = new Label();
            this.tbTLX = new TextBox();
            this.tbTLY = new TextBox();
            this.label2 = new Label();
            this.tbBRX = new TextBox();
            this.label3 = new Label();
            this.tbBRY = new TextBox();
            this.label4 = new Label();
            this.btnBuildMap = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "左上坐标X";
            this.tbTLX.Location = new Point(0x51, 12);
            this.tbTLX.Name = "tbTLX";
            this.tbTLX.Size = new Size(100, 0x15);
            this.tbTLX.TabIndex = 1;
            this.tbTLY.Location = new Point(0x51, 0x27);
            this.tbTLY.Name = "tbTLY";
            this.tbTLY.Size = new Size(100, 0x15);
            this.tbTLY.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x10, 0x2a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "左上坐标Y";
            this.tbBRX.Location = new Point(0x51, 0x42);
            this.tbBRX.Name = "tbBRX";
            this.tbBRX.Size = new Size(100, 0x15);
            this.tbBRX.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x10, 0x45);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3b, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "右下坐标X";
            this.tbBRY.Location = new Point(0x51, 0x5d);
            this.tbBRY.Name = "tbBRY";
            this.tbBRY.Size = new Size(100, 0x15);
            this.tbBRY.TabIndex = 7;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x10, 0x60);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3b, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "右下坐标Y";
            this.btnBuildMap.Location = new Point(0x51, 0x7b);
            this.btnBuildMap.Name = "btnBuildMap";
            this.btnBuildMap.Size = new Size(100, 0x17);
            this.btnBuildMap.TabIndex = 8;
            this.btnBuildMap.Text = "生成地图";
            this.btnBuildMap.UseVisualStyleBackColor = true;
            this.btnBuildMap.Click += new EventHandler(this.btnBuildMap_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xd1, 0x9e);
            base.Controls.Add(this.btnBuildMap);
            base.Controls.Add(this.tbBRY);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.tbBRX);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.tbTLY);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.tbTLX);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmCutMap";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "裁剪某块地图";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

