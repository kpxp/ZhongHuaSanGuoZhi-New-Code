namespace MapEditor
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using Microsoft.Xna.Framework;
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class MapPanel : Panel
    {
        public ImageList ArchitectureImageList;
        public bool DisplayBarrack = false;
        public bool DisplayBlock = false;
        public bool DisplayCity = false;
        public bool DisplayDesert = false;
        public bool DisplayForest = false;
        public bool DisplayGrassland = false;
        public bool DisplayGrid = false;
        public bool DisplayMarsh = false;
        public bool DisplayMountain = false;
        public bool DisplayNone = false;
        public bool DisplayPlain = false;
        public bool DisplayPort = false;
        public bool DisplayRidge = false;
        public bool DisplayRiver = false;
        public bool DisplayWasteland = false;
        public bool DrawShowRegion = false;
        private Graphics graphics;
        public string[] mapDataValueString;
        public Pen MapPen = new Pen(Color.Black);
        public GameScenario Scenario = new GameScenario(null);
        public int ShowRegionHeight;
        public int ShowRegionWidth;
        public int ShowRegionX;
        public int ShowRegionY;
        public bool StartPaintingMap = false;
        public ImageList TerrainImageList;

        public Architecture AddArchitecture(int X, int Y, int architectureIndex)
        {
            int x = X / this.TileWidth;
            int y = Y / this.TileHeight;
            if (this.GetArchitecture(new System.Drawing.Point(x, y)) == null)
            {
                int freeGameObjectID = this.Architectures.GetFreeGameObjectID();
                Architecture t = new Architecture();
                t.ID = freeGameObjectID;
                t.Name = "建筑";
                t.Kind = this.Scenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind(architectureIndex);
                t.Scenario = this.Scenario;
                t.LocationState = this.Scenario.States[0] as GameObjects.ArchitectureDetail.State;
                StaticMethods.LoadFromString(t.ArchitectureArea.Area, x.ToString() + " " + y.ToString());
                this.Architectures.Add(t);
                return t;
            }
            return null;
        }

        public bool ChangeArchitectureData(Architecture a, int X, int Y)
        {
            int x = X / this.TileWidth;
            int y = Y / this.TileHeight;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            if (a.ArchitectureArea.HasPoint(new Microsoft.Xna.Framework.Point(x, y)))
            {
                return false;
            }
            if (!a.ArchitectureArea.GetContactArea(false).HasPoint(new Microsoft.Xna.Framework.Point(x, y)))
            {
                return false;
            }
            foreach (Architecture architecture in this.Architectures)
            {
                int pointIndex = architecture.ArchitectureArea.GetPointIndex(new Microsoft.Xna.Framework.Point(x, y));
                if (pointIndex >= 0)
                {
                    architecture.ArchitectureArea.Area.RemoveAt(pointIndex);
                    if (pointIndex == 0)
                    {
                        this.Architectures.Remove(architecture);
                    }
                    break;
                }
            }
            a.ArchitectureArea.AddPoint(new Microsoft.Xna.Framework.Point(x, y));
            return true;
        }

        public void ChangeMapData(int X, int Y, int terrainIndex, int width, bool horizontal)
        {
            if (this.mapDataValueString != null)
            {
                int num = X / this.TileWidth;
                int num2 = Y / this.TileHeight;
                for (int i = 1; i <= width; i++)
                {
                    int num4;
                    if (!horizontal)
                    {
                        num4 = num + (((num2 + i) - 1) * this.TileCountX);
                        if (num4 > this.Scenario.ScenarioMap.MapTileCount)
                        {
                            break;
                        }
                        this.mapDataValueString[num4] = terrainIndex.ToString();
                    }
                    else
                    {
                        num4 = ((num + i) - 1) + (num2 * this.TileCountX);
                        if (num4 > this.Scenario.ScenarioMap.MapTileCount)
                        {
                            break;
                        }
                        this.mapDataValueString[num4] = terrainIndex.ToString();
                    }
                }
            }
        }

        public bool DeleteArchitecture(int X, int Y, bool whole)
        {
            int x = X / this.TileWidth;
            int y = Y / this.TileHeight;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            int index = -1;
            for (int i = 0; i < this.Architectures.Count; i++)
            {
                if ((this.Architectures[i] as Architecture).ArchitectureArea.HasPoint(new Microsoft.Xna.Framework.Point(point.X, point.Y)))
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
            {
                if (whole)
                {
                    this.Architectures.RemoveAt(index);
                }
                else
                {
                    (this.Architectures[index] as Architecture).ArchitectureArea.Area.Remove(new Microsoft.Xna.Framework.Point(point.X, point.Y));
                    if ((this.Architectures[index] as Architecture).AreaCount == 0)
                    {
                        this.Architectures.RemoveAt(index);
                    }
                }
                return true;
            }
            return false;
        }

        private void DoPaint()
        {
            if (this.StartPaintingMap && !this.DrawShowRegion)
            {
                System.Drawing.Rectangle rectangle;
                for (int i = 0; i < this.TileCountY; i++)
                {
                    for (int j = 0; j < this.TileCountX; j++)
                    {
                        if (this.DisplayGrid)
                        {
                            rectangle = new System.Drawing.Rectangle(j * this.TileWidth, i * this.TileHeight, this.TileWidth, this.TileHeight);
                            if ((((rectangle.Left < this.ShowRegionX) || (rectangle.Top < this.ShowRegionY)) || (rectangle.Right > (this.ShowRegionX + this.ShowRegionWidth))) || (rectangle.Bottom > (this.ShowRegionY + this.ShowRegionHeight)))
                            {
                                continue;
                            }
                            this.graphics.DrawRectangle(this.MapPen, rectangle);
                        }
                        rectangle = new System.Drawing.Rectangle((j * this.TileWidth) + 1, (i * this.TileHeight) + 1, this.TileWidth - 1, this.TileHeight - 1);
                        if ((((rectangle.Left >= this.ShowRegionX) && (rectangle.Top >= this.ShowRegionY)) && (rectangle.Right <= (this.ShowRegionX + this.ShowRegionWidth))) && (rectangle.Bottom <= (this.ShowRegionY + this.ShowRegionHeight)))
                        {
                            string s = this.mapDataValueString[j + (i * this.TileCountX)];
                            if ((s != null) && (s.Length > 0))
                            {
                                int num3 = int.Parse(s);
                                if (((((num3 != 0) || this.DisplayNone) && ((num3 != 1) || this.DisplayPlain)) && (((num3 != 2) || this.DisplayGrassland) && ((num3 != 3) || this.DisplayForest))) && (((num3 != 4) || this.DisplayMarsh) && ((((((num3 != 5) || this.DisplayMountain) && ((num3 != 6) || this.DisplayRiver)) && ((num3 != 7) || this.DisplayRidge)) && ((num3 != 8) || this.DisplayWasteland)) && ((num3 != 9) || this.DisplayDesert))))
                                {
                                    this.graphics.DrawImage(this.TerrainImageList.Images[num3], rectangle);
                                }
                            }
                        }
                    //Label_02A2:;
                    }
                }
                foreach (Architecture architecture in this.Architectures)
                {
                    foreach (Microsoft.Xna.Framework.Point point in architecture.ArchitectureArea.Area)
                    {
                        rectangle = new System.Drawing.Rectangle((point.X * this.TileWidth) + 1, (point.Y * this.TileHeight) + 1, this.TileWidth - 1, this.TileHeight - 1);
                        if ((((((rectangle.Left >= this.ShowRegionX) && (rectangle.Top >= this.ShowRegionY)) && (rectangle.Right <= (this.ShowRegionX + this.ShowRegionWidth))) && (rectangle.Bottom <= (this.ShowRegionY + this.ShowRegionHeight))) && ((architecture.Kind.ID != 1) || this.DisplayCity)) && ((((architecture.Kind.ID != 2) || this.DisplayBlock) && ((architecture.Kind.ID != 3) || this.DisplayPort)) && ((architecture.Kind.ID != 4) || this.DisplayBarrack)))
                        {
                            try
                            {
                                this.graphics.DrawImage(this.ArchitectureImageList.Images[architecture.Kind.ID], rectangle);
                            }
                            catch
                            {
                                this.graphics.DrawImage(this.ArchitectureImageList.Images[4], rectangle);

                            }
                        }
                    }
                }
            }
        }

        private Architecture GetArchitecture(System.Drawing.Point p)
        {
            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.ArchitectureArea.HasPoint(new Microsoft.Xna.Framework.Point(p.X, p.Y)))
                {
                    return architecture;
                }
            }
            return null;
        }

        public Architecture GetArchitectureByMouse(int X, int Y)
        {
            int x = X / this.TileWidth;
            int y = Y / this.TileHeight;
            return this.GetArchitecture(new System.Drawing.Point(x, y));
        }

        public string GetCoordString(int X, int Y)
        {
            int num = X / this.TileWidth;
            int num2 = Y / this.TileHeight;
            return ("坐标:" + num.ToString() + "," + num2.ToString());
        }

        private void InitializeComponent()
        {
        }

        public void LoadMapData()
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            this.mapDataValueString = this.Scenario.ScenarioMap.SaveToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.graphics = pe.Graphics;
            Thread thread = new Thread(new ThreadStart(this.DoPaint));
            thread.Start();
            thread.Join();
            base.OnPaint(pe);
        }

        public void ReGenID()
        {
            for (int i = 0; i < this.Architectures.Count; i++)
            {
                this.Architectures[i].ID = i + 1;
            }
        }

        public void ResetMapDataValueString(int terrainIndex)
        {
            this.mapDataValueString = new string[this.TileCountX * this.TileCountY];
            for (int i = 0; i < this.mapDataValueString.Length; i++)
            {
                this.mapDataValueString[i] = terrainIndex.ToString();
            }
            this.Scenario.ScenarioMap.LoadMapData(this.mapDataValueString, this.TileCountX, this.TileCountY);
        }

        public void ResetMapPanelSize(int Margin)
        {
            base.Width = (this.TileWidth * this.TileCountX) + Margin;
            base.Height = (this.TileHeight * this.TileCountY) + Margin;
        }

        public void SaveMapData()
        {
            this.Scenario.ScenarioMap.LoadMapData(this.mapDataValueString, this.TileCountX, this.TileCountY);
        }

        public void SetShowRegion(int X, int Y, int width, int height)
        {
            this.ShowRegionX = X;
            this.ShowRegionY = Y;
            this.ShowRegionWidth = width;
            this.ShowRegionHeight = height;
        }

        public ArchitectureList Architectures
        {
            get
            {
                return this.Scenario.Architectures;
            }
        }

        public FactionList Factions
        {
            get
            {
                return this.Scenario.Factions;
            }
        }

        public PersonList Persons
        {
            get
            {
                return this.Scenario.Persons;
            }
        }

        public int TileCountX
        {
            get
            {
                return this.Scenario.ScenarioMap.MapDimensions.X;
            }
        }

        public int TileCountY
        {
            get
            {
                return this.Scenario.ScenarioMap.MapDimensions.Y;
            }
        }

        public int TileHeight
        {
            get
            {
                return this.Scenario.ScenarioMap.TileHeight;
            }
            set
            {
                this.Scenario.ScenarioMap.TileHeight = value;
            }
        }

        public int TileWidth
        {
            get
            {
                return this.Scenario.ScenarioMap.TileWidth;
            }
            set
            {
                this.Scenario.ScenarioMap.TileWidth = value;
            }
        }
    }
}

