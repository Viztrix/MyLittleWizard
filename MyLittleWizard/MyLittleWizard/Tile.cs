using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    enum Tiletype {  }
    class Tile : GameObject
    {
        public Tile(Vector2 position, Vector2 gridPos) : base(position, gridPos)
        {
            this.position = position;
            this.gridPos = gridPos;
        }
    }
}
