namespace ContextMenuPlugin
{
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class ContextMenuPlugin : GameObject, IGameContextMenu, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private ContextMenu contextMenu = new ContextMenu();
        private const string DataPath = @"GameComponents\ContextMenu\Data\";
        private string description = "上下文菜单";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\ContextMenu\";
        private string pluginName = "ContextMenuPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "ContextMenuData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.contextMenu.Draw(spriteBatch);
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
            this.contextMenu.RightClickItemTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.contextMenu.RightClickItemSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.contextMenu.RightClickFreeTextBuilder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.contextMenu.RightClickTextColor = color;
            node = nextSibling.ChildNodes.Item(1);
            this.contextMenu.LeftClickItemTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.contextMenu.LeftClickItemSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.contextMenu.LeftClickFreeTextBuilder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.contextMenu.LeftClickTextColor = color;
            node = nextSibling.ChildNodes.Item(2);
            this.contextMenu.DisabledItemTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.contextMenu.DisabledItemSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.contextMenu.DisabledFreeTextBuilder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.contextMenu.DisabledTextColor = color;
            node = nextSibling.ChildNodes.Item(3);
            this.contextMenu.RightDisabledItemTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.contextMenu.RightDisabledItemSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.contextMenu.RightDisabledFreeTextBuilder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.contextMenu.RightDisabledTextColor = color;
            node = nextSibling.ChildNodes.Item(4);
            this.contextMenu.HasChildTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.contextMenu.ClickSoundFile = @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("Click").Value;
            this.contextMenu.OpenSoundFile = @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("Open").Value;
            this.contextMenu.FoldSoundFile = @"GameComponents\ContextMenu\Data\" + node.Attributes.GetNamedItem("Fold").Value;
            node = nextSibling.ChildNodes.Item(6);
            this.contextMenu.LoadFromXmlNode(node);
        }

        public void Prepare(int X, int Y, Microsoft.Xna.Framework.Point viewportSize)
        {
            this.contextMenu.Prepare(X, Y, viewportSize);
        }

        public void SetCurrentGameObject(object gameObject)
        {
            this.contextMenu.CurrentGameObject = gameObject;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\ContextMenu\ContextMenuData.xml");
        }

        public void SetScenario(GameScenario scen)
        {
            foreach (MenuKind kind in this.contextMenu.MenuKinds)
            {
                if (kind.Name.Equals("TroopLeftClick"))
                {
                    foreach (MenuItem i in kind.MenuItems)
                    {
                        if (i.Name.Equals("TroopCombatMethod"))
                        {
                            i.MenuItems.Clear();
                            foreach (GameObjects.TroopDetail.CombatMethod m in scen.GameCommonData.AllCombatMethods.CombatMethods.Values)
                            {
                                MenuItem item = new MenuItem(i, kind, kind.contextMenu);
                                item.ID = m.ID;
                                item.Name = m.ID.ToString();
                                item.DisplayName = m.Name;
                                item.ChangeDisplayName = "GetCombatMethodDisplayName";
                                item.DisplayIfTrue = "HasCombatMethod";
                                item.IsParamIDItem = true;
                                item.Param = m.ID.ToString();
                                i.MenuItems.Add(item);
                            }
                        }
                        else if (i.Name.Equals("TroopStratagem"))
                        {
                            i.MenuItems.Clear();
                            foreach (GameObjects.TroopDetail.Stratagem m in scen.GameCommonData.AllStratagems.Stratagems.Values)
                            {
                                MenuItem item = new MenuItem(i, kind, kind.contextMenu);
                                item.ID = m.ID;
                                item.Name = m.ID.ToString();
                                item.DisplayName = m.Name;
                                item.ChangeDisplayName = "GetStratagemDisplayName";
                                item.DisplayIfTrue = "HasStratagem";
                                item.Param = m.ID.ToString();
                                i.MenuItems.Add(item);
                            }
                        }
                        else if (i.Name.Equals("TroopStunt"))
                        {
                            i.MenuItems.Clear();
                            foreach (GameObjects.PersonDetail.Stunt m in scen.GameCommonData.AllStunts.Stunts.Values)
                            {
                                MenuItem item = new MenuItem(i, kind, kind.contextMenu);
                                item.ID = m.ID;
                                item.Name = m.ID.ToString();
                                item.DisplayName = m.Name;
                                item.ChangeDisplayName = "GetStuntDisplayName";
                                item.DisplayIfTrue = "HasStunt";
                                item.IsParamIDItem = true;
                                item.Param = m.ID.ToString();
                                i.MenuItems.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public void SetIHelp(IHelp iHelp)
        {
            this.contextMenu.HelpPlugin = iHelp;
        }

        public void SetMenuKindByID(int ID)
        {
            this.contextMenu.SetMenuKindByID(ID);
        }

        public void SetMenuKindByName(string Name)
        {
            this.contextMenu.SetMenuKindByName(Name);
        }

        public void SetScreen(object screen)
        {
            this.contextMenu.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void ShezhiBianduiLiebiaoXinxi(bool Xianshi, Microsoft.Xna.Framework.Rectangle Weizhi)
        {
            this.contextMenu.BianduiLiebiaoXianshi = Xianshi;
            this.contextMenu.BianduiLiebiaoWeizhi = Weizhi;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public int CurrentParamID
        {
            get
            {
                return this.contextMenu.CurrentParamID;
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
                return this.contextMenu.IsShowing;
            }
            set
            {
                this.contextMenu.IsShowing = value;
            }
        }

        public ContextMenuKind Kind
        {
            get
            {
                return this.contextMenu.Kind;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public ContextMenuResult Result
        {
            get
            {
                return this.contextMenu.Result;
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

