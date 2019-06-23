using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public interface IFloatingState
    {
        void Surface(MovingObject movingObj, string lastChar);
    }
}