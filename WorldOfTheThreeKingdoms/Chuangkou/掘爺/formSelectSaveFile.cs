using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameObjects;

using		System.Data;
using		System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Data.OleDb;




namespace WorldOfTheThreeKingdoms.GameForms

{
    public class formSelectSaveFile : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private ContextMenuStrip cmsDelete;
        private IContainer components = null;
        private ListBox lbSaveFiles;
        public string SaveFilePath;
        private List<string> SaveFilePaths = new List<string>();
        private ToolStripMenuItem 删除存档ToolStripMenuItem;
        private ToolStripMenuItem 删除所有存档ToolStripMenuItem;

        public formSelectSaveFile()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                this.SaveFilePath = this.SaveFilePaths[this.lbSaveFiles.SelectedIndex];
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择存档。");
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

        private void formSelectSaveFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void frmSelectSaveFile_Load(object sender, EventArgs e)
        {
            this.RefreshSaveFiles();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.lbSaveFiles = new ListBox();
            this.cmsDelete = new ContextMenuStrip(this.components);
            this.删除存档ToolStripMenuItem = new ToolStripMenuItem();
            this.删除所有存档ToolStripMenuItem = new ToolStripMenuItem();
            this.cmsDelete.SuspendLayout();
            base.SuspendLayout();
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x220, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.Location = new Point(0x1cf, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.lbSaveFiles.ContextMenuStrip = this.cmsDelete;
            this.lbSaveFiles.FormattingEnabled = true;
            this.lbSaveFiles.ItemHeight = 12;
            this.lbSaveFiles.Location = new Point(12, 12);
            this.lbSaveFiles.Name = "lbSaveFiles";
            this.lbSaveFiles.Size = new Size(0x25e, 0x16c);
            this.lbSaveFiles.TabIndex = 6;
            this.lbSaveFiles.MouseDoubleClick += new MouseEventHandler(this.lbSaveFiles_MouseDoubleClick);
            this.lbSaveFiles.MouseClick += new MouseEventHandler(this.formSelectSaveFile_MouseClick);
            this.cmsDelete.Items.AddRange(new ToolStripItem[] { this.删除存档ToolStripMenuItem, this.删除所有存档ToolStripMenuItem });
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new Size(0x99, 70);
            this.删除存档ToolStripMenuItem.Name = "删除存档ToolStripMenuItem";
            this.删除存档ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.删除存档ToolStripMenuItem.Text = "删除存档";
            this.删除存档ToolStripMenuItem.Click += new EventHandler(this.删除存档ToolStripMenuItem_Click);
            this.删除所有存档ToolStripMenuItem.Name = "删除所有存档ToolStripMenuItem";
            this.删除所有存档ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.删除所有存档ToolStripMenuItem.Text = "删除所有存档";
            this.删除所有存档ToolStripMenuItem.Click += new EventHandler(this.删除所有存档ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(630, 0x1a9);
            base.Controls.Add(this.lbSaveFiles);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "formSelectSaveFile";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择存档";
            base.Load += new EventHandler(this.frmSelectSaveFile_Load);
            base.MouseClick += new MouseEventHandler(this.formSelectSaveFile_MouseClick);
            this.cmsDelete.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void lbSaveFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                this.SaveFilePath = this.SaveFilePaths[this.lbSaveFiles.SelectedIndex];
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择存档。");
            }
        }

        private void ReadSaveFile(string fileName)
        {
            string str = "GameData/Save/";
            if (File.Exists(str + fileName))
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = str + fileName,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                this.lbSaveFiles.Items.Add(fileName+"  "+GameScenario.GetGameSaveFileSurveyText(builder.ConnectionString));
                this.SaveFilePaths.Add(fileName);
            }
        }

        private void RefreshSaveFiles()
        {
            this.SaveFilePaths.Clear();
            this.lbSaveFiles.Items.Clear();
            this.ReadSaveFile("Save01.mdb");
            this.ReadSaveFile("Save02.mdb");
            this.ReadSaveFile("Save03.mdb");
            this.ReadSaveFile("Save04.mdb");
            this.ReadSaveFile("Save05.mdb");
            this.ReadSaveFile("Save06.mdb");
            this.ReadSaveFile("Save07.mdb");
            this.ReadSaveFile("Save08.mdb");
            this.ReadSaveFile("Save09.mdb");
            this.ReadSaveFile("Save10.mdb");
            this.ReadSaveFile("AutoSave.mdb");
        }

        private void 删除存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                File.Delete("GameData/Save/" + this.SaveFilePaths[this.lbSaveFiles.SelectedIndex]);
                this.RefreshSaveFiles();
            }
        }

        private void 删除所有存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.lbSaveFiles.Items.Count != 0) && (MessageBox.Show("删除所有存档？", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                foreach (string str in this.SaveFilePaths)
                {
                    File.Delete("GameData/Save/" + str);
                }
                this.RefreshSaveFiles();
            }
        }
    }

 

}
