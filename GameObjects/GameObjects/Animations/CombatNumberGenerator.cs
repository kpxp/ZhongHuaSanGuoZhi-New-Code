namespace GameObjects.Animations
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class CombatNumberGenerator
    {
        public GraphicsDevice Device;
        public int DigitHeight = 20;
        public int DigitWidth = 12;
        private Texture2D texture;
        public string TextureFileName;

        public Rectangle GetCurrentArrowRectangle(CombatNumberKind kind, CombatNumberDirection direction)
        {
            return new Rectangle(this.DigitWidth * (10 + (int) direction), this.DigitHeight * (((int) kind *(int)  CombatNumberKind.战意) + (((int) direction))), this.DigitWidth, this.DigitHeight);
        }

        public Rectangle GetCurrentDigitRectangle(CombatNumberKind kind, CombatNumberDirection direction, int digit)
        {
            return new Rectangle(this.DigitWidth * digit, this.DigitHeight * (((int) kind *(int)  CombatNumberKind.战意) + ( ((int) direction))), this.DigitWidth, this.DigitHeight);
        }

        public Texture2D Texture
        {
            get
            {
                if (this.texture == null)
                {
                    this.texture = Texture2D.FromFile(this.Device, this.TextureFileName);
                    this.DigitWidth = this.texture.Width / 12;
                    this.DigitHeight = (this.texture.Height / Enum.GetValues(typeof(CombatNumberKind)).Length) / 2;
                }
                return this.texture;
            }
        }
    }
}

