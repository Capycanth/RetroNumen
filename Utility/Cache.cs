using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace RetroNumen.Utility
{
    public class Cache
    {
        private static Cache _instance;
        public static Cache Instance(ContentManager contentManager)
        {
            return _instance ?? (_instance = new Cache(contentManager));
        }

        private Cache(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }

        private ContentManager contentManager;

        private Dictionary<string, Texture2D> _textures;
        private Dictionary<string, SpriteFont> _fonts;
        private Dictionary<string, Song> _songs;

        public Dictionary<string, Song> Songs { get { return _songs; } }
        public Dictionary<string, SpriteFont> Fonts { get { return _fonts; } }
        public Dictionary<string, Texture2D> Textures { get { return _textures; } }

    }
}
