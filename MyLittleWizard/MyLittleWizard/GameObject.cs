using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position, gridPos;
        protected float layer, rotation, scale;

        public GameObject(Vector2 position, Vector2 gridPos)
        {
            this.position = position;
            this.gridPos = gridPos;
        }

        public virtual void Update(GameTime gametime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, position, null, Color.White, 0, new Vector2(0,0), 1, SpriteEffects.None, layer);
        }
    }
}
