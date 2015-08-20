using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameGlobal;
using Microsoft.Xna.Framework.Graphics;
using GameFreeText;
using GameObjects;

namespace ArchitectureSurveyPlugin
{
    internal class ArchitectureSurvey
    {
        public FreeText AgricultureText;
        public Architecture ArchitectureToSurvey;
        public FreeText ArmyText;
        public Point BackgroundSize;
        public Texture2D BackgroundTexture;
        public FreeText CommerceText;
        private bool Controlling;
        public Point ControllingBackgroundSize;
        public Texture2D ControllingBackgroundTexture;
        public Point CurrentPosition;
        private Point displayOffset;
        public FreeText DominationText;
        public FreeText EnduranceText;
        public Color FactionColor;
        public Rectangle FactionPosition;
        public FreeText FactionText;
        public Texture2D FactionTexture;
        public FreeText FoodText;
        public FreeText FundText;
        public FreeText KindText;
        public int Left;
        public InformationLevel Level;
        public FreeText MoraleText;
        public FreeText NameText;
        public FreeText NoFactionPersonCountText;
        public FreeText PersonCountText;
        public FreeText PopulationText;
        public FreeText MilitaryPopulationText;
        public FreeText FacilityCountText;
        public FreeText TechnologyText;
        public int Top;
        public Faction ViewingFaction;

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle? nullable;
            if (!this.Controlling)
            {
                nullable = null;
                spriteBatch.Draw(this.BackgroundTexture, new Rectangle(this.displayOffset.X, this.displayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y), nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.05f);
                spriteBatch.Draw(this.FactionTexture, new Rectangle(this.displayOffset.X + this.FactionPosition.X, this.displayOffset.Y + this.FactionPosition.Y, this.FactionPosition.Width, this.FactionPosition.Height), null, this.FactionColor, 0f, Vector2.Zero, SpriteEffects.None, 0.049f);
                this.NameText.Draw(spriteBatch, 0.05f);
                this.KindText.Draw(spriteBatch, 0.05f);
                this.FactionText.Draw(spriteBatch, 0.05f);
                this.PopulationText.Draw(spriteBatch, 0.05f);
                this.MilitaryPopulationText.Draw(spriteBatch, 0.05f);
                this.ArmyText.Draw(spriteBatch, 0.05f);
                this.DominationText.Draw(spriteBatch, 0.05f);
                this.EnduranceText.Draw(spriteBatch, 0.05f);
            }
            else
            {
                nullable = null;
                spriteBatch.Draw(this.ControllingBackgroundTexture, new Rectangle(this.displayOffset.X, this.displayOffset.Y, this.ControllingBackgroundSize.X, this.ControllingBackgroundSize.Y), nullable, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.05f);
                spriteBatch.Draw(this.FactionTexture, new Rectangle(this.displayOffset.X + this.FactionPosition.X, this.displayOffset.Y + this.FactionPosition.Y, this.FactionPosition.Width, this.FactionPosition.Height), null, this.FactionColor, 0f, Vector2.Zero, SpriteEffects.None, 0.049f);
                this.NameText.Draw(spriteBatch, 0.05f);
                this.KindText.Draw(spriteBatch, 0.05f);
                this.FactionText.Draw(spriteBatch, 0.05f);
                this.PopulationText.Draw(spriteBatch, 0.05f);
                this.MilitaryPopulationText.Draw(spriteBatch, 0.05f);
                this.ArmyText.Draw(spriteBatch, 0.05f);
                this.DominationText.Draw(spriteBatch, 0.05f);
                this.EnduranceText.Draw(spriteBatch, 0.05f);
                this.FundText.Draw(spriteBatch, 0.05f);
                this.FoodText.Draw(spriteBatch, 0.05f);
                this.PersonCountText.Draw(spriteBatch, 0.05f);
                this.FacilityCountText.Draw(spriteBatch, 0.05f);
                this.NoFactionPersonCountText.Draw(spriteBatch, 0.05f);
                this.AgricultureText.Draw(spriteBatch, 0.05f);
                this.CommerceText.Draw(spriteBatch, 0.05f);
                this.TechnologyText.Draw(spriteBatch, 0.05f);
                this.MoraleText.Draw(spriteBatch, 0.05f);
            }
        }

        private void ResetTextsPosition()
        {
            this.NameText.DisplayOffset = this.displayOffset;
            this.KindText.DisplayOffset = this.displayOffset;
            this.FactionText.DisplayOffset = this.displayOffset;
            this.PopulationText.DisplayOffset = this.displayOffset;
            this.MilitaryPopulationText.DisplayOffset = this.displayOffset;
            this.ArmyText.DisplayOffset = this.displayOffset;
            this.DominationText.DisplayOffset = this.displayOffset;
            this.EnduranceText.DisplayOffset = this.displayOffset;
            this.FundText.DisplayOffset = this.displayOffset;
            this.FoodText.DisplayOffset = this.displayOffset;
            this.PersonCountText.DisplayOffset = this.displayOffset;
            this.FacilityCountText.DisplayOffset = this.displayOffset;
            this.NoFactionPersonCountText.DisplayOffset = this.displayOffset;
            this.AgricultureText.DisplayOffset = this.displayOffset;
            this.CommerceText.DisplayOffset = this.displayOffset;
            this.TechnologyText.DisplayOffset = this.displayOffset;
            this.MoraleText.DisplayOffset = this.displayOffset;
        }

        public void Update()
        {
            Rectangle rectangle;
            this.FactionColor = Color.White;
            string meigongzuoderenshuzifuchuan;
            if (this.ArchitectureToSurvey.BelongedFaction != null)
            {
                this.FactionColor = this.ArchitectureToSurvey.BelongedFaction.FactionColor;
            }
            if (((this.ViewingFaction != null) && !GlobalVariables.SkyEye) && (this.ViewingFaction != this.ArchitectureToSurvey.BelongedFaction))
            {
                this.Controlling = false;
                rectangle = new Rectangle(this.Left - this.BackgroundSize.X, this.Top - this.BackgroundSize.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
                StaticMethods.AdjustRectangleInViewport(ref rectangle);
                this.DisplayOffset = new Point(rectangle.X, rectangle.Y);
                this.NameText.Text = this.ArchitectureToSurvey.Name;
                this.KindText.Text = this.ArchitectureToSurvey.KindString;
                this.FactionText.Text = this.ArchitectureToSurvey.FactionString;
                this.PopulationText.Text = this.ArchitectureToSurvey.PopulationInInformationLevel(this.Level);
                this.MilitaryPopulationText.Text = this.ArchitectureToSurvey.MilitaryPopulationInInformationLevel(this.Level);
                //this.ArmyText.Text = this.ArchitectureToSurvey.ArmyQuantityInInformationLevel(this.Level);

                //////////////////////////////////////////////////////////临时代码 ，合理的应该恢复上句并修改GameObjects.Architecture
                if (this.Level == InformationLevel.未知 || this.Level == InformationLevel.无 || this.Level == InformationLevel.低)
                {
                    this.ArmyText.Text = this.ArchitectureToSurvey.ArmyQuantityInInformationLevel(this.Level);
                }
                else
                {
                    this.ArmyText.Text = this.ArchitectureToSurvey.MilitaryCount.ToString() + "/" + this.ArchitectureToSurvey.ArmyQuantity.ToString();

                }
                /////////////////////////////////////////////////////////////
                this.DominationText.Text = this.ArchitectureToSurvey.DominationInInformationLevel(this.Level);
                this.EnduranceText.Text = this.ArchitectureToSurvey.EnduranceInInformationLevel(this.Level);
            }
            else
            {
                this.Controlling = true;
                rectangle = new Rectangle(this.Left - this.ControllingBackgroundSize.X, this.Top - this.ControllingBackgroundSize.Y, this.ControllingBackgroundSize.X, this.ControllingBackgroundSize.Y);
                StaticMethods.AdjustRectangleInViewport(ref rectangle);
                meigongzuoderenshuzifuchuan = meigongzuoderenshu(this.ArchitectureToSurvey).ToString();

                this.DisplayOffset = new Point(rectangle.X, rectangle.Y);
                this.NameText.Text = this.ArchitectureToSurvey.Name;
                this.KindText.Text = this.ArchitectureToSurvey.KindString;
                this.FactionText.Text = this.ArchitectureToSurvey.FactionString;
                this.PopulationText.Text = this.ArchitectureToSurvey.Population.ToString();
                this.MilitaryPopulationText.Text = this.ArchitectureToSurvey.MilitaryPopulation.ToString();
                this.ArmyText.Text =this.ArchitectureToSurvey.MilitaryCount.ToString()+"/"+   this.ArchitectureToSurvey.ArmyQuantity.ToString();
                this.DominationText.Text = this.ArchitectureToSurvey.DominationString;
                this.EnduranceText.Text = this.ArchitectureToSurvey.EnduranceString;
                this.FundText.Text = this.ArchitectureToSurvey.Fund.ToString();
                if (this.ArchitectureToSurvey.Food < 10000)
                {
                    this.FoodText.Text = (this.ArchitectureToSurvey.Food / 10000.0f).ToString("f1") + "万";

                }
                else
                {
                    this.FoodText.Text = Math.Floor(this.ArchitectureToSurvey.Food / 10000.0f).ToString() + "万";
                }
                this.PersonCountText.Text =meigongzuoderenshuzifuchuan +"/"+ this.ArchitectureToSurvey.PersonCount.ToString();
                this.FacilityCountText.Text = this.ArchitectureToSurvey.SheshiMiaoshu;
                this.NoFactionPersonCountText.Text = this.ArchitectureToSurvey.NoFactionPersonCount.ToString();
                this.AgricultureText.Text = this.ArchitectureToSurvey.AgricultureString;
                this.CommerceText.Text = this.ArchitectureToSurvey.CommerceString;
                this.TechnologyText.Text = this.ArchitectureToSurvey.TechnologyString;
                this.MoraleText.Text = this.ArchitectureToSurvey.MoraleString;
            }
        }

        private int  meigongzuoderenshu(Architecture jianzhu)
        {
            int renshu = 0;
            foreach (Person person in jianzhu.Persons.GetList())    
            {
                if (person.WorkKind == ArchitectureWorkKind.无)
                {
                    renshu ++;
                }
            }
            return renshu;
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
    }

 

}
