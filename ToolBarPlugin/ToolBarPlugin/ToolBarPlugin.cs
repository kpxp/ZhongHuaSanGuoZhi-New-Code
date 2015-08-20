namespace ToolBarPlugin
{
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Xml;

    public class ToolBarPlugin : GameObject, IToolBar, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\ToolBar\Data\";
        private string description = "工具栏";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\ToolBar\";
        private string pluginName = "ToolBarPlugin";
        private ToolBar toolBar = new ToolBar();
        private string version = "1.0.0";
        private const string XMLFilename = "ToolBarData.xml";

        public void AddTool(object tool)
        {
            this.toolBar.Tools.Add(tool as Tool);
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (this.IsShowing)
            {
                this.toolBar.Draw(spriteBatch,gameTime);
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
            XmlNode node2 = nextSibling.ChildNodes.Item(0);
            this.toolBar.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ToolBar\Data\" + node2.Attributes.GetNamedItem("FileName").Value);
            this.toolBar.BackgroundHeight = int.Parse(node2.Attributes.GetNamedItem("Height").Value);
            node2 = nextSibling.ChildNodes.Item(1);
            this.toolBar.SpliterTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ToolBar\Data\" + node2.Attributes.GetNamedItem("FileName").Value);
            this.toolBar.SpliterWidth = int.Parse(node2.Attributes.GetNamedItem("Width").Value);
        }

        public void RemoveTool(object tool)
        {
            this.toolBar.Tools.Remove(tool as Tool);
        }

        public void SetContextMenuPlugin(IGameContextMenu contextMenuPlugin)
        {
            this.toolBar.ContextMenuPlugin = contextMenuPlugin;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\ToolBar\ToolBarData.xml");
        }

        public void SetRealViewportSize(Point realViewportSize)
        {
            this.toolBar.BackgroundPosition = new Rectangle(0, realViewportSize.Y - this.toolBar.BackgroundHeight, realViewportSize.X, this.toolBar.BackgroundHeight);
            this.toolBar.ResetToolsOffset();
        }

        public void SetScreen(object screen)
        {
            this.toolBar.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
            if (this.IsShowing)
            {
                this.toolBar.Update();
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

        public bool DrawTools
        {
            get
            {
                return this.toolBar.DrawTools;
            }
            set
            {
                this.toolBar.DrawTools = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.toolBar.Enabled;
            }
            set
            {
                this.toolBar.Enabled = value;
                this.toolBar.SetToolsEnabled(value);
            }
        }

        public int Height
        {
            get
            {
                return (this.IsShowing ? this.toolBar.BackgroundHeight : 0);
            }
            set
            {
                this.toolBar.BackgroundHeight = value;
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
                return this.toolBar.IsShowing;
            }
            set
            {
                this.toolBar.IsShowing = value;
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

