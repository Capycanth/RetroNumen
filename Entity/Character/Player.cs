using Microsoft.Xna.Framework;
using RetroNumen.Display.MainDisplay.HexMap;
using RetroNumen.Input;
using RetroNumen.Utility;

namespace RetroNumen.Entity.Character
{
    public class Player : CharacterBase
    {
        private double flicker_count = 0;
        private readonly double FLICKER_TIME = 750;

        public Player(int id) : base(id)
        {
            this.character = HexBoxHelper.CreateHexBoxByEnum(HexBoxType.PLAYER);
            this.character.SetPosition(Globals.CHUNK_HEX_BOX_SIZE >> 1, Globals.CHUNK_HEX_BOX_SIZE >> 1);
            this.character.Mod = HexBoxMod.BLACK;
        }

        public override void Draw()
        {
            this.character.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            this.UpdateFlicker(gameTime.ElapsedGameTime.TotalMilliseconds);

            InputManager input = GameMain.InputManager;

            if (input.IsPressed(InputDurations.SINGLE_PRESS, InputEnum.LEFT))
                this.character.MovePosition(-1, 0);
            else if (input.IsPressed(InputDurations.SINGLE_PRESS, InputEnum.RIGHT))
                this.character.MovePosition(1, 0);
            else if (input.IsPressed(InputDurations.SINGLE_PRESS, InputEnum.UP))
                this.character.MovePosition(0, 1);
            else if (input.IsPressed(InputDurations.SINGLE_PRESS, InputEnum.DOWN))
                this.character.MovePosition(0, -1);

            this.character.Update(gameTime);
        }

        private void UpdateFlicker(double msElapsed)
        {
            if ((this.flicker_count += msElapsed) > this.FLICKER_TIME)
            {
                this.flicker_count = 0;
                this.character.Mod = this.character.Mod == HexBoxMod.FLICKER ? HexBoxMod.BLACK : HexBoxMod.FLICKER;
            }
        }
    }
}
