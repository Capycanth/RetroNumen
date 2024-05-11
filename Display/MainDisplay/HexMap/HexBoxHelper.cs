using Microsoft.Xna.Framework;

namespace RetroNumen.Display.MainDisplay.HexMap
{
    public static class HexBoxHelper
    {
        public static HexBox CreateHexBoxByEnum(HexBoxType type)
        {
            return type switch
            {
                HexBoxType.NONE =>      null,
                HexBoxType.SAND =>      new HexBox("00", 0x00, new Color(212, 191, 142), HexBoxType.SAND),
                HexBoxType.GRASS =>     new HexBox("11", 0x11, new Color(124, 252, 000), HexBoxType.GRASS),
                HexBoxType.WATER =>     new HexBox("33", 0x33, new Color(062, 128, 144), HexBoxType.WATER),
                HexBoxType.ROCK =>      new HexBox("44", 0x44, new Color(103, 103, 103), HexBoxType.ROCK),
                HexBoxType.MUSHROOM =>  new HexBox("55", 0x55, new Color(216, 072, 088), HexBoxType.MUSHROOM),
                HexBoxType.NUMEN =>     new HexBox("77", 0x77, new Color(153, 102, 204), HexBoxType.NUMEN),
                HexBoxType.PLAYER =>    new HexBox("A0", 0xA0, new Color(255, 215, 000), HexBoxType.PLAYER),
                HexBoxType.ART =>       new HexBox("00", 0x00, Color.White, HexBoxType.ART),
                _ => null,
            };
        }

        public static Color GetHexBoxModColor(HexBoxMod mod)
        {
            return mod switch
            {
                HexBoxMod.NORMAL =>     Color.Black,
                HexBoxMod.FIRE =>       Color.Red,
                HexBoxMod.FLICKER =>    new Color(100, 100, 100),
                HexBoxMod.BLACK =>      Color.Black,
                _ => Color.HotPink, // WARNING COLOR
            };
        }
    }
}
