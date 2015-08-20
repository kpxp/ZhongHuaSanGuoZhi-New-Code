namespace BianduiLiebiaoChajian
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class TabListPlugin : GameObject, IBianduiLiebiao, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\BianduiLiebiao\Data\";
        private string description = "可选择类别的详细列表";
        private const string Path = @"GameComponents\BianduiLiebiao\";
        private string pluginName = "BianduiLiebiaoChajian";
        private TabListInFrame tabList = new TabListInFrame();
        private string version = "1.0.1";
        private const string XMLFilename = "BianduiLiebiaoChajian.xml";

        public void ShezhiBingyi(int bingyi)
        {
            this.tabList.Bingyi = bingyi;
        }

        public Microsoft.Xna.Framework.Rectangle Weizhi
        {
            get
            {
                return new Microsoft.Xna.Framework.Rectangle(this.tabList.backgroundRectangle.X - this.tabList.leftedgeWidth, this.tabList.backgroundRectangle.Y - this.tabList.topedgeRectangle.Height,
                    this.tabList.backgroundRectangle.Width + this.tabList.leftedgeWidth + this.tabList.rightedgeWidth, this.tabList.backgroundRectangle.Height
                    + this.tabList.bottomedgeRectangle.Height + this.tabList.topedgeRectangle.Height);
            }
        }

        public FrameFunction Function
        {
            get
            {
                return this.tabList.Function;
            }
            set
            {
                this.tabList.Function = value;
            }
        }

        public FrameKind Kind
        {
            get;
            set;
            /*
            get
            {
                return this.tabList.Kind;
            }
            set
            {
                this.tabList.Kind = value;
            }*/
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.tabList.Draw(spriteBatch);
        }

        public void Initialize()
        {
        }

        public void InitialValues(object gameObjectList, object selectedObjectList, int scrollValue, string title)
        {
            this.tabList.InitialValues(gameObjectList as GameObjectList, selectedObjectList as GameObjectList, scrollValue, title);
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;

            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.tabList.leftedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.leftedgeTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.tabList.rightedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.rightedgeTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.tabList.topedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.topedgeTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(3);
            this.tabList.bottomedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.bottomedgeTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.tabList.backgroundTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            





            node = nextSibling.ChildNodes.Item(5);
            this.tabList.ToolTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.ToolSelectedTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.tabList.ToolDisplayTexture = this.tabList.ToolSelectedTexture;
            this.tabList.ToolPosition = StaticMethods.LoadRectangleFromXMLNode(node);


            node = nextSibling.ChildNodes.Item(6);
            this.tabList.tabbuttonWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.tabbuttonHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.tabbuttonTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.tabbuttonselectedTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.tabList.columnheaderHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.columnheaderTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.tabList.columnspliterWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.columnspliterHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.columnspliterTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.tabList.scrollbuttonWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.scrollbuttonTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(10);
            this.tabList.scrolltrackWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.scrolltrackTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(11);
            this.tabList.leftArrowTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("LeftFileName").Value);
            this.tabList.rightArrowTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("RightFileName").Value);
            node = nextSibling.ChildNodes.Item(12);
            this.tabList.focusTrackTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(13);
            this.tabList.checkboxName = node.Attributes.GetNamedItem("Name").Value;
            this.tabList.checkboxDisplayName = node.Attributes.GetNamedItem("DisplayName").Value;
            this.tabList.checkboxWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.checkboxTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.checkboxSelectedTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            this.tabList.roundcheckboxTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("RoundFileName").Value);
            this.tabList.roundcheckboxSelectedTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("RoundSelectedFileName").Value);
            node = nextSibling.ChildNodes.Item(14);
            this.tabList.PortraitWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.PortraitHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            node = nextSibling.ChildNodes.Item(15);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.tabList.TabTextBuilder.SetFreeTextBuilder(this.tabList.graphicsDevice, font);
            this.tabList.TabTextColor = color;
            this.tabList.TabTextAlign = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(16);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.tabList.ColumnTextBuilder.SetFreeTextBuilder(this.tabList.graphicsDevice, font);
            this.tabList.ColumnTextColor = color;
            this.tabList.ColumnTextAlign = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(17);
            this.tabList.SelectSoundFile = @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("Select").Value;
            node = nextSibling.ChildNodes.Item(18);
            this.tabList.TopLeftPosition.X  = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.tabList.TopLeftPosition.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);

            node = nextSibling.ChildNodes.Item(19);
            //this.gameFrame.TopLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.TopLeftTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(20);
            //this.gameFrame.TopRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.TopRightTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(21);
            //this.gameFrame.BottomLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.BottomLeftTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(22);
            //this.gameFrame.BottomRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.BottomRightTexture = Texture2D.FromFile(this.tabList.graphicsDevice, @"GameComponents\BianduiLiebiao\Data\" + node.Attributes.GetNamedItem("FileName").Value);




            this.tabList.LoadFromXMLNode(nextSibling.ChildNodes.Item(23));
        }

        public void RefreshEditable()
        {
            this.tabList.RefreshEditable();
        }

        public void SetArchitectureDetailDialog(IArchitectureDetail iArchitectureDetail)
        {
            this.tabList.iArchitectureDetail = iArchitectureDetail;
        }

        public void SetFactionTechniquesDialog(IFactionTechniques iFactionTechniques)
        {
            this.tabList.iFactionTechniques = iFactionTechniques;
        }

        public void SetGameFrame(IGameFrame iGameFrame)
        {
            this.tabList.iGameFrame = iGameFrame;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.tabList.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\BianduiLiebiao\BianduiLiebiaoChajian.xml");
        }

        public void SetListKindByName(string Name, bool ShowCheckBox, bool MultiSelecting)
        {
            this.tabList.SetListKindByName(Name, ShowCheckBox, MultiSelecting);
        }

        public void SetMapViewSelector(IMapViewSelector iMapViewSelector)
        {
            this.tabList.iMapViewSelector = iMapViewSelector;
            //iMapViewSelector.SetTabList(this);
        }

        public void SetPersonDetailDialog(IPersonDetail iPersonDetail)
        {
            this.tabList.iPersonDetail = iPersonDetail;
        }

        public void SetScreen(object screen)
        {
            this.tabList.Initialize(screen as Screen);
        }

        public void SetSelectedItemMaxCount(int max)
        {
            this.tabList.SelectedItemMaxCount = max;
        }

        public void SetSelectedTab(string tabName)
        {
            this.tabList.SetSelectedTab(tabName);
        }

        public void SetTreasureDetailDialog(ITreasureDetail iTreasureDetail)
        {
            this.tabList.iTreasureDetail = iTreasureDetail;
        }

        public void SetTroopDetailDialog(ITroopDetail iTroopDetail)
        {
            this.tabList.iTroopDetail = iTroopDetail;
        }

        public void Update(GameTime gameTime)
        {
            this.tabList.ReCalculate();
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.tabList.IsShowing;
            }
            set
            {
                this.tabList.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public object SelectedItem
        {
            get
            {
                return this.tabList.SelectedItem;
            }
        }

        public object SelectedItemList
        {
            get
            {
                return this.tabList.SelectedItemList;
            }
        }

        public object TabList
        {
            get
            {
                return this.tabList;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }


        public void SetyoucelanContent(Microsoft.Xna.Framework.Point viewportSize)
        {
            //if (content is FrameContent)
            //{
            this.tabList.SetyoucelanContent(viewportSize);
            //}
        }
    }
}

