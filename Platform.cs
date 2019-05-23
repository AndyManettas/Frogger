using System;
using SplashKitSDK;

namespace splashkit
{
    public class Platform : MovingObject
    {
        public Platform(string bitmap, double x, double y, int polarity) : base(bitmap, x, y, polarity) { }
    }
}
