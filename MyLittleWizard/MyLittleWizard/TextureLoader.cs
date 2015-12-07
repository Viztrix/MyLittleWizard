using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleWizard
{
    public class TextureLoader
    {
        static public Texture2D wizard, grass, path, wall, forest, monsterPath, potionTower, frostTower, potionKey, frostKey, portal, frostKeyPath, potionKeyPath;

        public static void LoadContent(ContentManager content)
        {
            wizard = content.Load<Texture2D>(@"Wizard");
            grass = content.Load<Texture2D>(@"Grass");
            forest = content.Load<Texture2D>(@"Tree");
            path = content.Load<Texture2D>(@"Path");
            wall = content.Load<Texture2D>(@"Wall");
            monsterPath = content.Load<Texture2D>(@"Monster");
            potionTower = content.Load<Texture2D>(@"PotionTower");
            frostTower = content.Load<Texture2D>(@"FrostTower");
            potionKey = content.Load<Texture2D>(@"PotionKey");
            potionKeyPath = content.Load<Texture2D>(@"PotionKeyPath");
            frostKey = content.Load<Texture2D>(@"FrostKey");
            frostKeyPath = content.Load<Texture2D>(@"FrostKeyPath");
            portal = content.Load<Texture2D>(@"Portal");

        }

    }
}
