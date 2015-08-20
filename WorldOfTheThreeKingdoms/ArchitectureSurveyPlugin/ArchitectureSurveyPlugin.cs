using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using GameGlobal;
using GameFreeText;
using GameObjects;
using PluginInterface;
using PluginInterface.BaseInterface;


namespace ArchitectureSurveyPlugin
{
    public class ArchitectureSurveyPlugin : GameObject, IArchitectureSurvey, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private ArchitectureSurvey architectureSurvey = new ArchitectureSurvey();
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\ArchitectureSurvey\Data\";
        private string description = "用来显示建筑概况窗口的各个属性";
        private bool enableUpdate;
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\ArchitectureSurvey\";
        private string pluginName = "ArchitectureSurveyPlugin";
        private bool showing;
        private string version = "1.0.1";
        private const string XMLFilename = "ArchitectureSurveyData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Showing)
            {
                this.architectureSurvey.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            System.Drawing.Font font;
            Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.architectureSurvey.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.BackgroundSize = new Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(1);
            this.architectureSurvey.FactionTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.FactionPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.NameText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.NameText.Position = rectangle;
            this.architectureSurvey.NameText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(3);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.KindText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.KindText.Position = rectangle;
            this.architectureSurvey.KindText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(4);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FactionText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FactionText.Position = rectangle;
            this.architectureSurvey.FactionText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(5);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.PopulationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.PopulationText.Position = rectangle;
            this.architectureSurvey.PopulationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(6);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.ArmyText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.ArmyText.Position = rectangle;
            this.architectureSurvey.ArmyText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(7);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.DominationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.DominationText.Position = rectangle;
            this.architectureSurvey.DominationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(8);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.EnduranceText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.EnduranceText.Position = rectangle;
            this.architectureSurvey.EnduranceText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.architectureSurvey.ControllingBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.ControllingBackgroundSize = new Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(10);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FundText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FundText.Position = rectangle;
            this.architectureSurvey.FundText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(11);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FoodText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FoodText.Position = rectangle;
            this.architectureSurvey.FoodText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(12);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.PersonCountText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.PersonCountText.Position = rectangle;
            this.architectureSurvey.PersonCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(13);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.NoFactionPersonCountText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.NoFactionPersonCountText.Position = rectangle;
            this.architectureSurvey.NoFactionPersonCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(14);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.AgricultureText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.AgricultureText.Position = rectangle;
            this.architectureSurvey.AgricultureText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(15);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.CommerceText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.CommerceText.Position = rectangle;
            this.architectureSurvey.CommerceText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(0x10);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.TechnologyText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.TechnologyText.Position = rectangle;
            this.architectureSurvey.TechnologyText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(0x11);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.MoraleText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.MoraleText.Position = rectangle;
            this.architectureSurvey.MoraleText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            
            node = nextSibling.ChildNodes.Item(18);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.MilitaryPopulationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.MilitaryPopulationText.Position = rectangle;
            this.architectureSurvey.MilitaryPopulationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(19);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FacilityCountText  = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FacilityCountText.Position = rectangle;
            this.architectureSurvey.FacilityCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

        }

        public void SetArchitecture(object architecture, Point position)
        {
            this.enableUpdate = this.architectureSurvey.ArchitectureToSurvey != architecture;
            this.architectureSurvey.ArchitectureToSurvey = architecture as Architecture;
            this.architectureSurvey.CurrentPosition = position;
        }

        public void SetFaction(object faction)
        {
            this.architectureSurvey.ViewingFaction = faction as Faction;
            if (this.architectureSurvey.ViewingFaction != null)
            {
                InformationLevel knownAreaData = this.architectureSurvey.ViewingFaction.GetKnownAreaData(this.architectureSurvey.CurrentPosition);
                this.enableUpdate = this.enableUpdate || (this.architectureSurvey.Level != knownAreaData);
                this.architectureSurvey.Level = knownAreaData;
            }
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\ArchitectureSurvey\ArchitectureSurveyData.xml");
        }

        public void SetTopLeftPoint(int Left, int Top)
        {
            this.architectureSurvey.Left = Left;
            this.architectureSurvey.Top = Top;
        }

        public void Update(GameTime gameTime)
        {
            if (this.Showing && this.enableUpdate)
            {
                this.architectureSurvey.Update();
            }
        }

        public void Gengxin()
        {
            if (this.Showing)
            {
                this.architectureSurvey.Update();
            }
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

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public bool Showing
        {
            get
            {
                return ((this.architectureSurvey.ArchitectureToSurvey != null) && this.showing);
            }
            set
            {
                this.showing = value;
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
