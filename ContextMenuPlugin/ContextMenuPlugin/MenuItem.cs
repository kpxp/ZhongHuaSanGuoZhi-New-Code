namespace ContextMenuPlugin
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    internal class MenuItem
    {
        internal string ChangeDisplayName;
        private ContextMenu contextMenu;
        internal string DefaultName;
        internal string DisplayIfTrue;
        internal string DisplayName;
        internal bool DisplayAll = true;
        private MenuItem fatherItem;
        internal int ID;
        internal bool IsParamIDItem;
        internal bool IsRootItem;
        internal List<MenuItem> MenuItems;
        private MenuKind menuKind;
        internal string Name;
        private bool open;
        internal string OppositeIfTrue;
        internal string OppositeName;
        internal string Param;
        internal Rectangle Position;
        private bool selected;
        internal Texture2D TextTexture;
        private bool visible;
        private bool enabled;

        internal MenuItem(MenuKind menuKind, ContextMenu contextMenu)
        {
            this.IsRootItem = false;
            this.menuKind = menuKind;
            this.contextMenu = contextMenu;
            this.MenuItems = new List<MenuItem>();
        }

        internal MenuItem(MenuItem fatherItem, MenuKind menuKind, ContextMenu contextMenu)
        {
            this.IsRootItem = false;
            this.fatherItem = fatherItem;
            this.menuKind = menuKind;
            this.contextMenu = contextMenu;
            this.MenuItems = new List<MenuItem>();
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.Visible)
            {
                Rectangle? nullable;
                if (this.selected || this.open)
                {
                    if (this.menuKind.IsLeft)
                    {
                        nullable = null;
                        spriteBatch.Draw(this.Enabled ? this.contextMenu.LeftClickItemSelectedTexture : this.contextMenu.DisabledItemSelectedTexture
                            , this.Position, nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        if (!this.open)
                        {
                            nullable = null;
                            spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), nullable, this.Enabled ? Color.White : this.contextMenu.DisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                        }
                        else
                        {
                            nullable = null;
                            spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), nullable, this.Enabled ? Color.Gold : this.contextMenu.DisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                        }
                    }
                    else
                    {
                        nullable = null;
                        spriteBatch.Draw(this.Enabled ? this.contextMenu.RightClickItemSelectedTexture : this.contextMenu.RightDisabledItemSelectedTexture, this.Position, nullable, this.Enabled ? Color.White : this.contextMenu.RightDisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        nullable = null;
                        spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), nullable, this.Enabled ? Color.White : this.contextMenu.RightDisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                    }
                    if (this.open)
                    {
                        foreach (MenuItem item in this.MenuItems)
                        {
                            item.Draw(spriteBatch);
                        }
                    }
                    else if (this.HasChild)
                    {
                        if (!this.menuKind.ShowLeft)
                        {
                            spriteBatch.Draw(this.contextMenu.HasChildTexture, StaticMethods.CenterRectangle(new Rectangle(this.Position.Right, this.Position.Top, this.contextMenu.HasChildTexture.Width, this.Position.Height), new Rectangle(0, 0, this.contextMenu.HasChildTexture.Width, this.contextMenu.HasChildTexture.Height)), null, this.Enabled ? Color.White : this.contextMenu.DisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        }
                        else
                        {
                            spriteBatch.Draw(this.contextMenu.HasChildTexture, StaticMethods.CenterRectangle(new Rectangle(this.Position.Left, this.Position.Top, -this.contextMenu.HasChildTexture.Width, this.Position.Height), new Rectangle(0, 0, -this.contextMenu.HasChildTexture.Width, -this.contextMenu.HasChildTexture.Height)), null, this.Enabled ? Color.White : this.contextMenu.RightDisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        }
                    }
                }
                else if (this.menuKind.IsLeft)
                {
                    if (this.Enabled)
                    {
                        nullable = null;
                        spriteBatch.Draw(this.contextMenu.LeftClickItemTexture, this.Position, nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), null, this.contextMenu.LeftClickTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                    }
                    else
                    {
                        nullable = null;
                        spriteBatch.Draw(this.contextMenu.DisabledItemTexture, this.Position, nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), null, this.contextMenu.DisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                    }
                }
                else
                {
                    if (this.Enabled)
                    {
                        nullable = null;
                        spriteBatch.Draw(this.contextMenu.RightClickItemTexture, this.Position, nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), null, this.contextMenu.RightClickTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                    }
                    else
                    {
                        nullable = null;
                        spriteBatch.Draw(this.contextMenu.RightDisabledItemTexture, this.Position, nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None,0.04f);
                        spriteBatch.Draw(this.TextTexture, StaticMethods.CenterRectangle(this.Position, new Rectangle(0, 0, this.TextTexture.Width, this.TextTexture.Height)), null, this.contextMenu.RightDisabledTextColor, 0f, Vector2.Zero, SpriteEffects.None, 0.0399f);
                    
                    }
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

        internal int GetTopToBe(bool reverse)
        {
            int num = 0;
            if (this.IsRootItem)
            {
                foreach (MenuItem item in this.menuKind.MenuItems)
                {
                    if (item == this)
                    {
                        return num;
                    }
                    if (item.visible)
                    {
                        if (reverse)
                        {
                            num -= this.menuKind.ItemHeight;
                        }
                        else
                        {
                            num += this.menuKind.ItemHeight;
                        }
                    }
                }
                return num;
            }
            foreach (MenuItem item in this.fatherItem.MenuItems)
            {
                if (item == this)
                {
                    return num;
                }
                if (item.visible)
                {
                    if (reverse)
                    {
                        num -= this.menuKind.ItemHeight;
                    }
                    else
                    {
                        num += this.menuKind.ItemHeight;
                    }
                }
            }
            return num;
        }

        internal void LoadFromXmlNode(XmlNode rootNode)
        {
            this.ID = int.Parse(rootNode.Attributes.GetNamedItem("ID").Value);
            this.Name = rootNode.Attributes.GetNamedItem("Name").Value;
            this.DisplayName = rootNode.Attributes.GetNamedItem("DisplayName").Value;
            this.DefaultName = this.DisplayName;
            if (rootNode.Attributes.GetNamedItem("DisplayIfTrue") != null)
            {
                this.DisplayIfTrue = rootNode.Attributes.GetNamedItem("DisplayIfTrue").Value;
            }
            if (rootNode.Attributes.GetNamedItem("DisplayAll") != null)
            {
                this.DisplayAll = bool.Parse(rootNode.Attributes.GetNamedItem("DisplayAll").Value);
            }
            if (rootNode.Attributes.GetNamedItem("IsParamIDItem") != null)
            {
                this.IsParamIDItem = bool.Parse(rootNode.Attributes.GetNamedItem("IsParamIDItem").Value);
            }
            if (rootNode.Attributes.GetNamedItem("Param") != null)
            {
                this.Param = rootNode.Attributes.GetNamedItem("Param").Value;
            }
            if (rootNode.Attributes.GetNamedItem("ChangeDisplayName") != null)
            {
                this.ChangeDisplayName = rootNode.Attributes.GetNamedItem("ChangeDisplayName").Value;
            }
            if (rootNode.Attributes.GetNamedItem("OppositeName") != null)
            {
                this.OppositeName = rootNode.Attributes.GetNamedItem("OppositeName").Value;
            }
            if (rootNode.Attributes.GetNamedItem("OppositeIfTrue") != null)
            {
                this.OppositeIfTrue = rootNode.Attributes.GetNamedItem("OppositeIfTrue").Value;
            }
            foreach (XmlNode node in rootNode)
            {
                MenuItem item = new MenuItem(this, this.menuKind, this.contextMenu);
                item.LoadFromXmlNode(node);
                this.MenuItems.Add(item);
            }
        }

        internal void MoveMargin(int offset)
        {
            this.Position = new Rectangle(this.Position.X + offset, this.Position.Y, this.Position.Width, this.Position.Height);
        }

        internal void Prepare()
        {
            int num;
            if (this.IsRootItem)
            {
                this.Position = new Rectangle(this.contextMenu.left, this.contextMenu.top + this.GetTopToBe(false), this.menuKind.ItemWidth, this.menuKind.ItemHeight);
                if (this.open)
                {
                    if (this.menuKind.ShowLeft)
                    {
                        this.MoveMargin(-10);
                    }
                    else
                    {
                        this.MoveMargin(10);
                    }
                }
                for (num = 0; num < this.MenuItems.Count; num++)
                {
                    if (this.MenuItems[num].visible)
                    {
                        this.MenuItems[num].Prepare();
                    }
                }
            }
            else
            {
                if (!this.menuKind.ShowLeft)
                {
                    this.Position = new Rectangle(this.fatherItem.Position.Right, this.fatherItem.Position.Top + this.GetTopToBe(this.menuKind.ShowTop), this.menuKind.ItemWidth, this.menuKind.ItemHeight);
                }
                else
                {
                    this.Position = new Rectangle(this.fatherItem.Position.Left - this.menuKind.ItemWidth, this.fatherItem.Position.Top + this.GetTopToBe(this.menuKind.ShowTop), this.menuKind.ItemWidth, this.menuKind.ItemHeight);
                }
                if (this.open)
                {
                    if (this.menuKind.ShowLeft)
                    {
                        this.MoveMargin(-10);
                    }
                    else
                    {
                        this.MoveMargin(10);
                    }
                }
                for (num = 0; num < this.MenuItems.Count; num++)
                {
                    if (this.MenuItems[num].visible)
                    {
                        this.MenuItems[num].Prepare();
                    }
                }
            }
        }

        internal void RefreshItemDisplayName()
        {
            if (this.ChangeDisplayName != null)
            {
                if (this.Param == null)
                {
                    this.DisplayName = (string) StaticMethods.GetPropertyValue(this.contextMenu.CurrentGameObject, this.ChangeDisplayName);
                }
                else
                {
                    this.DisplayName = StaticMethods.GetStringMethodValue(this.contextMenu.CurrentGameObject, this.ChangeDisplayName, new object[] { int.Parse(this.Param) });
                }
                this.ResetTextTexture();
            }
            else if (this.OppositeIfTrue != null)
            {
                if ((bool) StaticMethods.GetPropertyValue(this.contextMenu.CurrentGameObject, this.OppositeIfTrue))
                {
                    this.DisplayName = this.OppositeName;
                }
                else
                {
                    this.DisplayName = this.DefaultName;
                }
                this.ResetTextTexture();
            }
            foreach (MenuItem item in this.MenuItems)
            {
                item.RefreshItemDisplayName();
            }
        }

        internal bool RefreshItemVisible()
        {
            if (this.DisplayIfTrue != null)
            {
                if (this.Param != null)
                {
                    this.Visible = StaticMethods.GetBoolMethodValue(this.contextMenu.CurrentGameObject, this.DisplayIfTrue, new object[] { int.Parse(this.Param) });
                }
                else
                {
                    this.Visible = StaticMethods.GetBoolMethodValue(this.contextMenu.CurrentGameObject, this.DisplayIfTrue, new object[0]);
                }
            }
            else
            {
                this.Visible = true;
            }
            if (this.MenuItems.Count > 0)
            {
                bool flag = false;
                foreach (MenuItem item in this.MenuItems)
                {
                    if (item.RefreshItemVisible())
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    this.Visible = false;
                }
            }
            this.Enabled = this.Visible;
            if (this.fatherItem == null ? this.menuKind.DisplayAll : this.fatherItem.DisplayAll)
            {
                this.Visible = true;
            }
            return this.Visible;
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
                item.ResetAllItemsSelected();
            }
        }

        internal void ResetOpen()
        {
            this.open = false;
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

        internal void ResetSelected()
        {
            this.selected = false;
            this.ResetAllItemsSelected();
        }

        internal void ResetTextTexture()
        {
            if (this.menuKind.IsLeft)
            {
                if (this.Enabled)
                {
                    this.TextTexture = this.contextMenu.LeftClickFreeTextBuilder.CreateTextTexture(this.DisplayName);
                }
                else
                {
                    this.TextTexture = this.contextMenu.DisabledFreeTextBuilder.CreateTextTexture(this.DisplayName);
                }
            }
            else
            {
                if (this.Enabled)
                {
                    this.TextTexture = this.contextMenu.RightClickFreeTextBuilder.CreateTextTexture(this.DisplayName);
                }
                else
                {
                    this.TextTexture = this.contextMenu.RightDisabledFreeTextBuilder.CreateTextTexture(this.DisplayName);
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

        internal int Depth
        {
            get
            {
                if (this.IsRootItem)
                {
                    return 1;
                }
                int num = 2;
                while (!this.fatherItem.IsRootItem)
                {
                    num++;
                }
                return num;
            }
        }

        internal bool HasChild
        {
            get
            {
                foreach (MenuItem item in this.MenuItems)
                {
                    if (item.visible)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        internal bool Open
        {
            get
            {
                return this.open;
            }
            set
            {
                bool open = this.open;
                if (value)
                {
                    if (this.HasChild)
                    {
                        this.open = value;
                        if (this.IsRootItem)
                        {
                            this.menuKind.ResetOtherOpen(this);
                        }
                        else
                        {
                            this.fatherItem.ResetOtherOpen(this);
                        }
                        if (!this.menuKind.ShowLeft && (((this.contextMenu.left + this.menuKind.ItemWidth) + (this.Depth * (10 + this.menuKind.ItemWidth))) > this.contextMenu.ViewportSize.X))
                        {
                            this.menuKind.ShowLeft = true;
                        }
                        if (!this.menuKind.ShowTop && ((this.Position.Top + this.TotalSubItemHeight) > this.contextMenu.ViewportSize.Y))
                        {
                            this.menuKind.ShowTop = true;
                        }
                    }
                }
                else if (this.open)
                {
                    this.open = value;
                    if (this.menuKind.ShowLeft && (((this.contextMenu.left + this.menuKind.ItemWidth) + (this.Depth * (10 + this.menuKind.ItemWidth))) <= this.contextMenu.ViewportSize.X))
                    {
                        this.menuKind.ShowLeft = false;
                    }
                    if (this.menuKind.ShowTop && ((this.Position.Top + this.TotalSubItemHeight) <= this.contextMenu.ViewportSize.Y))
                    {
                        this.menuKind.ShowTop = false;
                    }
                    if (this.contextMenu.HelpPlugin != null)
                    {
                        this.contextMenu.HelpPlugin.IsButtonShowing = false;
                    }
                }
                if (open != this.open)
                {
                    this.menuKind.RePrepare();
                }
            }
        }

        internal string Result
        {
            get
            {
                string name = this.Name;
                for (MenuItem item = this; !item.IsRootItem; item = item.fatherItem)
                {
                    name = item.fatherItem.Name + "_" + name;
                }
                return name;
            }
        }

        internal string ResultDecludeParam
        {
            get
            {
                string name = "";
                MenuItem fatherItem = this.fatherItem;
                if (fatherItem != null)
                {
                    name = fatherItem.Name;
                    while (!fatherItem.IsRootItem)
                    {
                        name = fatherItem.fatherItem.Name + "_" + name;
                        fatherItem = fatherItem.fatherItem;
                    }
                }
                return name;
            }
        }

        internal bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
                if (value)
                {
                    if (this.IsRootItem)
                    {
                        this.menuKind.ResetOtherSelected(this);
                    }
                    else
                    {
                        this.fatherItem.ResetOtherSelected(this);
                    }
                    if (!this.HasChild)
                    {
                        if (this.contextMenu.HelpPlugin != null)
                        {
                            if (this.contextMenu.HelpPlugin.SetCurrentKey(this.Result))
                            {
                                this.contextMenu.HelpPlugin.SetButtonDisplayOffset(new Point(this.Position.Right, this.Position.Top));
                                this.contextMenu.HelpPlugin.IsButtonShowing = true;
                            }
                            else
                            {
                                this.contextMenu.HelpPlugin.IsButtonShowing = false;
                            }
                        }
                    }
                    else if (this.contextMenu.HelpPlugin != null)
                    {
                        this.contextMenu.HelpPlugin.IsButtonShowing = false;
                    }
                }
                else if (this.contextMenu.HelpPlugin != null)
                {
                    this.contextMenu.HelpPlugin.IsButtonShowing = false;
                }
            }
        }

        internal int TotalSubItemHeight
        {
            get
            {
                int num = 0;
                foreach (MenuItem item in this.MenuItems)
                {
                    if (item.visible)
                    {
                        num += this.menuKind.ItemHeight;
                    }
                }
                return num;
            }
        }

        internal bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
                if (value)
                {
                    this.ResetTextTexture();
                }
            }
        }

        internal bool Visible
        {
            get
            {
                if (!GlobalVariables.EnableCheat && this.DisplayName.Contains("*")) return false;
                if (GlobalVariables.hougongGetChildrenRate <= 0 && this.Name.Equals("hougongTop")) return false;
                return this.visible;
            }
            set
            {
                if (!GlobalVariables.EnableCheat && this.DisplayName.Contains("*")) return;
                if (GlobalVariables.hougongGetChildrenRate <= 0 && this.Name.Equals("hougongTop")) return;
                this.visible = value;
                if (value)
                {
                    this.ResetTextTexture();
                }
            }
        }
    }
}

