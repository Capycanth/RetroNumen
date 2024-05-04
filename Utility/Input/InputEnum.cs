using System;

namespace RetroNumen.Input
{
    [Flags]
    public enum InputEnum
    {
        NONE =              0,
        UP =                1<<0,
        DOWN =              1<<1,
        LEFT =              1<<2,
        RIGHT =             1<<3,
        LEFT_CLICK =        1<<4,
        RIGHT_CLICK =       1<<5,
    }
}
