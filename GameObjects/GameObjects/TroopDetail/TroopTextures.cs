namespace GameObjects.TroopDetail
{
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TroopTextures
    {
        public GraphicsDevice Device;
        public string MoveTextureFileName;
        private Texture2D moveTexture;
        public string AttackTextureFileName;
        private Texture2D attackTexture;
        public string BeAttackedTextureFileName;
        private Texture2D beAttackedTexture;
        public string CastTextureFileName;
        private Texture2D castTexture;
        public string BeCastedTextureFileName;
        private Texture2D beCastedTexture;
        public Texture2D MoveTexture
        {
            get
            {
                try
                {
                    if (this.moveTexture == null)
                    {
                        this.moveTexture = Texture2D.FromFile(this.Device, this.MoveTextureFileName);
                    }
                }
                catch
                {
                    if (this.moveTexture == null)
                    {
                        this.moveTexture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.moveTexture;
            }
        }
        public Texture2D AttackTexture
        {
            get
            {
                try
                {
                    if (this.attackTexture == null)
                    {
                        this.attackTexture = Texture2D.FromFile(this.Device, this.AttackTextureFileName);
                    }
                }
                catch
                {
                    if (this.attackTexture == null)
                    {
                        this.attackTexture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.attackTexture;
            }
        }
        public Texture2D BeAttackedTexture
        {
            get
            {
                try
                {
                    if (this.beAttackedTexture == null)
                    {
                        this.beAttackedTexture = Texture2D.FromFile(this.Device, this.BeAttackedTextureFileName);
                    }
                }
                catch
                {
                    if (this.beAttackedTexture == null)
                    {
                        this.beAttackedTexture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.beAttackedTexture;
            }
        }
        public Texture2D CastTexture
        {
            get
            {
                try
                {
                    if (this.castTexture == null)
                    {
                        if (this.CastTextureFileName == this.AttackTextureFileName)
                        {
                            this.castTexture = this.AttackTexture;
                        }
                        else
                        {
                            this.castTexture = Texture2D.FromFile(this.Device, this.CastTextureFileName);
                        }
                    }
                }
                catch
                {
                    if (this.castTexture == null)
                    {
                        this.castTexture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.castTexture;
            }
        }
        public Texture2D BeCastedTexture
        {
            get
            {
                try
                {
                    if (this.beCastedTexture == null)
                    {
                        if (this.BeCastedTextureFileName == this.BeAttackedTextureFileName)
                        {
                            this.beCastedTexture = this.BeAttackedTexture;
                        }
                        else
                        {
                            this.beCastedTexture = Texture2D.FromFile(this.Device, this.BeCastedTextureFileName);
                        }
                    }
                }
                catch
                {
                    if (this.beCastedTexture == null)
                    {
                        this.beCastedTexture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.beCastedTexture;
            }
        }
        public void Dispose()
        {
            if (this.moveTexture != null)
            {
                this.moveTexture.Dispose();
                this.moveTexture = null;
            }
            if (this.attackTexture != null)
            {
                this.attackTexture.Dispose();
                this.attackTexture = null;
            }
            if (this.beAttackedTexture != null)
            {
                this.beAttackedTexture.Dispose();
                this.beAttackedTexture = null;
            }
            if (this.castTexture != null)
            {
                this.castTexture.Dispose();
                this.castTexture = null;
            }
            if (this.beCastedTexture != null)
            {
                this.beCastedTexture.Dispose();
                this.beCastedTexture = null;
            }
        }
    }
}

