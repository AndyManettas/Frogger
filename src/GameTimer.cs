using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class GameTimer
    {
        private static readonly Lazy<GameTimer> _instance = new Lazy<GameTimer>(() => new GameTimer());

        private GameTimer()
        {
            SplashKit.CreateTimer("Timer");
            SplashKit.StartTimer("Timer");
        }

        public static GameTimer Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public bool TimerEquals(double x)
        {
            double perThousandTicks = Math.Round(SplashKit.TimerTicks("Timer") / 1000d, 0) * 1000;

            if (perThousandTicks.Equals(x))
            {
                return true;
            }

            return false;
        }

        public void ResetTimer()
        {
            if (TimerEquals(6000))
            {
                SplashKit.ResetTimer("Timer");
            }
        }

    }
}
