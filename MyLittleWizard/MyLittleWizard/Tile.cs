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

        private Tile parent;

        public Tiletype Type
        {
            get { return type; }
            set { type = value; }
        }

        public Tile(Vector2 position, Vector2 gridPos, Tiletype type) : base(position, gridPos)
        {
            this.position = position;
            this.gridPos = gridPos;
            this.type = type;
            this.layer = 0.5f;


            #region type switch
            switch (type)
            {
                case Tiletype.grass:
                    this.sprite = TextureLoader.grass;
                    state = TileState.walkable;
                    break;
                case Tiletype.path:
                    this.sprite = TextureLoader.path;
                    state = TileState.walkable;
                    break;
                case Tiletype.forest:
                    this.sprite = TextureLoader.forest;
                    state = TileState.unwalkable;
                    break;
                case Tiletype.wall:
                    this.sprite = TextureLoader.wall;
                    state = TileState.unwalkable;
                    break;
                case Tiletype.frostKey:
                    this.sprite = TextureLoader.frostKey;
                    state = TileState.walkable;
                    break;
                case Tiletype.potionKey:
                    this.sprite = TextureLoader.potionKey;
                    state = TileState.walkable;
                    break;
                case Tiletype.potionTower:
                    this.sprite = TextureLoader.potionTower;
                    state = TileState.walkable;
                    break;
                case Tiletype.frostTower:
                    this.sprite = TextureLoader.frostTower;
                    state = TileState.walkable;
                    break;
                case Tiletype.monsterPath:
                    this.sprite = TextureLoader.monsterPath;
                    state = TileState.onceWalkable;
                    break;
                case Tiletype.portal:
                    this.sprite = TextureLoader.portal;
                    state = TileState.walkable;
                    break;
                default:
                    this.sprite = TextureLoader.grass;
                    state = TileState.walkable;
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
                    state = TileState.walkable;
                    break;
                case Tiletype.path:
                    this.sprite = TextureLoader.path;
                    state = TileState.walkable;
                    break;
                case Tiletype.forest:
                    this.sprite = TextureLoader.forest;
                    state = TileState.unwalkable;
                    break;
                case Tiletype.wall:
                    this.sprite = TextureLoader.wall;
                    state = TileState.unwalkable;
                    break;
                case Tiletype.frostKey:
                    this.sprite = TextureLoader.frostKey;
                    state = TileState.walkable;
                    break;
                case Tiletype.potionKey:
                    this.sprite = TextureLoader.potionKey;
                    state = TileState.walkable;
                    break;
                case Tiletype.potionTower:
                    this.sprite = TextureLoader.potionTower;
                    state = TileState.walkable;
                    break;
                case Tiletype.frostTower:
                    this.sprite = TextureLoader.frostTower;
                    state = TileState.walkable;
                    break;
                case Tiletype.monsterPath:
                    this.sprite = TextureLoader.monsterPath;
                    state = TileState.onceWalkable;
                    break;
                case Tiletype.portal:
                    this.sprite = TextureLoader.portal;
                    state = TileState.walkable;
                    break;
                default:
                    this.sprite = TextureLoader.grass;
                    state = TileState.walkable;
                    break;
            }
        }
    }
}
