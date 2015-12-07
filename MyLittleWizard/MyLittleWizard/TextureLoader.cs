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
        static public Texture2D wizard;

        public static void LoadContent(ContentManager content)
        {
            wizard = content.Load<Texture2D>(@"Wizard");
        }

    }
}
