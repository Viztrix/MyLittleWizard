using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    class Grid
    {
        private Tile[,] tiles = new Tile[10, 10];
        private string[,] tileArray = new string[10, 10]
        {
            {"W","W","W","W","W","G","G","G","G","G"},
            {"G","P","P","P","P","P","P","G","G","G"},
            {"G","P","G","G","G","G","P","G","G","G"},
            {"G","P","G","G","G","G","P","G","G","G"},
            {"G","P","G","G","G","G","P","P","P","G"},
            {"G","P","G","G","G","G","G","G","P","G"},
            {"G","P","G","G","G","G","G","G","P","G"},
            {"G","P","P","P","G","G","G","G","P","G"},
            {"G","G","G","P","P","P","P","P","P","G"},
            {"G","G","G","G","G","G","G","G","G","G"}, 
        };

        
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
                    //[x, y] = new Tile(new Vector2(x * 64, y * 64), new Vector2(x, y), Tiletype.grass);
                }
            }

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                   if(tileArray[y,x] == "G")
                   {
                       tiles[x, y] = new Tile(new Vector2(x * 64, y * 64), new Vector2(x, y), Tiletype.grass);
                   }
                   else if(tileArray[y,x] == "W")
                   {
                       tiles[x, y] = new Tile(new Vector2(x * 64, y * 64), new Vector2(x, y), Tiletype.wall);
                   }
                   else if (tileArray[y, x] == "P")
                   {
                       tiles[x, y] = new Tile(new Vector2(x * 64, y * 64), new Vector2(x, y), Tiletype.path);
                   }
                }   
            }

            //Change the type of the tiles here

            //Creates the portal
            //tiles[8, 1].Type = Tiletype.portal;

            //Creates the towers
            //tiles[1, 8].Type = Tiletype.potionTower;
            //tiles[9, 8].Type = Tiletype.frostTower;

            //Creates the path
            //tiles[1, 3].Type = Tiletype.path;
            //tiles[1, 4].Type = Tiletype.path;
            //tiles[1, 5].Type = Tiletype.path;
            //tiles[1, 6].Type = Tiletype.path;
            //tiles[1, 7].Type = Tiletype.path;
            //tiles[2, 7].Type = Tiletype.path;
            //tiles[3, 7].Type = Tiletype.path;
            //tiles[3, 8].Type = Tiletype.path;

            //tiles[4, 8].Type = Tiletype.monsterPath;
            //tiles[5, 8].Type = Tiletype.monsterPath;
            //tiles[6, 8].Type = Tiletype.monsterPath;

            //tiles[7, 8].Type = Tiletype.path;
            //tiles[8, 8].Type = Tiletype.path;
            //tiles[8, 7].Type = Tiletype.path;
            //tiles[8, 6].Type = Tiletype.path;
            //tiles[8, 5].Type = Tiletype.path;
            //tiles[8, 4].Type = Tiletype.path;
            //tiles[7, 4].Type = Tiletype.path;
            //tiles[6, 4].Type = Tiletype.path;
            //tiles[6, 3].Type = Tiletype.path;
            //tiles[6, 2].Type = Tiletype.path;
            //tiles[5, 2].Type = Tiletype.path;
            //tiles[4, 2].Type = Tiletype.path;
            //tiles[3, 2].Type = Tiletype.path;
            //tiles[2, 2].Type = Tiletype.path;
            //tiles[1, 2].Type = Tiletype.path;

            ////Creates the walls
            ////tiles[0, 0].Type = Tiletype.wall;
            ////tiles[1, 0].Type = Tiletype.wall;
            ////tiles[2, 0].Type = Tiletype.wall;
            ////tiles[0, 1].Type = Tiletype.wall;

            ////tiles[3, 3].Type = Tiletype.wall;
            ////tiles[3, 4].Type = Tiletype.wall;
            ////tiles[3, 5].Type = Tiletype.wall;
            ////tiles[3, 6].Type = Tiletype.wall;
            ////tiles[4, 3].Type = Tiletype.wall;
            ////tiles[4, 4].Type = Tiletype.wall;
            ////tiles[4, 5].Type = Tiletype.wall;
            ////tiles[4, 6].Type = Tiletype.wall;
            ////tiles[5, 3].Type = Tiletype.wall;
            ////tiles[5, 4].Type = Tiletype.wall;
            ////tiles[5, 5].Type = Tiletype.wall;
            ////tiles[5, 6].Type = Tiletype.wall;

            ////Creates the forest
            //tiles[4, 7].Type = Tiletype.forest;
            //tiles[5, 7].Type = Tiletype.forest;
            //tiles[6, 7].Type = Tiletype.forest;
            //tiles[4, 9].Type = Tiletype.forest;
            //tiles[5, 9].Type = Tiletype.forest;
            //tiles[6, 9].Type = Tiletype.forest;

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
    }
}
