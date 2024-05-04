using Microsoft.Xna.Framework.Input;
using RetroNumen.Utility;
using System.Collections.Generic;

namespace RetroNumen.Input
{
    public class InputManager
    {
        private static InputManager instance;
        public static InputManager Instance => instance ?? (instance = new InputManager());

        private Dictionary<Keys, InputEnum> keyBindings = Globals.DefaultKeyBindings;
        private int playerInput;
        private InputContainer inputContainer;

        public InputManager()
        {
            this.inputContainer = new InputContainer();
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            this.playerInput = 0;
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (this.keyBindings.ContainsKey(key))
                {
                    this.playerInput |= (int)keyBindings[key];
                }
            }
            inputContainer.Update(this.playerInput, mouseState);
        }

        public bool IsPressed(InputDurations duration, params InputEnum[] input)
        {
            if (input.Length == 0)
                return false;
            
            foreach (InputEnum inputEnum in input)
            {
                if (inputContainer._keyboard[inputEnum] != duration)
                {
                    return false;
                }
            }
            return true;
        }

        public MouseState GetCurrentMouseState()
        {
            return this.inputContainer.c_Mouse;
        }

        public Dictionary<Keys, InputEnum> KeyBindings { get { return keyBindings; } set { this.keyBindings = value; } }

        private class InputContainer
        {
            private List<int> playerInputMemory = new List<int>(10);
            public Dictionary<InputEnum, InputDurations> _keyboard = new Dictionary<InputEnum, InputDurations>()
            {
                { InputEnum.LEFT, InputDurations.NONE },
                { InputEnum.RIGHT, InputDurations.NONE },
                { InputEnum.UP, InputDurations.NONE },
                { InputEnum.DOWN, InputDurations.NONE },
            };
            public MouseState p_Mouse;
            public MouseState c_Mouse;

            public InputContainer() { }

            public void Update(int playerInput, MouseState mouseState)
            {
                if (this.playerInputMemory.Count == 10)
                {
                    this.playerInputMemory.RemoveAt(9);
                }
                this.playerInputMemory.Insert(0, playerInput);
                this.p_Mouse = this.c_Mouse;
                this.c_Mouse = mouseState;
                if (this.playerInputMemory.Count == 10)
                {
                    this.SetInputDurations();
                }
            }

            private void SetInputDurations()
            {
                foreach (InputEnum inputEnum in _keyboard.Keys)
                {
                    int enumInt = (int)inputEnum;

                    if ((this.playerInputMemory[0] & enumInt) == 0)
                        _keyboard[inputEnum] = InputDurations.NONE;
                    else if ((this.playerInputMemory[0] & enumInt) > 0 && (this.playerInputMemory[1] & enumInt) == 0) // 1 0
                        _keyboard[inputEnum] = InputDurations.SINGLE_PRESS;
                    else if ((this.playerInputMemory[0] & enumInt) > 0 && (this.playerInputMemory[1] & enumInt) > 0 && (this.playerInputMemory[4] & enumInt) == 0) // 1 1 (0/1) (0/1) 0
                        _keyboard[inputEnum] = InputDurations.SINGLE_PRESS_BLOCK;
                    else if (_keyboard[inputEnum] == InputDurations.SINGLE_PRESS_BLOCK && (this.playerInputMemory[4] & enumInt) > 0)
                        _keyboard[inputEnum] = InputDurations.LONG_PRESS;
                    else
                        _keyboard[inputEnum] = InputDurations.NONE; // Not sure if possible
                }
            }
        }
    }
}
