using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public interface IGameState
    {
        void Display(GameFacade facade);
    }
}
