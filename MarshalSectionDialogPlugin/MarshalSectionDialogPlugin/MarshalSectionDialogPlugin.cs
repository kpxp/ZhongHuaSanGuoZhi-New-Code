namespace MarshalSectionDialogPlugin
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

    public class MarshalSectionDialogPlugin : GameObject, IMarshalSectionDialog, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\MarshalSectionDialog\Data\";
        private string description = "编组军区对话框";
        private GraphicsDevice graphicsDevice;
        private MarshalSectionDialog marshalSectionDialog = new MarshalSectionDialog();
        private const string Path = @"GameComponents\MarshalSectionDialog\";
        private string pluginName = "MarshalSectionDialogPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "MarshalSectionDialogData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsShowing)
            {
                this.marshalSectionDialog.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.marshalSectionDialog.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.marshalSectionDialog.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            node = nextSibling.ChildNodes.Item(1);
            for (int i = 0; i < node.ChildNodes.Count; i += 2)
            {
                Font font;
                Microsoft.Xna.Framework.Graphics.Color color;
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
                this.marshalSectionDialog.LabelTexts.Add(item);
            }
            node = nextSibling.ChildNodes.Item(2);
            this.marshalSectionDialog.OKButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.OKButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.marshalSectionDialog.OKButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.marshalSectionDialog.OKButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.marshalSectionDialog.OKButtonDisplayTexture = this.marshalSectionDialog.OKButtonDisabledTexture;
            node = nextSibling.ChildNodes.Item(3);
            this.marshalSectionDialog.CancelButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.CancelButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.marshalSectionDialog.CancelButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.marshalSectionDialog.CancelButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.marshalSectionDialog.CancelButtonDisplayTexture = this.marshalSectionDialog.CancelButtonTexture;
            node = nextSibling.ChildNodes.Item(4);
            this.marshalSectionDialog.ArchitectureListButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.ArchitectureListButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.marshalSectionDialog.ArchitectureListButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.marshalSectionDialog.ArchitectureListButtonDisplayTexture = this.marshalSectionDialog.ArchitectureListButtonTexture;
            node = nextSibling.ChildNodes.Item(5);
            this.marshalSectionDialog.AIDetailButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.AIDetailButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.marshalSectionDialog.AIDetailButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.marshalSectionDialog.AIDetailButtonDisplayTexture = this.marshalSectionDialog.AIDetailButtonTexture;
            node = nextSibling.ChildNodes.Item(6);
            this.marshalSectionDialog.OrientationButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.marshalSectionDialog.OrientationButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.marshalSectionDialog.OrientationButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\MarshalSectionDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.marshalSectionDialog.OrientationButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.marshalSectionDialog.OrientationButtonDisplayTexture = this.marshalSectionDialog.OrientationButtonDisabledTexture;
        }

        public void SetFaction(object faction)
        {
            this.marshalSectionDialog.SetFaction(faction as Faction);
        }

        public void SetGameFrame(IGameFrame iGameFrame)
        {
            this.marshalSectionDialog.GameFramePlugin = iGameFrame;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\MarshalSectionDialog\MarshalSectionDialogData.xml");
        }

        public void SetMapPosition(ShowPosition showPosition)
        {
            this.marshalSectionDialog.SetDisplayOffset(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.marshalSectionDialog.Initialize(screen as Screen);
        }

        public void SetSection(object section)
        {
            this.marshalSectionDialog.SetSection(section as Section);
        }

        public void SetTabList(ITabList iTabList)
        {
            this.marshalSectionDialog.TabListPlugin = iTabList;
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
                return this.marshalSectionDialog.IsShowing;
            }
            set
            {
                this.marshalSectionDialog.IsShowing = value;
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

