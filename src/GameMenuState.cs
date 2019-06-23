using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class GameMenuState : IGameState
    {
        public void Display(GameFacade facade)
        {
            FileHandler fileHandler = FileHandler.Instance;
            fileHandler.Menu();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                // Clicks play button
                if (SplashKit.MousePosition().X > 150 && SplashKit.MousePosition().X < 550)
                {
                    if (SplashKit.MousePosition().Y > 450 && SplashKit.MousePosition().Y < 608)
                    {
                        facade.SetState(new GamePlayState());
                    }
                }
                // Clicks quit button
                if (SplashKit.MousePosition().X > 225 && SplashKit.MousePosition().X < 475)
                {
                    if (SplashKit.MousePosition().Y > 650 && SplashKit.MousePosition().Y < 748)
                    {
                        SplashKit.CloseCurrentWindow();
                    }
                }
            }
        }
    }
}
