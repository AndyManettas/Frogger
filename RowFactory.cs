using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace splashkit
{
    public static class RowFactory
    {
        public static Row GetRow(MovingObject[] movingObjArray, double y)
        {
            if (y >= 450)
            {
                return new Lane(movingObjArray, y);
            }
            if (y <= 350)
            {
                return new River(movingObjArray, y);
            }
            return null;
        }
    }
}
