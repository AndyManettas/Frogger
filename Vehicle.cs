using System;
using SplashKitSDK;

namespace splashkit
{
    public class Vehicle : MovingObject
    {
        public Vehicle(string bitmap, double x, double y, int polarity) : base(bitmap, x, y, polarity) { }
    }
}