using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    /// <summary>
    /// This defines the new GameEvent type.
    /// 'delegate' - Used to define the type as a delegate that can store a reference to functions
    /// 'void' - The return type of the functions the delegate can store
    /// 'GameEvent' - The name of the new type
    /// '()' - The parameters for the functions the delegate can store a reference to.
    /// It's empty in this case as a GameEvent currently doesn't need any arguments when called.
    /// However, just like a function, the parameter list can be filled with any number of 
    /// arguments of any type.
    /// </summary>
    delegate void GameEvent();

    /// <summary>
    /// The GameManager class contains all game logic that needs to be accessed globally.
    /// Making the class static means that no instance of it can be created. It also means
    /// that any fields or methods declared inside must also be static.
    /// </summary>
    static class GameManager
    {
        private static bool _gameOver = false;

        /// <summary>
        /// This is an instance of the GameEvent delegate.
        /// Just as with classes, you must create an instance of a custom type
        /// before you can use it.
        /// This instance is being used to store functions that are called
        /// when the player has won the game.
        /// Find all references to see how this instance is used.
        /// </summary>
        public static GameEvent onLose;

        public static bool GameOver { get => _gameOver; set => _gameOver = value; }

    }
}
