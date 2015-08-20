namespace GameFreeText
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Drawing;

    public class FreeText
    {
        private TextAlign align;
        private Microsoft.Xna.Framework.Rectangle alignedPosition;
        public FreeTextBuilder Builder;
        private Microsoft.Xna.Framework.Point displayOffset;
        private Microsoft.Xna.Framework.Rectangle position;
        private string text;
        private Microsoft.Xna.Framework.Graphics.Color textColor;
        private Texture2D textTexture;

        public FreeText(FreeTextBuilder builder)
        {
            this.position = Microsoft.Xna.Framework.Rectangle.Empty;
            this.displayOffset = Microsoft.Xna.Framework.Point.Zero;
            this.align = TextAlign.None;
            this.textColor = Microsoft.Xna.Framework.Graphics.Color.Black;
            this.textTexture = null;
            this.Builder = builder;
        }

        public FreeText(GraphicsDevice device, Font font)
        {
            this.position = Microsoft.Xna.Framework.Rectangle.Empty;
            this.displayOffset = Microsoft.Xna.Framework.Point.Zero;
            this.align = TextAlign.None;
            this.textColor = Microsoft.Xna.Framework.Graphics.Color.Black;
            this.textTexture = null;
            this.Builder = new FreeTextBuilder();
            this.Builder.SetFreeTextBuilder(device, font);
        }

        public FreeText(GraphicsDevice device, Font font, Microsoft.Xna.Framework.Graphics.Color color)
        {
            this.position = Microsoft.Xna.Framework.Rectangle.Empty;
            this.displayOffset = Microsoft.Xna.Framework.Point.Zero;
            this.align = TextAlign.None;
            this.textColor = Microsoft.Xna.Framework.Graphics.Color.Black;
            this.textTexture = null;
            this.Builder = new FreeTextBuilder();
            this.Builder.SetFreeTextBuilder(device, font);
            this.textColor = color;
        }

        public void Draw(SpriteBatch spriteBatch, float Depth, Microsoft.Xna.Framework.Rectangle weizhijuxing)
        {
            if (this.textTexture != null)
            {
                spriteBatch.Draw(this.textTexture, weizhijuxing , null, this.textColor, 0f, Vector2.Zero, SpriteEffects.None, Depth + -0.0001f);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.textTexture != null)
            {
                spriteBatch.Draw(this.textTexture, this.alignedPosition, this.textColor);
            }
        }

        public void Draw(SpriteBatch spriteBatch, float Depth)
        {
            if (this.textTexture != null)
            {
                spriteBatch.Draw(this.textTexture, this.alignedPosition, null, this.textColor, 0f, Vector2.Zero, SpriteEffects.None, Depth + -0.0001f);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Graphics.Color color, float Depth)
        {
            if (this.textTexture != null)
            {
                spriteBatch.Draw(this.textTexture, this.alignedPosition, null, color, 0f, Vector2.Zero, SpriteEffects.None, Depth + -0.0001f);
            }
        }

        public void Draw(SpriteBatch spriteBatch, float Rotation, float Depth)
        {
            if (this.textTexture != null)
            {
                spriteBatch.Draw(this.textTexture, this.alignedPosition, null, this.textColor, Rotation, Vector2.Zero, SpriteEffects.None, Depth + -0.0001f);
            }
        }

        private void ResetAlignedPosition()
        {
            if (((this.align != TextAlign.None) && (this.textTexture != null)) && !(this.position == Microsoft.Xna.Framework.Rectangle.Empty))
            {
                switch (this.align)
                {
                    case TextAlign.Left:
                        this.alignedPosition = StaticMethods.LeftRectangle(this.DisplayPosition, new Microsoft.Xna.Framework.Rectangle(0, 0, this.textTexture.Width, this.textTexture.Height));
                        break;

                    case TextAlign.Middle:
                        this.alignedPosition = StaticMethods.CenterRectangle(this.DisplayPosition, new Microsoft.Xna.Framework.Rectangle(0, 0, this.textTexture.Width, this.textTexture.Height));
                        break;

                    case TextAlign.Right:
                        this.alignedPosition = StaticMethods.RightRectangle(this.DisplayPosition, new Microsoft.Xna.Framework.Rectangle(0, 0, this.textTexture.Width, this.textTexture.Height));
                        break;
                }
            }
        }

        private void ResetTextTexture()
        {
            if (this.text != null)
            {
                this.TextTexture = this.Builder.CreateTextTexture(this.text);
            }
        }

        public TextAlign Align
        {
            get
            {
                return this.align;
            }
            set
            {
                this.align = value;
                this.ResetAlignedPosition();
            }
        }

        public Microsoft.Xna.Framework.Rectangle AlignedPosition
        {
            get
            {
                return this.alignedPosition;
            }
        }

        public Microsoft.Xna.Framework.Point DisplayOffset
        {
            get
            {
                return this.displayOffset;
            }
            set
            {
                this.displayOffset = value;
                this.ResetAlignedPosition();
            }
        }

        public Microsoft.Xna.Framework.Rectangle DisplayPosition
        {
            get
            {
                return new Microsoft.Xna.Framework.Rectangle(this.position.X + this.displayOffset.X, this.position.Y + this.displayOffset.Y, this.position.Width, this.position.Height);
            }
        }

        public int Height
        {
            get
            {
                return ((this.textTexture == null) ? 0 : this.textTexture.Height);
            }
        }

        public Microsoft.Xna.Framework.Rectangle Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                this.ResetAlignedPosition();
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.ResetTextTexture();
            }
        }

        public Microsoft.Xna.Framework.Graphics.Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                this.textColor = value;
                this.ResetTextTexture();
            }
        }

        public Texture2D TextTexture
        {
            get
            {
                return this.textTexture;
            }
            set
            {
                this.textTexture = value;
                this.ResetAlignedPosition();
            }
        }

        public int Width
        {
            get
            {
                return ((this.textTexture == null) ? 0 : this.textTexture.Width);
            }

        }
    }
}

