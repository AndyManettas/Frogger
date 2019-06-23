using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class GamePlayState : IGameState
    {
        public void Display(GameFacade facade)
        {
            Frogger game = Frogger.Instance;
            GameTimer timer = GameTimer.Instance;
            game.RunGame();
            timer.ResetTimer();

            // sidebars
            SplashKit.FillRectangle(Color.Black, 0, 0, 25, 800);
            SplashKit.FillRectangle(Color.Black, 675, 0, 25, 800);

            if (SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                facade.SetState(new GameMenuState());
            }
        }
    }
}
