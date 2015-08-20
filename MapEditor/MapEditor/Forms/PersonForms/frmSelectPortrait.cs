namespace MapEditor.Forms.PersonForms
{
    using GameObjects;
    using MapEditor;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectPortrait : Form
    {
        private IContainer components = null;
        private bool loaded = false;
        private ListView lvPortraits;
        public formMapEditor MainForm;
        public bool OnlySelectFromNew = false;
        public Person person;

        public frmSelectPortrait()
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

        private void frmSelectPortrait_Load(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = this.OnlySelectFromNew ? 0x7d1 : 1;
            for (int i = num2; i < 32767; i++)
            {
                if (this.MainForm.GetPersonPortrait(i) != null)
                {
                    this.lvPortraits.Items.Add(i.ToString(), i);
                    num++;
                }
            }
            this.loaded = true;
        }

        private void InitializeComponent()
        {
            this.lvPortraits = new ListView();
            base.SuspendLayout();
            this.lvPortraits.Dock = DockStyle.Fill;
            this.lvPortraits.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lvPortraits.Location = new Point(0, 0);
            this.lvPortraits.MultiSelect = false;
            this.lvPortraits.Name = "lvPortraits";
            this.lvPortraits.OwnerDraw = true;
            this.lvPortraits.Size = new Size(0x2e6, 0x247);
            this.lvPortraits.TabIndex = 0;
            this.lvPortraits.TileSize = new Size(120, 120);
            this.lvPortraits.UseCompatibleStateImageBehavior = false;
            this.lvPortraits.View = View.Tile;
            this.lvPortraits.DrawItem += new DrawListViewItemEventHandler(this.lvPortraits_DrawItem);
            this.lvPortraits.DoubleClick += new EventHandler(this.lvPortraits_DoubleClick);
            this.lvPortraits.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.lvPortraits_ItemSelectionChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2e6, 0x247);
            base.Controls.Add(this.lvPortraits);
            base.Name = "frmSelectPortrait";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "更换头像(双击选择)";
            base.Load += new EventHandler(this.frmSelectPortrait_Load);
            base.ResumeLayout(false);
        }

        private void lvPortraits_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvPortraits.SelectedItems.Count == 1)
            {
                this.person.PictureIndex = this.lvPortraits.SelectedItems[0].ImageIndex;
                base.DialogResult = DialogResult.OK;
            }
        }

        private void lvPortraits_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (this.loaded)
            {
                e.Graphics.DrawImage(this.MainForm.GetPersonPortrait(e.Item.ImageIndex), e.Bounds);
            }
        }

        private void lvPortraits_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }
    }
}

