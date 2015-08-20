namespace GameRecordPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    internal class GameRecord : Tool
    {
        private Color ButtonDrawingColor = Color.White;
        private DateTime ButtonDrawingTime;
        private bool isRecordShowing;
        internal string PopSoundFile;
        private List<Rectangle> PositionRectangles = new List<Rectangle>();
        private List<Point> Positions = new List<Point>();
        internal FreeRichText Record = new FreeRichText();
        internal Rectangle RecordBackgroundClient;
        internal Texture2D RecordBackgroundTexture;
        private Point RecordDisplayOffset;
        internal ShowPosition RecordShowPosition;
        private Screen screen;
        internal GameObjectTextTree TextTree = new GameObjectTextTree();
        internal Rectangle ToolClient;
        internal Texture2D ToolDisplayTexture;
        internal Texture2D ToolSelectedTexture;
        internal Texture2D ToolTexture;

        internal void AddBranch(GameObject gameObject, string branchName, Point position)
        {
            int num = this.Record.TopAddGameObjectTextBranch(gameObject, this.TextTree.GetBranch(branchName));
            this.Positions.Insert(0, position);
            this.MoveRectangleDown(this.Record.RowHeight * num);
            int index = this.Record.ClientHeight / this.Record.RowHeight;
            if (index < this.Positions.Count)
            {
                this.Positions.RemoveRange(index, this.Positions.Count - index);
                this.PositionRectangles.RemoveRange(index, this.PositionRectangles.Count - index);
            }
            this.screen.PlayNormalSound(this.PopSoundFile);
            this.ButtonDrawingColor = Color.Lime;
            this.ButtonDrawingTime = DateTime.Now;
        }

        internal void AddDisableRects()
        {
            this.screen.AddDisableRectangle(this.screen.LaterMouseEventDisableRects, this.RecordDisplayPosition);
            this.screen.AddDisableRectangle(this.screen.SelectingDisableRects, this.RecordDisplayPosition);
        }

        internal void Clear()
        {
            this.Record.Clear();
            this.Positions.Clear();
            this.PositionRectangles.Clear();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle? sourceRectangle = null;
            spriteBatch.Draw(this.ToolDisplayTexture, this.ToolDisplayPosition, sourceRectangle, this.ButtonDrawingColor, 0f, Vector2.Zero, SpriteEffects.None, 0.099f);
            if (this.IsRecordShowing)
            {
                spriteBatch.Draw(this.RecordBackgroundTexture, this.RecordDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                this.Record.Draw(spriteBatch, 0.0999f);
            }
        }

        private Rectangle GetPositionRectangle(int i)
        {
            return new Rectangle(this.PositionRectangles[i].X + this.RecordDisplayOffset.X, this.PositionRectangles[i].Y + this.RecordDisplayOffset.Y, this.PositionRectangles[i].Width, this.PositionRectangles[i].Height);
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
            this.Record.OnePage = true;
            screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
            screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
        }

        private void MoveRectangleDown(int height)
        {
            for (int i = 0; i < this.PositionRectangles.Count; i++)
            {
                this.PositionRectangles[i] = new Rectangle(this.PositionRectangles[i].X, this.PositionRectangles[i].Y + height, this.PositionRectangles[i].Width, this.PositionRectangles[i].Height);
            }
            this.PositionRectangles.Insert(0, new Rectangle(this.RecordBackgroundClient.X, this.RecordBackgroundClient.Y, this.RecordBackgroundClient.Width, height));
        }

        internal void RemoveDisableRects()
        {
            this.screen.RemoveDisableRectangle(this.screen.LaterMouseEventDisableRects, this.RecordDisplayPosition);
            this.screen.RemoveDisableRectangle(this.screen.SelectingDisableRects, this.RecordDisplayPosition);
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (base.IsDrawing)
            {
                if (StaticMethods.PointInRectangle(position, this.ToolDisplayPosition))
                {
                    this.IsRecordShowing = !this.IsRecordShowing;
                }
                if (this.IsRecordShowing)
                {
                    for (int i = 0; i < this.PositionRectangles.Count; i++)
                    {
                        if (StaticMethods.PointInRectangle(position, this.GetPositionRectangle(i)))
                        {
                            this.screen.JumpTo(this.Positions[i]);
                            break;
                        }
                    }
                }
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (base.Enabled)
            {
                if (!this.IsRecordShowing)
                {
                    if (StaticMethods.PointInRectangle(position, this.ToolDisplayPosition))
                    {
                        this.screen.ResetMouse();
                        this.ToolDisplayTexture = this.ToolSelectedTexture;
                    }
                    else
                    {
                        this.ToolDisplayTexture = this.ToolTexture;
                    }
                }
                else if (StaticMethods.PointInRectangle(position, this.RecordDisplayPosition))
                {
                    this.screen.ResetMouse();
                }
            }
        }

        private void screen_OnMouseRightUp(Point position)
        {
            if ((base.IsDrawing && this.IsRecordShowing) && StaticMethods.PointInRectangle(position, this.RecordDisplayPosition))
            {
                this.IsRecordShowing = false;
                this.ToolDisplayTexture = this.ToolTexture;
            }
        }

        internal void SetDisplayOffset(ShowPosition showPosition)
        {
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            if (rectDes != Rectangle.Empty)
            {
                Rectangle recordBackgroundClient = this.RecordBackgroundClient;
                switch (showPosition)
                {
                    case ShowPosition.Center:
                        recordBackgroundClient = StaticMethods.GetCenterRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.Top:
                        recordBackgroundClient = StaticMethods.GetTopRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.Left:
                        recordBackgroundClient = StaticMethods.GetLeftRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.Right:
                        recordBackgroundClient = StaticMethods.GetRightRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.Bottom:
                        recordBackgroundClient = StaticMethods.GetBottomRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.TopLeft:
                        recordBackgroundClient = StaticMethods.GetTopLeftRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.TopRight:
                        recordBackgroundClient = StaticMethods.GetTopRightRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.BottomLeft:
                        recordBackgroundClient = StaticMethods.GetBottomLeftRectangle(rectDes, recordBackgroundClient);
                        break;

                    case ShowPosition.BottomRight:
                        recordBackgroundClient = StaticMethods.GetBottomRightRectangle(rectDes, recordBackgroundClient);
                        break;
                }
                this.RecordDisplayOffset = new Point(recordBackgroundClient.X, recordBackgroundClient.Y);
                this.Record.DisplayOffset = this.RecordDisplayOffset;
            }
        }

        public override void Update()
        {
            TimeSpan span = (TimeSpan) (DateTime.Now - this.ButtonDrawingTime);
            if (span.Milliseconds >= 300)
            {
                this.ButtonDrawingColor = Color.White;
            }
        }

        internal bool IsRecordShowing
        {
            get
            {
                return this.isRecordShowing;
            }
            set
            {
                this.isRecordShowing = value;
                if (value)
                {
                    this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    this.SetDisplayOffset(this.RecordShowPosition);
                    this.AddDisableRects();
                }
                else
                {
                    this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    this.RemoveDisableRects();
                }
            }
        }

        private Rectangle RecordDisplayPosition
        {
            get
            {
                return new Rectangle(this.RecordDisplayOffset.X + this.RecordBackgroundClient.X, this.RecordDisplayOffset.Y + this.RecordBackgroundClient.Y, this.RecordBackgroundClient.Width, this.RecordBackgroundClient.Height);
            }
        }

        private Rectangle ToolDisplayPosition
        {
            get
            {
                return new Rectangle(this.ToolClient.X + this.DisplayOffset.X, this.ToolClient.Y + this.DisplayOffset.Y, this.ToolClient.Width, this.ToolClient.Height);
            }
        }
    }
}

