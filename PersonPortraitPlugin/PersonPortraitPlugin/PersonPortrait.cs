namespace PersonPortraitPlugin
{
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Resources;

    public class PersonPortrait
    {
        internal GraphicsDevice Device;
        internal Dictionary<int, PlayerImage> PlayerImages = new Dictionary<int, PlayerImage>();
        private Dictionary<int, PortraitItem> portraits = new Dictionary<int, PortraitItem>();
        internal string TempImageFileName;

        private PlayerImage defaultImage;

        public PersonPortrait()
        {
            defaultImage = LoadImage(9999);
        }

        public bool HasPortrait(int id) 
        {
            return GetImage(id) != defaultImage.Portrait;
        }

        internal Image GetImage(int id)
        {
            Image portrait = null;
            PlayerImage image = null;
            
            if (!this.PlayerImages.TryGetValue(id, out image))
            {
                image = this.LoadImage(id);
                if (image == null)
                {
                    image = defaultImage;
                    
                }
                this.PlayerImages.Add(id, image);
            }

            portrait = image.Portrait;

            return portrait;
        }

        private PortraitItem GetItem(int id)
        {
            PortraitItem item;
            this.portraits.TryGetValue(id, out item);
            if (item == null)
            {
                PlayerImage image = null;
                this.PlayerImages.TryGetValue(id, out image);
                if (image == null)
                {
                    image = this.LoadImage(id);
                    this.PlayerImages.Add(id, image);
                    if (image == null)
                    {
                        image = defaultImage;
                    }
                }
                item = new PortraitItem();
                image.Portrait.Save(this.TempImageFileName);
                item.PortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                image.SmallPortrait.Save(this.TempImageFileName);
                item.SmallPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                this.portraits.Add(id, item);
            }
            return item;
        }

        internal Texture2D GetPortrait(int id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.PortraitTexture;
            }
            return null;
        }

        internal Texture2D GetSmallPortrait(int id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.SmallPortraitTexture;
            }
            return null;
        }

        private PlayerImage LoadImage(string path, int id)
        {
            if (File.Exists(path + @"\" + id + "s.jpg"))
            {
                PlayerImage image = new PlayerImage
                {
                    Portrait = Image.FromFile(path + @"\" + id + ".jpg"),
                    SmallPortrait = Image.FromFile(path + @"\" + id + "s.jpg")
                };
                return image;
            }
            return null;
        }

        private PlayerImage LoadImage(int id)
        {
            PlayerImage result = this.LoadImage(@"GameComponents\PersonPortrait\Images\Player", id);
            if (result == null)
            {
                result = this.LoadImage(@"GameComponents\PersonPortrait\Images\Default", id);
            }
            return result;
        }

    }
}

