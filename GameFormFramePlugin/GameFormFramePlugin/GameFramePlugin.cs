namespace GameFormFramePlugin
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

    public class GameFramePlugin : GameObject, IGameFrame, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\GameFrame\Data\";
        private string description = "窗体的框架";
        private GameFrame gameFrame = new GameFrame();
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\GameFrame\";
        private string pluginName = "GameFramePlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "GameFrameData.xml";

        public void Cancel()
        {
            this.gameFrame.DoCancel();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.gameFrame.Draw(spriteBatch);
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.gameFrame.leftedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.leftedgeTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.gameFrame.rightedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.rightedgeTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.gameFrame.topedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.topedgeTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(3);
            this.gameFrame.bottomedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.bottomedgeTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.gameFrame.backgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.gameFrame.okbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.okbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame.okbuttonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame.okbuttonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame.okbuttonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame.okbuttonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(6);
            this.gameFrame.cancelbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.cancelbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame.cancelbuttonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame.cancelbuttonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame.cancelbuttonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame.cancelbuttonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.gameFrame.titleWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.titleHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame.titleTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.gameFrame.TitleText = new FreeText(this.graphicsDevice, font, color);
            this.gameFrame.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.gameFrame.OKSoundFile = @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("OK").Value;
            this.gameFrame.CancelSoundFile = @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Cancel").Value;
            node = nextSibling.ChildNodes.Item(9);
            this.gameFrame.mapviewselectorbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.mapviewselectorbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame.MapViewSelectorButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame.MapViewSelectorButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);


            node = nextSibling.ChildNodes.Item(10);
            //this.gameFrame.TopLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.TopLeftTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(11);
            //this.gameFrame.TopRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.TopRightTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(12);
            //this.gameFrame.BottomLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.BottomLeftTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(13);
            //this.gameFrame.BottomRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.BottomRightTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            /*
            node = nextSibling.ChildNodes.Item(14);
            this.gameFrame.selectallbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame.selectallbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame.selectallbuttonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame.selectallbuttonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame.selectallbuttonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame.selectallbuttonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\GameFrame\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
             */
        }

        public void OK()
        {
            this.gameFrame.DoOK();
        }
        /*
        public void SelectAll()
        {
            this.gameFrame.DoSelectAll();
        }
        
        public void SetSelectAllFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame.SetSelectAllFunction(function);
        }
        */
        public void SetCancelFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame.SetCancelFunction(function);
        }

        public void SetFrameContent(object content, Microsoft.Xna.Framework.Point viewportSize)
        {
            if (content is FrameContent)
            {
                this.gameFrame.SetFrameContent(content as FrameContent, viewportSize);
            }
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\GameFrame\GameFrameData.xml");
        }

        public void SetOKFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame.SetOKFunction(function);
        }

        public void SetScreen(object screen)
        {
            this.gameFrame.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public bool CancelButtonEnabled
        {
            get
            {
                return this.gameFrame.CancelButtonEnabled;
            }
            set
            {
                this.gameFrame.CancelButtonEnabled = value;
            }
        }
        /*
        public bool SelectAllButtonEnabled
        {
            get
            {
                return this.gameFrame.SelectAllButtonEnabled;
            }
            set
            {
                this.gameFrame.SelectAllButtonEnabled = value;
            }
        }
        */
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public FrameFunction Function
        {
            get
            {
                return this.gameFrame.Function;
            }
            set
            {
                this.gameFrame.Function = value;
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
                return this.gameFrame.IsShowing;
            }
            set
            {
                this.gameFrame.IsShowing = value;
            }
        }

        public FrameKind Kind
        {
            get
            {
                return this.gameFrame.Kind;
            }
            set
            {
                this.gameFrame.Kind = value;
            }
        }

        public bool OKButtonEnabled
        {
            get
            {
                return this.gameFrame.OKButtonEnabled;
            }
            set
            {
                this.gameFrame.OKButtonEnabled = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public FrameResult Result
        {
            get
            {
                return this.gameFrame.Result;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }

        public int LeftEdge
        {
            get
            {
                return this.gameFrame.leftedgeWidth;
            }
        }

        public int RightEdge
        {
            get
            {
                return this.gameFrame.rightedgeWidth;
            }
        }

        public int TopEdge
        {
            get
            {
                return this.gameFrame.topedgeWidth;
            }
        }

        public int BottomEdge
        {
            get
            {
                return this.gameFrame.bottomedgeWidth;
            }
        }
    }
}

