using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using		GameFreeText;
using		GameGlobal;
using		GameObjects;
using		Microsoft.Xna.Framework;


using		PluginInterface;

using		System.Xml;
using TroopTitlePlugin;
using Microsoft.Xna.Framework.Graphics;
using PluginInterface.BaseInterface;
using System.Drawing;




namespace TroopTitlePlugin
{
    public class TroopTitlePlugin : GameObject, ITroopTitle, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\TroopTitle\Data\";
        private string description = "用来显示部队的标题";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\TroopTitle\";
        private string pluginName = "TroopTitlePlugin";
        private TroopTitle troopTitle = new TroopTitle();
        private string version = "1.0.0";
        private const string XMLFilename = "TroopTitleData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void DrawTroop(SpriteBatch spriteBatch, object troop, bool playerControlling)
        {
            if (this.IsShowing)
            {
                this.troopTitle.DrawTroop(spriteBatch, troop as Troop, playerControlling);
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
            this.troopTitle.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.troopTitle.BackgroundSize = new  Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(1);
            this.troopTitle.PortraitPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            this.troopTitle.FactionTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.troopTitle.FactionPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(3);
            Microsoft.Xna.Framework.Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.troopTitle.NameText = new FreeText(this.graphicsDevice, font, color);
            this.troopTitle.NameText.Position = rectangle;
            this.troopTitle.NameText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.troopTitle.ActionDoneTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Done").Value);
            this.troopTitle.ActionUndoneTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Undone").Value);
            this.troopTitle.ActionAutoTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Auto").Value);
            this.troopTitle.ActionAutoDoneTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("AutoDone").Value);
            this.troopTitle.ActionIconPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(5);
            this.troopTitle.FoodNormalTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Normal").Value);
            this.troopTitle.FoodShortageTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Shortage").Value);
            this.troopTitle.FoodIconPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(6);
            this.troopTitle.NoControlTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("NoControl").Value);
            this.troopTitle.NoControlIconPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(7);
            this.troopTitle.StuntTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("Stunt").Value);
            this.troopTitle.StuntIconPosition = StaticMethods.LoadRectangleFromXMLNode(node);

            node = nextSibling.ChildNodes.Item(8);
            Microsoft.Xna.Framework.Rectangle rectangle1 = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.troopTitle.binglitext = new FreeText(this.graphicsDevice, font, color);
            this.troopTitle.binglitext.Position = rectangle1;
            this.troopTitle.binglitext.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

            node = nextSibling.ChildNodes.Item(9);
            this.troopTitle.shiqicaotupian  = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.troopTitle.shiqicaoweizhi  = StaticMethods.LoadRectangleFromXMLNode(node);

            node = nextSibling.ChildNodes.Item(10);
            this.troopTitle.shiqitiaotupian = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\TroopTitle\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.troopTitle.shiqitiaoweizhi = StaticMethods.LoadRectangleFromXMLNode(node);
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\TroopTitle\TroopTitleData.xml");
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
                return this.troopTitle.IsShowing;
            }
            set
            {
                this.troopTitle.IsShowing = value;
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
