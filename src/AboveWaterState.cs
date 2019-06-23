using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class AboveWaterState : IFloatingState
    {
        public void Surface(MovingObject movingObj, string lastChar)
        {
            GameTimer timer = GameTimer.Instance;

            switch (lastChar)
            {
                case "2":
                    movingObj.Bitmap = SplashKit.BitmapNamed("turtle2");
                    if (timer.TimerEquals(0))
                    {
                        movingObj.SetState(new BelowWaterState());
                    }
                    break;
                case "3":
                    movingObj.Bitmap = SplashKit.BitmapNamed("turtle3");
                    if (timer.TimerEquals(3000))
                    {
                        movingObj.SetState(new BelowWaterState());
                    }
                    break;
            }
        }
    }
}