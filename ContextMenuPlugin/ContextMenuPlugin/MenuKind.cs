namespace ContextMenuPlugin
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    internal class MenuKind
    {
        internal ContextMenu contextMenu;
        internal string DisplayIfTrue;
        internal string DisplayName;
        internal int ID;
        internal bool IsLeft;
        internal int ItemHeight;
        internal int ItemWidth;
        internal List<MenuItem> MenuItems;
        internal string Name;
        internal bool ShowLeft = false;
        internal bool ShowTop = false;
        internal bool DisplayAll = true;

        internal MenuKind(ContextMenu contextMenu)
        {
            this.contextMenu = contextMenu;
            this.MenuItems = new List<MenuItem>();
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in this.MenuItems)
            {
                item.Draw(spriteBatch);
            }
            if (this.contextMenu.HelpPlugin != null)
            {
                this.contextMenu.HelpPlugin.DrawButton(spriteBatch, 0.04f);
            }
        }

        internal void FoldOpenedItem()
        {
            foreach (MenuItem item in this.MenuItems)
            {
                if (item.Open)
                {
                    item.Open = false;
                    break;
                }
            }
        }

        internal MenuItem GetItemByPosition(Point position)
        {
            for (int i = 0; i < this.MenuItems.Count; i++)
            {
                if (this.MenuItems[i].Visible)
                {
                    if (StaticMethods.PointInRectangle(position, this.MenuItems[i].Position))
                    {
                        return this.MenuItems[i];
                    }
                    if (this.MenuItems[i].Open)
                    {
                        MenuItem itemByPosition = this.MenuItems[i].GetItemByPosition(position);
                        if (itemByPosition != null)
                        {
                            return itemByPosition;
                        }
                    }
                }
            }
            return null;
        }

        internal void LoadFromXmlNode(XmlNode rootNode)
        {
            this.ID = int.Parse(rootNode.Attributes.GetNamedItem("ID").Value);
            this.Name = rootNode.Attributes.GetNamedItem("Name").Value;
            this.DisplayName = rootNode.Attributes.GetNamedItem("DisplayName").Value;
            this.IsLeft = bool.Parse(rootNode.Attributes.GetNamedItem("IsLeft").Value);
            this.ItemWidth = int.Parse(rootNode.Attributes.GetNamedItem("Width").Value);
            this.ItemHeight = int.Parse(rootNode.Attributes.GetNamedItem("Height").Value);
            if (rootNode.Attributes.GetNamedItem("DisplayIfTrue") != null)
            {
                this.DisplayIfTrue = rootNode.Attributes.GetNamedItem("DisplayIfTrue").Value;
            }
            if (rootNode.Attributes.GetNamedItem("DisplayAll") != null)
            {
                this.DisplayAll = bool.Parse(rootNode.Attributes.GetNamedItem("DisplayAll").Value);
            }
            foreach (XmlNode node in rootNode)
            {
                MenuItem item = new MenuItem(this, this.contextMenu);
                item.IsRootItem = true;
                item.LoadFromXmlNode(node);
                this.MenuItems.Add(item);
            }
        }

        internal void Prepare()
        {
            this.ShowLeft = false;
            this.ShowTop = false;
            this.ResetAllItemsSelected();
            this.ResetAllItemsOpen();
            this.RePrepare();
        }

        internal void RePrepare()
        {
            for (int i = 0; i < this.MenuItems.Count; i++)
            {
                if (this.MenuItems[i].Visible)
                {
                    this.MenuItems[i].Prepare();
                }
            }
        }

        internal void ResetAllItemsOpen()
        {
            foreach (MenuItem item in this.MenuItems)
            {
                item.ResetOpen();
                item.ResetAllItemsOpen();
            }
        }

        internal void ResetAllItemsSelected()
        {
            foreach (MenuItem item in this.MenuItems)
            {
                item.ResetSelected();
                if (item.Open)
                {
                    item.ResetAllItemsSelected();
                }
            }
        }

        internal void ResetOtherOpen(MenuItem menuItem)
        {
            foreach (MenuItem item in this.MenuItems)
            {
                if (item == menuItem)
                {
                    item.ResetAllItemsOpen();
                }
                else
                {
                    item.ResetOpen();
                    item.ResetAllItemsOpen();
                }
            }
        }

        internal void ResetOtherSelected(MenuItem menuItem)
        {
            foreach (MenuItem item in this.MenuItems)
            {
                if (item == menuItem)
                {
                    item.ResetAllItemsSelected();
                }
                else
                {
                    item.ResetSelected();
                    item.ResetAllItemsSelected();
                }
            }
        }

        internal void SetAllItemsVisible(bool visible)
        {
            foreach (MenuItem item in this.MenuItems)
            {
                item.Visible = visible;
                item.SetAllItemsVisible(visible);
            }
        }

        internal bool HasOpenItem
        {
            get
            {
                foreach (MenuItem item in this.MenuItems)
                {
                    if (item.Open)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        internal int VisibleCount
        {
            get
            {
                int num = 0;
                foreach (MenuItem item in this.MenuItems)
                {
                    if (item.Visible)
                    {
                        num++;
                    }
                }
                return num;
            }
        }
    }
}

