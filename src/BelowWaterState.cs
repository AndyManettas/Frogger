using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class BelowWaterState : IFloatingState
    {
        public void Surface(MovingObject movingObj, string lastChar)
        {
            GameTimer timer = GameTimer.Instance;

            switch (lastChar)
            {
                case "2":
                    movingObj.Bitmap = SplashKit.BitmapNamed("turtleUW2");
                    if (timer.TimerEquals(3000))
                    {
                        movingObj.SetState(new AboveWaterState());
                    }
                    break;
                case "3":
                    movingObj.Bitmap = SplashKit.BitmapNamed("turtleUW3");
                    if (timer.TimerEquals(6000))
                    {
                        movingObj.SetState(new AboveWaterState());
                    }
                    break;
            }
        }
    }
}