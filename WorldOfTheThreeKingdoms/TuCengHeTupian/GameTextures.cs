using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameGlobal;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using GameObjects.MapDetail;
using GameObjects.TroopDetail;
using GameObjects.Animations;
using GameObjects.ArchitectureDetail;

namespace WorldOfTheThreeKingdoms.Resources

{

        public class GameTextures
        {
            //public Texture2D BackgroundMap;
            public Texture2D[] MapVeilTextures;
            public Texture2D[] MouseArrowTextures;
            public Texture2D[] RoutewayDirectionArrowTextures;
            public Texture2D[] RoutewayDirectionTailTextures;
            public Texture2D[] RoutewayTextures;
            public Texture2D SelectorTexture;
            public Texture2D[] TerrainTextures;
            public Texture2D[] TileFrameTextures;
            public Texture2D qizitupian;
            public Texture2D huangditupian;
            //public Texture2D jianzhubiaotibeijing;
            public Texture2D zidongcundangtupian;
            public Dictionary<int, Texture2D> mediumCityImg = new Dictionary<int, Texture2D>();
            public Dictionary<int, Texture2D> largeCityImg = new Dictionary<int, Texture2D>();
            public Texture2D[] guandetupian = new Texture2D[3];
            public Texture2D wanggetupian;
            public Texture2D EditModeGrid;
            public Texture2D LandConnect;
            public Texture2D WaterConnect;
            public Texture2D SingleConnect;

            public void LoadTextures(GraphicsDevice device, GameScenario scenario)
            {
                Exception exception;
                string str;
                //this.BackgroundMap = Texture2D.FromFile(device, "Resources/bg.jpg");

                try
                {
                    this.MouseArrowTextures = new Texture2D[Enum.GetValues(typeof(MouseArrowKind)).Length];
                    this.MouseArrowTextures[0] = Texture2D.FromFile(device, "Resources/MouseArrow/Normal.png");
                    this.MouseArrowTextures[1] = Texture2D.FromFile(device, "Resources/MouseArrow/Left.png");
                    this.MouseArrowTextures[2] = Texture2D.FromFile(device, "Resources/MouseArrow/Right.png");
                    this.MouseArrowTextures[3] = Texture2D.FromFile(device, "Resources/MouseArrow/Top.png");
                    this.MouseArrowTextures[4] = Texture2D.FromFile(device, "Resources/MouseArrow/Bottom.png");
                    this.MouseArrowTextures[5] = Texture2D.FromFile(device, "Resources/MouseArrow/TopLeft.png");
                    this.MouseArrowTextures[6] = Texture2D.FromFile(device, "Resources/MouseArrow/TopRight.png");
                    this.MouseArrowTextures[7] = Texture2D.FromFile(device, "Resources/MouseArrow/BottomLeft.png");
                    this.MouseArrowTextures[8] = Texture2D.FromFile(device, "Resources/MouseArrow/BottomRight.png");
                    this.MouseArrowTextures[9] = Texture2D.FromFile(device, "Resources/MouseArrow/Selecting.png");
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception("The MouseArrow Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    foreach (TerrainDetail detail in scenario.GameCommonData.AllTerrainDetails.TerrainDetails.Values)
                    {
                        str = "Resources/Terrain/" + detail.ID.ToString() + "/";
                        detail.Textures.BasicTextures.Clear();
                        if (Directory.Exists(str))
                        {
                            foreach (string str2 in Directory.GetFiles(str))
                            {
                                FileInfo info = new FileInfo(str2);
                                if (info.Extension.Equals(".bmp") && info.Name.Contains("Basic"))
                                {
                                    detail.Textures.BasicTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                /*    
                                else if (info.Extension.Equals(".png") && info.Name.Contains("TopLeftCorner"))
                                {
                                    detail.Textures.TopLeftCornerTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("TopRightCorner"))
                                {
                                    detail.Textures.TopRightCornerTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("BottomLeftCorner"))
                                {
                                    detail.Textures.BottomLeftCornerTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("BottomRightCorner"))
                                {
                                    detail.Textures.BottomRightCornerTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("Centre"))
                                {
                                    detail.Textures.CentreTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("LeftEdge"))
                                {
                                    detail.Textures.LeftEdgeTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("TopEdge"))
                                {
                                    detail.Textures.TopEdgeTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("RightEdge"))
                                {
                                    detail.Textures.RightEdgeTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("BottomEdge"))
                                {
                                    detail.Textures.BottomEdgeTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("Left"))
                                {
                                    detail.Textures.LeftTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("Top"))
                                {
                                    detail.Textures.TopTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("Right"))
                                {
                                    detail.Textures.RightTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                else if (info.Extension.Equals(".png") && info.Name.Contains("Bottom"))
                                {
                                    detail.Textures.BottomTextures.Add(Texture2D.FromFile(device, str2));
                                }
                                */
                            }
                        }
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception("The Terrain Textures are not completely loaded.\n" + exception.ToString());
                }
                try         //加载建筑
                {
                    foreach (ArchitectureKind kind in scenario.GameCommonData.AllArchitectureKinds.ArchitectureKinds.Values )
                    {
                        kind.Device = device;
                    }
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    throw new Exception("The Architecture Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    foreach (MilitaryKind kind2 in scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
                    {
                        str = "Resources/Troop/" + kind2.ID.ToString() + "/";
                        if (Directory.Exists(str))
                        {
                            TroopTextures textures = new TroopTextures
                            {
                                Device = device,
                                MoveTextureFileName = str + "Move.png",
                                AttackTextureFileName = str + "Attack.png",
                                BeAttackedTextureFileName = str + "BeAttacked.png",
                                CastTextureFileName = str + "Cast.png"
                            };
                            if (!File.Exists(textures.CastTextureFileName))
                            {
                                textures.CastTextureFileName = textures.AttackTextureFileName;
                            }
                            textures.BeCastedTextureFileName = str + "BeCasted.png";
                            if (!File.Exists(textures.BeCastedTextureFileName))
                            {
                                textures.BeCastedTextureFileName = textures.BeAttackedTextureFileName;
                            }
                            kind2.Textures = textures;
                            TroopSounds sounds = new TroopSounds
                            {
                                MovingSoundPath = str + "Moving.wav",
                                NormalAttackSoundPath = str + "NormalAttack.wav",
                                CriticalAttackSoundPath = str + "CriticalAttack.wav"
                            };
                            kind2.Sounds = sounds;
                        }
                    }
                }
                catch (Exception exception4)
                {
                    exception = exception4;
                    throw new Exception("The Troop Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    this.MapVeilTextures = new Texture2D[Enum.GetValues(typeof(MapVeilKind)).Length];
                    this.MapVeilTextures[0] = Texture2D.FromFile(device, "Resources/MapVeil/Gray.bmp");
                }
                catch (Exception exception5)
                {
                    exception = exception5;
                    throw new Exception("The MapVeil Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    this.TileFrameTextures = new Texture2D[Enum.GetValues(typeof(TileFrameKind)).Length];
                    this.TileFrameTextures[0] = Texture2D.FromFile(device, "Resources/TileFrame/White.png");
                    this.TileFrameTextures[1] = Texture2D.FromFile(device, "Resources/TileFrame/Black.png");
                    this.TileFrameTextures[2] = Texture2D.FromFile(device, "Resources/TileFrame/Red.png");
                    this.TileFrameTextures[3] = Texture2D.FromFile(device, "Resources/TileFrame/Blue.png");
                    this.TileFrameTextures[4] = Texture2D.FromFile(device, "Resources/TileFrame/Green.png");
                    this.TileFrameTextures[5] = Texture2D.FromFile(device, "Resources/TileFrame/Purple.png");
                    this.TileFrameTextures[6] = Texture2D.FromFile(device, "Resources/TileFrame/Yellow.png");
                }
                catch (Exception exception6)
                {
                    exception = exception6;
                    throw new Exception("The TileFrame Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    this.RoutewayTextures = new Texture2D[Enum.GetValues(typeof(RoutewayState)).Length];
                    this.RoutewayTextures[0] = Texture2D.FromFile(device, "Resources/Routeway/Planning.png");
                    this.RoutewayTextures[1] = Texture2D.FromFile(device, "Resources/Routeway/Active.png");
                    this.RoutewayTextures[2] = Texture2D.FromFile(device, "Resources/Routeway/Inefficiency.png");
                    this.RoutewayTextures[3] = Texture2D.FromFile(device, "Resources/Routeway/Building.png");
                    this.RoutewayTextures[4] = Texture2D.FromFile(device, "Resources/Routeway/NoFood.png");
                    this.RoutewayTextures[5] = Texture2D.FromFile(device, "Resources/Routeway/Hostile.png");
                    this.RoutewayDirectionArrowTextures = new Texture2D[Enum.GetValues(typeof(SimpleDirection)).Length];
                    this.RoutewayDirectionArrowTextures[0] = Texture2D.FromFile(device, "Resources/Routeway/DirectionArrowNone.png");
                    this.RoutewayDirectionArrowTextures[1] = Texture2D.FromFile(device, "Resources/Routeway/DirectionArrowLeft.png");
                    this.RoutewayDirectionArrowTextures[2] = Texture2D.FromFile(device, "Resources/Routeway/DirectionArrowUp.png");
                    this.RoutewayDirectionArrowTextures[3] = Texture2D.FromFile(device, "Resources/Routeway/DirectionArrowRight.png");
                    this.RoutewayDirectionArrowTextures[4] = Texture2D.FromFile(device, "Resources/Routeway/DirectionArrowDown.png");
                    this.RoutewayDirectionTailTextures = new Texture2D[Enum.GetValues(typeof(SimpleDirection)).Length];
                    this.RoutewayDirectionTailTextures[1] = Texture2D.FromFile(device, "Resources/Routeway/DirectionTailLeft.png");
                    this.RoutewayDirectionTailTextures[2] = Texture2D.FromFile(device, "Resources/Routeway/DirectionTailUp.png");
                    this.RoutewayDirectionTailTextures[3] = Texture2D.FromFile(device, "Resources/Routeway/DirectionTailRight.png");
                    this.RoutewayDirectionTailTextures[4] = Texture2D.FromFile(device, "Resources/Routeway/DirectionTailDown.png");
                }
                catch (Exception exception7)
                {
                    exception = exception7;
                    throw new Exception("The Routeway Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    foreach (Animation animation in scenario.GameCommonData.AllTileAnimations.Animations.Values)
                    {
                        animation.Device = device;
                        animation.TextureFileName = "Resources/Effects/TileEffect/" + animation.Name + ".png";
                        
                        animation.MaleSoundPath = "GameSound/Animation/Male/" + animation.Name + ".wav";
                        if (!File.Exists(animation.MaleSoundPath))
                        {
                            animation.MaleSoundPath = "GameSound/Animation/" + animation.Name + ".wav";
                        }
                        
                        animation.FemaleSoundPath = "GameSound/Animation/Female/" + animation.Name + ".wav";
                        if (!File.Exists(animation.FemaleSoundPath))
                        {
                            animation.FemaleSoundPath = "GameSound/Animation/" + animation.Name + ".wav";
                        }
                     
                    }
                }
                catch (Exception exception8)
                {
                    exception = exception8;
                    throw new Exception("The TileAnimation Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    scenario.GameCommonData.NumberGenerator.Device = device;
                    scenario.GameCommonData.NumberGenerator.TextureFileName = "Resources/Effects/CombatNumber/CombatNumber.png";
                }
                catch (Exception exception9)
                {
                    exception = exception9;
                    throw new Exception("The NumberGenerator Textures are not completely loaded.\n" + exception.ToString());
                }
                try
                {
                    this.SelectorTexture = Texture2D.FromFile(device, "Resources/Effects/Selector/Selector.png");
                }
                catch (Exception exception10)
                {
                    exception = exception10;
                    throw new Exception("The NumberGenerator Textures are not completely loaded.\n" + exception.ToString());
                }

                try
                {
                    this.qizitupian = Texture2D.FromFile(device, "Resources/Architecture/qizi.png");
                }
                catch (Exception exception11)
                {
                    exception = exception11;
                    throw new Exception("The qizi Textures are not completely loaded.\n" + exception.ToString());
                }

                try
                {
                    this.huangditupian  = Texture2D.FromFile(device, "Resources/Architecture/huangdi.png");
                }
                catch (Exception exception11)
                {
                    exception = exception11;
                    throw new Exception("The huangdi Textures are not completely loaded.\n" + exception.ToString());
                }

                try
                {
                    this.LandConnect = Texture2D.FromFile(device, "Resources/Architecture/LandConnect.png");
                    this.WaterConnect = Texture2D.FromFile(device, "Resources/Architecture/WaterConnect.png");
                    this.SingleConnect = Texture2D.FromFile(device, "Resources/Architecture/SingleConnect.png");
                }
                catch (Exception exception12)
                {
                    exception = exception12;
                    throw new Exception("The ArchitectureConnect Textures are not completely loaded.\n" + exception.ToString());
                }

                //this.jianzhubiaotibeijing = Texture2D.FromFile(device, "Resources/Architecture/jianzhubiaotibeijing.png");

                mediumCityImg.Clear();
                largeCityImg.Clear();
                string[] filePaths = Directory.GetFiles("Resources/Architecture/", "*.png");
                foreach (String s in filePaths)
                {
                    string fileName = s.Substring(s.LastIndexOf('/') + 1, s.LastIndexOf('.') - s.LastIndexOf('/') - 1);
                    if (fileName.IndexOf('-') < 0)
                    {
                        continue;
                    }
                    string archIdStr = fileName.Substring(0, fileName.IndexOf('-'));
                    string size = fileName.Substring(fileName.IndexOf('-') + 1);

                    int archId;
                    if (int.TryParse(archIdStr, out archId) && (size.Equals("5") || size.Equals("13")))
                    {
                        if (size.Equals("5"))
                        {
                            mediumCityImg.Add(archId, Texture2D.FromFile(device, s));
                        }
                        else
                        {
                            largeCityImg.Add(archId, Texture2D.FromFile(device, s));
                        }
                    }
                }

                this.guandetupian[0] = Texture2D.FromFile(device, "Resources/Architecture/hengguan3.png");
                this.guandetupian[1] = Texture2D.FromFile(device, "Resources/Architecture/shuguan3.png");
                this.guandetupian[2] = Texture2D.FromFile(device, "Resources/Architecture/shuguan5.png");
                this.wanggetupian = Texture2D.FromFile(device, "Resources/TileFrame/wangge.png");
                this.EditModeGrid = Texture2D.FromFile(device, "Resources/TileFrame/Blue.png");
                this.zidongcundangtupian  = Texture2D.FromFile(device, "Resources/Effects/zidongcundang.png");
            }
        }

 



 

}
