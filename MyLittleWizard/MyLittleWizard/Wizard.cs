using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    enum Goal { potionKey, potionTower, frostKey, frostTower }

    class Wizard : GameObject
    {
        private bool hasPotionKey, hasFrostKey, hasReachedFrostTower, hasReachedPotionTower, hasReachedPortal, moving;
        private Stack<Tile> path;
        float deltaTime, coolDown;
        private Vector2 goal;
        private Tiletype nextObjective;
        public bool HasReachedPortal
        {
            get { return hasReachedPortal; }
            set { hasReachedPortal = value; }
        }

        internal Tiletype NextObjective
        {
            get { return nextObjective; }
        }
        private List<Tile> goals;

        public Vector2 Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public Wizard(Vector2 position, Vector2 gridPos)
            : base(position, gridPos)
        {
            this.sprite = TextureLoader.wizard;
            this.GridPos = GetSpawnPoint();
            this.position = this.GridPos * 64;
            this.layer = 1;

            nextObjective = Tiletype.frostKey;

            goals = new List<Tile>();
            goal = new Vector2(5, 8);

            SetupGoals();
            ChangeGoal();
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
            coolDown = 250;

            if (!moving)
            {
                moving = true;
                
                path = GameWorld.GameGrid.AStar(GameWorld.GameGrid.Tiles[(int)gridPos.X,(int)gridPos.Y], GameWorld.GameGrid.Tiles[(int)goal.X, (int)goal.Y]);
            }

            if (path.Count != 0 && deltaTime > coolDown)
            {
                this.position = path.Pop().GridPos * 64;
                this.gridPos = position / 64;
                deltaTime = 0;
            }
            else if(path.Count == 0 && gridPos != goal)
            {
                moving = false;
            }

            if(PositionReached(goal))
            {
                CheckForObjective();
                ChangeGoal();
            }

            base.Update(gametime);
        }

        private bool PositionReached(Vector2 goal)
        {
            if(gridPos == goal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetupGoals()
        {
            foreach (Tile tile in GameWorld.GameGrid.Tiles)
            {
                if (tile.Type == Tiletype.frostKey || tile.Type == Tiletype.potionKey || tile.Type == Tiletype.potionTower || tile.Type == Tiletype.frostTower || tile.Type == Tiletype.portal)
                {
                    goals.Add(tile);
                }
            }
        }

        private void CheckForObjective()
        {
            if(GameWorld.GameGrid.Tiles[(int)gridPos.X, (int)gridPos.Y].Type == nextObjective)
            {
                switch (nextObjective)
                {
                    case Tiletype.frostKey:
                        hasFrostKey = true;
                        nextObjective = Tiletype.frostTower;
                        GameWorld.GameGrid.Tiles[(int)gridPos.X, (int)gridPos.Y].ChangeType();
                        break;
                    case Tiletype.potionKey:
                        hasPotionKey = true;
                        nextObjective = Tiletype.potionTower;
                        GameWorld.GameGrid.Tiles[(int)gridPos.X, (int)gridPos.Y].ChangeType();
                        break;
                    case Tiletype.potionTower:
                        hasReachedPotionTower = true;
                        nextObjective = Tiletype.portal;
                        break;
                    case Tiletype.frostTower:
                        hasReachedFrostTower = true;
                        nextObjective = Tiletype.potionKey;
                        break;
                    case Tiletype.portal:
                        hasReachedPortal = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChangeGoal()
        {
            Tile goalTile;
            goalTile = goals.Find(z => z.Type == nextObjective);
            if(goalTile != null)
            goal = new Vector2(goalTile.GridPos.X, goalTile.GridPos.Y);
        }
    }
}
