using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    enum Tiletype { grass, path, forest, wall, frostKey, potionKey, potionTower, frostTower, monsterPath, portal }
    enum TileState { unwalkable, walkable, onceWalkable }
    class Tile : GameObject
    {
        Tiletype type;
        TileState state;
        private float h, g, totalG;
        private Tile parent;
        private bool noLongerWalkable, hasKey;

        #region Properties
        public bool HasKey
        {
            get { return hasKey; }
            set { hasKey = value; }
        }
        public Tiletype Type
        {
            get { return type; }
            set { type = value; }
        }

        public Tile Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public float H
        {
            get
            {
                return h;
            }

            set
            {
                h = value;
            }
        }

        public float G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
            }
        }

        public float TotalG
        {
            get
            {
                return totalG;
            }

            set
            {
                totalG = value;
            }
        }

        public TileState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
        #endregion

        public Tile(Vector2 position, Vector2 gridPos, Tiletype type) : base(position, gridPos)
        {
            this.position = position;
            this.GridPos = gridPos;
            this.type = type;
            this.layer = 0.5f;
            hasKey = false;
            noLongerWalkable = false;
            
            #region type switch
            switch (type)
            {
                case Tiletype.grass:
                    this.sprite = TextureLoader.grass;
                    State = TileState.walkable;
                    break;
                case Tiletype.path:
                    this.sprite = TextureLoader.path;
                    State = TileState.walkable;
                    break;
                case Tiletype.forest:
                    this.sprite = TextureLoader.forest;
                    State = TileState.unwalkable;
                    break;
                case Tiletype.wall:
                    this.sprite = TextureLoader.wall;
                    State = TileState.unwalkable;
                    break;
                case Tiletype.frostKey:
                    this.sprite = TextureLoader.frostKey;
                    State = TileState.walkable;
                    break;
                case Tiletype.potionKey:
                    this.sprite = TextureLoader.potionKey;
                    State = TileState.walkable;
                    break;
                case Tiletype.potionTower:
                    this.sprite = TextureLoader.potionTower;
                    State = TileState.walkable;
                    break;
                case Tiletype.frostTower:
                    this.sprite = TextureLoader.frostTower;
                    State = TileState.walkable;
                    break;
                case Tiletype.monsterPath:
                    this.sprite = TextureLoader.path;
                    State = TileState.onceWalkable;
                    break;
                case Tiletype.portal:
                    this.sprite = TextureLoader.portal;
                    State = TileState.walkable;
                    break;
                default:
                    this.sprite = TextureLoader.grass;
                    State = TileState.walkable;
                    break;
            }
            #endregion
        }

        public void ChangeType()
        {
            switch (type)
            {
                case Tiletype.grass:
                    this.sprite = TextureLoader.grass;
                    State = TileState.walkable;
                    break;
                case Tiletype.path:
                    this.sprite = TextureLoader.path;
                    State = TileState.walkable;
                    break;
                case Tiletype.forest:
                    this.sprite = TextureLoader.forest;
                    State = TileState.unwalkable;
                    break;
                case Tiletype.wall:
                    this.sprite = TextureLoader.wall;
                    State = TileState.unwalkable;
                    break;
                case Tiletype.frostKey:
                    if (hasKey)
                    {
                        this.sprite = TextureLoader.frostKeyPath;
                        hasKey = false;
                    }
                    else
                        this.sprite = TextureLoader.frostKey;

                    State = TileState.walkable;
                    break;
                case Tiletype.potionKey:
                    if(hasKey)
                    {
                        this.sprite = TextureLoader.potionKeyPath;
                        hasKey = false;
                    }
                    else
                        this.sprite = TextureLoader.potionKey;

                    State = TileState.walkable;
                    break;
                case Tiletype.potionTower:
                    this.sprite = TextureLoader.potionTower;
                    State = TileState.walkable;
                    break;
                case Tiletype.frostTower:
                    this.sprite = TextureLoader.frostTower;
                    State = TileState.walkable;
                    break;
                case Tiletype.monsterPath:
                    this.sprite = TextureLoader.path;
                    State = TileState.onceWalkable;
                    break;
                case Tiletype.portal:
                    this.sprite = TextureLoader.portal;
                    State = TileState.walkable;
                    break;
                default:
                    this.sprite = TextureLoader.grass;
                    State = TileState.walkable;
                    break;
            }
        }

        public override void Update(GameTime gametime)
        {
            if(GameWorld.Wizard.GridPos == this.gridPos && this.state == TileState.onceWalkable)
            {
                this.state = TileState.unwalkable;
                noLongerWalkable = true;
            }

            if (noLongerWalkable && GameWorld.Wizard.GridPos != this.gridPos)
            {

                this.sprite = TextureLoader.monsterPath;
            }

            base.Update(gametime);
        }
    }
}
