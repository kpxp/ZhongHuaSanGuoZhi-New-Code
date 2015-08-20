using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameGlobal;
using GameFreeText;

using GameObjects;
using Microsoft.Xna.Framework;


using GameFormFramePlugin;
using Microsoft.Xna.Framework.Graphics;








namespace GameFormFramePlugin
{
    internal class GameFrame
    {
        private Rectangle backgroundRectangle;
        internal Texture2D backgroundTexture;
        private Rectangle bottomedgeRectangle;
        internal Texture2D bottomedgeTexture;
        internal int bottomedgeWidth;
        private float buttonDepthOffset = -0.01f;
        internal Texture2D cancelbuttonDisabledTexture;
        private Point cancelbuttonPosition;
        internal Texture2D cancelbuttonPressedTexture;
        private Rectangle cancelbuttonRectangle;
        internal Texture2D cancelbuttonSelectedTexture;
        internal Point cancelbuttonSize;
        private FrameButtonState CancelButtonState;
        internal Texture2D cancelbuttonTexture;
        internal string CancelSoundFile;
        private bool Draging;
        private FrameContent frameContent = null;
        internal FrameFunction Function;
        internal FrameKind Kind;
        private Rectangle leftedgeRectangle;
        internal Texture2D leftedgeTexture;
        internal int leftedgeWidth;
        private Point mapviewselectorbuttonPosition;
        private Rectangle mapviewselectorButtonRectangle;
        private bool MapViewSelectorButtonSelected;
        internal Texture2D MapViewSelectorButtonSelectedTexture;
        internal Point mapviewselectorbuttonSize;
        internal Texture2D MapViewSelectorButtonTexture;
        internal Texture2D okbuttonDisabledTexture;
        private Point okbuttonPosition;
        internal Texture2D okbuttonPressedTexture;
        private Rectangle okbuttonRectangle;
        internal Texture2D okbuttonSelectedTexture;
        internal Point okbuttonSize;
        private FrameButtonState OKButtonState;
        internal Texture2D okbuttonTexture;
        internal string OKSoundFile;
        internal Rectangle Position;
        internal FrameResult Result = FrameResult.Cancel;
        private Rectangle rightedgeRectangle;
        internal Texture2D rightedgeTexture;
        internal int rightedgeWidth;
        private Screen screen;
        internal int titleHeight;
        private Rectangle titleRectangle;
        internal FreeText TitleText;
        internal Texture2D titleTexture;
        internal int titleWidth;
        private Rectangle topedgeRectangle;
        internal Texture2D topedgeTexture;
        internal int topedgeWidth;

        internal void DoCancel()
        {
            this.screen.PlayNormalSound(this.CancelSoundFile);
            this.Result = FrameResult.Cancel;
            this.IsShowing = false;
        }

        internal void DoOK()
        {
            if (this.OKButtonEnabled)
            {
                this.screen.PlayNormalSound(this.OKSoundFile);
                this.Result = FrameResult.OK;
                if (this.frameContent.OKFunction != null)
                {
                    this.frameContent.OKFunction();
                    this.frameContent.OKFunction = null;
                }
                this.IsShowing = false;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            
            Rectangle? sourceRectangle = null;
            spriteBatch.Draw(this.titleTexture, this.titleRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            this.TitleText.Draw(spriteBatch, 0.3999f);
            sourceRectangle = null;
            spriteBatch.Draw(this.leftedgeTexture, this.leftedgeRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            sourceRectangle = null;
            spriteBatch.Draw(this.rightedgeTexture, this.rightedgeRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            sourceRectangle = null;
            spriteBatch.Draw(this.topedgeTexture, this.topedgeRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            sourceRectangle = null;
            spriteBatch.Draw(this.bottomedgeTexture, this.bottomedgeRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            sourceRectangle = null;
            spriteBatch.Draw(this.backgroundTexture, this.backgroundRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
            if (this.OKButtonEnabled)
            {
                switch (this.OKButtonState)
                {
                    case FrameButtonState.Normal:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.okbuttonTexture, this.okbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_024F;

                    case FrameButtonState.Selected:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.okbuttonSelectedTexture, this.okbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_024F;

                    case FrameButtonState.Pressed:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.okbuttonPressedTexture, this.okbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_024F;
                }
            }
            else
            {
                sourceRectangle = null;
                //if (!this.shiyoucelan)
                //{
                    spriteBatch.Draw(this.okbuttonDisabledTexture, this.okbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                //}
            }
        Label_024F:
            if (this.CancelButtonEnabled)
            {
                switch (this.CancelButtonState)
                {
                    case FrameButtonState.Normal:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.cancelbuttonTexture, this.cancelbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_0365;

                    case FrameButtonState.Selected:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.cancelbuttonSelectedTexture, this.cancelbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_0365;

                    case FrameButtonState.Pressed:
                        sourceRectangle = null;
                        spriteBatch.Draw(this.cancelbuttonPressedTexture, this.cancelbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                        goto Label_0365;
                }
            }
            else
            {
                sourceRectangle = null;
                spriteBatch.Draw(this.cancelbuttonDisabledTexture, this.cancelbuttonRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
            }
        Label_0365:
            if (this.frameContent.MapViewSelectorButtonEnabled)
            {
                if (this.MapViewSelectorButtonSelected)
                {
                    spriteBatch.Draw(this.MapViewSelectorButtonSelectedTexture, this.mapviewselectorButtonRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                }
                else
                {
                    spriteBatch.Draw(this.MapViewSelectorButtonTexture, this.mapviewselectorButtonRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4f + this.buttonDepthOffset);
                }
            }
            if (this.frameContent != null)
            {
                this.frameContent.Draw(spriteBatch);
            }
        }

        private void frameContent_OnItemClick()
        {
            if (this.Function == FrameFunction.Jump)
            {
                this.IsShowing = false;
            }
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void ResetRectangles()
        {
            this.leftedgeRectangle = new Rectangle(this.Position.X - this.leftedgeWidth, this.Position.Y, this.leftedgeWidth, this.Position.Height);
            this.rightedgeRectangle = new Rectangle(this.Position.X + this.Position.Width, this.Position.Y, this.rightedgeWidth, this.Position.Height);
            this.topedgeRectangle = new Rectangle(this.Position.X, this.Position.Y - this.topedgeWidth, this.Position.Width, this.topedgeWidth);
            this.bottomedgeRectangle = new Rectangle(this.Position.X, this.Position.Y + this.Position.Height, this.Position.Width, this.bottomedgeWidth);
            this.backgroundRectangle = new Rectangle(this.Position.X, this.Position.Y, this.Position.Width, this.Position.Height);
            this.okbuttonRectangle = new Rectangle(this.Position.X + this.okbuttonPosition.X, this.Position.Y + this.okbuttonPosition.Y, this.okbuttonSize.X, this.okbuttonSize.Y);
            this.cancelbuttonRectangle = new Rectangle(this.Position.X + this.cancelbuttonPosition.X, this.Position.Y + this.cancelbuttonPosition.Y, this.cancelbuttonSize.X, this.cancelbuttonSize.Y);
            this.titleRectangle = new Rectangle(this.Position.X, this.Position.Y - this.titleHeight, this.titleWidth, this.titleHeight);
            this.TitleText.Position = this.titleRectangle;
            this.mapviewselectorButtonRectangle = new Rectangle(this.Position.X + this.mapviewselectorbuttonPosition.X, this.Position.Y + this.mapviewselectorbuttonPosition.Y, this.mapviewselectorbuttonSize.X, this.mapviewselectorbuttonSize.Y);
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame )
            {
                if (this.OKButtonEnabled)
                {
                    if (StaticMethods.PointInRectangle(position, this.okbuttonRectangle))
                    {
                        this.OKButtonState = FrameButtonState.Pressed;
                    }
                    else
                    {
                        this.OKButtonState = FrameButtonState.Normal;
                    }
                }
                if (this.CancelButtonEnabled)
                {
                    if (StaticMethods.PointInRectangle(position, this.cancelbuttonRectangle))
                    {
                        this.CancelButtonState = FrameButtonState.Pressed;
                    }
                    else
                    {
                        this.CancelButtonState = FrameButtonState.Normal;
                    }
                }
                if ((this.frameContent.MapViewSelectorButtonEnabled && StaticMethods.PointInRectangle(position, this.mapviewselectorButtonRectangle)) && (this.frameContent.MapViewSelectorFunction != null))
                {
                    this.frameContent.MapViewSelectorFunction();
                }
            }
        }

        private void screen_OnMouseLeftUp(Point position)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame)
            {
                this.Draging = false;
                if ((this.OKButtonEnabled && (this.OKButtonState == FrameButtonState.Pressed)) && StaticMethods.PointInRectangle(position, this.okbuttonRectangle))
                {
                    this.screen.PlayNormalSound(this.OKSoundFile);
                    this.OKButtonState = FrameButtonState.Selected;
                    this.Result = FrameResult.OK;
                    if (this.frameContent.OKFunction != null)
                    {
                        this.frameContent.OKFunction();
                        this.frameContent.OKFunction = null;
                    }
                    this.IsShowing = false;
                }
                if ((this.CancelButtonEnabled && (this.CancelButtonState == FrameButtonState.Pressed)) && StaticMethods.PointInRectangle(position, this.cancelbuttonRectangle))
                {
                    this.screen.PlayNormalSound(this.CancelSoundFile);
                    this.CancelButtonState = FrameButtonState.Selected;
                    this.Result = FrameResult.Cancel;
                    this.IsShowing = false;
                }
            }
        }
        
        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame || this.screen.PeekUndoneWork().Kind == UndoneWorkKind.None )
            {
                if (this.OKButtonEnabled)
                {
                    if (StaticMethods.PointInRectangle(position, this.okbuttonRectangle))
                    {
                        if (leftDown)
                        {
                            this.OKButtonState = FrameButtonState.Pressed;
                        }
                        else
                        {
                            this.OKButtonState = FrameButtonState.Selected;
                        }
                    }
                    else
                    {
                        this.OKButtonState = FrameButtonState.Normal;
                    }
                }
                if (this.CancelButtonEnabled)
                {
                    if (StaticMethods.PointInRectangle(position, this.cancelbuttonRectangle))
                    {
                        if (leftDown)
                        {
                            this.CancelButtonState = FrameButtonState.Pressed;
                        }
                        else
                        {
                            this.CancelButtonState = FrameButtonState.Selected;
                        }
                    }
                    else
                    {
                        this.CancelButtonState = FrameButtonState.Normal;
                    }
                }
                if (this.frameContent.MapViewSelectorButtonEnabled)
                {
                    if (StaticMethods.PointInRectangle(position, this.mapviewselectorButtonRectangle))
                    {
                        this.MapViewSelectorButtonSelected = true;
                    }
                    else
                    {
                        this.MapViewSelectorButtonSelected = false;
                    }
                }
                if (leftDown)
                {
                    if (StaticMethods.PointInRectangle(position, this.titleRectangle))
                    {
                        this.Draging = true;
                    }
                    if (this.Draging)
                    {
                        this.frameContent.FramePosition = new Rectangle(this.frameContent.FramePosition.X + this.screen.MouseOffset.X, this.frameContent.FramePosition.Y + this.screen.MouseOffset.Y, this.frameContent.FramePosition.Width, this.frameContent.FramePosition.Height);
                        this.SetPosition(this.frameContent.FramePosition);
                        this.frameContent.ReCalculate();
                    }
                }
            }
        }

        

        private void screen_OnMouseRightUp(Point position)
        {
            if ((this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame) && (this.CancelButtonEnabled && this.frameContent.CanClose))
            {
                this.screen.PlayNormalSound(this.CancelSoundFile);
                this.Result = FrameResult.Cancel;
                this.IsShowing = false;
            }
        }

        internal void SetCancelFunction(GameDelegates.VoidFunction cancelfunction)
        {
            this.frameContent.CancelFunction = cancelfunction;
        }

        public void SetFrameContent(FrameContent frameContent, Point viewportSize)
        {
            this.Result = FrameResult.Cancel;
            this.frameContent = frameContent;
            this.frameContent.Function = this.Function;
            this.TitleText.Text = frameContent.GetCurrentTitle();
            frameContent.FramePosition = StaticMethods.GetRectangleFitViewport(frameContent.DefaultFrameWidth, frameContent.DefaultFrameHeight, viewportSize);
            this.OKButtonPosition = frameContent.OKButtonPosition;
            this.CancelButtonPosition = frameContent.CancelButtonPosition;
            this.MapViewSelectorButtonPosition = frameContent.MapViewSelectorButtonPosition;
            this.SetPosition(frameContent.FramePosition);
            frameContent.ReCalculate();
            frameContent.InitializeMapViewSelectorButton();
            frameContent.OnItemClick += new FrameContent.ItemClick(this.frameContent_OnItemClick);
        }

        public void SetFrameyoucelanContent(FrameContent frameContent, Point viewportSize)
        {
            this.Result = FrameResult.Cancel;
            this.frameContent = frameContent;
            this.frameContent.Function = this.Function;
            this.TitleText.Text = frameContent.GetCurrentTitle();
            frameContent.FramePosition = GetRectangleFityoucelan(frameContent.DefaultFrameWidth, frameContent.DefaultFrameHeight, viewportSize);
            this.OKButtonPosition = frameContent.OKButtonPosition;
            this.CancelButtonPosition = frameContent.CancelButtonPosition;
            this.MapViewSelectorButtonPosition = frameContent.MapViewSelectorButtonPosition;
            this.SetPosition(frameContent.FramePosition);
            frameContent.ReCalculate();
            frameContent.InitializeMapViewSelectorButton();
            frameContent.OnItemClick += new FrameContent.ItemClick(this.frameContent_OnItemClick);
        }

        private  Rectangle GetRectangleFityoucelan(int width, int height, Point viewportSize)
        {
            int x = width;
            int y = height;
            if (viewportSize.X < width)
            {
                x = viewportSize.X;
            }
            if (viewportSize.Y < height)
            {
                y = viewportSize.Y;
            }
            return new Rectangle((viewportSize.X - x  - this.rightedgeRectangle.Width ), (viewportSize.Y - y) / 2, x, y);
        }







        internal void SetOKFunction(GameDelegates.VoidFunction okfunction)
        {
            this.frameContent.OKFunction = okfunction;
        }

        private void SetPosition(Rectangle position)
        {
            this.Position = position;
            this.ResetRectangles();
        }

        public bool CancelButtonEnabled
        {
            get
            {
                if (this.frameContent != null)
                {
                    return this.frameContent.CancelButtonEnabled;
                }
                return true;
            }
            set
            {
                if (this.frameContent != null)
                {
                    this.frameContent.CancelButtonEnabled = value;
                }
            }
        }

        internal Point CancelButtonPosition
        {
            get
            {
                return this.cancelbuttonPosition;
            }
            set
            {
                this.cancelbuttonPosition = value;
                this.cancelbuttonRectangle = new Rectangle(this.Position.X + this.cancelbuttonPosition.X, this.Position.Y + this.cancelbuttonPosition.Y, this.cancelbuttonSize.X, this.cancelbuttonSize.Y);
            }
        }

        public bool IsShowing
        {
            
           
            get
            {
                return ((this.frameContent != null) && this.frameContent.IsShowing);
            }
            set
            {
                
                if (this.IsShowing != value)
                {
                    if (value)
                    {
                        if (this.frameContent != null)
                        {
                            
                            this.frameContent.IsShowing = true;
                            
                            //if (this.shiyoucelan)
                            //{
                            //    this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.None           , UndoneWorkSubKind.None));

                            //}
                            //else
                            //{
                                this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Frame, UndoneWorkSubKind.None));

                            //}
                            

                            //this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Frame, UndoneWorkSubKind.None));
                           

                            this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                            this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                            this.screen.OnMouseLeftUp += new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                            this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                        }
                    }
                    else
                    {
                        this.frameContent.IsShowing = false;
                        
                        /*UndoneWorkItem item = this.screen.PopUndoneWork();
                        
                        if (item.Kind != UndoneWorkKind.Frame && item.Kind != UndoneWorkKind.None )
                        {
                            throw new Exception("The UndoneWork is not a Frame or None.");
                        }*/


                        
                        
                        if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.Frame)
                        {
                            //throw new Exception("The UndoneWork is not a Frame.");  //错误检查
                        }

                        this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseLeftUp -= new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                        this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                        this.frameContent.OKFunction = null;
                    }
                }
            }
        }
        /*
        public bool shiyoucelan
        {
            get;
            set;
        }*/

        internal Point MapViewSelectorButtonPosition
        {
            get
            {
                return this.mapviewselectorbuttonPosition;
            }
            set
            {
                this.mapviewselectorbuttonPosition = value;
                this.mapviewselectorButtonRectangle = new Rectangle(this.Position.X + this.mapviewselectorbuttonPosition.X, this.Position.Y + this.mapviewselectorbuttonPosition.Y, this.mapviewselectorbuttonSize.X, this.mapviewselectorbuttonSize.Y);
            }
        }

        public bool OKButtonEnabled
        {
            get
            {
                if (this.frameContent != null)
                {
                    return this.frameContent.OKButtonEnabled;
                }
                return true;
            }
            set
            {
                if (this.frameContent != null)
                {
                    this.frameContent.OKButtonEnabled = value;
                }
            }
        }

        internal Point OKButtonPosition
        {
            get
            {
                return this.okbuttonPosition;
            }
            set
            {
                this.okbuttonPosition = value;
                this.okbuttonRectangle = new Rectangle(this.Position.X + this.okbuttonPosition.X, this.Position.Y + this.okbuttonPosition.Y, this.okbuttonSize.X, this.okbuttonSize.Y);
            }
        }

        internal string TitleString
        {
            get
            {
                if (this.frameContent != null)
                {
                    return this.frameContent.GetTitleString();
                }
                return "";
            }
        }
    }

 

}
