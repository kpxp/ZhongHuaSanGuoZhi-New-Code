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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbSaveFiles = new System.Windows.Forms.ListBox();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除存档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所有存档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(544, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(463, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbSaveFiles
            // 
            this.lbSaveFiles.ContextMenuStrip = this.cmsDelete;
            this.lbSaveFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbSaveFiles.Font = new System.Drawing.Font("宋体", 9F);
            this.lbSaveFiles.FormattingEnabled = true;
            this.lbSaveFiles.ItemHeight = 16;
            this.lbSaveFiles.Location = new System.Drawing.Point(12, 12);
            this.lbSaveFiles.Name = "lbSaveFiles";
            this.lbSaveFiles.Size = new System.Drawing.Size(606, 364);
            this.lbSaveFiles.TabIndex = 6;
            this.lbSaveFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSaveFiles_MouseDoubleClick);
            this.lbSaveFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbSaveFiles_DrawItem);
            this.lbSaveFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectSaveFile_MouseClick);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除存档ToolStripMenuItem,
            this.删除所有存档ToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(147, 48);
            // 
            // 删除存档ToolStripMenuItem
            // 
            this.删除存档ToolStripMenuItem.Name = "删除存档ToolStripMenuItem";
            this.删除存档ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除存档ToolStripMenuItem.Text = "删除存档";
            this.删除存档ToolStripMenuItem.Click += new System.EventHandler(this.删除存档ToolStripMenuItem_Click);
            // 
            // 删除所有存档ToolStripMenuItem
            // 
            this.删除所有存档ToolStripMenuItem.Name = "删除所有存档ToolStripMenuItem";
            this.删除所有存档ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除所有存档ToolStripMenuItem.Text = "删除所有存档";
            this.删除所有存档ToolStripMenuItem.Click += new System.EventHandler(this.删除所有存档ToolStripMenuItem_Click);
            // 
            // formSelectSaveFile
            // 
            this.ClientSize = new System.Drawing.Size(630, 425);
            this.Controls.Add(this.lbSaveFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSelectSaveFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择存档";
            this.Load += new System.EventHandler(this.frmSelectSaveFile_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectSaveFile_MouseClick);
            this.cmsDelete.ResumeLayout(false);
            this.ResumeLayout(false);

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
            this.ReadSaveFile("QuitSave.mdb");

            this.ReadSaveFile("Save01.zhs");
            this.ReadSaveFile("Save02.zhs");
            this.ReadSaveFile("Save03.zhs");
            this.ReadSaveFile("Save04.zhs");
            this.ReadSaveFile("Save05.zhs");
            this.ReadSaveFile("Save06.zhs");
            this.ReadSaveFile("Save07.zhs");
            this.ReadSaveFile("Save08.zhs");
            this.ReadSaveFile("Save09.zhs");
            this.ReadSaveFile("Save10.zhs");
            this.ReadSaveFile("AutoSave.zhs");
            this.ReadSaveFile("QuitSave.zhs");
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

        private void lbSaveFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            // 临时修复，e.Index返回-1的具体原因不明
            if (e.Index != -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                StringFormat strFmt = new System.Drawing.StringFormat();
                strFmt.Alignment = StringAlignment.Near ; //文本垂直居中
                strFmt.LineAlignment = StringAlignment.Center ; //文本水平居中
                e.Graphics.DrawString(lbSaveFiles.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
            }
        }
    }

 

}
