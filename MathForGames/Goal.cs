using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    /// <summary>
    /// A goal is an actor that checks if the player has collided with it.
    /// If so the player wins the game.
    /// </summary>
    class Goal : Actor
    {
        public Goal(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, icon, color)
        {
            _collisionRadius = 5;
        }

        public Goal(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, rayColor, icon, color)
        {
            _collisionRadius = 5;
        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), _collisionRadius * 32, _rayColor);
            Raylib.DrawText("GOAL", ((int)(WorldPosition.X * 32) - 100), ((int)(WorldPosition.Y * 32) - 75), 100, Color.BLUE);
            base.Draw();
        }

        public override void End()
        {
            base.End();
        }

        public override void OnCollision(Actor other)
        {
            ///
            /// In this case, the desired behaviour is for
            /// the delegate to execute all of its functions when
            /// when the player collides with it. First, a check is done to see if the actor
            /// the goal collided with is in fact the player. Afterwards the delegate is
            /// told to execute all of its functions which is also known as "Invoking"
            /// the delegate. You may notice the question mark after the delegate call.
            /// This is there to check if the delegate is null before using it. If the
            /// delegate is null, then the Invoke() call will not be executed.
            /// This is a shorthand way to type the following:
            ///  if (GameManager.onWin != null)
            ///     GameManager.onWin.Invoke();
            /// This the advantage of using the Invoke call rather than calling the delegate
            /// like so:
            ///      GameManager.onWin();
            ///
            if (other is Player)
                GameManager.onLose?.Invoke();

            base.OnCollision(other);
        }

        public override void Start()
        {
            ///
            /// The function DrawWinText() is responsible for putting text on the 
            /// screen that tells the player that they've won. This function needs to be 
            /// called when the player wins the game, so it is added to the GameManager's
            /// onWin delegate.
            ///
            GameManager.onLose += DrawWinText;
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        private void DrawWinText()
        {
            Raylib.DrawText("You Win!!\nPress Esc to quit", 100, 100, 100, Color.BLUE);
        }
    }
}
