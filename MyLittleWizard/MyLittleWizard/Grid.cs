using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    class Grid
    {
        private List<Tile> aStarList;
        private Tile[,] tiles = new Tile[10, 10];

        public Tile[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Grid()
        {
            GridSetup();
            AddGrid();
        }

        private void GridSetup()
        {
            //Creates a 10x10 grid of Tiles with default value "grass"
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    tiles[x, y] = new Tile(new Vector2(x * 64, y * 64), new Vector2(x, y), Tiletype.grass);
                }
            }

            //Change the type of the tiles here

            //Creates the portal
            tiles[8, 1].Type = Tiletype.portal;

            //Creates the towers
            tiles[1, 8].Type = Tiletype.potionTower;
            tiles[9, 8].Type = Tiletype.frostTower;

            //Creates the path
            tiles[1, 3].Type = Tiletype.path;
            tiles[1, 4].Type = Tiletype.path;
            tiles[1, 5].Type = Tiletype.path;
            tiles[1, 6].Type = Tiletype.path;
            tiles[1, 7].Type = Tiletype.path;
            tiles[2, 7].Type = Tiletype.path;
            tiles[3, 7].Type = Tiletype.path;
            tiles[3, 8].Type = Tiletype.path;

            tiles[4, 8].Type = Tiletype.monsterPath;
            tiles[5, 8].Type = Tiletype.monsterPath;
            tiles[6, 8].Type = Tiletype.monsterPath;

            tiles[7, 8].Type = Tiletype.path;
            tiles[8, 8].Type = Tiletype.path;
            tiles[8, 7].Type = Tiletype.path;
            tiles[8, 6].Type = Tiletype.path;
            tiles[8, 5].Type = Tiletype.path;
            tiles[8, 4].Type = Tiletype.path;
            tiles[7, 4].Type = Tiletype.path;
            tiles[6, 4].Type = Tiletype.path;
            tiles[6, 3].Type = Tiletype.path;
            tiles[6, 2].Type = Tiletype.path;
            tiles[5, 2].Type = Tiletype.path;
            tiles[4, 2].Type = Tiletype.path;
            tiles[3, 2].Type = Tiletype.path;
            tiles[2, 2].Type = Tiletype.path;
            tiles[1, 2].Type = Tiletype.path;

            //Creates the walls
            tiles[0, 0].Type = Tiletype.wall;
            tiles[1, 0].Type = Tiletype.wall;
            tiles[2, 0].Type = Tiletype.wall;
            tiles[0, 1].Type = Tiletype.wall;

            tiles[3, 3].Type = Tiletype.wall;
            tiles[3, 4].Type = Tiletype.wall;
            tiles[3, 5].Type = Tiletype.wall;
            tiles[3, 6].Type = Tiletype.wall;
            tiles[4, 3].Type = Tiletype.wall;
            tiles[4, 4].Type = Tiletype.wall;
            tiles[4, 5].Type = Tiletype.wall;
            tiles[4, 6].Type = Tiletype.wall;
            tiles[5, 3].Type = Tiletype.wall;
            tiles[5, 4].Type = Tiletype.wall;
            tiles[5, 5].Type = Tiletype.wall;
            tiles[5, 6].Type = Tiletype.wall;

            //Creates the forest
            tiles[4, 7].Type = Tiletype.forest;
            tiles[5, 7].Type = Tiletype.forest;
            tiles[6, 7].Type = Tiletype.forest;
            tiles[4, 9].Type = Tiletype.forest;
            tiles[5, 9].Type = Tiletype.forest;
            tiles[6, 9].Type = Tiletype.forest;

            SpawnKeys();

            //Reevaluates the tile visual
            UpdateGrid();
        }

        private void SpawnKeys()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            bool keysSpawned = false;
            bool potionKeySpawned = false;
            bool frostKeySpawned = false;

            while (!keysSpawned)
            {
                int x = rand.Next(0, 10);
                int y = rand.Next(0, 10);

                if (!potionKeySpawned && (tiles[x, y].Type == Tiletype.grass || tiles[x, y].Type == Tiletype.path))
                {
                    tiles[x, y].Type = Tiletype.potionKey;
                    potionKeySpawned = true;
                }
                else if (!frostKeySpawned && (tiles[x, y].Type == Tiletype.grass || tiles[x, y].Type == Tiletype.path))
                {
                    tiles[x, y].Type = Tiletype.frostKey;
                    frostKeySpawned = true;
                }

                if(potionKeySpawned && frostKeySpawned)
                {
                    keysSpawned = true;
                }
            }
        }

        private void AddGrid()
        {
            //Adds the grid to the GameObjects list
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    GameWorld.GameObjects.Add(tiles[x, y]);
                }
            }
        }

        private void UpdateGrid()
        {
            //Updates the visual on each tile in the grid
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    tiles[x, y].ChangeType();
                }
            }
        }

        public Stack<Tile> AStar(Tile start, Tile goal)
        {
            ResetParents();
            List<Tile> open = new List<Tile>();
            List<Tile> closed = new List<Tile>();
            open.Add(start);

            Tile current = start;
            aStarList = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                for (int t = 0; t < 10; t++)
                {
                    aStarList.Add(GameWorld.GameGrid.tiles[i, t]);
                }
            }

            while (open.Count != 0)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        Tile nabo = aStarList.Find(z => z.GridPos == new Vector2(-1 + x + current.GridPos.X, -1 + y + current.GridPos.Y) && z != current && z.State != TileState.unwalkable);
                        if (!closed.Contains(nabo) && !open.Contains(nabo) && nabo != null)
                        {

                            nabo.Parent = current;
                            open.Add(nabo);


                        }

                    }
                }
                //for (int x = 0; x < 3; x++)
                //{
                //    for (int y = 0; y < 3; y++)
                //    {

                //        Tile wallRemove = open.Find(z => z.GridPos == new Point(-1 + x + current.GridPos.X, -1 + y + current.GridPos.Y) && z.MyType == TileType.WALL);
                //        open.Remove(wallRemove);
                //        if (!closed.Contains(wallRemove) && wallRemove != null && (wallRemove.GridPos.X == current.GridPos.X || wallRemove.GridPos.Y == current.GridPos.Y))
                //        {
                //            for (int g = 0; g < 3; g++)
                //            {
                //                for (int u = 0; u < 3; u++)
                //                {

                //                    Tile tmpRemove = open.Find(z =>  z.GridPos == new Point(-1 + g + wallRemove.GridPos.X, -1 + u + wallRemove.GridPos.Y) && z != current);
                //                    if (tmpRemove != null && (wallRemove.GridPos.X == tmpRemove.GridPos.X || wallRemove.GridPos.Y == tmpRemove.GridPos.Y))
                //                    {
                //                        open.Remove(tmpRemove);

                //                    }
                //                }
                //            }



                //        }

                //    }
                //}

                open.Remove(current);
                closed.Add(current);
                //calculate stuff
                Tile tmpCurrent;
                current = FValue(open, goal, current);

                if (current == goal)
                {
                    closed.Add(current);
                    return Path(goal);
                }
                if (current.Parent != null && BetterG(current, open, out tmpCurrent))
                {
                    tmpCurrent.Parent = current.Parent;
                    current = tmpCurrent;

                }
            }
            //do stuff with current maybe find path
            return null;

        }



        private void ResetParents()
        {
            foreach (Tile item in aStarList)
            {
                item.Parent = null;
            }
        }
        private void GValue(List<Tile> openList, Tile current)
        {
            foreach (Tile item in openList)
            {
                if (item.Parent == current)
                {
                    if (item.GridPos.X == current.GridPos.X || item.GridPos.Y == current.GridPos.Y)
                    {
                        item.G = 10;
                    }
                    else
                    {
                        item.G = 14;
                    }
                    item.TotalG = item.G;
                    Tile tempParents = item;
                    while (tempParents.Parent != null)
                    {
                        item.TotalG += tempParents.Parent.G;
                        tempParents = tempParents.Parent;
                    }

                }
            }
        }

        private void HValue(List<Tile> openList, Tile goal)
        {
            foreach (Tile item in openList)
            {
                item.H = (Math.Abs(goal.GridPos.X - item.GridPos.X) + Math.Abs(goal.GridPos.Y - item.GridPos.Y)) * 10;
            }
        }

        private Tile FValue(List<Tile> openList, Tile goal, Tile current)
        {
            HValue(openList, goal);
            GValue(openList, current);
            float f = float.MaxValue;
            Tile bestTile = null;
            foreach (Tile item in openList)
            {
                if (item.TotalG + item.H < f)
                {
                    f = item.TotalG + item.H;
                    bestTile = item;

                }
            }
            return bestTile;


        }



        private Stack<Tile> Path(Tile goal)
        {
            Stack<Tile> path = new Stack<Tile>();
            Tile next = goal;
            while (next.Parent != null)
            {
                path.Push(next.Parent);
                next = next.Parent;
            }

            return path;
        }

        private bool BetterG(Tile current, List<Tile> open, out Tile bestG)
        {
            List<Tile> currentList = new List<Tile>();
            List<Tile> ParentList = new List<Tile>();
            Tile currentTile = null;
            Tile ParentTile = null;
            float lowestGCurrent = float.MaxValue;
            float lowestGParent = float.MaxValue;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Tile nabo = open.Find(z => z.GridPos == new Vector2(-1 + x + current.GridPos.X, -1 + y + current.GridPos.Y) && z != current && z.State != TileState.unwalkable);
                    if (nabo != null && nabo.TotalG < lowestGCurrent)
                    {
                        currentTile = nabo;
                        lowestGCurrent = nabo.TotalG;
                    }
                }
            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Tile nabo = open.Find(z => z.GridPos == new Vector2(-1 + x + current.Parent.GridPos.X, -1 + y + current.Parent.GridPos.Y) && z != current.Parent && z.State != TileState.unwalkable && z != current);
                    if (nabo != null && nabo.TotalG < lowestGParent)
                    {
                        ParentTile = nabo;
                        lowestGParent = nabo.TotalG;
                    }
                }
            }

            if (lowestGCurrent <= lowestGParent)
            {
                bestG = currentTile;
                return false;
            }
            else
            {
                bestG = ParentTile;
                return true;
            }


        }
    }
}
