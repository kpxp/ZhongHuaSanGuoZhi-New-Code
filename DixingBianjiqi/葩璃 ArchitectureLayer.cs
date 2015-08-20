using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;

using		Microsoft.Xna.Framework;

using WorldOfTheThreeKingdoms;
using Microsoft.Xna.Framework.Graphics;
using GameObjects.Animations;



namespace WorldOfTheThreeKingdoms.GameScreens.ScreenLayers

{
    internal class ArchitectureLayer
    {
        private ArchitectureList Architectures;
        private GameScenario gameScenario;
        private MainMapLayer mainMapLayer;
        private Point point;


        public void Draw(SpriteBatch spriteBatch, Point viewportSize, GameTime gameTime)
        {
            if (spriteBatch != null)
            {
                foreach (Architecture architecture in this.Architectures)
                {
                    /////////////////////////////////////////////////////////////////
                    if (architecture.Kind.ID == 1) //绘制城池
                    {                            

                        point = architecture.ArchitectureArea.TopLeft;
                        
                            if (this.mainMapLayer.TileInScreen(point))
                            {
                                Rectangle? sourceRectangle = null;

                                spriteBatch.Draw(architecture.Texture, this.mainMapLayer.huoqujianzhujuxing(point,architecture.AreaCount ), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
                                if ((GlobalVariables.SkyEye || this.gameScenario.NoCurrentPlayer) || this.gameScenario.CurrentPlayer.IsArchitectureKnown(architecture))
                                {
                                    if (!architecture.IncrementNumberList.IsEmpty)
                                    {
                                        architecture.IncrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                    }
                                    if (!architecture.DecrementNumberList.IsEmpty)
                                    {
                                        architecture.DecrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                        sourceRectangle = null;
                                        spriteBatch.Draw(this.mainMapLayer.screen.Textures.TileFrameTextures[2], this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.799f);
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
                    //////////////////////////////////////////////////////////////////
                    else
                    {
                        foreach (Point point in architecture.ArchitectureArea.Area)
                        {
                            if (this.mainMapLayer.TileInScreen(point))
                            {
                                Rectangle? sourceRectangle = null;



                                if (architecture.Kind.ID == 2 || architecture.Kind.ID == 5)  //绘制关隘
                                {
                                    //spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
                                    if (architecture.ArchitectureArea.Area[0].X == architecture.ArchitectureArea.Area[1].X) //忽略了关只有一块的特例，可能产生BUG
                                    {

                                        spriteBatch.Draw(gameScenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind(5).Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                    }
                                    else
                                    {
                                        spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                    }
                                }

                                else
                                {
                                    spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

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
                                        sourceRectangle = null;
                                        spriteBatch.Draw(this.mainMapLayer.screen.Textures.TileFrameTextures[2], this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.799f);
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
        }

        public void Initialize(MainMapLayer mainMapLayer, GameScenario scenario)
        {
            this.mainMapLayer = mainMapLayer;
            this.Architectures = scenario.Architectures;
            this.gameScenario = scenario;
        }
    }

 

}
