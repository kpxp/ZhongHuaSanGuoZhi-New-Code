using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;
using GameFreeText;
using		Microsoft.Xna.Framework;

using WorldOfTheThreeKingdoms;
using Microsoft.Xna.Framework.Graphics;
using GameObjects.Animations;
using WorldOfTheThreeKingdoms.Resources;


namespace WorldOfTheThreeKingdoms.GameScreens.ScreenLayers

{
    internal class ArchitectureLayer
    {
        private ArchitectureList Architectures;
        private GameScenario gameScenario;
        private MainMapLayer mainMapLayer;

        static Point currentFrame = new Point(0, 0);
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 180;
        Point frameSize = new Point(100, 100);
        Point sheetSize = new Point(6, 1);

        private Texture2D huangditupian;

        public void Draw(SpriteBatch spriteBatch, Point viewportSize, Texture2D qizitupian, GameTime gameTime)
        {

            if (spriteBatch != null)
            {
                foreach (Architecture architecture in this.Architectures)
                {
                    Color zainanyanse = new Color();
                    if (architecture.youzainan )
                    {
                        zainanyanse=Color.Red ;
                    }
                    else
                    {
                        zainanyanse=Color.White;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        if (this.mainMapLayer.TileInScreen(point))
                        {
                            //Rectangle? sourceRectangle = null;
                            /*
                            if (point == architecture.ArchitectureArea.TopLeft && point.Y>0)
                            {
                                architecture.jianzhubiaoti.Position = this.mainMapLayer.GetDestination(point);
                                architecture.jianzhubiaoti.Draw(spriteBatch, 0.7999f);
                                if (architecture.BelongedFaction != null && this.mainMapLayer.TileInScreen(architecture.jianzhuqizi.qizipoint))      //不是空城的话绘制旗子
                                {
                                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds; 
                                    if (timeSinceLastFrame > millisecondsPerFrame) 
                                    { 
                                         timeSinceLastFrame-= millisecondsPerFrame; 
                                        ++currentFrame.X;
                                        if (currentFrame.X >= sheetSize.X)
                                        {
                                            currentFrame.X = 0;
                                            //++currentFrame.Y;
                                            //if (currentFrame.Y >= sheetSize.Y)
                                            //    currentFrame.Y = 0;
                                        }
                                    }

                                    
                                     spriteBatch.Draw(qizitupian, this.mainMapLayer.GetDestination(architecture.jianzhuqizi.qizipoint), 
                                        new Rectangle(currentFrame.X * frameSize.X,
                                          currentFrame.Y * frameSize.Y,
                                          frameSize.X,
                                          frameSize.Y),
                                     
                                    architecture.BelongedFaction.FactionColor, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
                                    
                                    //architecture.jianzhuqizi.qizidezi.Position = this.mainMapLayer.huoquqizijuxing (architecture.jianzhuqizi.qizipoint);
                                    //architecture.jianzhuqizi.qizidezi.Draw(spriteBatch, 0.7999f, architecture.jianzhuqizi.qizidezi.Position);
                                    
                                    if (architecture.huangdisuozai)
                                    {
                                        spriteBatch.Draw(huangditupian,
                                            this.mainMapLayer.GetDestination(new Point(architecture.jianzhuqizi.qizipoint.X+1,architecture.jianzhuqizi.qizipoint.Y)),
                                            null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                        

                                    }
                                    
                                
                                }
                            } //end      if (point == architecture.ArchitectureArea.TopLeft && point.Y>0)
                            */
                            
                            

                            if (architecture.Kind.ID == 2)  //绘制关隘
                            {
                                //spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
                                if (architecture.JianzhuGuimo == 1)
                                {
                                }
                                else if (architecture.ArchitectureArea.Area[0].X == architecture.ArchitectureArea.Area[1].X) //绘制竖关
                                {

                                   // spriteBatch.Draw(gameScenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind(5).Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                }
                                else
                                {
                                   // spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                }
                            }

                            else
                            {
                                //spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                            }                         
                            
                            if ((GlobalVariables.SkyEye || this.gameScenario.NoCurrentPlayer) || this.gameScenario.CurrentPlayer.IsArchitectureKnown(architecture))
                            {
                                if (!architecture.IncrementNumberList.IsEmpty)
                                {
                                    architecture.IncrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                }
                                if (!architecture.DecrementNumberList.IsEmpty)
                                {
                                    architecture.DecrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                    //sourceRectangle = null;
                                    spriteBatch.Draw(this.mainMapLayer.screen.Textures.TileFrameTextures[2], this.mainMapLayer.GetDestination(point), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.799f);
                                }
                            }
                            else
                            {
                                architecture.IncrementNumberList.Clear();
                                architecture.DecrementNumberList.Clear();
                            }
                        }
                        else
                        {
                            architecture.IncrementNumberList.Clear();
                            architecture.DecrementNumberList.Clear();
                        }
                    }
                }
            }
        }





        public void Initialize(MainMapLayer mainMapLayer, GameScenario scenario,MainGameScreen mainGameScreen)
        {
            this.mainMapLayer = mainMapLayer;
            this.Architectures = scenario.Architectures;
            this.gameScenario = scenario;
            //this.huangditupian = huangditupian;
        }
    }

 

}
