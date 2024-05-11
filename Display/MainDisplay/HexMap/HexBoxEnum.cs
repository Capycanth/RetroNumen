namespace RetroNumen.Display.MainDisplay.HexMap
{
    public enum HexBoxType : byte
    {
        // Floor Types
        NONE = 0,
        GRASS = 1,
        SAND = 2,
        ROCK = 3,
        WATER = 4,
        MUSHROOM = 5,
        NUMEN = 6,

        // Character Types
        PLAYER = 50,

        // Item Types

        // Special Types
        ART = 150,
    }

    public enum HexBoxMod : byte
    {
        NORMAL = 0,
        // Affects
        FIRE = 1,
        FLICKER = 2,

        // Special

        // Color
        BLACK = 100,
    }
}
