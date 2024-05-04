using Microsoft.Xna.Framework.Input;
using RetroNumen.Input;
using System.Collections.Generic;

namespace RetroNumen.Utility
{
    public static class Globals
    {
        #region Size
        public static readonly int HEX_BOX_SIZE = 16;
        public static readonly int CHUNK_HEX_BOX_SIZE = 32;
        public static readonly int MAP_HEX_BOX_SIZE = 32;
        #endregion

        #region Input
        public static Dictionary<Keys, InputEnum> DefaultKeyBindings = new Dictionary<Keys, InputEnum>()
        {
            { Keys.Left, InputEnum.LEFT },
            { Keys.Right, InputEnum.RIGHT },
            { Keys.Up, InputEnum.UP },
            { Keys.Down, InputEnum.DOWN },
        };
        #endregion
    }
}
