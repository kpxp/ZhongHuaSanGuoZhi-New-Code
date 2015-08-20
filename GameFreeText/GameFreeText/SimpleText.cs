namespace GameFreeText
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class SimpleText
    {
        public bool NewLine;
        public int Row;
        public string Text;
        public Color TextColor;
        public Rectangle TextPosition;
        public Texture2D TextTexture;

        public int Height
        {
            get
            {
                return ((this.TextTexture != null) ? this.TextTexture.Height : 0);
            }
        }

        public int Width
        {
            get
            {
                return ((this.TextTexture != null) ? this.TextTexture.Width : 0);
            }
        }
    }
}

