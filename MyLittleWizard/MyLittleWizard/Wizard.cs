using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    class Wizard : GameObject
    {
        private Vector2 gridPos;

        public Wizard(Vector2 position, Vector2 gridPos) : base(position, gridPos)
        {
            this.sprite = TextureLoader.wizard;
            this.position = position;
            this.gridPos = gridPos;
        }
    }
}
