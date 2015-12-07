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
        float deltaTime, coolDown;
        int goalX, goalY;

        public int GoalY
        {
            get { return goalY; }
        }

        public int GoalX
        {
            get { return goalX; }
        }

        public Wizard(Vector2 position, Vector2 gridPos)
            : base(position, gridPos)
        {
            this.sprite = TextureLoader.wizard;
            this.GridPos = GetSpawnPoint();
            this.position = this.GridPos * 64;
            this.layer = 1;

            goalX = 0;
            goalY = 9;
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
            deltaTime += gametime.ElapsedGameTime.Milliseconds;
            coolDown = 1000;

            if (!moving)
            {
                moving = true;
                
                path = GameWorld.GameGrid.AStar(GameWorld.GameGrid.Tiles[(int)gridPos.X,(int)gridPos.Y], GameWorld.GameGrid.Tiles[goalX,goalY]);
            }

            if (path.Count != 0 && deltaTime > coolDown)
            {
                this.position = path.Pop().GridPos * 64;
                this.gridPos = position / 64;
                deltaTime = 0;
            }



            base.Update(gametime);
        }
    }
}
