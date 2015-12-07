using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    class Wizard : GameObject
    {
        private bool hasPotionKey, hasFrostKey, hasReachedFrostTower, hasReachedPotionTower, moving;
        private Stack<Tile> path;    
        public Wizard(Vector2 position, Vector2 gridPos)
            : base(position, gridPos)
        {
            this.sprite = TextureLoader.wizard;
            this.GridPos = GetSpawnPoint();
            this.position = this.GridPos * 64;
            this.layer = 1;
        }

        private Vector2 GetSpawnPoint()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if(GameWorld.GameGrid.Tiles[x,y].Type == Tiletype.portal)
                    {
                        return new Vector2(x, y);
                    }
                }
            }

            return new Vector2(0, 0);
        }

        public override void Update(GameTime gametime)
        {
            if (!moving)
            {
                moving = true;
                
                //path = GameWorld.GameGrid.AStar(GameWorld.GameGrid.Tiles[(int)gridPos.X,(int)gridPos.Y], GameWorld.GameGrid.Tiles[,]);
            }




            base.Update(gametime);
        }
    }
}
