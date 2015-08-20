namespace PersonPortraitPlugin
{
    using GameObjects;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;

    public class PersonPortraitPlugin : GameObject, IPersonPortrait, IBasePlugin
    {
        private string author = "clip_on";
        private string description = "人物头像";
        private const string Path = @"GameComponents\PersonPortrait\";
        private PersonPortrait personPortrait = new PersonPortrait();
        private string pluginName = "PersonPortraitPlugin";
        private string version = "1.0.0";

        public void Dispose()
        {
        }

        public bool HasPortrait(int id)
        {
            return this.personPortrait.HasPortrait(id);
        }

        public Image GetImage(int id)
        {
            return this.personPortrait.GetImage(id);
        }

        public Texture2D GetPortrait(int id)
        {
            return this.personPortrait.GetPortrait(id);
        }

        public Texture2D GetSmallPortrait(int id)
        {
            return this.personPortrait.GetSmallPortrait(id);
        }

        public void Initialize()
        {
            this.personPortrait.TempImageFileName = @"GameComponents\PersonPortrait\~tmp.image";
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.personPortrait.Device = device;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

