using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;
using		Microsoft.Xna.Framework;
using WorldOfTheThreeKingdoms;
using Microsoft.Xna.Framework.Graphics;
using GameObjects.MapDetail;
using GameFreeText;
using System.Threading;
using System.IO;






namespace WorldOfTheThreeKingdoms.GameScreens.ScreenLayers

{
    public class MainMapLayer
    {
        //private beijingtupian beijingtupian = new beijingtupian();
        private Texture2D BackgroundMap;
        //private Texture2D BackgroundMap1;
        //private Texture2D BackgroundMap2;
        //private Texture2D BackgroundMap3;
        //private Texture2D BackgroundMap4;
        

        public List<Tile> DisplayingTiles = new List<Tile>();
        private GameScenario gameScenario;
        private int leftEdge = 0;
        public Map mainMap;
        public MainGameScreen screen;
        private GraphicsDevice device;
        private List<int> TerrainList = new List<int>();
        public Tile[,] Tiles;
        
        public int tileWidthMax = 100;
        public int tileWidthMin = 30;
        private int topEdge = 0;
        private Rectangle jianzhujuxing = new Rectangle();
        private Rectangle qizijuxing = new Rectangle();
        public bool xianshiwangge = false;

        private void CheckTileTexture(Tile tile, out List<Texture2D> decorativeTextures)
        {
            decorativeTextures = null;
            TerrainDetail terrainDetailByPositionNoCheck = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(tile.Position);
            if (terrainDetailByPositionNoCheck.Textures.BasicTextures.Count != 0)
            {
                int num;
                List<int> list;
                int num12;
                for (num = 0; num < this.TerrainList.Count; num++)
                {
                    this.TerrainList[num] = 0;
                }
                TerrainDirection none = TerrainDirection.None;
                int num2 = 0;
                Point position = new Point(tile.Position.X - 1, tile.Position.Y);
                int iD = 0;
                TerrainDetail detail2 = null;
                if (!this.screen.Scenario.PositionOutOfRange(position))
                {
                    detail2 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(position);
                    iD = detail2.ID;
                    (list = this.TerrainList)[num12 = this.mainMap.MapData[position.X, position.Y]] = list[num12] + 1;
                }
                Point point2 = new Point(tile.Position.X - 1, tile.Position.Y - 1);
                int num4 = 0;
                if (!this.screen.Scenario.PositionOutOfRange(point2))
                {
                    num4 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point2).ID;
                    (list = this.TerrainList)[num12 = this.mainMap.MapData[point2.X, point2.Y]] = list[num12] + 1;
                }
                Point point3 = new Point(tile.Position.X, tile.Position.Y - 1);
                int num5 = 0;
                TerrainDetail detail4 = null;
                if (!this.screen.Scenario.PositionOutOfRange(point3))
                {
                    detail4 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point3);
                    num5 = detail4.ID;
                }
                Point point4 = new Point(tile.Position.X + 1, tile.Position.Y - 1);
                int num6 = 0;
                if (!this.screen.Scenario.PositionOutOfRange(point4))
                {
                    num6 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point4).ID;
                }
                Point point5 = new Point(tile.Position.X + 1, tile.Position.Y);
                int num7 = 0;
                TerrainDetail detail6 = null;
                if (!this.screen.Scenario.PositionOutOfRange(point5))
                {
                    detail6 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point5);
                    num7 = detail6.ID;
                }
                Point point6 = new Point(tile.Position.X + 1, tile.Position.Y + 1);
                int num8 = 0;
                if (!this.screen.Scenario.PositionOutOfRange(point6))
                {
                    num8 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point6).ID;
                }
                Point point7 = new Point(tile.Position.X, tile.Position.Y + 1);
                int num9 = 0;
                TerrainDetail detail8 = null;
                if (!this.screen.Scenario.PositionOutOfRange(point7))
                {
                    detail8 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point7);
                    num9 = detail8.ID;
                }
                Point point8 = new Point(tile.Position.X - 1, tile.Position.Y + 1);
                int num10 = 0;
                if (!this.screen.Scenario.PositionOutOfRange(point8))
                {
                    num10 = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(point8).ID;
                }
                int num11 = 0;
                if ((iD > 0) && (iD == terrainDetailByPositionNoCheck.ID))
                {
                    num11++;
                }
                if ((num5 > 0) && (num5 == terrainDetailByPositionNoCheck.ID))
                {
                    num11++;
                }
                if ((num7 > 0) && (num7 == terrainDetailByPositionNoCheck.ID))
                {
                    num11++;
                }
                if ((num9 > 0) && (num9 == terrainDetailByPositionNoCheck.ID))
                {
                    num11++;
                }
                if (num11 < 4)
                {
                    if (detail4 != null)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point3.X, point3.Y]] = list[num12] + 1;
                        for (num = 0; num < this.TerrainList.Count; num++)
                        {
                            if ((num != terrainDetailByPositionNoCheck.ID) && ((((this.TerrainList[num] >= 2) && (iD == num)) && (num4 != terrainDetailByPositionNoCheck.ID)) && (num5 == num)))
                            {
                                none = TerrainDirection.TopLeft;
                                num2 = num;
                                break;
                            }
                        }
                    }
                    if (num6 > 0)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point4.X, point4.Y]] = list[num12] + 1;
                    }
                    if (num7 > 0)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point5.X, point5.Y]] = list[num12] + 1;
                        for (num = 0; num < this.TerrainList.Count; num++)
                        {
                            if (num != terrainDetailByPositionNoCheck.ID)
                            {
                                if (((none == TerrainDirection.None) && (this.TerrainList[num] >= 2)) && (((num5 == num) && (num6 != terrainDetailByPositionNoCheck.ID)) && (num7 == num)))
                                {
                                    none = TerrainDirection.TopRight;
                                    num2 = num;
                                }
                                if (this.TerrainList[num] >= 3)
                                {
                                    if ((((iD == num) && (num5 == num)) && ((num7 == num) && (num6 != terrainDetailByPositionNoCheck.ID))) && (num4 != terrainDetailByPositionNoCheck.ID))
                                    {
                                        none = TerrainDirection.Top;
                                        num2 = num;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (num8 > 0)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point6.X, point6.Y]] = list[num12] + 1;
                    }
                    if (num9 > 0)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point7.X, point7.Y]] = list[num12] + 1;
                        for (num = 0; num < this.TerrainList.Count; num++)
                        {
                            if (num != terrainDetailByPositionNoCheck.ID)
                            {
                                if (((none == TerrainDirection.None) && (this.TerrainList[num] >= 2)) && (((num7 == num) && (num8 != terrainDetailByPositionNoCheck.ID)) && (num9 == num)))
                                {
                                    none = TerrainDirection.BottomRight;
                                    num2 = num;
                                }
                                if ((this.TerrainList[num] >= 3) && ((((num5 == num) && (num7 == num)) && ((num9 == num) && (num6 != terrainDetailByPositionNoCheck.ID))) && (num8 != terrainDetailByPositionNoCheck.ID)))
                                {
                                    none = TerrainDirection.Right;
                                    num2 = num;
                                }
                            }
                        }
                    }
                    if (num10 > 0)
                    {
                        (list = this.TerrainList)[num12 = this.mainMap.MapData[point8.X, point8.Y]] = list[num12] + 1;
                    }
                    if (iD > 0)
                    {
                        for (num = 0; num < this.TerrainList.Count; num++)
                        {
                            if (num != terrainDetailByPositionNoCheck.ID)
                            {
                                if (((none == TerrainDirection.None) && (this.TerrainList[num] >= 2)) && (((num9 == num) && (num10 != terrainDetailByPositionNoCheck.ID)) && (iD == num)))
                                {
                                    none = TerrainDirection.BottomLeft;
                                    num2 = num;
                                }
                                if ((this.TerrainList[num] >= 3) && ((((num7 == num) && (num9 == num)) && ((iD == num) && (num8 != terrainDetailByPositionNoCheck.ID))) && (num10 != terrainDetailByPositionNoCheck.ID)))
                                {
                                    none = TerrainDirection.Bottom;
                                    num2 = num;
                                }
                                if (((((this.TerrainList[num] >= 4) && (iD == num)) && ((num5 == num) && (num7 == num))) && (num9 == num)) && ((((num4 != terrainDetailByPositionNoCheck.ID) && (num6 != terrainDetailByPositionNoCheck.ID)) && ((num8 != terrainDetailByPositionNoCheck.ID) && (num10 != terrainDetailByPositionNoCheck.ID))) || (this.TerrainList[num] >= 7)))
                                {
                                    none = TerrainDirection.Centre;
                                    num2 = num;
                                    break;
                                }
                            }
                        }
                    }
                    if ((((none != TerrainDirection.Centre) && (none != TerrainDirection.Top)) && ((none != TerrainDirection.Right) && (none != TerrainDirection.Bottom))) && (num5 > 0))
                    {
                        for (num = 0; num < this.TerrainList.Count; num++)
                        {
                            if (((num != terrainDetailByPositionNoCheck.ID) && (this.TerrainList[num] >= 3)) && ((((num9 == num) && (iD == num)) && ((num5 == num) && (num10 != terrainDetailByPositionNoCheck.ID))) && (num4 != terrainDetailByPositionNoCheck.ID)))
                            {
                                none = TerrainDirection.Left;
                                num2 = num;
                            }
                        }
                    }
                    decorativeTextures = new List<Texture2D>();
                    switch (none)
                    {
                        case TerrainDirection.Top:
                            decorativeTextures.Add(detail4.Textures.TopTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopTextures.Count]);
                            if ((((detail8 != null) && (detail8.ID != terrainDetailByPositionNoCheck.ID)) && ((num8 != terrainDetailByPositionNoCheck.ID) && (num10 != terrainDetailByPositionNoCheck.ID))) && (detail8.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail8.Textures.BottomEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomEdgeTextures.Count]);
                            }
                            return;

                        case TerrainDirection.Left:
                            decorativeTextures.Add(detail2.Textures.LeftTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.LeftTextures.Count]);
                            if ((((detail6 != null) && (detail6.ID != terrainDetailByPositionNoCheck.ID)) && ((num6 != terrainDetailByPositionNoCheck.ID) && (num8 != terrainDetailByPositionNoCheck.ID))) && (detail6.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail6.Textures.RightEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.RightEdgeTextures.Count]);
                            }
                            return;

                        case TerrainDirection.Right:
                            decorativeTextures.Add(detail6.Textures.RightTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.RightTextures.Count]);
                            if ((((detail2 != null) && (detail2.ID != terrainDetailByPositionNoCheck.ID)) && ((num10 != terrainDetailByPositionNoCheck.ID) && (num4 != terrainDetailByPositionNoCheck.ID))) && (detail2.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail2.Textures.LeftEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.LeftEdgeTextures.Count]);
                            }
                            return;

                        case TerrainDirection.Bottom:
                            decorativeTextures.Add(detail8.Textures.BottomTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomTextures.Count]);
                            if ((((detail4 != null) && (detail4.ID != terrainDetailByPositionNoCheck.ID)) && ((num4 != terrainDetailByPositionNoCheck.ID) && (num6 != terrainDetailByPositionNoCheck.ID))) && (detail4.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail4.Textures.TopEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopEdgeTextures.Count]);
                            }
                            return;

                        case TerrainDirection.TopLeft:
                            decorativeTextures.Add(detail2.Textures.TopLeftCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.TopLeftCornerTextures.Count]);
                            if ((((detail6 == null) || (terrainDetailByPositionNoCheck.ID == num8)) || (num7 != num9)) || (terrainDetailByPositionNoCheck.ID == num7))
                            {
                                if ((((detail6 != null) && (detail6.ID != terrainDetailByPositionNoCheck.ID)) && ((num6 != terrainDetailByPositionNoCheck.ID) && (num8 != terrainDetailByPositionNoCheck.ID))) && (detail6.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail6.Textures.RightEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.RightEdgeTextures.Count]);
                                }
                                if ((((detail8 != null) && (detail8.ID != terrainDetailByPositionNoCheck.ID)) && ((num8 != terrainDetailByPositionNoCheck.ID) && (num10 != terrainDetailByPositionNoCheck.ID))) && (detail8.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail8.Textures.BottomEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomEdgeTextures.Count]);
                                }
                                return;
                            }
                            decorativeTextures.Add(detail6.Textures.BottomRightCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.BottomRightCornerTextures.Count]);
                            return;

                        case TerrainDirection.TopRight:
                            decorativeTextures.Add(detail4.Textures.TopRightCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopRightCornerTextures.Count]);
                            if ((((detail8 == null) || (terrainDetailByPositionNoCheck.ID == num10)) || (num9 != iD)) || (terrainDetailByPositionNoCheck.ID == num9))
                            {
                                if ((((detail2 != null) && (detail2.ID != terrainDetailByPositionNoCheck.ID)) && ((num10 != terrainDetailByPositionNoCheck.ID) && (num4 != terrainDetailByPositionNoCheck.ID))) && (detail2.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail2.Textures.LeftEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.LeftEdgeTextures.Count]);
                                }
                                if ((((detail8 != null) && (detail8.ID != terrainDetailByPositionNoCheck.ID)) && ((num8 != terrainDetailByPositionNoCheck.ID) && (num10 != terrainDetailByPositionNoCheck.ID))) && (detail8.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail8.Textures.BottomEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomEdgeTextures.Count]);
                                }
                                return;
                            }
                            decorativeTextures.Add(detail8.Textures.BottomLeftCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomLeftCornerTextures.Count]);
                            return;

                        case TerrainDirection.BottomLeft:
                            decorativeTextures.Add(detail8.Textures.BottomLeftCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomLeftCornerTextures.Count]);
                            if ((((detail4 == null) || (terrainDetailByPositionNoCheck.ID == num6)) || (num5 != num7)) || (terrainDetailByPositionNoCheck.ID == num5))
                            {
                                if ((((detail4 != null) && (detail4.ID != terrainDetailByPositionNoCheck.ID)) && ((num4 != terrainDetailByPositionNoCheck.ID) && (num6 != terrainDetailByPositionNoCheck.ID))) && (detail4.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail4.Textures.TopEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopEdgeTextures.Count]);
                                }
                                if ((((detail6 != null) && (detail6.ID != terrainDetailByPositionNoCheck.ID)) && ((num6 != terrainDetailByPositionNoCheck.ID) && (num8 != terrainDetailByPositionNoCheck.ID))) && (detail6.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail6.Textures.RightEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.RightEdgeTextures.Count]);
                                }
                                return;
                            }
                            decorativeTextures.Add(detail4.Textures.TopRightCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopRightCornerTextures.Count]);
                            return;

                        case TerrainDirection.BottomRight:
                            decorativeTextures.Add(detail6.Textures.BottomRightCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.BottomRightCornerTextures.Count]);
                            if ((((detail2 == null) || (terrainDetailByPositionNoCheck.ID == num4)) || (iD != num5)) || (terrainDetailByPositionNoCheck.ID == iD))
                            {
                                if ((((detail2 != null) && (detail2.ID != terrainDetailByPositionNoCheck.ID)) && ((num10 != terrainDetailByPositionNoCheck.ID) && (num4 != terrainDetailByPositionNoCheck.ID))) && (detail2.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail2.Textures.LeftEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.LeftEdgeTextures.Count]);
                                }
                                if ((((detail4 != null) && (detail4.ID != terrainDetailByPositionNoCheck.ID)) && ((num4 != terrainDetailByPositionNoCheck.ID) && (num6 != terrainDetailByPositionNoCheck.ID))) && (detail4.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                                {
                                    decorativeTextures.Add(detail4.Textures.TopEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopEdgeTextures.Count]);
                                }
                                return;
                            }
                            decorativeTextures.Add(detail2.Textures.TopLeftCornerTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.TopLeftCornerTextures.Count]);
                            return;

                        case TerrainDirection.Centre:
                            decorativeTextures.Add(detail2.Textures.CentreTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.CentreTextures.Count]);
                            return;

                        case TerrainDirection.None:
                            if ((((detail2 != null) && (detail2.ID != terrainDetailByPositionNoCheck.ID)) && ((num10 != terrainDetailByPositionNoCheck.ID) && (num4 != terrainDetailByPositionNoCheck.ID))) && (detail2.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail2.Textures.LeftEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail2.Textures.LeftEdgeTextures.Count]);
                            }
                            if ((((detail4 != null) && (detail4.ID != terrainDetailByPositionNoCheck.ID)) && ((num4 != terrainDetailByPositionNoCheck.ID) && (num6 != terrainDetailByPositionNoCheck.ID))) && (detail4.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail4.Textures.TopEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail4.Textures.TopEdgeTextures.Count]);
                            }
                            if ((((detail6 != null) && (detail6.ID != terrainDetailByPositionNoCheck.ID)) && ((num6 != terrainDetailByPositionNoCheck.ID) && (num8 != terrainDetailByPositionNoCheck.ID))) && (detail6.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail6.Textures.RightEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail6.Textures.RightEdgeTextures.Count]);
                            }
                            if ((((detail8 != null) && (detail8.ID != terrainDetailByPositionNoCheck.ID)) && ((num8 != terrainDetailByPositionNoCheck.ID) && (num10 != terrainDetailByPositionNoCheck.ID))) && (detail8.GraphicLayer < terrainDetailByPositionNoCheck.GraphicLayer))
                            {
                                decorativeTextures.Add(detail8.Textures.BottomEdgeTextures[((tile.Position.X * 7) + (tile.Position.Y * 11)) % detail8.Textures.BottomEdgeTextures.Count]);
                            }
                            return;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point viewportSize)
        {
            if (spriteBatch != null)
            {
                //if (GlobalVariables.LoadBackGroundMapTexture)
                if(true )

                {
                    int x = viewportSize.X;
                    int y = viewportSize.Y;
                    spriteBatch.Draw(this.BackgroundMap, new Rectangle(0, 0, x, y), new Rectangle((-this.BackgroundMap.Width * this.LeftEdge) / this.TotalTileWidth, (-this.BackgroundMap.Height * this.topEdge) / this.TotalTileHeight, (this.BackgroundMap.Width * x) / this.TotalTileWidth, (this.BackgroundMap.Height * y) / this.TotalTileHeight), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.9f);
                    //spriteBatch.Draw(this.BackgroundMap, new Rectangle(0 , 0 , x, y), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.9f);
                    if (this.xianshiwangge)
                    {
                        foreach (Tile tile in this.DisplayingTiles)
                        {
                            if (this.mainMap.MapData[tile.Position.X, tile.Position.Y] != 0 && this.mainMap.MapData[tile.Position.X, tile.Position.Y] != 7)
                            {
                                spriteBatch.Draw(this.screen.Textures.wanggetupian, tile.Destination, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.81f);
                            }
                        }
                    }

                }
                else
                {
                    foreach (Tile tile in this.DisplayingTiles)
                    {
                        Rectangle? sourceRectangle = null;


                        List<Texture2D> decorativeTextures = null;
                        this.CheckTileTexture(tile, out decorativeTextures);
                        
                        spriteBatch.Draw(tile.TileTexture, tile.Destination, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.9f);
                        if (decorativeTextures != null)
                        {
                            foreach (Texture2D textured in decorativeTextures)
                            {
                                sourceRectangle = null;
                                spriteBatch.Draw(textured, tile.Destination, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.8998f);
                            }
                        }
                    }
                }
            }
        }

        public Point GetCurrentScreenCenter(Point viewportSize)
        {
            return new Point(((viewportSize.X / 2) - this.LeftEdge) / this.TileWidth, ((viewportSize.Y / 2) - this.TopEdge) / this.TileHeight);
        }

        public Rectangle GetDestination(Point position)
        {
            return this.Tiles[position.X, position.Y].Destination;
        }
        public Rectangle huoqujianzhujuxing(Point position,Architecture jianzhu)
        {
            jianzhujuxing = this.Tiles[position.X, position.Y].Destination;//此句是为了防止出错。

            int guimo = jianzhu.JianzhuGuimo;

            if (jianzhu.Kind.ID  == 1)
            {
                if (guimo == 5)
                {
                    jianzhujuxing.X = (position.X - 1) * this.TileWidth + this.LeftEdge;
                    jianzhujuxing.Y = (position.Y - 1) * this.TileHeight + this.TopEdge;

                    jianzhujuxing.Width = this.TileWidth * 3;
                    jianzhujuxing.Height = this.TileHeight * 3;
                }
                else if (guimo == 13)
                {
                    jianzhujuxing.X = (position.X - 2) * this.TileWidth + this.LeftEdge;
                    jianzhujuxing.Y = (position.Y - 2) * this.TileHeight + this.TopEdge;

                    jianzhujuxing.Width = this.TileWidth * 5;
                    jianzhujuxing.Height = this.TileHeight * 5;

                }
            }
            else if (jianzhu.Kind.ID == 2)
            {
                if (guimo == 1)
                {
                    return jianzhujuxing;
                }
                else if (guimo == 5)
                {
                    if (jianzhu.ArchitectureArea.Area[0].X == jianzhu.ArchitectureArea.Area[1].X) //竖关
                    {
                        jianzhujuxing.X = (position.X - 2) * this.TileWidth + this.LeftEdge;
                        jianzhujuxing.Y = (position.Y - 3) * this.TileHeight + this.TopEdge;

                        jianzhujuxing.Width = this.TileWidth * 5;
                        jianzhujuxing.Height = this.TileHeight * 7;

                    }
                    else
                    {
                        jianzhujuxing.X = (position.X - 4) * this.TileWidth + this.LeftEdge;
                        jianzhujuxing.Y = (position.Y - 1) * this.TileHeight + this.TopEdge;

                        jianzhujuxing.Width = this.TileWidth * 9;
                        jianzhujuxing.Height = this.TileHeight * 3;
                    }
                }
                else if (guimo == 3)
                {
                    if (jianzhu.ArchitectureArea.Area[0].X == jianzhu.ArchitectureArea.Area[1].X) //竖关
                    {
                        jianzhujuxing.X = (position.X - 2) * this.TileWidth + this.LeftEdge;
                        jianzhujuxing.Y = (position.Y - 2) * this.TileHeight + this.TopEdge;

                        jianzhujuxing.Width = this.TileWidth * 5;
                        jianzhujuxing.Height = this.TileHeight * 5;
                    }
                    else
                    {
                        jianzhujuxing.X = (position.X - 2) * this.TileWidth + this.LeftEdge;
                        jianzhujuxing.Y = (position.Y -1) * this.TileHeight + this.TopEdge;

                        jianzhujuxing.Width = this.TileWidth * 5;
                        jianzhujuxing.Height = this.TileHeight * 3;
                    }
                }
            }
            return jianzhujuxing ;
        }
        public Rectangle huoquqizijuxing(Point position)
        {
            qizijuxing = this.Tiles[position.X, position.Y].Destination;
            qizijuxing.X += (int)(qizijuxing.Width * 0.08);
            qizijuxing.Y  += (int)(qizijuxing.Height  * 0.19);
            qizijuxing.Width = (int)(qizijuxing.Width * 0.7);
            qizijuxing.Height = (int)(qizijuxing.Height * 0.7);
            return qizijuxing;
        }


        public Rectangle GetHalfDestination(Point position)
        {
            return new Rectangle(this.Tiles[position.X, position.Y].Destination.X + (this.Tiles[position.X, position.Y].Destination.Width / 4), this.Tiles[position.X, position.Y].Destination.Y + (this.Tiles[position.X, position.Y].Destination.Height / 4), this.Tiles[position.X, position.Y].Destination.Width / 2, this.Tiles[position.X, position.Y].Destination.Height / 2);
        }

        public string GetTerrainNameByPosition(Point position)
        {
            return this.gameScenario.GetTerrainNameByPosition(position);
        }

        public Rectangle GetThreeFourthsDestination(Point position)
        {
            return new Rectangle(this.Tiles[position.X, position.Y].Destination.X + (this.Tiles[position.X, position.Y].Destination.Width / 8), this.Tiles[position.X, position.Y].Destination.Y + (this.Tiles[position.X, position.Y].Destination.Height / 8), (this.Tiles[position.X, position.Y].Destination.Width * 3) / 4, (this.Tiles[position.X, position.Y].Destination.Height * 3) / 4);
        }

        public Point GetTopCenterPoint(Point position)
        {
            return new Point(((position.X * this.TileWidth) + (this.TileWidth / 2)) + this.leftEdge, (position.Y * this.TileHeight) + this.topEdge);
        }

        public void Initialize(GameScenario scenario, MainGameScreen screen,GraphicsDevice device)
        {
            this.gameScenario = scenario;
            this.mainMap = scenario.ScenarioMap;
            this.screen = screen;
            this.device = device;
            this.TerrainList.Clear();
            for (int i = 0; i < Enum.GetValues(typeof(TerrainKind)).Length; i++)
            {
                this.TerrainList.Add(0);
            }
        }
        
        public void PrepareMap()
        {
            this.Tiles = null;
            this.Tiles = new Tile[this.mainMap.MapDimensions.X, this.mainMap.MapDimensions.Y];
            for (int i = 0; i < this.mainMap.MapDimensions.X; i++)
            {
                for (int j = 0; j < this.mainMap.MapDimensions.Y; j++)
                {
                    this.Tiles[i, j] = new Tile();
                    this.Tiles[i, j].Position = new Point(i, j);
                    TerrainDetail terrainDetailByPositionNoCheck = this.screen.Scenario.GetTerrainDetailByPositionNoCheck(this.Tiles[i, j].Position);
                    if (terrainDetailByPositionNoCheck != null)
                    {
                        if (terrainDetailByPositionNoCheck.Textures.BasicTextures.Count > 0)
                        {
                            this.Tiles[i, j].TileTexture = terrainDetailByPositionNoCheck.Textures.BasicTextures[((i * 7) + (j * 11)) % terrainDetailByPositionNoCheck.Textures.BasicTextures.Count];
                        }
                        else
                        {
                            this.Tiles[i, j].TileTexture = this.screen.Textures.TerrainTextures[this.mainMap.MapData[i, j]];
                        }
                    }
                }
            }
        }




        public void ReCalculateTileDestination(GraphicsDevice device)
        {
            
            this.ResetDisplayingTiles();
            foreach (Tile tile in this.DisplayingTiles)
            {
                tile.Destination.X = this.leftEdge + (tile.Position.X * this.TileWidth);
                tile.Destination.Y = this.topEdge + (tile.Position.Y * this.TileHeight);
                tile.Destination.Width = this.TileWidth;
                tile.Destination.Height = this.TileHeight;
            }
        }

        public void ResetDisplayingTiles()
        {

            if (this.Tiles != null)
            {
                this.DisplayingTiles.Clear();
                for (int i = this.screen.TopLeftPosition.X; i <= this.screen.BottomRightPosition.X; i++)
                {
                    for (int j = this.screen.TopLeftPosition.Y; j <= this.screen.BottomRightPosition.Y; j++)
                    {
                        if ((((i >= 0) && (i < this.mainMap.MapDimensions.X)) && (j >= 0)) && (j < this.mainMap.MapDimensions.Y))
                        {
                            this.DisplayingTiles.Add(this.Tiles[i, j]);
                        }
                    }
                }
            }
        }

        public bool TileInScreen(Point tile)
        {
            return this.screen.TileInScreen(tile);
        }

        public Point TranslateCoordinateToTilePosition(int coordinateX, int coordinateY)
        {
            int num = coordinateX - this.leftEdge;
            int num2 = coordinateY - this.topEdge;
            return new Point(num / this.TileWidth, num2 / this.TileHeight);
        }

        public int LeftEdge
        {
            get
            {
                return this.leftEdge;
            }
            set
            {
                this.leftEdge = value;
            }
        }

        public int TileHeight
        {
            get
            {
                return this.mainMap.TileHeight;
            }
        }

        public int TileWidth
        {
            get
            {
                return this.mainMap.TileWidth;
            }
            set
            {
                this.mainMap.TileWidth = value;
                if (this.mainMap.TileWidth < this.tileWidthMin)
                {
                    this.mainMap.TileWidth = this.tileWidthMin;
                }
                else if (this.mainMap.TileWidth > this.tileWidthMax)
                {
                    this.mainMap.TileWidth = this.tileWidthMax;
                }

            }
        }



        public int TopEdge
        {
            get
            {
                return this.topEdge;
            }
            set
            {
                this.topEdge = value;
            }
        }

        public Point TotalMapSize
        {
            get
            {
                return new Point(this.TotalTileWidth, this.TotalTileHeight);
            }
        }

        public int TotalTileHeight
        {
            get
            {
                return this.mainMap.TotalTileHeight;
            }
        }

        public int TotalTileWidth
        {
            get
            {
                return this.mainMap.TotalTileWidth;
            }
        }

        internal void jiazaibeijingtupian()
        {

            if (this.BackgroundMap != null)
            {
                this.BackgroundMap.Dispose();
            }
            //s=this.beijingtupian.BitmapToMemoryStream(device, bm);
            //bm.Dispose();

            //this.BackgroundMap = this.beijingtupian.huoqupingmutuxing(-this.LeftEdge, -this.TopEdge, this.screen.viewportSize.X, this.screen.viewportSize.Y,device );
            this.BackgroundMap = Texture2D.FromFile(device, "Resources/" + this.gameScenario.ScenarioMap.dituwenjian);
            


        }





    }

 

}
