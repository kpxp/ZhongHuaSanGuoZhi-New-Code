namespace TransportDialogPlugin
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

    public class TransportDialogPlugin : GameObject, ITransportDialog, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\TransportDialog\Data\";
        private string description = "运输对话框";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\TransportDialog\";
        private string pluginName = "TransportDialogPlugin";
        private TransportDialog transportDialog = new TransportDialog();
        private string version = "1.0.1";
        private const string XMLFilename = "TransportDialogData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsShowing)
            {
                this.transportDialog.Draw(spriteBatch);
            }
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
            this.transportDialog.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.transportDialog.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            node = nextSibling.ChildNodes.Item(1);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.TitleText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.TitleText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(2);
            for (int i = 0; i < node.ChildNodes.Count; i += 2)
            {
                LabelText item = new LabelText();
                XmlNode node3 = node.ChildNodes.Item(i);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Label = new FreeText(this.graphicsDevice, font, color);
                item.Label.Position = StaticMethods.LoadRectangleFromXMLNode(node3);
                item.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
                node3 = node.ChildNodes.Item(i + 1);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Text = new FreeText(this.graphicsDevice, font, color);
                item.Text.Position = StaticMethods.LoadRectangleFromXMLNode(node3);
                item.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
                this.transportDialog.LabelTexts.Add(item);
            }

            node = nextSibling.ChildNodes.Item(3);
            this.transportDialog.DestinationButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.DestinationButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.DestinationButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.DestinationButtonDisplayTexture = this.transportDialog.DestinationButtonTexture;
            node = nextSibling.ChildNodes.Item(4);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.DestinationText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.DestinationText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.DestinationText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.transportDialog.InputNumberButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.InputNumberButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.InputNumberButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.InputNumberButtonDisplayTexture = this.transportDialog.InputNumberButtonTexture;
            node = nextSibling.ChildNodes.Item(6);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.InputNumberText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.InputNumberText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.InputNumberText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(7);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.DestinationCommentText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.DestinationCommentText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.DestinationCommentText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.transportDialog.StartButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.StartButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.StartButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.transportDialog.StartButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.StartButtonDisplayTexture = this.transportDialog.StartButtonDisabledTexture;

            node = nextSibling.ChildNodes.Item(9);
            this.transportDialog.EmperorDestinationButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.EmperorDestinationButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.EmperorDestinationButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorDestinationButtonDisplayTexture = this.transportDialog.EmperorDestinationButtonTexture;
            node = nextSibling.ChildNodes.Item(10);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.EmperorDestinationText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.EmperorDestinationText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorDestinationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(11);
            this.transportDialog.EmperorInputNumberButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.EmperorInputNumberButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.EmperorInputNumberButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorInputNumberButtonDisplayTexture = this.transportDialog.EmperorInputNumberButtonTexture;
            node = nextSibling.ChildNodes.Item(12);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.EmperorInputNumberText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.EmperorInputNumberText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorInputNumberText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(13);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.EmperorDestinationCommentText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.EmperorDestinationCommentText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorDestinationCommentText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(14);
            this.transportDialog.EmperorStartButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.EmperorStartButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.EmperorStartButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.transportDialog.EmperorStartButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.EmperorStartButtonDisplayTexture = this.transportDialog.EmperorStartButtonDisabledTexture;

            node = nextSibling.ChildNodes.Item(15);
            this.transportDialog.FundDestinationButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.FundDestinationButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.FundDestinationButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundDestinationButtonDisplayTexture = this.transportDialog.FundDestinationButtonTexture;
            node = nextSibling.ChildNodes.Item(16);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.FundDestinationText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.FundDestinationText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundDestinationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(17);
            this.transportDialog.FundInputNumberButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.FundInputNumberButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.FundInputNumberButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundInputNumberButtonDisplayTexture = this.transportDialog.FundInputNumberButtonTexture;
            node = nextSibling.ChildNodes.Item(18);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.FundInputNumberText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.FundInputNumberText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundInputNumberText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(19);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.transportDialog.FundDestinationCommentText = new FreeText(this.graphicsDevice, font, color);
            this.transportDialog.FundDestinationCommentText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundDestinationCommentText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(20);
            this.transportDialog.FundStartButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.transportDialog.FundStartButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.transportDialog.FundStartButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TransportDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.transportDialog.FundStartButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.transportDialog.FundStartButtonDisplayTexture = this.transportDialog.FundStartButtonDisabledTexture;
        }

        public void SetGameFrame(IGameFrame iGameFrame)
        {
            this.transportDialog.GameFramePlugin = iGameFrame;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\TransportDialog\TransportDialogData.xml");
        }

        public void SetKind(TransportKind kind)
        {
            this.transportDialog.SetKind(kind);
        }

        public void SetMapPosition(ShowPosition showPosition)
        {
            this.transportDialog.SetDisplayOffset(showPosition);
        }

        public void SetNumberInputer(INumberInputer iNumberInputer)
        {
            this.transportDialog.NumberInputerPlugin = iNumberInputer;
        }

        public void SetGameRecord(IGameRecord iGameRecord)
        {
            this.transportDialog.GameRecordPlugin = iGameRecord;
        }

        public void SetScreen(object screen)
        {
            this.transportDialog.Initialize(screen as Screen);
        }

        public void SetSourceArchiecture(object architecture)
        {
            this.transportDialog.SetSourceArchiecture(architecture as Architecture);
        }

        public void SetTabList(ITabList iTabList)
        {
            this.transportDialog.TabListPlugin = iTabList;
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
                return this.transportDialog.IsShowing;
            }
            set
            {
                this.transportDialog.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

