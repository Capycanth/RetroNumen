using Microsoft.Xna.Framework;
using RetroNumen.Display.MainDisplay.HexMap;

namespace RetroNumen.Entity.Character
{
    public abstract class CharacterBase
    {
        protected HexBox character;
        protected int characterId;

        public CharacterBase(int characterId)
        {
            this.characterId = characterId;
        }

        public CharacterBase(HexBoxType type)
        {
            this.character = HexBoxHelper.CreateHexBoxByEnum(type);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw();

        public HexBox Character { get { return this.character; } }
        public int CharacterId { get { return this.characterId; } }
    }
}
