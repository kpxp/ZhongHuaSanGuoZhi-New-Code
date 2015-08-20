namespace MapEditor
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using MapEditor.Forms;
    using MapEditor.Forms.ArchitectureForms;
    using Microsoft.Xna.Framework;
    using PluginInterface;
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class formMapEditor : Form
    {
        private int ArchitectureIndex = 1;
        private Button btnArchitectureBarrack;
        private Button btnArchitectureBlock;
        private Button btnArchitectureCity;
        private Button btnArchitecturePort;
        private Button btnBuildMap;
        private Button btnCliff;
        private Button btnCutMap;
        private Button btnDeleteArchitecture;
        private Button btnDesert;
        private Button btnEnlargeArchitecture;
        private Button btnForest;
        private Button btnGrassland;
        private Button btnLandLinks;
        private Button btnMarsh;
        private Button btnMountain;
        private Button btnPlain;
        private Button btnRidge;
        private Button btnRiver;
        private Button btnWasteland;
        private Button btnWaterLinks;
        private bool CanSave = false;
        private CheckBox cbDeleteWholeArchitecture;
        private CheckBox cbHorizontal;
        private ToolStripMenuItem cmenuArchitectureProperty;
        private ContextMenuStrip cmsEdit;
        private string CommonDataFileName;
        private IContainer components = null;
        private OleDbConnectionStringBuilder connectionStringBuilder;
        private Architecture CurrentArchitecture;
        private EditKind CurrentKind;
        private bool EditArchitecture = false;
        private GroupBox groupBrushes;
        private ImageList imageListArchitecture;
        private ImageList imageListTerrain;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private int LastShowX;
        private int LastShowY;
        private Label lbConment;
        private Label lbCoord;
        private bool LeftMouseButtonDown = false;
        private MenuStrip mainMenu;
        private ToolStripMenuItem menuAbout;
        private ToolStripMenuItem menuArchitectureAll;
        private ToolStripMenuItem menuArchitectureBarrack;
        private ToolStripMenuItem menuArchitectureBlock;
        private ToolStripMenuItem menuArchitectureCity;
        private ToolStripMenuItem menuArchitecturePort;
        private ToolStripMenuItem menuDisplayArchitecture;
        private ToolStripMenuItem menuDisplayGrid;
        private ToolStripMenuItem menuDisplayGridLine;
        private ToolStripMenuItem menuDisplayTerrain;
        private ToolStripMenuItem menuEdit;
        private ToolStripMenuItem menuEditArchitecture;
        private ToolStripMenuItem menuEditFactions;
        private ToolStripMenuItem menuEditMilitary;
        private ToolStripMenuItem menuEditPersons;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuGenerateMapJpg;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuOpenScenario;
        private ToolStripMenuItem menuRegenArchitectureID;
        private ToolStripMenuItem menuReplaceTerrain;
        private ToolStripMenuItem menuSaveScenario;
        private ToolStripMenuItem menuShowErrors;
        private ToolStripMenuItem menuScenarioInformation;
        private ToolStripMenuItem menuTerrainAll;
        private ToolStripMenuItem menuTerrainDesert;
        private ToolStripMenuItem menuTerrainForest;
        private ToolStripMenuItem menuTerrainGrassland;
        private ToolStripMenuItem menuTerrainMarsh;
        private ToolStripMenuItem menuTerrainMountain;
        private ToolStripMenuItem menuTerrainNone;
        private ToolStripMenuItem menuTerrainPlain;
        private ToolStripMenuItem menuTerrainRidge;
        private ToolStripMenuItem menuTerrainRiver;
        private ToolStripMenuItem menuTerrainWasteland;
        private bool MoveTo = false;
        private MaskedTextBox mtbHeight;
        private MaskedTextBox mtbPenWidth;
        private MaskedTextBox mtbTileWidth;
        private MaskedTextBox mtbWidth;
        private int oldhorizontalscrollvalue = 0;
        private int oldverticalscrollvalue = 0;
        private string OpenedFileName;
        private OpenFileDialog openScenario;
        private Panel panel1;
        private Panel panelMap;
        private Assembly PersonPortraitDll = Assembly.LoadFrom("GameComponents/PersonPortrait/PersonPortraitPlugin.dll");
        private IPersonPortrait PersonPortraitPlugin;
        private Panel pnlBase;
        private MapPanel pnlMap;
        private Architecture TargetArchitecture;
        private TabControl tcEdit;
        private int TerrainIndex = 1;
        private TabPage tpArchitecture;
        private TabPage tpMap;
        private ToolStripMenuItem 编辑宝物ToolStripMenuItem;
        private ToolStripMenuItem 编辑部队ToolStripMenuItem;
        private ToolStripMenuItem 编辑部队事件ToolStripMenuItem;
        private ToolStripMenuItem 编辑地区ToolStripMenuItem;
        private ToolStripMenuItem 编辑州域ToolStripMenuItem;
        private ToolStripMenuItem 初始化剧本只保留人物列表ToolStripMenuItem;
        private ToolStripMenuItem 删除所有建筑ToolStripMenuItem;
        private ToolStripMenuItem 设置建筑地形ToolStripMenuItem;
        private ToolStripMenuItem 新编剧本ToolStripMenuItem;

        public formMapEditor()
        {
            this.InitializeComponent();
            System.Type type = this.PersonPortraitDll.GetType("PersonPortraitPlugin.PersonPortraitPlugin");
            this.PersonPortraitPlugin = Activator.CreateInstance(type) as IPersonPortrait;
            this.PersonPortraitPlugin.Initialize();
            this.pnlMap.TerrainImageList = this.imageListTerrain;
            this.pnlMap.ArchitectureImageList = this.imageListArchitecture;
            this.connectionStringBuilder = new OleDbConnectionStringBuilder();
            this.connectionStringBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            this.CommonDataFileName = Application.StartupPath + "/GameData/Common/CommonData.mdb";
            this.connectionStringBuilder.DataSource = this.CommonDataFileName;
            new GlobalVariables().InitialGlobalVariables();
            this.Scenario.GameCommonData.LoadFromDatabase(this.connectionStringBuilder.ConnectionString, this.Scenario);
            this.pnlMap.DisplayNone = this.menuTerrainNone.Checked;
            this.pnlMap.DisplayPlain = this.menuTerrainPlain.Checked;
            this.pnlMap.DisplayGrassland = this.menuTerrainGrassland.Checked;
            this.pnlMap.DisplayForest = this.menuTerrainForest.Checked;
            this.pnlMap.DisplayMarsh = this.menuTerrainMarsh.Checked;
            this.pnlMap.DisplayMountain = this.menuTerrainMountain.Checked;
            this.pnlMap.DisplayRiver = this.menuTerrainRiver.Checked;
            this.pnlMap.DisplayRidge = this.menuTerrainRidge.Checked;
            this.pnlMap.DisplayWasteland = this.menuTerrainWasteland.Checked;
            this.pnlMap.DisplayDesert = this.menuTerrainDesert.Checked;
            this.pnlMap.DisplayCity = this.menuArchitectureCity.Checked;
            this.pnlMap.DisplayBlock = this.menuArchitectureBlock.Checked;
            this.pnlMap.DisplayPort = this.menuArchitecturePort.Checked;
            this.pnlMap.DisplayBarrack = this.menuArchitectureBarrack.Checked;
            this.pnlMap.DisplayGrid = this.menuDisplayGridLine.Checked;
        }

        private void btnArchitectureBarrack_Click(object sender, EventArgs e)
        {
            this.ArchitectureIndex = 4;
            this.CurrentKind = EditKind.新增;
        }

        private void btnArchitectureBlock_Click(object sender, EventArgs e)
        {
            this.ArchitectureIndex = 2;
            this.CurrentKind = EditKind.新增;
        }

        private void btnArchitectureCity_Click(object sender, EventArgs e)
        {
            this.ArchitectureIndex = 1;
            this.CurrentKind = EditKind.新增;
        }

        private void btnArchitecturePort_Click(object sender, EventArgs e)
        {
            this.ArchitectureIndex = 3;
            this.CurrentKind = EditKind.新增;
        }

        private void btnBuildMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("重新生成地图。（所有地图数据将被初始化）", "请确认", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
            {
                int x = int.Parse(this.mtbWidth.Text);
                int y = int.Parse(this.mtbHeight.Text);
                this.pnlMap.Scenario.ScenarioMap.Clear();
                this.pnlMap.TileWidth = 20;
                this.mtbTileWidth.Text = "20";
                this.pnlMap.Scenario.ScenarioMap.MapDimensions = new Microsoft.Xna.Framework.Point(x, y);
                this.pnlMap.ResetMapDataValueString(1);
                this.pnlMap.ResetMapPanelSize(1);
                this.pnlMap.StartPaintingMap = true;
                this.pnlMap.Invalidate();
            }
        }

        private void btnCliff_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 10;
        }

        private void btnCutMap_Click(object sender, EventArgs e)
        {
            frmCutMap map = new frmCutMap();
            if (map.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int x = (map.BottomRightX - map.TopLeftX) + 1;
                int y = (map.BottomRightY - map.TopLeftY) + 1;
                int[,] numArray = new int[x, y];
                for (int i = map.TopLeftX; i <= map.BottomRightX; i++)
                {
                    for (int j = map.TopLeftY; j <= map.BottomRightY; j++)
                    {
                        numArray[i - map.TopLeftX, j - map.TopLeftY] = this.pnlMap.Scenario.ScenarioMap.MapData[i, j];
                    }
                }
                this.pnlMap.Scenario.ScenarioMap.Clear();
                this.pnlMap.Scenario.ScenarioMap.MapData = numArray;
                foreach (Architecture architecture in this.Scenario.Architectures.GetList())
                {
                    bool flag = false;
                    foreach (Microsoft.Xna.Framework.Point point in architecture.ArchitectureArea.Area)
                    {
                        if ((((point.X < map.TopLeftX) || (point.X > map.BottomRightX)) || (point.Y < map.TopLeftY)) || (point.Y > map.BottomRightY))
                        {
                            this.Scenario.Architectures.Remove(architecture);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        architecture.ArchitectureArea.MoveArea(-map.TopLeftX, -map.TopLeftY);
                    }
                }
                this.pnlMap.TileWidth = 40;
                this.mtbTileWidth.Text = "40";
                this.pnlMap.Scenario.ScenarioMap.MapDimensions = new Microsoft.Xna.Framework.Point(x, y);
                this.pnlMap.LoadMapData();
                this.pnlMap.ResetMapPanelSize(1);
                this.pnlMap.StartPaintingMap = true;
                this.pnlMap.Invalidate();
            }
        }

        private void btnDeleteArchitecture_Click(object sender, EventArgs e)
        {
            this.CurrentKind = EditKind.删除;
            this.TargetArchitecture = null;
        }

        private void btnDesert_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 9;
        }

        private void btnEnlargeArchitecture_Click(object sender, EventArgs e)
        {
            this.CurrentKind = EditKind.増筑;
            this.TargetArchitecture = null;
            this.lbConment.Text = "请先点击一个建筑物，然后再点击需要増筑的相邻坐标。";
        }

        private void btnForest_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 3;
        }

        private void btnGrassland_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 2;
        }

        private void btnLandLinks_Click(object sender, EventArgs e)
        {
            this.CurrentKind = EditKind.陆上;
            this.TargetArchitecture = null;
            this.lbConment.Text = "请先点击一个建筑物，然后再点击需要添加陆上链接的建筑。";
        }

        private void btnMarsh_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 4;
        }

        private void btnMountain_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 5;
        }

        private void btnPlain_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 1;
        }

        private void btnRidge_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 7;
        }

        private void btnRiver_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 6;
        }

        private void btnWasteland_Click(object sender, EventArgs e)
        {
            this.TerrainIndex = 8;
        }

        private void btnWaterLinks_Click(object sender, EventArgs e)
        {
            this.CurrentKind = EditKind.水上;
            this.TargetArchitecture = null;
            this.lbConment.Text = "请先点击一个建筑物，然后再点击需要添加水上链接的建筑。";
        }

        private void cbDeleteWholeArchitecture_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(this.cbDeleteWholeArchitecture, "是否删除整个建筑。");
        }

        private void cmenuArchitectureProperty_Click(object sender, EventArgs e)
        {
            if (this.CurrentArchitecture != null)
            {
                frmEditArchitecture architecture = new frmEditArchitecture();
                architecture.MainForm = this;
                architecture.editingArchitecture = this.CurrentArchitecture;
                if (architecture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.pnlMap.Invalidate();
                }
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

        public Image GetPersonPortrait(int id)
        {
            if (this.PersonPortraitPlugin != null)
            {
                if (this.PersonPortraitPlugin.HasPortrait(id))
                {
                    return this.PersonPortraitPlugin.GetImage(id);
                }
            }
            return null;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(formMapEditor));
            this.openScenario = new OpenFileDialog();
            this.imageListTerrain = new ImageList(this.components);
            this.imageListArchitecture = new ImageList(this.components);
            this.panelMap = new Panel();
            this.pnlBase = new Panel();
            this.pnlMap = new MapPanel();
            this.cmsEdit = new ContextMenuStrip(this.components);
            this.cmenuArchitectureProperty = new ToolStripMenuItem();
            this.panel1 = new Panel();
            this.btnCutMap = new Button();
            this.cbHorizontal = new CheckBox();
            this.label5 = new Label();
            this.mtbPenWidth = new MaskedTextBox();
            this.lbCoord = new Label();
            this.btnBuildMap = new Button();
            this.label2 = new Label();
            this.mtbHeight = new MaskedTextBox();
            this.label1 = new Label();
            this.mtbWidth = new MaskedTextBox();
            this.tcEdit = new TabControl();
            this.tpMap = new TabPage();
            this.btnCliff = new Button();
            this.btnDesert = new Button();
            this.btnWasteland = new Button();
            this.btnRidge = new Button();
            this.btnRiver = new Button();
            this.btnMountain = new Button();
            this.btnMarsh = new Button();
            this.btnForest = new Button();
            this.btnGrassland = new Button();
            this.btnPlain = new Button();
            this.tpArchitecture = new TabPage();
            this.btnWaterLinks = new Button();
            this.btnLandLinks = new Button();
            this.cbDeleteWholeArchitecture = new CheckBox();
            this.btnDeleteArchitecture = new Button();
            this.btnEnlargeArchitecture = new Button();
            this.btnArchitectureBarrack = new Button();
            this.btnArchitecturePort = new Button();
            this.btnArchitectureBlock = new Button();
            this.btnArchitectureCity = new Button();
            this.groupBrushes = new GroupBox();
            this.label3 = new Label();
            this.mtbTileWidth = new MaskedTextBox();
            this.lbConment = new Label();
            this.mainMenu = new MenuStrip();
            this.menuFile = new ToolStripMenuItem();
            this.menuOpenScenario = new ToolStripMenuItem();
            this.menuSaveScenario = new ToolStripMenuItem();
            this.menuShowErrors = new ToolStripMenuItem();
            this.menuExit = new ToolStripMenuItem();
            this.menuDisplayTerrain = new ToolStripMenuItem();
            this.menuTerrainNone = new ToolStripMenuItem();
            this.menuTerrainPlain = new ToolStripMenuItem();
            this.menuTerrainGrassland = new ToolStripMenuItem();
            this.menuTerrainForest = new ToolStripMenuItem();
            this.menuTerrainMarsh = new ToolStripMenuItem();
            this.menuTerrainMountain = new ToolStripMenuItem();
            this.menuTerrainRiver = new ToolStripMenuItem();
            this.menuTerrainRidge = new ToolStripMenuItem();
            this.menuTerrainWasteland = new ToolStripMenuItem();
            this.menuTerrainDesert = new ToolStripMenuItem();
            this.menuTerrainAll = new ToolStripMenuItem();
            this.menuDisplayArchitecture = new ToolStripMenuItem();
            this.menuArchitectureCity = new ToolStripMenuItem();
            this.menuArchitectureBlock = new ToolStripMenuItem();
            this.menuArchitecturePort = new ToolStripMenuItem();
            this.menuArchitectureBarrack = new ToolStripMenuItem();
            this.menuArchitectureAll = new ToolStripMenuItem();
            this.menuDisplayGrid = new ToolStripMenuItem();
            this.menuDisplayGridLine = new ToolStripMenuItem();
            this.menuEdit = new ToolStripMenuItem();
            this.menuEditPersons = new ToolStripMenuItem();
            this.menuEditMilitary = new ToolStripMenuItem();
            this.menuEditArchitecture = new ToolStripMenuItem();
            this.menuEditFactions = new ToolStripMenuItem();
            this.编辑地区ToolStripMenuItem = new ToolStripMenuItem();
            this.编辑州域ToolStripMenuItem = new ToolStripMenuItem();
            this.编辑部队ToolStripMenuItem = new ToolStripMenuItem();
            this.编辑部队事件ToolStripMenuItem = new ToolStripMenuItem();
            this.menuGenerateMapJpg = new ToolStripMenuItem();
            this.新编剧本ToolStripMenuItem = new ToolStripMenuItem();
            this.初始化剧本只保留人物列表ToolStripMenuItem = new ToolStripMenuItem();
            this.删除所有建筑ToolStripMenuItem = new ToolStripMenuItem();
            this.menuReplaceTerrain = new ToolStripMenuItem();
            this.menuScenarioInformation = new ToolStripMenuItem();
            this.menuRegenArchitectureID = new ToolStripMenuItem();
            this.设置建筑地形ToolStripMenuItem = new ToolStripMenuItem();
            this.menuHelp = new ToolStripMenuItem();
            this.menuAbout = new ToolStripMenuItem();
            this.编辑宝物ToolStripMenuItem = new ToolStripMenuItem();
            this.panelMap.SuspendLayout();
            this.pnlBase.SuspendLayout();
            this.cmsEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tcEdit.SuspendLayout();
            this.tpMap.SuspendLayout();
            this.tpArchitecture.SuspendLayout();
            this.groupBrushes.SuspendLayout();
            this.mainMenu.SuspendLayout();
            base.SuspendLayout();
            this.openScenario.DefaultExt = "mdb";
            this.openScenario.FileName = "openScenario";
            this.imageListTerrain.ImageStream = (ImageListStreamer) manager.GetObject("imageListTerrain.ImageStream");
            this.imageListTerrain.TransparentColor = Color.Transparent;
            this.imageListTerrain.Images.SetKeyName(0, "None.jpg");
            this.imageListTerrain.Images.SetKeyName(1, "Plain.jpg");
            this.imageListTerrain.Images.SetKeyName(2, "Grassland.jpg");
            this.imageListTerrain.Images.SetKeyName(3, "Forest.jpg");
            this.imageListTerrain.Images.SetKeyName(4, "Marsh.jpg");
            this.imageListTerrain.Images.SetKeyName(5, "Mountain.jpg");
            this.imageListTerrain.Images.SetKeyName(6, "River.jpg");
            this.imageListTerrain.Images.SetKeyName(7, "Ridge.jpg");
            this.imageListTerrain.Images.SetKeyName(8, "Wasteland.jpg");
            this.imageListTerrain.Images.SetKeyName(9, "Desert.jpg");
            this.imageListTerrain.Images.SetKeyName(10, "Cliff.jpg");
            this.imageListArchitecture.ImageStream = (ImageListStreamer) manager.GetObject("imageListArchitecture.ImageStream");
            this.imageListArchitecture.TransparentColor = Color.Transparent;
            this.imageListArchitecture.Images.SetKeyName(0, "None.jpg");
            this.imageListArchitecture.Images.SetKeyName(1, "City.jpg");
            this.imageListArchitecture.Images.SetKeyName(2, "Block.jpg");
            this.imageListArchitecture.Images.SetKeyName(3, "Port.jpg");
            this.imageListArchitecture.Images.SetKeyName(4, "Barrack.jpg");

            this.panelMap.Controls.Add(this.pnlBase);
            this.panelMap.Controls.Add(this.panel1);
            this.panelMap.Dock = DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(0x88, 0x18);
            this.panelMap.Margin = new Padding(2);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new Size(0x2bf, 0x206);
            this.panelMap.TabIndex = 2;
            this.pnlBase.AutoScroll = true;
            this.pnlBase.Controls.Add(this.pnlMap);
            this.pnlBase.Dock = DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0x23);
            this.pnlBase.Margin = new Padding(2);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new Size(0x2bf, 0x1e3);
            this.pnlBase.TabIndex = 4;
            this.pnlBase.Scroll += new ScrollEventHandler(this.pnlBase_Scroll);
            this.pnlMap.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMap.ContextMenuStrip = this.cmsEdit;
            this.pnlMap.Cursor = Cursors.Default;
            this.pnlMap.ImeMode = ImeMode.Off;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Margin = new Padding(2);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new Size(0x217, 0x188);
            this.pnlMap.TabIndex = 3;
            this.pnlMap.TileHeight = 20;
            this.pnlMap.TileWidth = 20;
            this.pnlMap.MouseMove += new MouseEventHandler(this.pnlMap_MouseMove);
            this.pnlMap.MouseDown += new MouseEventHandler(this.pnlMap_MouseDown);
            this.pnlMap.MouseUp += new MouseEventHandler(this.pnlMap_MouseUp);
            this.cmsEdit.Items.AddRange(new ToolStripItem[] { this.cmenuArchitectureProperty });
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new Size(0xad, 0x1a);
            this.cmenuArchitectureProperty.Name = "cmenuArchitectureProperty";
            this.cmenuArchitectureProperty.Size = new Size(0xac, 0x16);
            this.cmenuArchitectureProperty.Text = "编辑建筑属性";
            this.cmenuArchitectureProperty.Click += new EventHandler(this.cmenuArchitectureProperty_Click);
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCutMap);
            this.panel1.Controls.Add(this.cbHorizontal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.mtbPenWidth);
            this.panel1.Controls.Add(this.lbCoord);
            this.panel1.Controls.Add(this.btnBuildMap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mtbHeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mtbWidth);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x2bf, 0x23);
            this.panel1.TabIndex = 1;
            this.btnCutMap.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnCutMap.Location = new System.Drawing.Point(0x25a, 7);
            this.btnCutMap.Margin = new Padding(2);
            this.btnCutMap.Name = "btnCutMap";
            this.btnCutMap.Size = new Size(0x59, 0x16);
            this.btnCutMap.TabIndex = 0x11;
            this.btnCutMap.Text = "裁剪某块地图";
            this.btnCutMap.UseVisualStyleBackColor = true;
            this.btnCutMap.Click += new EventHandler(this.btnCutMap_Click);
            this.cbHorizontal.AutoSize = true;
            this.cbHorizontal.Location = new System.Drawing.Point(410, 10);
            this.cbHorizontal.Margin = new Padding(2);
            this.cbHorizontal.Name = "cbHorizontal";
            this.cbHorizontal.Size = new Size(0x30, 0x10);
            this.cbHorizontal.TabIndex = 0x10;
            this.cbHorizontal.Text = "横向";
            this.cbHorizontal.UseVisualStyleBackColor = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0x139, 11);
            this.label5.Margin = new Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "画笔宽度";
            this.mtbPenWidth.AsciiOnly = true;
            this.mtbPenWidth.Location = new System.Drawing.Point(370, 7);
            this.mtbPenWidth.Margin = new Padding(2);
            this.mtbPenWidth.Mask = "9";
            this.mtbPenWidth.Name = "mtbPenWidth";
            this.mtbPenWidth.Size = new Size(0x17, 0x15);
            this.mtbPenWidth.TabIndex = 7;
            this.mtbPenWidth.Text = "1";
            this.lbCoord.AutoSize = true;
            this.lbCoord.Location = new System.Drawing.Point(200, 11);
            this.lbCoord.Margin = new Padding(2, 0, 2, 0);
            this.lbCoord.Name = "lbCoord";
            this.lbCoord.Size = new Size(0x1d, 12);
            this.lbCoord.TabIndex = 6;
            this.lbCoord.Text = "坐标";
            this.btnBuildMap.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBuildMap.Location = new System.Drawing.Point(0x202, 7);
            this.btnBuildMap.Margin = new Padding(2);
            this.btnBuildMap.Name = "btnBuildMap";
            this.btnBuildMap.Size = new Size(0x4b, 0x16);
            this.btnBuildMap.TabIndex = 5;
            this.btnBuildMap.Text = "生成地图";
            this.btnBuildMap.UseVisualStyleBackColor = true;
            this.btnBuildMap.Click += new EventHandler(this.btnBuildMap_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0x68, 11);
            this.label2.Margin = new Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "高度";
            this.mtbHeight.AsciiOnly = true;
            this.mtbHeight.Location = new System.Drawing.Point(0x88, 9);
            this.mtbHeight.Margin = new Padding(2);
            this.mtbHeight.Mask = "9999";
            this.mtbHeight.Name = "mtbHeight";
            this.mtbHeight.Size = new Size(50, 0x15);
            this.mtbHeight.TabIndex = 3;
            this.mtbHeight.Text = "10";
            this.mtbHeight.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0x10, 11);
            this.label1.Margin = new Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度";
            this.mtbWidth.AsciiOnly = true;
            this.mtbWidth.Location = new System.Drawing.Point(0x31, 9);
            this.mtbWidth.Margin = new Padding(2);
            this.mtbWidth.Mask = "9999";
            this.mtbWidth.Name = "mtbWidth";
            this.mtbWidth.Size = new Size(0x2c, 0x15);
            this.mtbWidth.TabIndex = 1;
            this.mtbWidth.Text = "10";
            this.mtbWidth.TextAlign = HorizontalAlignment.Right;
            this.tcEdit.Controls.Add(this.tpMap);
            this.tcEdit.Controls.Add(this.tpArchitecture);
            this.tcEdit.Dock = DockStyle.Top;
            this.tcEdit.Location = new System.Drawing.Point(2, 0x10);
            this.tcEdit.Margin = new Padding(2);
            this.tcEdit.Name = "tcEdit";
            this.tcEdit.SelectedIndex = 0;
            this.tcEdit.Size = new Size(0x84, 0x106);
            this.tcEdit.TabIndex = 0x13;
            this.tpMap.Controls.Add(this.btnCliff);
            this.tpMap.Controls.Add(this.btnDesert);
            this.tpMap.Controls.Add(this.btnWasteland);
            this.tpMap.Controls.Add(this.btnRidge);
            this.tpMap.Controls.Add(this.btnRiver);
            this.tpMap.Controls.Add(this.btnMountain);
            this.tpMap.Controls.Add(this.btnMarsh);
            this.tpMap.Controls.Add(this.btnForest);
            this.tpMap.Controls.Add(this.btnGrassland);
            this.tpMap.Controls.Add(this.btnPlain);
            this.tpMap.Location = new System.Drawing.Point(4, 0x15);
            this.tpMap.Margin = new Padding(2);
            this.tpMap.Name = "tpMap";
            this.tpMap.Padding = new Padding(2);
            this.tpMap.Size = new Size(0x7c, 0xed);
            this.tpMap.TabIndex = 0;
            this.tpMap.Text = "地形";
            this.tpMap.UseVisualStyleBackColor = true;
            this.btnCliff.BackgroundImage = (Image) manager.GetObject("btnCliff.BackgroundImage");
            this.btnCliff.FlatStyle = FlatStyle.Popup;
            this.btnCliff.Location = new System.Drawing.Point(0x2a, 50);
            this.btnCliff.Margin = new Padding(2);
            this.btnCliff.Name = "btnCliff";
            this.btnCliff.Size = new Size(0x26, 20);
            this.btnCliff.TabIndex = 0x12;
            this.btnCliff.TabStop = false;
            this.btnCliff.Text = "栈道";
            this.btnCliff.UseVisualStyleBackColor = true;
            this.btnCliff.Click += new EventHandler(this.btnCliff_Click);
            this.btnDesert.BackgroundImage = (Image) manager.GetObject("btnDesert.BackgroundImage");
            this.btnDesert.FlatStyle = FlatStyle.Popup;
            this.btnDesert.Location = new System.Drawing.Point(0x2a, 0x1a);
            this.btnDesert.Margin = new Padding(2);
            this.btnDesert.Name = "btnDesert";
            this.btnDesert.Size = new Size(0x26, 20);
            this.btnDesert.TabIndex = 0x11;
            this.btnDesert.TabStop = false;
            this.btnDesert.Text = "沙漠";
            this.btnDesert.UseVisualStyleBackColor = true;
            this.btnDesert.Click += new EventHandler(this.btnDesert_Click);
            this.btnWasteland.BackgroundImage = (Image) manager.GetObject("btnWasteland.BackgroundImage");
            this.btnWasteland.FlatStyle = FlatStyle.Popup;
            this.btnWasteland.Location = new System.Drawing.Point(0x2a, 3);
            this.btnWasteland.Margin = new Padding(2);
            this.btnWasteland.Name = "btnWasteland";
            this.btnWasteland.Size = new Size(0x26, 20);
            this.btnWasteland.TabIndex = 0x10;
            this.btnWasteland.TabStop = false;
            this.btnWasteland.Text = "荒原";
            this.btnWasteland.UseVisualStyleBackColor = true;
            this.btnWasteland.Click += new EventHandler(this.btnWasteland_Click);
            this.btnRidge.BackgroundImage = (Image) manager.GetObject("btnRidge.BackgroundImage");
            this.btnRidge.FlatStyle = FlatStyle.Popup;
            this.btnRidge.Location = new System.Drawing.Point(3, 0x8e);
            this.btnRidge.Margin = new Padding(2);
            this.btnRidge.Name = "btnRidge";
            this.btnRidge.Size = new Size(0x26, 20);
            this.btnRidge.TabIndex = 15;
            this.btnRidge.TabStop = false;
            this.btnRidge.Text = "峻岭";
            this.btnRidge.UseVisualStyleBackColor = true;
            this.btnRidge.Click += new EventHandler(this.btnRidge_Click);
            this.btnRiver.BackgroundImage = (Image) manager.GetObject("btnRiver.BackgroundImage");
            this.btnRiver.FlatStyle = FlatStyle.Popup;
            this.btnRiver.Location = new System.Drawing.Point(3, 0x77);
            this.btnRiver.Margin = new Padding(2);
            this.btnRiver.Name = "btnRiver";
            this.btnRiver.Size = new Size(0x26, 20);
            this.btnRiver.TabIndex = 14;
            this.btnRiver.TabStop = false;
            this.btnRiver.Text = "河流";
            this.btnRiver.UseVisualStyleBackColor = true;
            this.btnRiver.Click += new EventHandler(this.btnRiver_Click);
            this.btnMountain.BackgroundImage = (Image) manager.GetObject("btnMountain.BackgroundImage");
            this.btnMountain.FlatStyle = FlatStyle.Popup;
            this.btnMountain.Location = new System.Drawing.Point(3, 0x60);
            this.btnMountain.Margin = new Padding(2);
            this.btnMountain.Name = "btnMountain";
            this.btnMountain.Size = new Size(0x26, 20);
            this.btnMountain.TabIndex = 13;
            this.btnMountain.TabStop = false;
            this.btnMountain.Text = "山地";
            this.btnMountain.UseVisualStyleBackColor = true;
            this.btnMountain.Click += new EventHandler(this.btnMountain_Click);
            this.btnMarsh.BackgroundImage = (Image) manager.GetObject("btnMarsh.BackgroundImage");
            this.btnMarsh.FlatStyle = FlatStyle.Popup;
            this.btnMarsh.Location = new System.Drawing.Point(3, 0x49);
            this.btnMarsh.Margin = new Padding(2);
            this.btnMarsh.Name = "btnMarsh";
            this.btnMarsh.Size = new Size(0x26, 20);
            this.btnMarsh.TabIndex = 12;
            this.btnMarsh.TabStop = false;
            this.btnMarsh.Text = "湿地";
            this.btnMarsh.UseVisualStyleBackColor = true;
            this.btnMarsh.Click += new EventHandler(this.btnMarsh_Click);
            this.btnForest.BackgroundImage = (Image) manager.GetObject("btnForest.BackgroundImage");
            this.btnForest.FlatStyle = FlatStyle.Popup;
            this.btnForest.Location = new System.Drawing.Point(3, 50);
            this.btnForest.Margin = new Padding(2);
            this.btnForest.Name = "btnForest";
            this.btnForest.Size = new Size(0x26, 20);
            this.btnForest.TabIndex = 11;
            this.btnForest.TabStop = false;
            this.btnForest.Text = "森林";
            this.btnForest.UseVisualStyleBackColor = true;
            this.btnForest.Click += new EventHandler(this.btnForest_Click);
            this.btnGrassland.BackgroundImage = (Image) manager.GetObject("btnGrassland.BackgroundImage");
            this.btnGrassland.FlatStyle = FlatStyle.Popup;
            this.btnGrassland.Location = new System.Drawing.Point(3, 0x1a);
            this.btnGrassland.Margin = new Padding(2);
            this.btnGrassland.Name = "btnGrassland";
            this.btnGrassland.Size = new Size(0x26, 20);
            this.btnGrassland.TabIndex = 10;
            this.btnGrassland.TabStop = false;
            this.btnGrassland.Text = "草地";
            this.btnGrassland.UseVisualStyleBackColor = true;
            this.btnGrassland.Click += new EventHandler(this.btnGrassland_Click);
            this.btnPlain.BackgroundImage = (Image) manager.GetObject("btnPlain.BackgroundImage");
            this.btnPlain.FlatStyle = FlatStyle.Popup;
            this.btnPlain.Location = new System.Drawing.Point(3, 3);
            this.btnPlain.Margin = new Padding(2);
            this.btnPlain.Name = "btnPlain";
            this.btnPlain.Size = new Size(0x26, 20);
            this.btnPlain.TabIndex = 9;
            this.btnPlain.TabStop = false;
            this.btnPlain.Text = "平原";
            this.btnPlain.UseVisualStyleBackColor = true;
            this.btnPlain.Click += new EventHandler(this.btnPlain_Click);
            this.tpArchitecture.Controls.Add(this.btnWaterLinks);
            this.tpArchitecture.Controls.Add(this.btnLandLinks);
            this.tpArchitecture.Controls.Add(this.cbDeleteWholeArchitecture);
            this.tpArchitecture.Controls.Add(this.btnDeleteArchitecture);
            this.tpArchitecture.Controls.Add(this.btnEnlargeArchitecture);
            this.tpArchitecture.Controls.Add(this.btnArchitectureBarrack);
            this.tpArchitecture.Controls.Add(this.btnArchitecturePort);
            this.tpArchitecture.Controls.Add(this.btnArchitectureBlock);
            this.tpArchitecture.Controls.Add(this.btnArchitectureCity);
            this.tpArchitecture.Location = new System.Drawing.Point(4, 0x15);
            this.tpArchitecture.Margin = new Padding(2);
            this.tpArchitecture.Name = "tpArchitecture";
            this.tpArchitecture.Padding = new Padding(2);
            this.tpArchitecture.Size = new Size(0x7c, 0xed);
            this.tpArchitecture.TabIndex = 1;
            this.tpArchitecture.Text = "建筑";
            this.tpArchitecture.UseVisualStyleBackColor = true;
            this.btnWaterLinks.FlatStyle = FlatStyle.Popup;
            this.btnWaterLinks.ImageIndex = 0;
            this.btnWaterLinks.Location = new System.Drawing.Point(4, 210);
            this.btnWaterLinks.Margin = new Padding(2);
            this.btnWaterLinks.Name = "btnWaterLinks";
            this.btnWaterLinks.Size = new Size(0x41, 20);
            this.btnWaterLinks.TabIndex = 0x12;
            this.btnWaterLinks.TabStop = false;
            this.btnWaterLinks.Text = "水上链接";
            this.btnWaterLinks.UseVisualStyleBackColor = true;
            this.btnWaterLinks.Click += new EventHandler(this.btnWaterLinks_Click);
            this.btnLandLinks.FlatStyle = FlatStyle.Popup;
            this.btnLandLinks.ImageIndex = 0;
            this.btnLandLinks.Location = new System.Drawing.Point(4, 0xba);
            this.btnLandLinks.Margin = new Padding(2);
            this.btnLandLinks.Name = "btnLandLinks";
            this.btnLandLinks.Size = new Size(0x41, 20);
            this.btnLandLinks.TabIndex = 0x11;
            this.btnLandLinks.TabStop = false;
            this.btnLandLinks.Text = "陆上链接";
            this.btnLandLinks.UseVisualStyleBackColor = true;
            this.btnLandLinks.Click += new EventHandler(this.btnLandLinks_Click);
            this.cbDeleteWholeArchitecture.AutoSize = true;
            this.cbDeleteWholeArchitecture.Checked = true;
            this.cbDeleteWholeArchitecture.CheckState = CheckState.Checked;
            this.cbDeleteWholeArchitecture.Location = new System.Drawing.Point(0x3e, 0xa5);
            this.cbDeleteWholeArchitecture.Margin = new Padding(2);
            this.cbDeleteWholeArchitecture.Name = "cbDeleteWholeArchitecture";
            this.cbDeleteWholeArchitecture.Size = new Size(0x30, 0x10);
            this.cbDeleteWholeArchitecture.TabIndex = 15;
            this.cbDeleteWholeArchitecture.Text = "整体";
            this.cbDeleteWholeArchitecture.UseVisualStyleBackColor = true;
            this.cbDeleteWholeArchitecture.MouseHover += new EventHandler(this.cbDeleteWholeArchitecture_MouseHover);
            this.btnDeleteArchitecture.FlatStyle = FlatStyle.Popup;
            this.btnDeleteArchitecture.ImageIndex = 0;
            this.btnDeleteArchitecture.Location = new System.Drawing.Point(4, 0xa2);
            this.btnDeleteArchitecture.Margin = new Padding(2);
            this.btnDeleteArchitecture.Name = "btnDeleteArchitecture";
            this.btnDeleteArchitecture.Size = new Size(0x2b, 20);
            this.btnDeleteArchitecture.TabIndex = 14;
            this.btnDeleteArchitecture.TabStop = false;
            this.btnDeleteArchitecture.Text = "删除";
            this.btnDeleteArchitecture.UseVisualStyleBackColor = true;
            this.btnDeleteArchitecture.Click += new EventHandler(this.btnDeleteArchitecture_Click);
            this.btnEnlargeArchitecture.FlatStyle = FlatStyle.Popup;
            this.btnEnlargeArchitecture.ImageIndex = 0;
            this.btnEnlargeArchitecture.Location = new System.Drawing.Point(4, 0x8b);
            this.btnEnlargeArchitecture.Margin = new Padding(2);
            this.btnEnlargeArchitecture.Name = "btnEnlargeArchitecture";
            this.btnEnlargeArchitecture.Size = new Size(0x2b, 20);
            this.btnEnlargeArchitecture.TabIndex = 13;
            this.btnEnlargeArchitecture.TabStop = false;
            this.btnEnlargeArchitecture.Text = "増筑 ";
            this.btnEnlargeArchitecture.UseVisualStyleBackColor = true;
            this.btnEnlargeArchitecture.Click += new EventHandler(this.btnEnlargeArchitecture_Click);
            this.btnArchitectureBarrack.BackgroundImage = (Image) manager.GetObject("btnArchitectureBarrack.BackgroundImage");
            this.btnArchitectureBarrack.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnArchitectureBarrack.FlatStyle = FlatStyle.Popup;
            this.btnArchitectureBarrack.ForeColor = SystemColors.ControlLightLight;
            this.btnArchitectureBarrack.ImageIndex = 0;
            this.btnArchitectureBarrack.Location = new System.Drawing.Point(4, 0x4b);
            this.btnArchitectureBarrack.Margin = new Padding(2);
            this.btnArchitectureBarrack.Name = "btnArchitectureBarrack";
            this.btnArchitectureBarrack.Size = new Size(0x26, 20);
            this.btnArchitectureBarrack.TabIndex = 0x10;
            this.btnArchitectureBarrack.TabStop = false;
            this.btnArchitectureBarrack.Text = "军营";
            this.btnArchitectureBarrack.UseVisualStyleBackColor = true;
            this.btnArchitectureBarrack.Click += new EventHandler(this.btnArchitectureBarrack_Click);
            this.btnArchitecturePort.BackgroundImage = (Image) manager.GetObject("btnArchitecturePort.BackgroundImage");
            this.btnArchitecturePort.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnArchitecturePort.FlatStyle = FlatStyle.Popup;
            this.btnArchitecturePort.ForeColor = SystemColors.ControlLightLight;
            this.btnArchitecturePort.ImageIndex = 0;
            this.btnArchitecturePort.Location = new System.Drawing.Point(4, 0x33);
            this.btnArchitecturePort.Margin = new Padding(2);
            this.btnArchitecturePort.Name = "btnArchitecturePort";
            this.btnArchitecturePort.Size = new Size(0x26, 20);
            this.btnArchitecturePort.TabIndex = 12;
            this.btnArchitecturePort.TabStop = false;
            this.btnArchitecturePort.Text = "港口";
            this.btnArchitecturePort.UseVisualStyleBackColor = true;
            this.btnArchitecturePort.Click += new EventHandler(this.btnArchitecturePort_Click);
            this.btnArchitectureBlock.BackgroundImage = (Image) manager.GetObject("btnArchitectureBlock.BackgroundImage");
            this.btnArchitectureBlock.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnArchitectureBlock.FlatStyle = FlatStyle.Popup;
            this.btnArchitectureBlock.ForeColor = SystemColors.ButtonFace;
            this.btnArchitectureBlock.ImageIndex = 0;
            this.btnArchitectureBlock.Location = new System.Drawing.Point(4, 0x1c);
            this.btnArchitectureBlock.Margin = new Padding(2);
            this.btnArchitectureBlock.Name = "btnArchitectureBlock";
            this.btnArchitectureBlock.Size = new Size(0x26, 20);
            this.btnArchitectureBlock.TabIndex = 11;
            this.btnArchitectureBlock.TabStop = false;
            this.btnArchitectureBlock.Text = "关卡";
            this.btnArchitectureBlock.UseVisualStyleBackColor = true;
            this.btnArchitectureBlock.Click += new EventHandler(this.btnArchitectureBlock_Click);
            this.btnArchitectureCity.BackgroundImage = (Image) manager.GetObject("btnArchitectureCity.BackgroundImage");
            this.btnArchitectureCity.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnArchitectureCity.FlatStyle = FlatStyle.Popup;
            this.btnArchitectureCity.ForeColor = SystemColors.ButtonFace;
            this.btnArchitectureCity.ImageIndex = 0;
            this.btnArchitectureCity.Location = new System.Drawing.Point(4, 5);
            this.btnArchitectureCity.Margin = new Padding(2);
            this.btnArchitectureCity.Name = "btnArchitectureCity";
            this.btnArchitectureCity.Size = new Size(0x26, 20);
            this.btnArchitectureCity.TabIndex = 10;
            this.btnArchitectureCity.TabStop = false;
            this.btnArchitectureCity.Text = "城市";
            this.btnArchitectureCity.UseVisualStyleBackColor = true;
            this.btnArchitectureCity.Click += new EventHandler(this.btnArchitectureCity_Click);
            this.groupBrushes.Controls.Add(this.label3);
            this.groupBrushes.Controls.Add(this.mtbTileWidth);
            this.groupBrushes.Controls.Add(this.lbConment);
            this.groupBrushes.Controls.Add(this.tcEdit);
            this.groupBrushes.Dock = DockStyle.Left;
            this.groupBrushes.Location = new System.Drawing.Point(0, 0x18);
            this.groupBrushes.Margin = new Padding(2);
            this.groupBrushes.Name = "groupBrushes";
            this.groupBrushes.Padding = new Padding(2);
            this.groupBrushes.Size = new Size(0x88, 0x206);
            this.groupBrushes.TabIndex = 1;
            this.groupBrushes.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 0x135);
            this.label3.Margin = new Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 0x16;
            this.label3.Text = "方格宽度";
            this.mtbTileWidth.AsciiOnly = true;
            this.mtbTileWidth.Location = new System.Drawing.Point(10, 0x14e);
            this.mtbTileWidth.Margin = new Padding(2);
            this.mtbTileWidth.Mask = "9999";
            this.mtbTileWidth.Name = "mtbTileWidth";
            this.mtbTileWidth.Size = new Size(0x33, 0x15);
            this.mtbTileWidth.TabIndex = 0x15;
            this.mtbTileWidth.Text = "40";
            this.mtbTileWidth.TextAlign = HorizontalAlignment.Right;
            this.mtbTileWidth.TextChanged += new EventHandler(this.mtbTileWidth_TextChanged);
            this.lbConment.Dock = DockStyle.Bottom;
            this.lbConment.Location = new System.Drawing.Point(2, 0x1b2);
            this.lbConment.Margin = new Padding(2, 0, 2, 0);
            this.lbConment.Name = "lbConment";
            this.lbConment.Size = new Size(0x84, 0x52);
            this.lbConment.TabIndex = 20;
            this.mainMenu.Items.AddRange(new ToolStripItem[] { this.menuFile, this.menuDisplayTerrain, this.menuDisplayArchitecture, this.menuDisplayGrid, this.menuEdit, this.menuHelp });
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new Padding(4, 2, 0, 2);
            this.mainMenu.Size = new Size(0x347, 0x18);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "主菜单";
            this.menuFile.DropDownItems.AddRange(new ToolStripItem[] { this.menuOpenScenario, this.menuSaveScenario, this.menuShowErrors, this.menuExit });
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new Size(0x34, 20);
            this.menuFile.Text = "文件";
            this.menuOpenScenario.Name = "menuOpenScenario";
            this.menuOpenScenario.Size = new Size(0x6c, 0x16);
            this.menuOpenScenario.Text = "打开";
            this.menuOpenScenario.Click += new EventHandler(this.menuOpenScenario_Click);
            this.menuSaveScenario.Name = "menuSaveScenario";
            this.menuSaveScenario.Size = new Size(0x6c, 0x16);
            this.menuSaveScenario.Text = "保存";
            this.menuSaveScenario.Enabled = false;
            this.menuSaveScenario.Click += new EventHandler(this.menuSaveScenario_Click);
            this.menuShowErrors.Name = "menuShowErrors";
            this.menuShowErrors.Size = new Size(0x6c, 0x16);
            this.menuShowErrors.Text = "检查这剧本错误";
            this.menuShowErrors.Enabled = false;
            this.menuShowErrors.Click += new EventHandler(this.menuShowErrors_Click);
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new Size(0x6c, 0x16);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new EventHandler(this.menuExit_Click);
            this.menuDisplayTerrain.DropDownItems.AddRange(new ToolStripItem[] { this.menuTerrainNone, this.menuTerrainPlain, this.menuTerrainGrassland, this.menuTerrainForest, this.menuTerrainMarsh, this.menuTerrainMountain, this.menuTerrainRiver, this.menuTerrainRidge, this.menuTerrainWasteland, this.menuTerrainDesert, this.menuTerrainAll });
            this.menuDisplayTerrain.Name = "menuDisplayTerrain";
            this.menuDisplayTerrain.Size = new Size(0x54, 20);
            this.menuDisplayTerrain.Text = "显示地形";
            this.menuTerrainNone.CheckOnClick = true;
            this.menuTerrainNone.Name = "menuTerrainNone";
            this.menuTerrainNone.Size = new Size(0x6c, 0x16);
            this.menuTerrainNone.Text = "空地";
            this.menuTerrainNone.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainPlain.Checked = true;
            this.menuTerrainPlain.CheckOnClick = true;
            this.menuTerrainPlain.CheckState = CheckState.Checked;
            this.menuTerrainPlain.Name = "menuTerrainPlain";
            this.menuTerrainPlain.Size = new Size(0x6c, 0x16);
            this.menuTerrainPlain.Text = "平原";
            this.menuTerrainPlain.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainGrassland.Checked = true;
            this.menuTerrainGrassland.CheckOnClick = true;
            this.menuTerrainGrassland.CheckState = CheckState.Checked;
            this.menuTerrainGrassland.Name = "menuTerrainGrassland";
            this.menuTerrainGrassland.Size = new Size(0x6c, 0x16);
            this.menuTerrainGrassland.Text = "草地";
            this.menuTerrainGrassland.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainForest.Checked = true;
            this.menuTerrainForest.CheckOnClick = true;
            this.menuTerrainForest.CheckState = CheckState.Checked;
            this.menuTerrainForest.Name = "menuTerrainForest";
            this.menuTerrainForest.Size = new Size(0x6c, 0x16);
            this.menuTerrainForest.Text = "森林";
            this.menuTerrainForest.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainMarsh.Checked = true;
            this.menuTerrainMarsh.CheckOnClick = true;
            this.menuTerrainMarsh.CheckState = CheckState.Checked;
            this.menuTerrainMarsh.Name = "menuTerrainMarsh";
            this.menuTerrainMarsh.Size = new Size(0x6c, 0x16);
            this.menuTerrainMarsh.Text = "湿地";
            this.menuTerrainMarsh.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainMountain.Checked = true;
            this.menuTerrainMountain.CheckOnClick = true;
            this.menuTerrainMountain.CheckState = CheckState.Checked;
            this.menuTerrainMountain.Name = "menuTerrainMountain";
            this.menuTerrainMountain.Size = new Size(0x6c, 0x16);
            this.menuTerrainMountain.Text = "山地";
            this.menuTerrainMountain.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainRiver.Checked = true;
            this.menuTerrainRiver.CheckOnClick = true;
            this.menuTerrainRiver.CheckState = CheckState.Checked;
            this.menuTerrainRiver.Name = "menuTerrainRiver";
            this.menuTerrainRiver.Size = new Size(0x6c, 0x16);
            this.menuTerrainRiver.Text = "河流";
            this.menuTerrainRiver.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainRidge.Checked = true;
            this.menuTerrainRidge.CheckOnClick = true;
            this.menuTerrainRidge.CheckState = CheckState.Checked;
            this.menuTerrainRidge.Name = "menuTerrainRidge";
            this.menuTerrainRidge.Size = new Size(0x6c, 0x16);
            this.menuTerrainRidge.Text = "峻岭";
            this.menuTerrainRidge.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainWasteland.Checked = true;
            this.menuTerrainWasteland.CheckOnClick = true;
            this.menuTerrainWasteland.CheckState = CheckState.Checked;
            this.menuTerrainWasteland.Name = "menuTerrainWasteland";
            this.menuTerrainWasteland.Size = new Size(0x6c, 0x16);
            this.menuTerrainWasteland.Text = "荒原";
            this.menuTerrainWasteland.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainDesert.Checked = true;
            this.menuTerrainDesert.CheckOnClick = true;
            this.menuTerrainDesert.CheckState = CheckState.Checked;
            this.menuTerrainDesert.Name = "menuTerrainDesert";
            this.menuTerrainDesert.Size = new Size(0x6c, 0x16);
            this.menuTerrainDesert.Text = "沙漠";
            this.menuTerrainDesert.CheckStateChanged += new EventHandler(this.menuTerrains_CheckedChanged);
            this.menuTerrainAll.Checked = true;
            this.menuTerrainAll.CheckOnClick = true;
            this.menuTerrainAll.CheckState = CheckState.Checked;
            this.menuTerrainAll.Name = "menuTerrainAll";
            this.menuTerrainAll.Size = new Size(0x6c, 0x16);
            this.menuTerrainAll.Text = "全部";
            this.menuTerrainAll.CheckStateChanged += new EventHandler(this.menuTerrainAll_CheckStateChanged);
            this.menuDisplayArchitecture.DropDownItems.AddRange(new ToolStripItem[] { this.menuArchitectureCity, this.menuArchitectureBlock, this.menuArchitecturePort, this.menuArchitectureBarrack, this.menuArchitectureAll });
            this.menuDisplayArchitecture.Name = "menuDisplayArchitecture";
            this.menuDisplayArchitecture.Size = new Size(0x54, 20);
            this.menuDisplayArchitecture.Text = "显示建筑";
            this.menuArchitectureCity.Checked = true;
            this.menuArchitectureCity.CheckOnClick = true;
            this.menuArchitectureCity.CheckState = CheckState.Checked;
            this.menuArchitectureCity.Name = "menuArchitectureCity";
            this.menuArchitectureCity.Size = new Size(0x6c, 0x16);
            this.menuArchitectureCity.Text = "城池";
            this.menuArchitectureCity.CheckStateChanged += new EventHandler(this.menuArchitectures_CheckedChanged);
            this.menuArchitectureBlock.Checked = true;
            this.menuArchitectureBlock.CheckOnClick = true;
            this.menuArchitectureBlock.CheckState = CheckState.Checked;
            this.menuArchitectureBlock.Name = "menuArchitectureBlock";
            this.menuArchitectureBlock.Size = new Size(0x6c, 0x16);
            this.menuArchitectureBlock.Text = "关隘";
            this.menuArchitectureBlock.CheckStateChanged += new EventHandler(this.menuArchitectures_CheckedChanged);
            this.menuArchitecturePort.Checked = true;
            this.menuArchitecturePort.CheckOnClick = true;
            this.menuArchitecturePort.CheckState = CheckState.Checked;
            this.menuArchitecturePort.Name = "menuArchitecturePort";
            this.menuArchitecturePort.Size = new Size(0x6c, 0x16);
            this.menuArchitecturePort.Text = "港口";
            this.menuArchitecturePort.CheckStateChanged += new EventHandler(this.menuArchitectures_CheckedChanged);
            this.menuArchitectureBarrack.Checked = true;
            this.menuArchitectureBarrack.CheckOnClick = true;
            this.menuArchitectureBarrack.CheckState = CheckState.Checked;
            this.menuArchitectureBarrack.Name = "menuArchitectureBarrack";
            this.menuArchitectureBarrack.Size = new Size(0x6c, 0x16);
            this.menuArchitectureBarrack.Text = "军营";
            this.menuArchitectureBarrack.CheckStateChanged += new EventHandler(this.menuArchitectures_CheckedChanged);
            this.menuArchitectureAll.Checked = true;
            this.menuArchitectureAll.CheckOnClick = true;
            this.menuArchitectureAll.CheckState = CheckState.Checked;
            this.menuArchitectureAll.Name = "menuArchitectureAll";
            this.menuArchitectureAll.Size = new Size(0x6c, 0x16);
            this.menuArchitectureAll.Text = "全部";
            this.menuArchitectureAll.CheckStateChanged += new EventHandler(this.menuArchitectureAll_CheckStateChanged);
            this.menuDisplayGrid.DropDownItems.AddRange(new ToolStripItem[] { this.menuDisplayGridLine });
            this.menuDisplayGrid.Name = "menuDisplayGrid";
            this.menuDisplayGrid.Size = new Size(0x54, 20);
            this.menuDisplayGrid.Text = "显示网格";
            this.menuDisplayGridLine.CheckOnClick = true;
            this.menuDisplayGridLine.Name = "menuDisplayGridLine";
            this.menuDisplayGridLine.Size = new Size(0x6c, 0x16);
            this.menuDisplayGridLine.Text = "显示";
            this.menuDisplayGridLine.CheckStateChanged += new EventHandler(this.menuDisplayGridLine_CheckStateChanged);
            this.menuEdit.DropDownItems.AddRange(new ToolStripItem[] { this.menuEditPersons, this.menuEditMilitary, this.menuEditArchitecture, this.menuEditFactions, this.编辑地区ToolStripMenuItem, this.编辑州域ToolStripMenuItem, this.编辑部队ToolStripMenuItem, this.编辑宝物ToolStripMenuItem, this.编辑部队事件ToolStripMenuItem, this.menuGenerateMapJpg, this.新编剧本ToolStripMenuItem });
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new Size(0x34, 20);
            this.menuEdit.Text = "编辑";
            this.menuEdit.Enabled = false;
            this.menuEditPersons.Name = "menuEditPersons";
            this.menuEditPersons.Size = new Size(0xac, 0x16);
            this.menuEditPersons.Text = "编辑人物";
            this.menuEditPersons.Click += new EventHandler(this.menuEditPersons_Click);
            this.menuEditMilitary.Name = "menuEditMilitary";
            this.menuEditMilitary.Size = new Size(0xac, 0x16);
            this.menuEditMilitary.Text = "编辑编队";
            this.menuEditMilitary.Click += new EventHandler(this.menuEditMilitary_Click);
            this.menuEditArchitecture.Name = "menuEditArchitecture";
            this.menuEditArchitecture.Size = new Size(0xac, 0x16);
            this.menuEditArchitecture.Text = "编辑建筑";
            this.menuEditArchitecture.Click += new EventHandler(this.menuEditArchitecture_Click);
            this.menuEditFactions.Name = "menuEditFactions";
            this.menuEditFactions.Size = new Size(0xac, 0x16);
            this.menuEditFactions.Text = "编辑势力";
            this.menuEditFactions.Click += new EventHandler(this.menuEditFactions_Click);
            this.编辑地区ToolStripMenuItem.Name = "编辑地区ToolStripMenuItem";
            this.编辑地区ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑地区ToolStripMenuItem.Text = "编辑地区";
            this.编辑地区ToolStripMenuItem.Click += new EventHandler(this.编辑地区ToolStripMenuItem_Click);
            this.编辑州域ToolStripMenuItem.Name = "编辑州域ToolStripMenuItem";
            this.编辑州域ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑州域ToolStripMenuItem.Text = "编辑州域";
            this.编辑州域ToolStripMenuItem.Click += new EventHandler(this.编辑州域ToolStripMenuItem_Click);
            this.编辑部队ToolStripMenuItem.Name = "编辑部队ToolStripMenuItem";
            this.编辑部队ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑部队ToolStripMenuItem.Text = "编辑部队";
            this.编辑部队ToolStripMenuItem.Click += new EventHandler(this.编辑部队ToolStripMenuItem_Click);
            this.编辑部队事件ToolStripMenuItem.Name = "编辑部队事件ToolStripMenuItem";
            this.编辑部队事件ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑部队事件ToolStripMenuItem.Text = "编辑部队事件";
            this.编辑部队事件ToolStripMenuItem.Click += new EventHandler(this.编辑部队事件ToolStripMenuItem_Click);
            this.menuGenerateMapJpg.Name = "menuGenerateMapJpg";
            this.menuGenerateMapJpg.Size = new Size(0xac, 0x16);
            this.menuGenerateMapJpg.Text = "生成地图图片";
            this.menuGenerateMapJpg.Click += new EventHandler(this.menuGenerateMapJpg_Click);
            this.新编剧本ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.初始化剧本只保留人物列表ToolStripMenuItem, this.删除所有建筑ToolStripMenuItem, this.menuReplaceTerrain, this.menuScenarioInformation, this.menuRegenArchitectureID, this.设置建筑地形ToolStripMenuItem });
            this.新编剧本ToolStripMenuItem.Name = "新编剧本ToolStripMenuItem";
            this.新编剧本ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.新编剧本ToolStripMenuItem.Text = "新编剧本";
            this.初始化剧本只保留人物列表ToolStripMenuItem.Name = "初始化剧本只保留人物列表ToolStripMenuItem";
            this.初始化剧本只保留人物列表ToolStripMenuItem.Size = new Size(220, 0x16);
            this.初始化剧本只保留人物列表ToolStripMenuItem.Text = "初始化剧本";
            this.初始化剧本只保留人物列表ToolStripMenuItem.Click += new EventHandler(this.初始化剧本只保留人物列表ToolStripMenuItem_Click_1);
            this.删除所有建筑ToolStripMenuItem.Name = "删除所有建筑ToolStripMenuItem";
            this.删除所有建筑ToolStripMenuItem.Size = new Size(220, 0x16);
            this.删除所有建筑ToolStripMenuItem.Text = "删除所有建筑";
            this.删除所有建筑ToolStripMenuItem.Click += new EventHandler(this.删除所有建筑ToolStripMenuItem_Click_1);
            this.menuReplaceTerrain.Name = "menuReplaceTerrain";
            this.menuReplaceTerrain.Size = new Size(220, 0x16);
            this.menuReplaceTerrain.Text = "替换地形";
            this.menuReplaceTerrain.Click += new EventHandler(this.menuReplaceTerrain_Click_1);
            this.menuScenarioInformation.Name = "menuScenarioInformation";
            this.menuScenarioInformation.Size = new Size(220, 0x16);
            this.menuScenarioInformation.Text = "剧本信息";
            this.menuScenarioInformation.Click += new EventHandler(this.menuScenarioInformation_Click);
            this.menuRegenArchitectureID.Name = "menuRegenArchitectureID";
            this.menuRegenArchitectureID.Size = new Size(220, 0x16);
            this.menuRegenArchitectureID.Text = "重新生成所有建筑ID";
            this.menuRegenArchitectureID.ToolTipText = "从1开始";
            this.menuRegenArchitectureID.Click += new EventHandler(this.menuRegenArchitectureID_Click_1);
            this.设置建筑地形ToolStripMenuItem.Name = "设置建筑地形ToolStripMenuItem";
            this.设置建筑地形ToolStripMenuItem.Size = new Size(220, 0x16);
            this.设置建筑地形ToolStripMenuItem.Text = "设置建筑地形";
            this.设置建筑地形ToolStripMenuItem.Click += new EventHandler(this.设置建筑地形ToolStripMenuItem_Click);
            this.menuHelp.DropDownItems.AddRange(new ToolStripItem[] { this.menuAbout });
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new Size(0x34, 20);
            this.menuHelp.Text = "帮助";
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new Size(0x94, 0x16);
            this.menuAbout.Text = "MapEditor";
            this.menuAbout.Click += new EventHandler(this.menuAbout_Click);
            this.编辑宝物ToolStripMenuItem.Name = "编辑宝物ToolStripMenuItem";
            this.编辑宝物ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑宝物ToolStripMenuItem.Text = "编辑宝物";
            this.编辑宝物ToolStripMenuItem.Click += new EventHandler(this.编辑宝物ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x347, 0x21e);
            base.Controls.Add(this.panelMap);
            base.Controls.Add(this.groupBrushes);
            base.Controls.Add(this.mainMenu);
            base.Margin = new Padding(2);
            base.Name = "formMapEditor";
            this.Text = "剧本编辑器";
            base.WindowState = FormWindowState.Maximized;
            this.panelMap.ResumeLayout(false);
            this.pnlBase.ResumeLayout(false);
            this.cmsEdit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tcEdit.ResumeLayout(false);
            this.tpMap.ResumeLayout(false);
            this.tpArchitecture.ResumeLayout(false);
            this.tpArchitecture.PerformLayout();
            this.groupBrushes.ResumeLayout(false);
            this.groupBrushes.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.LeftMouseButtonDown = true;
                this.pnlMap.DrawShowRegion = true;
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("《中华三国志》剧本编辑器(版本1.0) By clip_on", "关于", MessageBoxButtons.OK);
        }

        private void menuArchitectureAll_CheckStateChanged(object sender, EventArgs e)
        {
            this.menuArchitectureCity.Checked = this.menuArchitectureAll.Checked;
            this.menuArchitectureBlock.Checked = this.menuArchitectureAll.Checked;
            this.menuArchitecturePort.Checked = this.menuArchitectureAll.Checked;
            this.menuArchitectureBarrack.Checked = this.menuArchitectureAll.Checked;
        }

        private void menuArchitectures_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlMap.DisplayCity = this.menuArchitectureCity.Checked;
            this.pnlMap.DisplayBlock = this.menuArchitectureBlock.Checked;
            this.pnlMap.DisplayPort = this.menuArchitecturePort.Checked;
            this.pnlMap.DisplayBarrack = this.menuArchitectureBarrack.Checked;
            this.pnlMap.Invalidate();
        }

        private void menuDisplayGridLine_CheckStateChanged(object sender, EventArgs e)
        {
            this.pnlMap.DisplayGrid = this.menuDisplayGridLine.Checked;
            this.pnlMap.Invalidate();
        }

        private void menuEditArchitecture_Click(object sender, EventArgs e)
        {
            frmArchitectureList list = new frmArchitectureList();
            list.MainForm = this;
            list.Architectures = this.Scenario.Architectures;
            list.ShowDialog();
        }

        private void menuEditFactions_Click(object sender, EventArgs e)
        {
            frmFactionList list = new frmFactionList();
            list.Scenario = this.Scenario;
            list.Factions = this.Scenario.Factions;
            list.ShowDialog();
        }

        private void menuEditMilitary_Click(object sender, EventArgs e)
        {
            frmMilitaryList list = new frmMilitaryList();
            list.Scenario = this.Scenario;
            list.Militaries = this.Scenario.Militaries;
            list.ShowDialog();
        }

        private void menuEditPersons_Click(object sender, EventArgs e)
        {
            frmPersonList list = new frmPersonList();
            list.Persons = this.Scenario.Persons;
            list.MainForm = this;
            list.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出吗？请确认已保存修改后的数据。", "请确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                base.Close();
            }
        }

        private void menuGenerateMapJpg_Click(object sender, EventArgs e)
        {
            int num = 8;
            int num2 = 8;
            Bitmap image = new Bitmap(this.pnlMap.TileCountX * num, this.pnlMap.TileCountY * num2, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            for (int i = 0; i < (this.pnlMap.TileCountX * this.pnlMap.TileCountY); i++)
            {
                int num3 = int.Parse(this.pnlMap.mapDataValueString[i]);
                graphics.DrawImage(this.imageListTerrain.Images[num3], new System.Drawing.Rectangle(num * (i % this.pnlMap.TileCountX), num2 * (i / this.pnlMap.TileCountX), num + (num / 20), num2 + (num2 / 20)));
            }
            image.Save("BackGroundMap.jpg", ImageFormat.Jpeg);
        }

        private void menuOpenScenario_Click(object sender, EventArgs e)
        {
            this.openScenario.InitialDirectory = ".";
            if (this.openScenario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.connectionStringBuilder.DataSource = this.openScenario.FileName;
                this.OpenedFileName = this.openScenario.FileName;
                HintForm form = new HintForm();
                form.SetHint("正在读取……");
                form.Show();
                Application.DoEvents();
                this.Scenario.LoadGameScenarioFromDatabase(this.connectionStringBuilder.ConnectionString);
                this.pnlMap.LoadMapData();
                this.pnlMap.TileWidth = this.pnlMap.Scenario.ScenarioMap.TileWidth;
                this.mtbTileWidth.Text = this.pnlMap.TileWidth.ToString();
                this.mtbWidth.Text = this.Scenario.ScenarioMap.MapDimensions.X.ToString();
                this.mtbHeight.Text = this.Scenario.ScenarioMap.MapDimensions.Y.ToString();
                this.pnlMap.ResetMapPanelSize(1);
                this.pnlMap.StartPaintingMap = true;
                this.pnlMap.SetShowRegion(0, 0, this.pnlBase.Width, this.pnlBase.Height);
                this.pnlMap.Invalidate();
                this.CanSave = true;
                this.menuSaveScenario.Enabled = true;
                this.menuShowErrors.Enabled = true;
                this.menuEdit.Enabled = true;
                form.Close();
            }
        }

        private void menuRegenArchitectureID_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("重新生成所有建筑的ID。（用于自创地图时）", " 请确认", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
            {
                this.pnlMap.ReGenID();
                this.pnlMap.Invalidate();
            }
        }

        private void menuReplaceTerrain_Click_1(object sender, EventArgs e)
        {
            frmReplaceTerrain terrain = new frmReplaceTerrain();
            terrain.Scenario = this.Scenario;
            if (terrain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pnlMap.LoadMapData();
                this.pnlMap.Invalidate();
            }
        }

        private void menuSaveScenario_Click(object sender, EventArgs e)
        {
            if (this.CanSave)
            {
                HintForm form = new HintForm();
                try
                {
                    form.SetHint("正在保存剧本文件……");
                    form.Show();
                    Application.DoEvents();
                    File.Copy(this.OpenedFileName, this.OpenedFileName + ".bak", true);
                    File.Delete(this.OpenedFileName);
                    File.Copy(Application.StartupPath + "/GameData/Common/SaveTemplate.mdb", this.OpenedFileName);
                    this.pnlMap.SaveMapData();
                    this.connectionStringBuilder.DataSource = this.OpenedFileName;
                    this.Scenario.SaveGameScenarioToDatabase(this.connectionStringBuilder.ConnectionString, true, this.Scenario.UsingOwnCommonData);
                    form.Close();
                    File.Delete(this.OpenedFileName + ".bak");
                }
                catch
                {
                    form.Close();
                    File.Copy(this.OpenedFileName + ".bak", this.OpenedFileName, true);
                    File.Delete(this.OpenedFileName + ".bak");
                    MessageBox.Show(this.OpenedFileName + "保存时产生错误，已恢复到修改前的状态。");
                }
                try
                {
                    form = new HintForm();
                    form.SetHint("正在保存一般数据……");
                    form.Show();
                    Application.DoEvents();
                    File.Copy(this.CommonDataFileName, this.CommonDataFileName + ".bak", true);
                    this.connectionStringBuilder.DataSource = this.CommonDataFileName;
                    this.Scenario.GameCommonData.SaveToDatabase(this.connectionStringBuilder.ConnectionString);
                    form.Close();
                    File.Delete(this.CommonDataFileName + ".bak");
                }
                catch
                {
                    form.Close();
                    File.Copy(this.CommonDataFileName + ".bak", this.CommonDataFileName, true);
                    File.Delete(this.CommonDataFileName + ".bak");
                    MessageBox.Show(this.CommonDataFileName + "保存时产生错误，已恢复到修改前的状态。");
                }
            }
        }

        private void menuScenarioInformation_Click(object sender, EventArgs e)
        {
            frmScenarioInformation information = new frmScenarioInformation();
            information.Initialize(this);
            if (information.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void menuShowErrors_Click(object sender, EventArgs e)
        {
            using (TextReader tr = new StreamReader(GameScenario.SCENARIO_ERROR_TEXT_FILE))
            {
                String errors = "";
                int lines = 0;
                while (tr.Peek() >= 0 && lines <= 15)
                {
                    String s = tr.ReadLine();
                    if (s.Trim().Length > 0)
                    {
                        errors += tr.ReadLine() + "\n";
                    }
                    lines++;
                }
                if (errors.Length > 0)
                {
                    if (lines > 15)
                    {
                        errors += "...等错误，完整内容在GameData/ScenarioErrors.txt里。";
                    }
                    MessageBox.Show(errors, "检查剧本");
                }
                else
                {
                    MessageBox.Show("没有发现错误", "检查剧本");
                }
            }
        }

        private void menuTerrainAll_CheckStateChanged(object sender, EventArgs e)
        {
            this.menuTerrainPlain.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainGrassland.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainForest.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainMarsh.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainMountain.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainRiver.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainRidge.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainWasteland.Checked = this.menuTerrainAll.Checked;
            this.menuTerrainDesert.Checked = this.menuTerrainAll.Checked;
        }

        private void menuTerrains_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlMap.DisplayNone = this.menuTerrainNone.Checked;
            this.pnlMap.DisplayPlain = this.menuTerrainPlain.Checked;
            this.pnlMap.DisplayGrassland = this.menuTerrainGrassland.Checked;
            this.pnlMap.DisplayForest = this.menuTerrainForest.Checked;
            this.pnlMap.DisplayMarsh = this.menuTerrainMarsh.Checked;
            this.pnlMap.DisplayMountain = this.menuTerrainMountain.Checked;
            this.pnlMap.DisplayRiver = this.menuTerrainRiver.Checked;
            this.pnlMap.DisplayRidge = this.menuTerrainRidge.Checked;
            this.pnlMap.DisplayWasteland = this.menuTerrainWasteland.Checked;
            this.pnlMap.DisplayDesert = this.menuTerrainDesert.Checked;
            this.pnlMap.Invalidate();
        }

        private void mtbTileWidth_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            try
            {
                num = int.Parse(this.mtbTileWidth.Text);
            }
            catch
            {
                num = 0;
            }
            if (num >= 10)
            {
                this.pnlMap.TileWidth = num;
                this.pnlMap.ResetMapPanelSize(1);
                this.pnlMap.Invalidate();
            }
        }

        private void pnlBase_Scroll(object sender, ScrollEventArgs e)
        {
            if ((this.oldhorizontalscrollvalue != this.pnlBase.HorizontalScroll.Value) || (this.oldverticalscrollvalue != this.pnlBase.VerticalScroll.Value))
            {
                this.pnlMap.SetShowRegion(this.pnlBase.HorizontalScroll.Value, this.pnlBase.VerticalScroll.Value, this.pnlBase.Width, this.pnlBase.Height);
                this.pnlMap.Invalidate();
                this.oldhorizontalscrollvalue = this.pnlBase.HorizontalScroll.Value;
                this.oldverticalscrollvalue = this.pnlBase.VerticalScroll.Value;
            }
        }

        private void pnlMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.CurrentArchitecture = this.pnlMap.GetArchitectureByMouse(e.X, e.Y);
                    if (this.CurrentArchitecture != null)
                    {
                        this.cmsEdit.Show();
                    }
                }
                return;
            }
            if (!this.MoveTo)
            {
                string text = this.tcEdit.SelectedTab.Text;
                if (text != null)
                {
                    if (!(text == "地形"))
                    {
                        if (text == "建筑")
                        {
                            switch (this.CurrentKind)
                            {
                                case EditKind.选中:
                                    this.CurrentArchitecture = this.pnlMap.GetArchitectureByMouse(e.X, e.Y);
                                    break;

                                case EditKind.新增:
                                    this.CurrentArchitecture = this.pnlMap.AddArchitecture(e.X, e.Y, this.ArchitectureIndex);
                                    break;

                                case EditKind.増筑:
                                    if (this.TargetArchitecture != null)
                                    {
                                        if (this.pnlMap.ChangeArchitectureData(this.TargetArchitecture, e.X, e.Y))
                                        {
                                            this.lbConment.Text = "已増筑" + this.TargetArchitecture.ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.TargetArchitecture = this.CurrentArchitecture;
                                        this.lbConment.Text = "已选中" + this.TargetArchitecture.ToString();
                                    }
                                    break;

                                case EditKind.删除:
                                    if (this.pnlMap.DeleteArchitecture(e.X, e.Y, this.cbDeleteWholeArchitecture.Checked))
                                    {
                                        this.lbConment.Text = "删除成功。";
                                    }
                                    break;

                                case EditKind.陆上:
                                    if (this.TargetArchitecture != null)
                                    {
                                        if (((this.CurrentArchitecture != null) && (this.CurrentArchitecture != this.TargetArchitecture)) && (this.TargetArchitecture.AILandLinks.GetGameObject(this.CurrentArchitecture.ID) == null))
                                        {
                                            this.TargetArchitecture.AILandLinks.Add(this.CurrentArchitecture);
                                            if (this.CurrentArchitecture.AILandLinks.GetGameObject(this.TargetArchitecture.ID) == null)
                                            {
                                                this.CurrentArchitecture.AILandLinks.Add(this.TargetArchitecture);
                                            }
                                            this.lbConment.Text = "已链接陆上増筑 " + this.CurrentArchitecture.ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.TargetArchitecture = this.CurrentArchitecture;
                                        this.lbConment.Text = "已选中" + this.TargetArchitecture.ToString();
                                    }
                                    break;

                                case EditKind.水上:
                                    if (this.TargetArchitecture != null)
                                    {
                                        if (((this.CurrentArchitecture != null) && (this.CurrentArchitecture != this.TargetArchitecture)) && (this.TargetArchitecture.AIWaterLinks.GetGameObject(this.CurrentArchitecture.ID) == null))
                                        {
                                            this.TargetArchitecture.AIWaterLinks.Add(this.CurrentArchitecture);
                                            if (this.CurrentArchitecture.AIWaterLinks.GetGameObject(this.TargetArchitecture.ID) == null)
                                            {
                                                this.CurrentArchitecture.AIWaterLinks.Add(this.TargetArchitecture);
                                            }
                                            this.lbConment.Text = "已链接水上増筑 " + this.CurrentArchitecture.ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.TargetArchitecture = this.CurrentArchitecture;
                                        this.lbConment.Text = "已选中" + this.TargetArchitecture.ToString();
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.pnlMap.ChangeMapData(e.X, e.Y, this.TerrainIndex, int.Parse(this.mtbPenWidth.Text), this.cbHorizontal.Checked);
                        this.lbConment.Text = "请不要放开鼠标左键，拖动鼠标以修改鼠标经过的地形。";
                    }
                }
            }
        //Label_03FC:
            this.LeftMouseButtonDown = true;
        }

        private void pnlMap_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbCoord.Text = this.pnlMap.GetCoordString(e.X, e.Y);
            this.CurrentArchitecture = this.pnlMap.GetArchitectureByMouse(e.X, e.Y);
            string text = this.tcEdit.SelectedTab.Text;
            if (text != null)
            {
                if (!(text == "地形"))
                {
                    if (text == "建筑")
                    {
                    }
                }
                else if (this.LeftMouseButtonDown)
                {
                    this.pnlMap.ChangeMapData(e.X, e.Y, this.TerrainIndex, int.Parse(this.mtbPenWidth.Text), this.cbHorizontal.Checked);
                }
            }
            if (this.CurrentArchitecture != null)
            {
                this.lbConment.Text = this.CurrentArchitecture.ToString() + " (右键点击编辑其属性)";
            }
            else
            {
                this.lbConment.Text = "";
            }
        }

        private void pnlMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.LeftMouseButtonDown)
                {
                    this.pnlMap.Invalidate();
                }
                this.LeftMouseButtonDown = false;
                if (this.MoveTo)
                {
                    this.MoveTo = false;
                    this.pnlMap.Cursor = Cursors.Default;
                }
                this.lbConment.Text = "";
            }
        }

        private void ReloadArchitectures()
        {
            OleDbConnection connection = new OleDbConnection(this.connectionStringBuilder.ConnectionString);
            OleDbCommand command = new OleDbCommand("Select * From Architecture", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            this.pnlMap.Architectures.Clear();
            while (reader.Read())
            {
                Architecture t = new Architecture();
                t.Scenario = this.Scenario;
                t.ID = (short) reader["ID"];
                t.Name = reader["Name"].ToString();
                t.Kind = this.Scenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind((short) reader["Kind"]);
                StaticMethods.LoadFromString(t.ArchitectureArea.Area, reader["Area"].ToString());
                this.pnlMap.Architectures.Add(t);
            }
            connection.Close();
        }

        private void 编辑宝物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTreasureList list = new frmTreasureList();
            list.Scenario = this.Scenario;
            list.ShowDialog();
        }

        private void 编辑部队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroopList list = new frmTroopList();
            list.Scenario = this.Scenario;
            list.ShowDialog();
        }

        private void 编辑部队事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroopEventList list = new frmTroopEventList();
            list.MainForm = this;
            list.ShowDialog();
        }

        private void 编辑地区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegionList list = new frmRegionList();
            list.Scenario = this.Scenario;
            list.ShowDialog();
        }

        private void 编辑州域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStateList list = new frmStateList();
            list.Scenario = this.Scenario;
            list.ShowDialog();
        }

        private void 初始化剧本只保留人物列表ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("初始化剧本，将删除所有势力、设施、和编队等信息，只保留人物列表、建筑列表、州域地区信息和地形数据。用于新编剧本。确定执行吗？", "请确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Scenario.Factions.Clear();
                this.Scenario.Sections.Clear();
                this.Scenario.Legions.Clear();
                this.Scenario.Troops.Clear();
                this.Scenario.Militaries.Clear();
                this.Scenario.Captives.Clear();
                this.Scenario.Facilities.Clear();
                this.Scenario.Informations.Clear();
                //this.Scenario.SpyMessages.Clear();
                this.Scenario.Routeways.Clear();
                this.Scenario.PlayerFactions.Clear();
                this.Scenario.FireTable.Clear();
                this.Scenario.NoFoodDictionary.Clear();
                this.Scenario.DiplomaticRelations.Clear();
                this.Scenario.CurrentFaction = null;
                this.Scenario.CurrentPlayer = null;
                foreach (Architecture architecture in this.Scenario.Architectures)
                {
                    architecture.Militaries.Clear();
                    architecture.Facilities.Clear();
                    architecture.BelongedSection = null;
                    architecture.BelongedFaction = null;
                }
                foreach (Person person in this.Scenario.Persons)
                {
                    person.Available = false;
                    person.SetBelongedCaptive(null, GameObjects.PersonDetail.PersonStatus.None);
                    person.LocationArchitecture = null;
                    person.LocationTroop = null;
                }
                foreach (GameObjects.ArchitectureDetail.State state in this.Scenario.States)
                {
                    state.Architectures.Clear();
                    state.StateAdmin = null;
                    state.StateAdminID = -1;
                }
                foreach (GameObjects.ArchitectureDetail.Region region in this.Scenario.Regions)
                {
                    region.Architectures.Clear();
                    region.RegionCore = null;
                    region.RegionCoreID = -1;
                }
            }
        }

        private void 删除所有建筑ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除所有建筑。确定执行吗？", "请确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Scenario.Architectures.Clear();
                foreach (Person person in this.Scenario.Persons)
                {
                    if (person.LocationArchitecture != null)
                    {
                        person.Available = false;
                        person.SetBelongedCaptive(null, GameObjects.PersonDetail.PersonStatus.None);
                        person.LocationArchitecture = null;
                    }
                }
                this.pnlMap.Invalidate();
            }
        }

        private void 设置建筑地形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("设置建筑的地形，港口的地形将被设置为水域，而其他的建筑地形将被设置为平原。", " 请确认", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.No)
            {
                foreach (Architecture architecture in this.Scenario.Architectures)
                {
                    if (architecture.Kind.HasHarbor)
                    {
                        foreach (Microsoft.Xna.Framework.Point point in architecture.ArchitectureArea.Area)
                        {
                            this.Scenario.ScenarioMap.MapData[point.X, point.Y] = 6;
                        }
                    }
                    else
                    {
                        foreach (Microsoft.Xna.Framework.Point point in architecture.ArchitectureArea.Area)
                        {
                            this.Scenario.ScenarioMap.MapData[point.X, point.Y] = 1;
                        }
                    }
                }
                this.pnlMap.LoadMapData();
                this.pnlMap.Invalidate();
            }
        }

        public GameScenario Scenario
        {
            get
            {
                return this.pnlMap.Scenario;
            }
        }
    }
}

