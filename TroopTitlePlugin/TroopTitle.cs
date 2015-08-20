using System;
using System.Collections.Generic;
using System.Linq;



using		GameFreeText;
using		GameGlobal;
using		GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace TroopTitlePlugin
{
    internal class TroopTitle
    {
        internal Texture2D ActionAutoDoneTexture;
        internal Texture2D ActionAutoTexture;
        internal Texture2D ActionDoneTexture;
        internal Rectangle ActionIconPosition;
        internal Texture2D ActionUndoneTexture;
        public Point BackgroundSize;
        public Texture2D BackgroundTexture;
        private Point displayOffset;
        public Rectangle FactionPosition;
        public Texture2D FactionTexture;
        internal Rectangle FoodIconPosition;
        internal Texture2D FoodNormalTexture;
        internal Texture2D FoodShortageTexture;
        private bool isShowing = true;
        public FreeText NameText;
        public FreeText binglitext;
        internal Rectangle NoControlIconPosition;
        internal Texture2D NoControlTexture;
        public Rectangle PortraitPosition;
        internal Rectangle StuntIconPosition;
        internal Texture2D StuntTexture;

        internal Rectangle shiqicaoweizhi;
        internal Texture2D shiqicaotupian;
        internal Rectangle shiqitiaoweizhi;
        internal Texture2D shiqitiaotupian;

        internal void DrawTroop(SpriteBatch spriteBatch, Troop troop, bool playerControlling)
        {
            if (troop.Scenario.ScenarioMap.TileWidth >= 50)
            {
                Color white = Color.White;
                this.DisplayOffset = troop.Scenario.GameScreen.GetPointByPosition(troop.Position);
                this.DisplayOffset=new Point( this.DisplayOffset.X ,this.DisplayOffset.Y- 13);
                if (troop.BelongedFaction != null)
                {
                    white = troop.BelongedFaction.FactionColor;
                }
                Rectangle? sourceRectangle = null;
                spriteBatch.Draw(this.BackgroundTexture, new Rectangle(this.displayOffset.X, this.displayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.47f);
                spriteBatch.Draw(this.shiqicaotupian, new Rectangle(this.displayOffset.X + this.shiqicaoweizhi.X, this.displayOffset.Y + this.shiqicaoweizhi.Y, this.shiqicaoweizhi.Width , this.shiqicaoweizhi.Height ), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.469f);
                spriteBatch.Draw(this.shiqitiaotupian, new Rectangle(this.displayOffset.X + this.shiqitiaoweizhi.X, this.displayOffset.Y + this.shiqitiaoweizhi.Y, shiqitiaokuandu(troop), this.shiqitiaoweizhi.Height), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.469f);

                sourceRectangle = null;
                spriteBatch.Draw(this.FactionTexture, new Rectangle(this.displayOffset.X + this.FactionPosition.X, this.displayOffset.Y + this.FactionPosition.Y, this.FactionPosition.Width, this.FactionPosition.Height), sourceRectangle, white, 0f, Vector2.Zero, SpriteEffects.None, 0.469f);
                this.NameText.Text = troop.Leader.Name;
                this.binglitext.Text=troop.Army.Quantity.ToString();
                this.NameText.Draw(spriteBatch, 0.47f);
                this.binglitext.Draw(spriteBatch, 0.47f);
                sourceRectangle = null;
                try
                {
                    spriteBatch.Draw(troop.Leader.SmallPortrait, new Rectangle(this.displayOffset.X + this.PortraitPosition.X, this.displayOffset.Y + this.PortraitPosition.Y, this.PortraitPosition.Width, this.PortraitPosition.Height), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4687f);
                }
                catch
                {
                }

                if (playerControlling && (GlobalVariables.SkyEye || troop.Scenario.IsCurrentPlayer(troop.BelongedFaction)))
                {
                    if (!troop.ControlAvail())
                    {
                        sourceRectangle = null;
                        spriteBatch.Draw(this.NoControlTexture, this.NoControlIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                    }
                    else 
                    {
                        switch (troop.ControlState)
                        {
                            case TroopControlState.Undone:
                                sourceRectangle = null;
                                spriteBatch.Draw(this.ActionUndoneTexture, this.ActionIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                                break;

                            case TroopControlState.Done:
                                sourceRectangle = null;
                                spriteBatch.Draw(this.ActionDoneTexture, this.ActionIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                                break;

                            case TroopControlState.Auto:
                                sourceRectangle = null;
                                spriteBatch.Draw(this.ActionAutoTexture, this.ActionIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                                break;

                            case TroopControlState.AutoDone:
                                sourceRectangle = null;
                                spriteBatch.Draw(this.ActionAutoDoneTexture, this.ActionIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                                break;
                        }
                    }
                    if (troop.Food < troop.FoodCostPerDay)
                    {
                        sourceRectangle = null;
                        spriteBatch.Draw(this.FoodShortageTexture, this.FoodIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                    }
                    /*
                    else
                    {
                        sourceRectangle = null;
                        spriteBatch.Draw(this.FoodNormalTexture, this.FoodIconDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                    }
                    */


                }
                if (troop.CurrentStunt != null)
                {
                    spriteBatch.Draw(this.StuntTexture, this.StuntIconDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.4688f);
                }
            }
        }

        private void ResetTextsPosition()
        {
            this.NameText.DisplayOffset = this.displayOffset;
            this.binglitext.DisplayOffset = this.displayOffset;
        }

        private Rectangle ActionIconDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.ActionIconPosition.X, this.DisplayOffset.Y + this.ActionIconPosition.Y, this.ActionIconPosition.Width, this.ActionIconPosition.Height);
            }
        }

        public Point DisplayOffset
        {
            get
            {
                return this.displayOffset;
            }
            set
            {
                this.displayOffset = value;
                this.ResetTextsPosition();
            }
        }

        private Rectangle FoodIconDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.FoodIconPosition.X, this.DisplayOffset.Y + this.FoodIconPosition.Y, this.FoodIconPosition.Width, this.FoodIconPosition.Height);
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
            }
        }

        private Rectangle NoControlIconDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.NoControlIconPosition.X, this.DisplayOffset.Y + this.NoControlIconPosition.Y, this.NoControlIconPosition.Width, this.NoControlIconPosition.Height);
            }
        }

        private Rectangle StuntIconDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.StuntIconPosition.X, this.DisplayOffset.Y + this.StuntIconPosition.Y, this.StuntIconPosition.Width, this.StuntIconPosition.Height);
            }
        }

        private int shiqitiaokuandu(Troop troop)
        {
            return troop.Army.Morale * this.shiqitiaoweizhi.Width  / troop.Army.MoraleCeiling;
        }
    }

 

}
