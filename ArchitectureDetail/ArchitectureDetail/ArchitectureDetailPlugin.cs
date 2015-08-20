namespace ArchitectureDetail
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

    public class ArchitectureDetailPlugin : GameObject, IArchitectureDetail, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private ArchitectureDetail architectureDetail = new ArchitectureDetail();
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\ArchitectureDetail\Data\";
        private string description = "建筑细节显示";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\ArchitectureDetail\";
        private string pluginName = "ArchitectureDetailPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "ArchitectureDetailData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.architectureDetail.IsShowing)
            {
                this.architectureDetail.Draw(spriteBatch);
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
            this.architectureDetail.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureDetail.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureDetail.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            for (int i = 0; i < node.ChildNodes.Count; i += 2)
            {
                LabelText item = new LabelText();
                XmlNode node3 = node.ChildNodes.Item(i);
                Microsoft.Xna.Framework.Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Label = new FreeText(this.graphicsDevice, font, color);
                item.Label.Position = rectangle;
                item.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
                node3 = node.ChildNodes.Item(i + 1);
                rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Text = new FreeText(this.graphicsDevice, font, color);
                item.Text.Position = rectangle;
                item.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
                this.architectureDetail.LabelTexts.Add(item);
            }
            node = nextSibling.ChildNodes.Item(2);
            this.architectureDetail.CharacteristicClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureDetail.CharacteristicText.ClientWidth = this.architectureDetail.CharacteristicClient.Width;
            this.architectureDetail.CharacteristicText.ClientHeight = this.architectureDetail.CharacteristicClient.Height;
            this.architectureDetail.CharacteristicText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.architectureDetail.CharacteristicText.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.architectureDetail.CharacteristicText.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureDetail.CharacteristicText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.architectureDetail.CharacteristicText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(3);
            this.architectureDetail.FacilityClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureDetail.FacilityText.ClientWidth = this.architectureDetail.FacilityClient.Width;
            this.architectureDetail.FacilityText.ClientHeight = this.architectureDetail.FacilityClient.Height;
            this.architectureDetail.FacilityText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.architectureDetail.FacilityText.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.architectureDetail.FacilityText.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            this.architectureDetail.FacilityText.SubTitleColor2 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor2").Value);
            this.architectureDetail.FacilityText.SubTitleColor3 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor3").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureDetail.FacilityText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.architectureDetail.FacilityText.DefaultColor = color;
        }

        public void SetArchitecture(object architecture)
        {
            this.architectureDetail.SetArchitecture(architecture as Architecture);
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\ArchitectureDetail\ArchitectureDetailData.xml");
        }

        public void SetPosition(ShowPosition showPosition)
        {
            this.architectureDetail.SetPosition(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.architectureDetail.Initialize(screen as Screen);
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
                return this.architectureDetail.IsShowing;
            }
            set
            {
                this.architectureDetail.IsShowing = value;
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

