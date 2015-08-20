using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using System.IO;


namespace WorldOfTheThreeKingdoms
{
    internal class beijingtupian
    {
        internal System.Drawing.Bitmap bm = new System.Drawing.Bitmap("Resources/bg.jpg");

        /*
        public static Texture2D BitmapToTexture2D(GraphicsDevice device, System.Drawing.Bitmap image)
        {
            //Buffer size is size of color array multiplied by 4 because each pixel has four color bytes
            int bufferSize = image.Height * image.Width * 4;
            // Create new memory stream and save image to stream so wo don't have to save and read file
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bufferSize);
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            // Creates a texture from IO.stream - our memory stream
            image.setdata
            Texture2D texture=Texture2D.FromStream(device,memoryStream);
            texture.SetData 
            return texture;
        }
        */

        public Texture2D BitmapToTexture2D(GraphicsDevice device, System.Drawing.Bitmap bmp)
        {

            using  (MemoryStream s = new  MemoryStream()) 
            {     bmp.Save(s, System.Drawing.Imaging.ImageFormat.Png);  
                s.Seek(0, SeekOrigin.Begin);
                Texture2D tx = Texture2D.FromFile(device, s);
                return tx;
            }  



        }

        public MemoryStream BitmapToMemoryStream(GraphicsDevice device, System.Drawing.Bitmap bmp)
        {

                MemoryStream s = new MemoryStream();
            
                bmp.Save(s,System.Drawing.Imaging.ImageFormat.Bmp);
                s.Seek(0, SeekOrigin.Begin);

                return s;
            



        }

        internal Texture2D huoqupingmutuxing(int x, int y, int w, int h,GraphicsDevice device)
        {
             //剪切大小

 

             System.Drawing.Graphics g;

             //以大小为剪切大小，像素格式为32位RGB创建一个位图对像

             System.Drawing.Bitmap bm1 = new System.Drawing.Bitmap(w,h,System.Drawing.Imaging.PixelFormat.Format24bppRgb) ;

            //定义一个区域

             System.Drawing.Rectangle rg = new System.Drawing.Rectangle(x,y,w,h);

             //要绘制到的位图

             g = System.Drawing.Graphics.FromImage(bm1);

             //将bm内rg所指定的区域绘制到bm1

             g.DrawImage(bm, new System.Drawing.Rectangle(0, 0, w, h), rg, System.Drawing.GraphicsUnit.Pixel);


            return BitmapToTexture2D(device ,bm1);


        }
        
 
        
    
        internal void jiazaibeijingtupian(GraphicsDevice device)
        {
           // MemoryStream s = this.BitmapToMemoryStream(device, bm);

        }

        internal Texture2D caijiandituxiaokuai(Microsoft.Xna.Framework.Point point, int i, int j,GraphicsDevice device)
        {
            int w = bm.Width / point.X;
            int h = bm.Height / point.Y;
            return huoqupingmutuxing(i * w, j * h, w, h, device);
 
        }

        internal MemoryStream caijianneicunliu(Microsoft.Xna.Framework.Point point, int i, int j, GraphicsDevice device)
        {
            int w = bm.Width / point.X;
            int h = bm.Height / point.Y;
            return this.huoquneicunliu(i * w, j * h, w, h, device);
        }

        private MemoryStream huoquneicunliu(int x, int y, int w, int h, GraphicsDevice device)
        {
            //剪切大小



            System.Drawing.Graphics g;

            //以大小为剪切大小，像素格式为32位RGB创建一个位图对像

            System.Drawing.Bitmap bm1 = new System.Drawing.Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //定义一个区域

            System.Drawing.Rectangle rg = new System.Drawing.Rectangle(x, y, w, h);

            //要绘制到的位图

            g = System.Drawing.Graphics.FromImage(bm1);

            //将bm内rg所指定的区域绘制到bm1

            g.DrawImage(bm, new System.Drawing.Rectangle(0, 0, w, h), rg, System.Drawing.GraphicsUnit.Pixel);


            return this.BitmapToMemoryStream(device, bm1);
        }
    }
}
