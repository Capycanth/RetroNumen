using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Drawing;

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
        private Dictionary<string, Bitmap> _bitmaps;
        

        public Dictionary<string, Song> Songs { get { return _songs; } }
        public Dictionary<string, SpriteFont> Fonts { get { return _fonts; } }
        public Dictionary<string, Texture2D> Textures { get { return _textures; } }
        public Dictionary<string, Bitmap> Bitmaps { get { return this._bitmaps; } }

        public void Initialize()
        {
            _textures = new Dictionary<string, Texture2D>()
            {
                { "background", contentManager.Load<Texture2D>("Textures/background") },
                { "InfoButtonSelected", contentManager.Load<Texture2D>("Textures/InfoButtonSelected") },
                { "InfoButtonUnselected", contentManager.Load<Texture2D>("Textures/InfoButtonUnSelected") },
            };
            _fonts = new Dictionary<string, SpriteFont>()
            {
                { "wartext14", contentManager.Load<SpriteFont>("Fonts/wartext14") },
                { "wartext20", contentManager.Load<SpriteFont>("Fonts/wartext20") }
            };
            _songs = new Dictionary<string, Song>()
            {

            };
            _bitmaps = new Dictionary<string, Bitmap>()
            {
                { "skully_still",  contentManager.Load<Bitmap>("skully_still") },
            };
        }
    }
}
