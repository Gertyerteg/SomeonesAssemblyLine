#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

//-----------------------------------------------------------------
//	Author:				Spencer Chang
//	Date:				May 18, 2017
//	Notes:				
//-----------------------------------------------------------------

namespace SAL
{
    ///	<summary>
    ///	Handles and manages all input from keyboard and mouse.
    ///	</summary>
    public class InputManager
    {
        private KeyboardState currentKeyState, prevKeyState;
        private MouseState currentMouseState, prevMouseState;
        private Point leftClickPos, rightClickPos;
        private bool isClickingR, isClickingL;

        private static InputManager instance;

        /// <summary>
        /// When the scroll wheel is scrolled.
        /// </summary>
        public MouseEvent onScroll;

        /// <summary>
        /// When any mouse button is clicked.
        /// </summary>
        public MouseEvent onClick;

        /// <summary>
        /// When a key is typed.
        /// </summary>
        public KeyboardEvent onType;

        /// <summary>
        /// Event handler for the mouse.
        /// </summary>
        public delegate void MouseEvent();

        /// <summary>
        /// Event handler for the keyboard.
        /// </summary>
        public delegate void KeyboardEvent(Keys[] key);
       
        /// <summary>
        /// Singleton instance of the inputmanager.
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();

                return instance;
            }
        }

        /// <summary>
        /// Creates a new instance of the inputManager
        /// </summary>
        private InputManager()
        {
            isClickingL = false;
            isClickingR = false;
        }

        /// <summary>
        /// Updates the instance of the inputmanager.
        /// </summary>
        public void Update()
        {
            prevKeyState = currentKeyState;
            prevMouseState = currentMouseState;

            if (leftMouseButtonDown() && !isClickingL)
            {
                isClickingL = true;
                leftClickPos = Mouse.GetState().Position;
            }
            else if (!leftMouseButtonDown())
                isClickingL = false;

            if (rightMouseButtonDown() && !isClickingR)
            {
                isClickingR = true;
                rightClickPos = Mouse.GetState().Position;
            }
            else if (!leftMouseButtonDown())
                isClickingR = false;

            #region Event handling
            if (onClick != null && (leftMouseButtonClicked() || rightMouseButtonClicked()))
                onClick();

            if (onScroll != null && (isScrollingDown() || isScrollingUp()))
                onScroll();

            if (onType != null && (Keyboard.GetState().GetPressedKeys().Length > 0
                && KeyPressed(Keyboard.GetState().GetPressedKeys())))
                onType(Keyboard.GetState().GetPressedKeys());
            #endregion
            
            currentKeyState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Returns true when the mouse wheel is scrolling down.
        /// </summary>
        /// <returns></returns>
        public bool isScrollingDown()
        {
            return prevMouseState.ScrollWheelValue < Mouse.GetState().ScrollWheelValue;
        }

        /// <summary>
        /// Returns true when the mouse wheel is scrolling up.
        /// </summary>
        /// <returns></returns>
        public bool isScrollingUp()
        {
            return prevMouseState.ScrollWheelValue > Mouse.GetState().ScrollWheelValue;
        }

        /// <summary>
        /// If the left mouse button is down.
        /// </summary>
        /// <returns></returns>
        public bool leftMouseButtonDown()
        {
            return currentMouseState.LeftButton.Equals(ButtonState.Pressed);
        }

        /// <summary>
        /// If the right mouse button is down.
        /// </summary>
        /// <returns></returns>
        public bool rightMouseButtonDown()
        {
            return currentMouseState.RightButton.Equals(ButtonState.Pressed);
        }

        /// <summary>
        /// If the right mouse button is clicked.
        /// </summary>
        /// <returns></returns>
        public bool rightMouseButtonClicked()
        {
            return currentMouseState.RightButton.Equals(ButtonState.Released) 
                && prevMouseState.RightButton.Equals(ButtonState.Pressed);
        }

        /// <summary>
        /// If the right mouse button is clicked and the position of the mouse hasn't changed.
        /// </summary>
        /// <returns></returns>
        public bool pureRightMouseButtonClicked()
        {
            return currentMouseState.RightButton.Equals(ButtonState.Released)
                && prevMouseState.RightButton.Equals(ButtonState.Pressed) &&
                rightClickPos.Equals(currentMouseState.Position);
        }

        /// <summary>
        /// If the right mouse button is clicked and the position of the mouse hasn't changed.
        /// </summary>
        /// <returns></returns>
        public bool pureLeftMouseButtonClicked()
        {
            bool isSamePos = leftClickPos == currentMouseState.Position;
            Point p = currentMouseState.Position;

            bool isTrue = currentMouseState.LeftButton.Equals(ButtonState.Released)
                && prevMouseState.LeftButton.Equals(ButtonState.Pressed) &&
                leftClickPos.Equals(currentMouseState.Position);

            if (isTrue)
            {

            }

            return isTrue;
        }

        /// <summary>
        /// If the left mouse button is clicked.
        /// </summary>
        /// <returns></returns>
        public bool leftMouseButtonClicked()
        {
            bool isClicked = currentMouseState.LeftButton == ButtonState.Released &&
                prevMouseState.LeftButton == ButtonState.Pressed;

            if (isClicked)
            {

            }

            return isClicked;
        }

        /// <summary>
        /// Determines whether the key(s) have been pressed.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the key(s) are released.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the key(s) are down.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
        
    }
}
