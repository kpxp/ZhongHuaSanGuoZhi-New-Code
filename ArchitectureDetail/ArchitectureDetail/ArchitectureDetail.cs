namespace ArchitectureDetail
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using GameObjects.Influences;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class ArchitectureDetail
    {
        internal Point BackgroundSize;
        internal Texture2D BackgroundTexture;
        internal Rectangle CharacteristicClient;
        internal FreeRichText CharacteristicText = new FreeRichText();
        private Point DisplayOffset;
        internal Rectangle FacilityClient;
        internal FreeRichText FacilityText = new FreeRichText();
        private bool isShowing;
        internal List<LabelText> LabelTexts = new List<LabelText>();
        internal Screen screen;
        internal Architecture ShowingArchitecture;

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.ShowingArchitecture != null)
            {
                spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                foreach (LabelText text in this.LabelTexts)
                {
                    text.Label.Draw(spriteBatch, 0.1999f);
                    text.Text.Draw(spriteBatch, 0.1999f);
                }
                this.CharacteristicText.Draw(spriteBatch, 0.1999f);
                this.FacilityText.Draw(spriteBatch, 0.1999f);
            }
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (StaticMethods.PointInRectangle(position, this.CharacteristicDisplayPosition))
            {
                if (this.CharacteristicText.CurrentPageIndex < (this.CharacteristicText.PageCount - 1))
                {
                    this.CharacteristicText.NextPage();
                }
                else if (this.CharacteristicText.CurrentPageIndex == (this.CharacteristicText.PageCount - 1))
                {
                    this.CharacteristicText.FirstPage();
                }
            }
            else if (StaticMethods.PointInRectangle(position, this.FacilityDisplayPosition))
            {
                if (this.FacilityText.CurrentPageIndex < (this.FacilityText.PageCount - 1))
                {
                    this.FacilityText.NextPage();
                }
                else if (this.FacilityText.CurrentPageIndex == (this.FacilityText.PageCount - 1))
                {
                    this.FacilityText.FirstPage();
                }
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
        }

        private void screen_OnMouseRightUp(Point position)
        {
            this.IsShowing = false;
        }

        internal void SetArchitecture(Architecture architecture)
        {
            this.ShowingArchitecture = architecture;
            foreach (LabelText text in this.LabelTexts)
            {
                text.Text.Text = StaticMethods.GetPropertyValue(architecture, text.PropertyName).ToString();
            }
            this.CharacteristicText.AddText("特色", this.CharacteristicText.TitleColor);
            this.CharacteristicText.AddNewLine();
            foreach (Influence influence in this.ShowingArchitecture.Characteristics.Influences.Values)
            {
                this.CharacteristicText.AddText(influence.Description, this.CharacteristicText.SubTitleColor);
                this.CharacteristicText.AddNewLine();
            }
            this.CharacteristicText.ResortTexts();
            this.FacilityText.AddText("设施", this.FacilityText.TitleColor);
            this.FacilityText.AddNewLine();
            if (this.ShowingArchitecture.BuildingFacility >= 0)
            {
                FacilityKind facilityKind = this.ShowingArchitecture.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.ShowingArchitecture.BuildingFacility);
                if (facilityKind != null)
                {
                    this.FacilityText.AddText("建造中：");
                    this.FacilityText.AddText(facilityKind.Name, this.FacilityText.SubTitleColor);
                    this.FacilityText.AddText("，剩余时间：");
                    this.FacilityText.AddText(this.ShowingArchitecture.BuildingDaysLeft.ToString(), this.FacilityText.SubTitleColor2);
                    this.FacilityText.AddText("天");
                    this.FacilityText.AddNewLine();
                }
            }
            this.FacilityText.AddText("已有设施" + this.ShowingArchitecture.Facilities.Count + "个", this.FacilityText.SubTitleColor3);
            this.FacilityText.AddNewLine();
            foreach (Facility facility in this.ShowingArchitecture.Facilities)
            {
                this.FacilityText.AddText(facility.Name, this.FacilityText.SubTitleColor);
                this.FacilityText.AddText("，占用空间：");
                this.FacilityText.AddText(facility.PositionOccupied.ToString(), this.FacilityText.SubTitleColor2);
                this.FacilityText.AddText("，维持费用：");
                this.FacilityText.AddText(facility.MaintenanceCost.ToString(), this.FacilityText.SubTitleColor2);
                this.FacilityText.AddNewLine();
            }
            this.FacilityText.ResortTexts();
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
            foreach (LabelText text in this.LabelTexts)
            {
                text.Label.DisplayOffset = this.DisplayOffset;
                text.Text.DisplayOffset = this.DisplayOffset;
            }
            this.CharacteristicText.DisplayOffset = new Point(this.DisplayOffset.X + this.CharacteristicClient.X, this.DisplayOffset.Y + this.CharacteristicClient.Y);
            this.FacilityText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityClient.X, this.DisplayOffset.Y + this.FacilityClient.Y);
        }

        private Rectangle BackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X, this.DisplayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
            }
        }

        private Rectangle CharacteristicDisplayPosition
        {
            get
            {
                return new Rectangle(this.CharacteristicText.DisplayOffset.X, this.CharacteristicText.DisplayOffset.Y, this.CharacteristicText.ClientWidth, this.CharacteristicText.ClientHeight);
            }
        }

        private Rectangle FacilityDisplayPosition
        {
            get
            {
                return new Rectangle(this.FacilityText.DisplayOffset.X, this.FacilityText.DisplayOffset.Y, this.FacilityText.ClientWidth, this.FacilityText.ClientHeight);
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.isShowing;
            }
            set
            {
                this.isShowing = value;
                if (value)
                {
                    this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.SubDialog, DialogKind.ArchitectureDetail));
                    this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                }
                else
                {
                    if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.SubDialog)
                    {
                        throw new Exception("The UndoneWork is not a SubDialog.");
                    }
                    this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    this.CharacteristicText.Clear();
                    this.FacilityText.Clear();
                }
            }
        }
    }
}

