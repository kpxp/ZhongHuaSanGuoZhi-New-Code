namespace tupianwenziPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using PluginInterface;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class tupianwenzilei
    {
        internal Point BackgroundSize;
        internal Texture2D BackgroundTexture;
        internal Rectangle shijiantupianjuxing;
        internal Texture2D shijiantupian;
        internal FreeRichText BuildingRichText = new FreeRichText();
        internal Rectangle ClientPosition;
        private Keys currentKey;
        private Point DisplayOffset;
        private Queue<GameObjectAndBranchName> DisplayQueue = new Queue<GameObjectAndBranchName>();
        internal Texture2D FirstPageButtonDisabledTexture;
        private Texture2D FirstPageButtonDisplayTexture;
        internal Rectangle FirstPageButtonPosition;
        internal Texture2D FirstPageButtonSelectedTexture;
        internal Texture2D FirstPageButtonTexture;
        private bool firstShowing;
        internal bool HasConfirmationDialog = false;
        internal IConfirmationDialog iConfirmationDialog;
        internal IGameContextMenu iContextMenu;
        internal Itupianwenzi iPersonTextDialog;
        private bool isShowing;
        internal FreeText NameText;
        internal GameDelegates.VoidFunction NoFunction;
        internal Rectangle PortraitClient;
        internal FreeRichText RichText = new FreeRichText();
        internal string shijianshengyin;

        private Screen screen;
        internal int ShowingSeconds;
        internal Person SpeakingPerson;
        private DateTime startShowingTime;
        internal GameObjectTextTree TextTree = new GameObjectTextTree();
        internal GameDelegates.VoidFunction YesFunction;

        internal event GameDelegates.VoidFunction CloseFunction;



        internal void Close()
        {
            if (this.DequeueAndDisplay())
            {
                this.IsShowing = false;
            }
        }

        private bool DequeueAndDisplay()
        {
            if (this.DisplayQueue.Count > 0)
            {
                this.startShowingTime = DateTime.Now;
                GameObjectAndBranchName name = this.DisplayQueue.Dequeue();
                this.SpeakingPerson = name.person;
                this.NameText.Text = name.person.Name;
                this.RichText.Clear();
                if (name.gameObject == null)
                {
                    this.RichText.AddText(name.branchName);
                }
                else
                {
                    this.RichText.Texts = name.texts;
                }
                this.RichText.ResortTexts();
                if (name.iConfirmationDialog != null)
                {/*
                    this.iConfirmationDialog = name.iConfirmationDialog;
                    this.iConfirmationDialog.SetPersonTextDialog(this.iPersonTextDialog);
                    this.iConfirmationDialog.AddYesFunction(name.YesFunction);
                    this.iConfirmationDialog.AddNoFunction(name.NoFunction);
                    this.iConfirmationDialog.IsShowing = true;
                    */
                }
                else
                {
                    this.iConfirmationDialog = null;
                    this.YesFunction = null;
                    this.NoFunction = null;
                }
                return false;
            }
            return true;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.SpeakingPerson != null)
            {
                Rectangle? sourceRectangle = null;
                spriteBatch.Draw(this.SpeakingPerson.Portrait, this.PortraitDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.201f);
                sourceRectangle = null;
                spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                if (this.shijiantupian != null)
                {
                    spriteBatch.Draw(this.shijiantupian, this.shijiantupianjuxing, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                }
                
                this.NameText.Draw(spriteBatch, 0.1999f);
                spriteBatch.Draw(this.FirstPageButtonDisplayTexture, this.FirstPageButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.199f);
                this.RichText.Draw(spriteBatch, 0.1999f);

                
            }
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (StaticMethods.PointInRectangle(position, this.FirstPageButtonDisplayPosition))
            {
                this.RichText.FirstPage();
                this.FirstPageButtonDisplayTexture = this.FirstPageButtonDisabledTexture;
            }
            else if ((this.RichText.CurrentPageIndex >= (this.RichText.PageCount - 1)) && ((this.iConfirmationDialog == null) || !this.iConfirmationDialog.IsShowing))
            {
                if (!this.firstShowing)
                {
                    this.Close();
                }
                this.firstShowing = false;
            }
            else
            {
                this.RichText.NextPage();
                this.startShowingTime = DateTime.Now;
                if (this.RichText.CurrentPageIndex > 0)
                {
                    this.FirstPageButtonDisplayTexture = this.FirstPageButtonTexture;
                }
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (this.RichText.CurrentPageIndex > 0)
            {
                if (StaticMethods.PointInRectangle(position, this.FirstPageButtonDisplayPosition))
                {
                    this.FirstPageButtonDisplayTexture = this.FirstPageButtonSelectedTexture;
                }
                else
                {
                    this.FirstPageButtonDisplayTexture = this.FirstPageButtonTexture;
                }
            }
        }

        internal void SetGameObjectBranch(GameObject   gongfang, GameObject gameObject, string branchName)
        {
            this.BuildingRichText.Clear();
            if (gameObject != null)
            {
                this.BuildingRichText.AddGameObjectTextBranch(gongfang , this.TextTree.GetBranch(branchName));
            }
            if (this.HasConfirmationDialog)
            {
                this.DisplayQueue.Enqueue(new GameObjectAndBranchName(gongfang, gameObject, this.BuildingRichText.Texts, branchName, this.iConfirmationDialog, this.YesFunction, this.NoFunction));
                this.YesFunction = null;
                this.NoFunction = null;
            }
            else
            {
                this.DisplayQueue.Enqueue(new GameObjectAndBranchName(gongfang, gameObject, this.BuildingRichText.Texts, branchName, null, null, null));
            }
            this.HasConfirmationDialog = false;
        }

        internal void SetPosition(ShowPosition showPosition)
        {
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            Rectangle rect = new Rectangle(0, 0, this.BackgroundSize.X, this.BackgroundSize.Y);
            switch (showPosition)
            {
                case ShowPosition.Center:
                    rect = StaticMethods.GetCenterRectangle(rectDes, rect);
                    break;

                case ShowPosition.Top:
                    rect = StaticMethods.GetTopRectangle(rectDes, rect);
                    break;

                case ShowPosition.Left:
                    rect = StaticMethods.GetLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.Right:
                    rect = StaticMethods.GetRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.Bottom:
                    rect = StaticMethods.GetBottomRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopLeft:
                    rect = StaticMethods.GetTopLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopRight:
                    rect = StaticMethods.GetTopRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomLeft:
                    rect = StaticMethods.GetBottomLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomRight:
                    rect = StaticMethods.GetBottomRightRectangle(rectDes, rect);
                    break;
            }
            this.DisplayOffset = new Point(rect.X, rect.Y);
            this.RichText.DisplayOffset = new Point(rect.X + this.ClientPosition.X, rect.Y + this.ClientPosition.Y);
            this.NameText.DisplayOffset = this.DisplayOffset;

            this.shijiantupianjuxing = StaticMethods.GetTopRectangle(rectDes, this.shijiantupianjuxing);
            this.shijiantupianjuxing.Y += 40;
        }

        internal void Update()
        {
            if ((this.iConfirmationDialog == null) || !this.iConfirmationDialog.IsShowing)
            {
                if (this.currentKey != Keys.None)
                {
                    if (!this.screen.KeyState.IsKeyUp(this.currentKey))
                    {
                        return;
                    }
                    this.currentKey = Keys.None;
                }
                if (this.screen.KeyState.IsKeyDown(Keys.Enter))
                {
                    this.currentKey = Keys.Enter;
                    this.Close();
                }
                TimeSpan span = (TimeSpan) (DateTime.Now - this.startShowingTime);
                if (span.Milliseconds >= 300)
                {
                    this.firstShowing = false;
                }
                if (span.Seconds >= this.ShowingSeconds)
                {
                    this.Close();
                }
            }
        }

        private Rectangle BackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X, this.DisplayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
            }
        }

        private Rectangle FirstPageButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.FirstPageButtonPosition.X + this.DisplayOffset.X, this.FirstPageButtonPosition.Y + this.DisplayOffset.Y, this.FirstPageButtonPosition.Width, this.FirstPageButtonPosition.Height);
            }
        }

        internal bool IsShowing
        {
            get
            {
                return this.isShowing;
            }
            set
            {
                if (this.isShowing != value)
                {
                    this.isShowing = value;
                    if (value)
                    {
                        if ((this.iContextMenu != null) && this.iContextMenu.IsShowing)
                        {
                            this.iContextMenu.IsShowing = false;
                        }
                        this.firstShowing = true;
                        this.screen.IsHolding = true;
                        this.screen.PlayNormalSound(this.shijianshengyin);

                        this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.tupianwenzi, UndoneWorkSubKind.None));
                        this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                        this.FirstPageButtonDisplayTexture = this.FirstPageButtonDisabledTexture;
                        this.screen.EnableLaterMouseEvent = false;
                        this.Close();
                    }
                    else
                    {
                        this.screen.IsHolding = false;
                        if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.tupianwenzi )
                        {
                            throw new Exception("The UndoneWork is not a tupianwenzi.");
                        }
                        this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.EnableLaterMouseEvent = true;

                        

                        this.iConfirmationDialog = null;
                        if (this.CloseFunction != null)
                        {
                            this.CloseFunction();
                            this.CloseFunction = null;
                        }
                    }
                }
            }
        }

        private Rectangle PortraitDisplayPosition
        {
            get
            {
                return new Rectangle(this.PortraitClient.X + this.DisplayOffset.X, this.PortraitClient.Y + this.DisplayOffset.Y, this.PortraitClient.Width, this.PortraitClient.Height);
            }
        }


    }
}

